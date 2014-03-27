package model;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.text.ParseException;


public class Main
{

	public static void main(String[] args) throws FileNotFoundException, ParseException, UnsupportedEncodingException, IOException
	{
		MomentumStrategy msm = new MomentumStrategy("src/bhp5Feb13.csv");
		
		msm.SelectTrades();
		msm.CalculateReturns();
		msm.CalculateMovingAverage(3);
		msm.GenerateTradingSignals(0.001);
		msm.GenerateOrders();

		msm.WriteToFile();
		msm.WriteToCSV();
	}

}
