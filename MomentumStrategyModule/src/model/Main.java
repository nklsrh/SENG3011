package model;

import java.io.File;
import java.io.IOException;
import java.util.Scanner;
import java.util.NoSuchElementException;

import model.test.MomentumStrategyTest;

public class Main
{
	
	public static void main(String[] args) throws IOException
	{
		MyLogger logger;
		MomentumStrategy msm;
		File argFile = null;
		File sircaFile = null;
		double threshold = 0;
		int window = 0;
		boolean test = false;		// Change to false for normal function.
		
		// Creating Log File
		try { logger = new MyLogger(); }
		catch (IOException e) { throw new RuntimeException("Problems with creating log file."); }
		catch (SecurityException e) { throw new RuntimeException("Problems writing to log file - not enough permission"); }
		
		// Checking for valid file arguments
		if (args.length == 2)
		{
			argFile = new File(args[1]);
			sircaFile = new File(args[0]);
			
			// Checking for valid file extension and path
			if (sircaFile.isFile() && argFile.isFile())
			{
				String argFileExt = argFile.getName().substring(argFile.getName().lastIndexOf(".") + 1, argFile.getName().length());
				String sircaFileExt = sircaFile.getName().substring(sircaFile.getName().lastIndexOf(".") + 1, sircaFile.getName().length());
				
				if (!argFileExt.equalsIgnoreCase("txt") || !sircaFileExt.equalsIgnoreCase("csv"))
				{
					logger.severe("Invalid arguments extension, required arguments: SircaFile(.csv) ArgumentFile(.txt)");
				}
			}
			else
			{
				logger.severe("Invalid path or files, required arguments: SircaFile(.csv) ArgumentFile(.txt)");
			}
			
			// Getting parameter from argument file
			try
			{
				Scanner sc = new Scanner(argFile);
				window = Integer.parseInt(sc.next());
				threshold = Double.parseDouble(sc.next());
				sc.close();
			}
			catch (NoSuchElementException e)
			{
				logger.severe("Not enough lines in argument file, there must be at least 2 lines");
			}
			catch (NumberFormatException e)
			{
				logger.severe("Invalid format inside argument file, format must be of type integer and double");
			}
		}
		else
		{
			logger.severe("Not enough arguments, required arguments: SircaFile(.csv) ArgumentFile(.txt)");
		}
		
		// If test mode is enabled, do tests
		if (test) 
		{
			try {
				MomentumStrategyTest tester = new MomentumStrategyTest(sircaFile);
				tester.testSelectTrades();
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		} 
		else 
		{
			// Start of Module Execution
			try
			{
				msm = new MomentumStrategy(logger);
				msm.selectTrades(sircaFile);
				msm.calculateReturns();
				msm.calculateMovingAverage(window);
				msm.generateTradingSignals(threshold);
				msm.generateOrders();
				
				logger.appendFooter(sircaFile.getName());
			}
			catch (Exception e)
			{
				logger.severe(e.getMessage());
			}
		}
	}
	
}
