package model.test;

import static org.junit.Assert.*;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.ArrayList;

import model.MomentumStrategy;
import model.MyLogger;

public class MomentumStrategyTest {

	private File sircaFile;
	private MomentumStrategy msm;
	
	public MomentumStrategyTest(File sircaFile) throws Exception {
		this.sircaFile = sircaFile;
		msm = new MomentumStrategy(new MyLogger());
	}

	public void testSelectTrades() {
		System.out.println(":::::::::::::			Starting tests			:::::::::::::");
		System.out.println(".............		Testing selectTrades()		.............");
		try {
			msm.selectTrades(sircaFile);
			ArrayList<ArrayList<String>> trades = msm.getTrades();
			
			for (int i = 0 ; i < trades.size() ; i++) {
				assert trades.get(i).get(3).equalsIgnoreCase("TRADE") : "Entry on line "+i+"is not a 'TRADE'!";
				if (i % 20 == 0) {
					System.out.println(".");
				}
			}
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		System.out.println(".............		selectTrades() is OK		.............");
	}

	// Column "S" in csv is returns.
	public void testCalculateReturns() {
		System.out.println(".............	Testing calculateReturns()		.............");
		msm.calculateReturns();
	}

	// column "T" is average.
	public void testCalculateMovingAverage() {
		fail("Not yet implemented");
	}

	public void testGenerateTradingSignals() {
		fail("Not yet implemented");
	}

	public void testGenerateOrders() {
		fail("Not yet implemented");
	}

}
