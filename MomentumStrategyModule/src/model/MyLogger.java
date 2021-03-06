package model;

import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.LogRecord;
import java.util.logging.Formatter;
import java.util.logging.FileHandler;
import java.util.concurrent.TimeUnit;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.BufferedWriter;
import java.text.SimpleDateFormat;


public class MyLogger
{
	private final static String LOG_FILE = "MomentumStrategyModule.log";
	
	private Logger logger;
	private Date startDate;
	private boolean isSevere;
	private long startNanoTime;
	private SimpleDateFormat sdf;
	private FileHandler fileHandler;
	
	public MyLogger() throws SecurityException, IOException
	{
		isSevere = false;
		fileHandler = new FileHandler(LOG_FILE, true);
		logger = Logger.getLogger(Logger.GLOBAL_LOGGER_NAME);
		sdf = new SimpleDateFormat("dd-MMM-yyyy HH:mm:ss");
		startDate = new Date();
		startNanoTime = System.nanoTime();
		
		initLogFile();
		setupFormatter();
		logger.setLevel(Level.ALL);
		logger.addHandler(fileHandler);
	}
	
	public void info(String message)
	{
		logger.info(message);
	}
	
	public void severe(String message) throws IOException
	{
		isSevere = true;
		logger.severe(message);
		appendFooter(null);
		System.exit(1);
	}
	
	public void appendFooter(String sircaFile) throws IOException
	{
		FileWriter fstream = new FileWriter(LOG_FILE, true);
		BufferedWriter out = new BufferedWriter(fstream);
		
		out.newLine();
		if (isSevere)
		{
			out.write(String.format("%-20s: %s\n", "Status", "Completed with error - see above for details"));
		}
		else
		{
			out.write(String.format("%-20s: %s\n", "Status", "Completed without error"));
			out.write(String.format("%-20s: %s\n", "Start time", sdf.format(startDate)));
			out.write(String.format("%-20s: %s\n", "End time", sdf.format(new Date())));
			out.write(String.format("%-20s: %s ms\n", "Elapsed time", TimeUnit.NANOSECONDS.toMillis(System.nanoTime()-startNanoTime)));
			out.write(String.format("%-20s: %s\n", "Input file", sircaFile));
			out.write(String.format("%-20s: %s %s", "Output produced", MomentumStrategy.ORDER_FILE, LOG_FILE));
		}

		out.close();
		fstream.close();
	}
	
	private void initLogFile() throws IOException
	{
		PrintWriter printWriter = new PrintWriter(LOG_FILE);
		printWriter.println("Fire Breathing Rubber Duckies");
		printWriter.println("Momentum Strategy Module - Version 1.1");
		printWriter.println();
		printWriter.close();
	}
	
	private void setupFormatter()
	{
		fileHandler.setFormatter(new Formatter()
		{
			@Override
			public String format(LogRecord record)
			{
				StringBuffer sb = new StringBuffer(1000);
				
				sb.append(sdf.format(new Date()));
				sb.append('\t');
				sb.append(record.getLevel());
				sb.append(':');
				sb.append(' ');
				sb.append(formatMessage(record));
				sb.append('\n');
				
				return sb.toString();
			}
		});
	}
	
}
