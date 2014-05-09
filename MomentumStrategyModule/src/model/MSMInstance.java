package model;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.NoSuchElementException;
import java.util.Scanner;

import model.test.MainTest;

public class MSMInstance 
{
	/**
	 * Logger object
	 */
	public MyLogger logger = null;	
	
	/**
	 * Actual worker object
	 */
	public MomentumStrategy msm = null;

	/**
	 * 'test' refers to true if the tests are run instead of core operations.
	 * 
	 * IMPORTANT: Always leave as false, 
	 * command line arguments will override if required (see checkFlags())
	 */
	public boolean test = false;

	/**
	 * List of trades
	 */
	public ArrayList<ArrayList<String>> prominentTrades = null;
	/**
	 * List of trades
	 */
	public ArrayList<ArrayList<String>> generatedTrades = null;

	/**
	 * File for Sirca
	 */
	public File argFile = null;
	
	/**
	 * File for Arguments
	 */
	public File sircaFile = null;
			
	public boolean verbosity = false;
	public double threshold = 0;
	public int window = 0;	
	
	/**
	 * @param args Argument file from Main
	 * @throws Exception
	 */
	public MSMInstance (String[] args) throws Exception
	{
		// Creating Log File and saving to variable
		logger = createLogFile();

		// Set values for Test and Verbosity after checking them for valid arg input
		// NOTE: args[0] and args[1] correspond to testArg (is Test enabled?) and assertArg (is Verbosity enabled?)
		test      = checkFlags(args[0], args[1]) [0];
		verbosity = checkFlags(args[0], args[1]) [1];
		
		// Checking for valid file arguments
		// If it's normal arguments
		if (args.length == 2)
		{
			sircaFile = getSircaFile (args, test);
			argFile = getArgsFile (args, test);
			checkValidFileArgs (args);
		}
		// If it's testing arguments
		else if (args.length == 4)
		{
			sircaFile = getSircaFile (args, test);
			argFile = getArgsFile (args, test);
			checkValidTestArgs (args);
		}
		else
		{
			logger.severe("Wrong usage, required arguments: SircaFile(.csv) ArgumentFile(.txt)\n"
				+ "To enter test mode, add flags '-t' and '-ea'. \n"
				+ "For verbose test mode, use '-tv and '-ea'");
		}		
	}

	/**
	 * Runs either tests or the module itself, depending on arguments supplied to Main
	 * @throws Exception
	 */
	public void Run () throws Exception
	{
		// If test mode is enabled, do tests
		if (test) 
		{
			runTests();
		} 
		// Otherwise, just run the module as normal
		else 
		{
			executeModule();
		}
	}
	
	
	/**
	 * Creates a new MyLogger object
	 * @return A brand new MyLogger object
	 */
	public MyLogger createLogFile ()
	{
		MyLogger logger;
		try 
		{ 
			logger = new MyLogger(); 			
		}
		catch (IOException e) 
		{ 
			throw new RuntimeException("Problems with creating log file."); 
		}
		catch (SecurityException e) 
		{ 
			throw new RuntimeException("Problems writing to log file - not enough permission"); 
		}
		return logger;
	}
	


	/**
	 * Checks flags in argument for indication of test and verbosity values.
	 * @param testArg The argument flag for test
	 * @param assertArg The argument flag for verbosity
	 * @return Boolean array of 2 elements: Is test enabled? and Is verbosity enabled?
	 */
	public boolean[] checkFlags(String testArg, String assertArg) 
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
	
	/**
	 * Ensures the sirca file is .CSV and arguments file is .TXT
	 * @param logger MyLogger object
	 * @param sircaFile SIRCA file
	 * @param argFile Arguments file
	 * @throws IOException Wrong file format
	 */
	public void checkExtensions() throws IOException 
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


	/**
	 * When normally operating, checks arguments for validity, then SAVES them to variables
	 * @param sircaFile (GETS OVERWRITTEN) SIRCA file
	 * @param argFile (GETS OVERWRITTEN) arguments file
	 * @param logger MyLogger object
	 * @param window Window for trade function
	 * @param threshold Threshold of function
	 * @param args arguments specified in the command line
	 * @throws Exception
	 */
	public void checkValidFileArgs (String[] args) throws Exception
	{		
		// Makes sure the file extensions are correct.
		checkExtensions();
		
		// Getting parameter from argument file
		try
		{
			Scanner sc = new Scanner(argFile);
			//window = Integer.parseInt(sc.next());
			//threshold = Double.parseDouble(sc.next());
			sc.next();
			if (sc.hasNextInt())
				window = sc.nextInt();
			sc.next();
			if (sc.hasNextDouble()) 
				threshold = sc.nextDouble();
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
	

	/**
	 * In the case of testing, checks arguments for validity, then SAVES them to variables
	 * @param test (GETS OVERWRITTEN) Is test enabled?
	 * @param logger MyLogger object
	 * @param sircaFile (GETS OVERWRITTEN) SIRCA file
	 * @param argFile (GETS OVERWRITTEN) arguments file
	 * @param window window for trade function
	 * @param threshold threshold for trade function
	 * @param verbosity (GETS OVERWRITTEN) Is Verbosity enabled?
	 * @param args arguments specified in the command line
	 * @throws Exception
	 */
	public void checkValidTestArgs (String[] args) throws Exception
	{
		// Makes sure the file extensions are correct.
		checkExtensions();		
				
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
	
	/**
	 * Given the values, executes the MSM module and generates Orders
	 * @param msm MSM module
	 * @param logger MyLogger object
	 * @param sircaFile File corresponding to Sirca CSV
	 * @param window Window size
	 * @param prominentTrades List of Trades to save to
	 * @param threshold Threshold of function
	 * @throws Exception
	 */
	public void executeModule () throws Exception
	{
		// Start of Module Execution
		try
		{
			msm = new MomentumStrategy(logger);
			msm.selectTrades(sircaFile);
			msm.calculateReturns();
			msm.calculateMovingAverage(window);
			prominentTrades = msm.generateTradingSignals(threshold);
			generatedTrades = msm.generateOrders(prominentTrades);
			msm.generateOutput(generatedTrades);
			
			logger.appendFooter(sircaFile.getName());
		}
		catch (Exception e)
		{
			logger.severe(e.getMessage());
		}
	}

	/**
	 * Runs all tests on the MSM module
	 * @param sircaFile Sirca-formatted CSV file in File object
	 * @param verbosity Is verbosity on or off?
	 */
	public void runTests ()
	{
		try 
        {
			MainTest tester = new MainTest(sircaFile, verbosity);
			tester.startTests();
		}
        catch (Exception e) 
        {
			e.printStackTrace();
		}
	}
	

	
	/**
	 * Given a set of valid arguments, returns a File that corresponds to the sircaFile
	 * @param args arguments given to the program
	 * @return File pointing to sircaFile
	 */
	public File getSircaFile (String[] args, boolean test)
	{
		if (test)
		{
			return new File(args[2]);
		}
		else
		{
			return new File(args[0]);
		}
	}
	/**
	 * Given a set of valid arguments, returns a File that corresponds to the argsFile
	 * @param args arguments given to the program
	 * @return File pointing to argsFile
	 */
	public File getArgsFile (String[] args, boolean test)
	{
		if (test)
		{
			return new File(args[3]);
		}
		else
		{
			return new File(args[1]);
		}
	}
}
