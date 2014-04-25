package model.test;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;

import model.MomentumStrategy;
import model.MyLogger;

// Attach "-ea" to VM arguments to enable assertions

public class MomentumStrategyTest {

	private File sircaFile;
	private MomentumStrategy msm;
	private ArrayList<ArrayList<String>> trades;
	private static final double epsilon = 0.001;
	boolean verbose = true;
	
	public MomentumStrategyTest(File sircaFile) throws Exception {
		this.sircaFile = sircaFile;
		msm = new MomentumStrategy(new MyLogger());
	}

	public void testSelectTrades() {
		System.out.println(":::::::::::::			Starting tests			:::::::::::::");
		System.out.println(".............		Testing selectTrades()		.............");
		try {
			msm.selectTrades(sircaFile);
			trades = msm.getTrades();
			
			for (int i = 0 ; i < trades.size() ; i++) {
				assert (trades.get(i).get(3).equalsIgnoreCase("TRADE")) : "Entry on line "+i+"is not a 'TRADE'!";
				
				// Print test status
				if (i % 5 == 0) {
					System.out.println(".ok");
				}
				if (verbose) {
					System.out.println("Row "+(i+1)+": "+trades.get(i).get(3));
				}
			}
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		System.out.println(".............		selectTrades() is OK		.............");
	}

	// Column "S" in csv is returns. (does not get printed out)
	// At this point, the field "trades" contains the arraylist of all rows categorised as trades.
	public void testCalculateReturns() {
		System.out.println(".............	Testing calculateReturns()		.............");
		msm.calculateReturns();
		ArrayList<ArrayList<String>> newTrades = msm.getTrades();
		
		for (int row = 0 ; row < newTrades.size() ; row++) {
			double testReturn = Double.parseDouble(newTrades.get(row).get(newTrades.size())); 
			double calculatedReturn = 0.0;
			
			if (row != 0) {
				double priceNow = Double.parseDouble(trades.get(row).get(4));
				double priceBefore = Double.parseDouble(trades.get(row-1).get(4));
				calculatedReturn = (priceNow - priceBefore) / priceBefore;
			}
			// If both return values are 0, simply do equality check.
			if (row == 0 || (calculatedReturn == 0.0 && testReturn == 0.0)) {
				assert (calculatedReturn == testReturn)
				: "Either test-calculated return "+ calculatedReturn +" or MSM return "+ testReturn +"is not 0!";
			} else {
				assert (Math.abs((calculatedReturn / testReturn) - 1.0) < epsilon) 
				: "Row "+(row+1)+": test-calculated return: "+ calculatedReturn +" does not match MSM return: "+ testReturn +"!";
			}
			
			// Print test status
			if (row % 5 == 0) {
				System.out.println(".ok");
			}
			if (verbose) {
				System.out.println("Row "+(row+1)+": ratio: "+Math.abs((calculatedReturn / testReturn) - 1.0)+" epsilon: "+epsilon);
				System.out.println("Row "+(row+1)+": test-calculated return: "+ calculatedReturn +" , MSM return: "+ testReturn);
			}
		}
		System.out.println(".............		calculateReturns() is OK		.............");
	}

	// column "T" is average.
	public void testCalculateMovingAverage() {
		System.out.println(".............	Testing calculateMovingAverage(3)	.............");
		msm.calculateMovingAverage(3);
		ArrayList<ArrayList<String>> newTrades = msm.getTrades();
		double sumReturns = 0.0;
		double calculatedMovingAverage = 0.0; 
		
		for (int row = 0 ; row < newTrades.size() ; row++) {
			double testMovingAverage = Double.parseDouble(newTrades.get(row).get(newTrades.size()));
			if ((row+1) >= 3) {
				for (int i = row ; i > (row-2) ; i--) {
					sumReturns += Double.parseDouble(newTrades.get(row).get(newTrades.size()-1));
				}
			}
			calculatedMovingAverage = sumReturns / 3;
			assert (Math.abs((calculatedMovingAverage / testMovingAverage) - 1.0) < epsilon) :
			"Row "+(row+1)+": test-calculated Moving Average: "+ calculatedMovingAverage +
			" does not match MSM Moving Average: "+ testMovingAverage +"!";
		}
	}

	public void testGenerateTradingSignals() {
		//TODO
	}

	public void testGenerateOrders() {
		//TODO
	}

}
