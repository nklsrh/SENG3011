package model;

import java.io.*;
import java.util.*;
import java.text.ParseException;


public class MomentumStrategy
{
	private String fileName;
	private LinkedList<LinkedList<String>> trades;
	
	public MomentumStrategy(String fileName)
	{
		this.fileName = fileName;
		trades = new LinkedList<LinkedList<String>>();
	}
	
//	XXX - Utility Functions to print out the list of trades
	public void WriteToFile() throws FileNotFoundException, UnsupportedEncodingException
	{
		PrintWriter writer = new PrintWriter("Trades List.txt", "UTF-8");
		
		for (LinkedList<String> trade : trades)
		{
			for (String field : trade)
			{
				writer.print(field +"\t");
			}
			writer.println();
		}

		writer.close();
	}
	
	// Not sure how the LinkedList is formated at the moment but I'm just writing it
	// the same way you did with the text file
	public void WriteToCSV() throws IOException
	{
		FileWriter writer = new FileWriter("Trades List.csv");
		
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
	
	public void SelectTrades() throws FileNotFoundException
	{		
		Scanner CSVScanner = new Scanner(new File(fileName));
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
        	
        }

        CSVScanner.close();
	}


	public void CalculateReturns() throws ParseException
	{
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
		

//		XXX - To be deleted once the above formula is correct
//		SimpleDateFormat formatter = new SimpleDateFormat("hh:mm:ss");
//		Date time = formatter.parse(trade.get(2));			
//		System.out.println(time.getHours() +"\t" + price);
	}


	public void CalculateMovingAverage(int n)
	{
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
	}


	public void GenerateTradingSignals(double th)
	{
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
	}


	public void GenerateOrders()
	{
		// TODO Auto-generated method stub
		
	}

}
