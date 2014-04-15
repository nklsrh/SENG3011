package model;

import java.io.*;
import java.util.*;


public class MomentumStrategy
{
	public final static String ORDER_FILE = "OrderList.csv";
	
	private MyLogger logger;
	private LinkedList<LinkedList<String>> trades;
	
	public MomentumStrategy(MyLogger logger)
	{
		this.logger = logger;
		trades = new LinkedList<LinkedList<String>>();
	}
	
	public void selectTrades(File sircaFile)
	{
		try
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
					trades.addLast(new LinkedList<String>());
					for (String field : fields)
					{
						trades.getLast().addLast(field);
					}
				}
				counter++;
			}
			
			CSVScanner.close();
			logger.info(String.format("Completed with %d Trades selected from %d lines", trades.size(), counter));
		}
		catch (FileNotFoundException e)
		{
			logger.severe(e.getLocalizedMessage());
		}
	}
	
	public void calculateReturns()
	{
		logger.info("Calculating Returns");
		
		for (int t = 0; t < trades.size(); t++)
		{
			if (t == 0)
			{
				trades.get(t).addLast(Double.toString(0));
			}
			else
			{
				double priceTradedAtTime = Double.parseDouble(trades.get(t).get(4));
				double priceTradedAsTime = Double.parseDouble(trades.get(t-1).get(4));
				double returnAtTime = (priceTradedAtTime - priceTradedAsTime) / priceTradedAsTime;
				
				trades.get(t).addLast(Double.toString(returnAtTime));
			}
		}
		
		logger.info("Completed");
	}
	
	public void calculateMovingAverage(int n)
	{
		logger.info("Calculating Moving Average");
		
		for (int t = 0; t < trades.size(); t++)
		{
			if (t >= n)
			{
				double simpleMovingAverage, sumOfReturns = 0;
				 
				for(int i = t, c = 0; c != n; i--, c++)
				{
					//Field 18 is trades returns calculated and added in the previous method
					sumOfReturns += Double.parseDouble(trades.get(i).get(18));
				}
				
				simpleMovingAverage = sumOfReturns / 3;
				trades.get(t).addLast(Double.toString(simpleMovingAverage));
			}
		}
		
		logger.info("Completed");
	}
	
	public void generateTradingSignals(double th)
	{
		logger.info("Generating Trading Signals");
		
		for (int t = 0; t < trades.size(); t++)
		{
			if (trades.get(t).size() == 20 && trades.get(t-1).size() == 20)
			{
				double tsv = Double.parseDouble(trades.get(t).get(19)) - Double.parseDouble(trades.get(t-1).get(19));
				if (tsv > th)
				{
					trades.get(t).addLast("BUY");					
				}
				else if (tsv < th)
				{
					trades.get(t).addLast("SELL");
				}
				else
				{
					trades.get(t).addLast("0");
				}
			}
			else
			{
				trades.get(t).addLast("0");
			}
		}
		
		logger.info("Completed");
	}
	
	public void generateOrders() throws IOException
	{
		logger.info("Generating Orders");
		
		//TODO - Add Cleanup Linked List Function
		writeToCSV();
		
		logger.info("Completed");
	}
	
	private void writeToCSV() throws IOException
	{
		FileWriter writer = new FileWriter(ORDER_FILE);
		
		for (LinkedList<String> trade : trades) 
		{
			for (String field : trade)
			{
				writer.append(field +",");
			}
			writer.append("\n");
		}
		
		writer.close();
	}
	
}
