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
	private boolean verbose = true;
	
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
				assert (trades.get(i).get(3).equalsIgnoreCase("TRADE")) : 
					"\nEntry on line "+i+"is not a 'TRADE'!";
				
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
			double testReturn = Double.parseDouble(newTrades.get(row).get(newTrades.get(row).size()-1)); 
			double calculatedReturn = 0.0;
			
			if (row != 0) {
				double priceNow = Double.parseDouble(trades.get(row).get(4));
				double priceBefore = Double.parseDouble(trades.get(row-1).get(4));
				calculatedReturn = (priceNow - priceBefore) / priceBefore;
			}
			// If both return values are 0, simply do equality check.
			if (row == 0 || (calculatedReturn == 0.0 && testReturn == 0.0)) {
				assert (calculatedReturn == testReturn) : 
					"\nEither test-calculated return "+ calculatedReturn +" or MSM return "+ testReturn +"is not 0!";
			} else {
				assert (Math.abs((calculatedReturn / testReturn) - 1.0) < epsilon) : 
					"\nRow "+(row+1)+": test-calculated return: "+ calculatedReturn +" does not match MSM return: "+ testReturn +"!";
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
		System.out.println(".............	calculateReturns() is OK	.............");
	}

	// column "T" is average.
	public void testCalculateMovingAverage(int n) {
		System.out.println(".............	Testing calculateMovingAverage("+n+")	.............");
		msm.calculateMovingAverage(n);
		ArrayList<ArrayList<String>> newTrades = msm.getTrades();
		double sumReturns = 0.0;
		double calculatedMovingAverage = 0.0;
		double testMovingAverage = 0.0;
		//System.out.println("Size of my Trades list is "+newTrades.get(0).size());
		
		// This is to allow repeated testing. Each instance of the test appends a column to the end of each row.
		if (newTrades.get(0).size() > 20) {
			for (ArrayList<String> row : newTrades) {
				row.remove(19);
			}
		}
		//System.out.println(newTrades);
		
		for (int row = 0 ; row < newTrades.size() ; row++) {
			sumReturns = 0.0;
			if ((row+1) >= n) {
				testMovingAverage = Double.parseDouble(newTrades.get(row).get(19));
				for (int i = row ; i > (row-n) ; i--) {
					if (i < (n-1)) {
						continue;
					} else {
						sumReturns += Double.parseDouble(newTrades.get(i).get(18));
					}
					if (verbose) {
						System.out.println("Row "+(row+1)+
							", currently adding row "+(i+1)+
							": current return is "+Double.parseDouble(newTrades.get(i).get(18))+
							", current sumReturns is "+sumReturns);
					}
				}
			}
			calculatedMovingAverage = sumReturns / 3;
			
			if (calculatedMovingAverage == 0.0 && sumReturns == 0.0) {
				assert (calculatedMovingAverage == sumReturns);
			} else {
				assert (Math.abs((calculatedMovingAverage / testMovingAverage) - 1.0) < epsilon) :
					"\nRow "+(row+1)+": test-calculated Moving Average: "+ calculatedMovingAverage +
					" does not match MSM Moving Average: "+ testMovingAverage +"!";
			}
			
			// Print test status
			if (row % 5 == 0) {
			System.out.println(".ok");
			}
			if (verbose) {
				System.out.println("***Row "+(row+1)+": "+ 
					"calculatedMovingAverage: "+calculatedMovingAverage+
					", MSMMovingAverage: "+testMovingAverage);
			}
		}
		System.out.println(".............		calculateMovingAverage("+n+") is OK		.............");
	}

	public void testGenerateTradingSignals(double th) {
		System.out.println(".............	Testing generateTradingSignals("+th+")	.............");
		msm.generateTradingSignals(th);
		double smaNow = 0.0;
		double smaBefore = 0.0;
		double tsv = 0.0;
		ArrayList<ArrayList<String>> newTrades = msm.getTrades();
		//System.out.println(newTrades);
		
		for (int row = 0 ; row < newTrades.size() ; row++) {
			if (newTrades.get(row).get(19).equalsIgnoreCase("")) {
				System.out.println("Skipped a line");
				continue;
			} else {
				if (newTrades.get(row-1).get(19).equalsIgnoreCase("")) {
					assert (newTrades.get(row).get(20).equalsIgnoreCase("UNDEFINED")) : 
						"\nThe first Trade with a valid SMA should be 'UNDEFINED'!";
				} else {
					smaNow = Double.parseDouble(newTrades.get(row).get(19));
					smaBefore = Double.parseDouble(newTrades.get(row-1).get(19));
					tsv = smaNow - smaBefore;
					System.out.println("Row "+(row+1)+
						": tsv is "+tsv);
					if (tsv > th) {
						assert (newTrades.get(row).get(12).equalsIgnoreCase("B")) : 
							"\nTSV is more than th but is not a BUY signal!";
					} else if (tsv < -th) {
						assert (newTrades.get(row).get(12).equalsIgnoreCase("A")) :
							"\nTSV is less than -th but is not a SELL signal!";
					} else {
						assert (newTrades.get(row).get(12).equalsIgnoreCase("")) :
							"\nTSV is not > th nor < -th, should be empty!";
					}
				}
			}
			// Print test status
			if (row % 5 == 0) {
			System.out.println(".ok");
			}
			if (verbose) {
				System.out.println("***Row "+(row+1)+": "+ 
					"TSV is "+tsv+", threshold is "+th+", Trade Signal is "+newTrades.get(row).get(12));
			}
		}
		System.out.println(".............	generateTradingSignals("+th+") is OK	.............");
	}

	public void testGenerateOrders() {
		//TODO
	}

}
