package model;

import java.io.*;
import java.util.*;

/**
 * This class implements the various methods involved in calculations for the Momentum Strategy Module. 
 * @author Fire Breathing Rubber Duckies
 * @version 1.1
 */
public class MomentumStrategy
{
	public final static String ORDER_FILE = "OrderList.csv";
	
	private MyLogger logger;
	private ArrayList<ArrayList<String>> trades;
	
	public MomentumStrategy(MyLogger logger)
	{
		this.logger = logger;
		trades = new ArrayList<ArrayList<String>>(20000);
	}
	
	/**
	 * This method takes in the input Sirca CSV file and selects the relevant trades for further processing
	 * @param sircaFile
	 * @throws FileNotFoundException 
	 */
	public void selectTrades(File sircaFile) throws FileNotFoundException
	{
		logger.info("Selecting Trades");
		
		int counter = 0;
		Scanner CSVScanner = new Scanner(sircaFile);
		CSVScanner.useDelimiter("\n");
		
		while (CSVScanner.hasNext())
		{
			String[] fields = CSVScanner.next().split(",");
			
			if (fields[3].equalsIgnoreCase("TRADE"))
			{
				ArrayList<String> tradeElements = new ArrayList<String>(25);
				
				for (String field : fields)
				{
					tradeElements.add(field);
				}
				
				trades.add(tradeElements);
			}
			
			counter++;
		}
		
		CSVScanner.close();
		
		logger.info(String.format("Completed with %d Trades selected from %d lines", trades.size(), counter));
	}
	
	/**
	 * This method calculates returns.
	 */
	public void calculateReturns()
	{
		logger.info("Calculating Returns");
		
		for (int t = 0; t < trades.size(); t++)
		{
			if (t == 0)
			{
				trades.get(t).add(Double.toString(0));
			}
			else
			{
				double priceTradedAtTime = Double.parseDouble(trades.get(t).get(4));
				double priceTradedAsTime = Double.parseDouble(trades.get(t-1).get(4));
				double returnAtTime = (priceTradedAtTime - priceTradedAsTime) / priceTradedAsTime;
				
				trades.get(t).add(Double.toString(returnAtTime));
			}
		}
		
		logger.info("Completed");
	}
	
	/**
	 * This method calculates the moving average, given a time n. (?)
	 * @param n time
	 */
	public void calculateMovingAverage(int n)
	{
		logger.info("Calculating Moving Average with window parameter of: " +n);
		
		for (int t = 0; t < trades.size(); t++)
		{
			if ((t+1) >= n)
			{
				double simpleMovingAverage, sumOfReturns = 0;
				 
				for(int i = t, c = 0; c < n; i--, c++)
				{
					//Field 18 is trades returns calculated and added in the previous method
					sumOfReturns += Double.parseDouble(trades.get(i).get(18));
				}
				
				simpleMovingAverage = sumOfReturns / n;
				trades.get(t).add(Double.toString(simpleMovingAverage));
			}
			else
			{
				trades.get(t).add("");
			}
		}
		
		logger.info("Completed");
	}

	/**
	 * This method generates trading signals of whether to buy or sell.
	 * @param th
	 */
	public void generateTradingSignals(double th)
	{
		logger.info("Generating Trading Signals with threshold of: " +th);
		
		for (int t = 0; t < trades.size(); t++)
		{
			if (!trades.get(t).get(19).isEmpty() && !trades.get(t-1).get(19).isEmpty())
			{
				double tsv = Double.parseDouble(trades.get(t).get(19)) - Double.parseDouble(trades.get(t-1).get(19));
				
				if (tsv > th)
				{
					trades.get(t).set(12, "B");
				}
				else if (tsv < th)
				{
					trades.get(t).set(12, "A");
				}
				else
				{
					trades.get(t).add("NOTHING");
				}
			}
			else if (!trades.get(t).get(19).isEmpty() && trades.get(t-1).get(19).isEmpty())
			{
				trades.get(t).add("UNDEFINED");
			}
			else
			{
				trades.get(t).add("");
			}
		}
		
		logger.info("Completed");
	}
	
	public void generateOrders() throws IOException
	{
		logger.info("Generating Orders");
		
		writeToCSV();
		
		logger.info("Completed");
	}

	/**
	 * This method formats and writes the output trade data into a CSV file.
	 * @throws IOException
	 */
	private void writeToCSV() throws IOException
	{
		FileWriter writer = new FileWriter(ORDER_FILE);
		
		for (ArrayList<String> trade : trades) 
		{
			for (int i = 0; i < 18; i++)
			{
				if (i == 5)
				{
					writer.append("100,");
				}
				else if (i == 7)
				{
					double value = 100 * Double.parseDouble(trade.get(4));
					writer.append(Double.toString(value) +",");
				}
				else
				{
					writer.append(trade.get(i) +",");
				}
			}
			writer.append("\n");
		}
		
		writer.close();
	}
	
}
