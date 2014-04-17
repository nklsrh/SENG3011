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
		try {
			msm.selectTrades(sircaFile);
			ArrayList<ArrayList<String>> trades = msm.getTrades();
			
			for (int i = 0 ; i < trades.size() ; i++) {
				assert trades.get(i).get(3).equalsIgnoreCase("TRADE") : "Entry on line "+i+"is not a 'TRADE'!";
			}
		} catch (FileNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public void testCalculateReturns() {
		fail("Not yet implemented");
	}

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
