package model;

import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.logging.LogRecord;
import java.util.logging.Formatter;
import java.util.logging.FileHandler;
import java.text.SimpleDateFormat;
import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;


public class MyLogger
{
	private final static String LOG_FILE = "Momentum Strategy Module.log";
	
	private Logger logger;
	private FileHandler fileHandler;
	private boolean isError;
	
	
	public MyLogger() throws SecurityException, IOException
	{
		logger = Logger.getLogger(Logger.GLOBAL_LOGGER_NAME);
		fileHandler = new FileHandler(LOG_FILE, true);
		isError = false;
		
		initLogFile();
		setupFormatter();
		logger.setLevel(Level.ALL);
		logger.addHandler(fileHandler);
	}
	
	public void info(String message)
	{
		logger.info(message);
	}
	
	public void severe(String message)
	{
		logger.severe(message);
		isError = true;
	}
	
	public void appendFooter() throws IOException
	{
		FileWriter fstream = new FileWriter(LOG_FILE, true);
		BufferedWriter out = new BufferedWriter(fstream);
		
		out.newLine();
		if (isError)
		{
			out.write("Module completed with error - see above for details");
		}
		else
		{
			out.write("Module completed without error");
			out.newLine();
			out.write("Start time: ");
			out.newLine();
			out.write("End time: ");
			out.newLine();
		}

		out.close();
		fstream.close();
	}
	
	private void initLogFile() throws IOException
	{
		PrintWriter printWriter = new PrintWriter(LOG_FILE);
		printWriter.println("Fire Breathing Rubber Duckies");
		printWriter.println("Momentum Strategy Module - Version 1.0");
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
				SimpleDateFormat sdf = new SimpleDateFormat("dd-MMM-yyyy HH:mm:ss");
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
