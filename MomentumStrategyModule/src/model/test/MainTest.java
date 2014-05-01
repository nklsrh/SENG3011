package model.test;

import java.io.File;

public class MainTest {
	
	private MomentumStrategyTest tester;
	
	public MainTest(File sircaFile, boolean verbosity) {
		try {
			tester = new MomentumStrategyTest(sircaFile, verbosity);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public void startTests() {
		tester.testSelectTrades();
		tester.testCalculateReturns();
		tester.testCalculateMovingAverage(3);
		//tester.testCalculateMovingAverage(4); //Currently fails tests.
		//tester.testCalculateMovingAverage(5);
		tester.testGenerateTradingSignals(0.001);
		tester.testGenerateTradingSignals(0.0001);
	}
}

