package model;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.NoSuchElementException;

import model.test.*;

public class Main
{	
	public static void main(String[] args) throws IOException
	{
		MyLogger logger;
		MomentumStrategy msm;
		ArrayList<ArrayList<String>> prominentTrades;
		File argFile = null;
		File sircaFile = null;
		String testArg = null;
		String assertArg = null;
		boolean test = false; // Change to false for normal function.
		boolean verbosity = false;
		double threshold = 0;
		int window = 0;	
		
		// Creating Log File
		try { logger = new MyLogger(); }
		catch (IOException e) { throw new RuntimeException("Problems with creating log file."); }
		catch (SecurityException e) { throw new RuntimeException("Problems writing to log file - not enough permission"); }
		
		// Checking for valid file arguments
		if (args.length == 2)
		{
			sircaFile = new File(args[0]);
			argFile = new File(args[1]);
			
			checkExtensions(logger, sircaFile, argFile);
			
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
		else if (args.length == 4)
		{
			testArg = args[0];
			assertArg = args[1];
			sircaFile = new File(args[2]);
			argFile = new File(args[3]);
			boolean[] returnFlags = null;
			verbosity = false;
			
			checkExtensions(logger, sircaFile, argFile);
			returnFlags = checkFlags(testArg, assertArg);
			test = returnFlags[0];
			verbosity = returnFlags[1];
			
			// Getting parameter from argument file
			// Should make this in a separate method later. (repeated code)
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
			logger.severe("Wrong usage, required arguments: SircaFile(.csv) ArgumentFile(.txt)\n"
				+ "To enter test mode, add flags '-t' and '-ea'. \n"
				+ "For verbose test mode, use '-tv and '-ea'");
		}
		
		// If test mode is enabled, do tests
		if (test) 
		{
			try {
				MainTest tester = new MainTest(sircaFile, verbosity);
				tester.startTests();
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
				prominentTrades = msm.generateTradingSignals(threshold);
				msm.generateOrders(prominentTrades);
				
				logger.appendFooter(sircaFile.getName());
			}
			catch (Exception e)
			{
				logger.severe(e.getMessage());
			}
		}
	}	
	
	public static void checkExtensions(MyLogger logger, File sircaFile, File argFile) throws IOException 
	{
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
	}
	
	//figure out how to return two things at once. array?
	public static boolean[] checkFlags(String testArg, String assertArg) 
	{
		boolean test = false;
		boolean verbosity = false;
		boolean[] returnFlags = new boolean[2];
		
		if ((testArg.equalsIgnoreCase("-t") || testArg.equalsIgnoreCase("-tv")) && assertArg.equalsIgnoreCase("-ea"))
		{
			test = true;
			returnFlags[0] = test;
			if (testArg.equalsIgnoreCase("-tv")) 
			{
				verbosity = true;
				returnFlags[1] = verbosity;
			} 
		}
		return returnFlags;
	}
}
