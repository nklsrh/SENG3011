package model;

import java.io.File;
import java.io.IOException;


public class Main
{
	
	public static void main(String[] args) throws IOException
	{
		MyLogger logger;
		MomentumStrategy msm;
		File sircaFile = null, argFile;
		
		// Creating Log File
		try { logger = new MyLogger(); }
		catch (IOException e) { throw new RuntimeException("Problems with creating log file."); }
		catch (SecurityException e) { throw new RuntimeException("Problems writing to log file - not enough permission"); }
		
		// Check for valid arguments
		if (args.length == 2)
		{
			argFile = new File(args[1]);
			sircaFile = new File(args[0]);
			
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
		else
		{
			logger.severe("Not enough arguments, required arguments: SircaFile(.csv) ArgumentFile(.txt)");
		}
		
		if (logger.isSevere()) { logger.appendFooter(null); return; }
		
		try
		{
			msm = new MomentumStrategy(logger);
			msm.selectTrades(sircaFile);
			msm.calculateReturns();
	//		msm.calculateMovingAverage(3);
	//		msm.generateTradingSignals(0.001);
	//		msm.generateOrders();
	//		msm.writeToFile();
	//		msm.writeToCSV();
			
			logger.appendFooter(sircaFile.getName());
		}
		finally
		{
			
		}
		
		
		
		
//		Tester for checking exception
//		new MomentumStrategy(new MyLogger()).selectTrades(new File("src/sometext.txt"));
	}
	
}
