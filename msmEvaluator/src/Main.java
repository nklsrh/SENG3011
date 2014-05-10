import java.io.File;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Scanner;


public class Main {

	static ArrayList<Double> returns;
	static ArrayList<Double> prices;
	static ArrayList<String> buysells;
	static double result;
	static int counter;
	
	/**
	 * @param args
	 */
	public static void main(String[] args) {
		returns = new ArrayList<Double>();
		prices = new ArrayList<Double>();
		buysells = new ArrayList<String>();
		result = 0.0;
		counter = 0;
		
		if (args.length == 1) {
			File inputFile = new File(args[0]);
			try {
				Scanner CSVScanner = new Scanner(inputFile);
				//CSVScanner.useDelimiter("\n");
				
				while (CSVScanner.hasNext()) {
					counter++;
					String[] fields = CSVScanner.nextLine().split(",");
					
					if (counter > 1) {
						prices.add(Double.parseDouble(fields[4]));
						buysells.add(fields[12]);
					}
				}
				
				CSVScanner.close();
			}
			catch (Exception e) {
				System.out.println(e.getMessage());
			}
			
			DecimalFormat df = new DecimalFormat("#.##");
			
			while (prices.size() > 1) {
				if (buysells.get(0).equalsIgnoreCase("B")) {
					double buyPrice = prices.get(0);
					int index = buysells.indexOf("A");
					double sellPrice = prices.get(index);
					double temp = (sellPrice - buyPrice) / buyPrice;
					returns.add(temp);
					temp = temp * 100;
					System.out.println("Bought first at " + buyPrice + " and sold at " + sellPrice + " with a return of " + df.format(temp) + "%");
					prices.remove(index);
					prices.remove(0);
					buysells.remove(index);
					buysells.remove(0);
				} else {
					double sellPrice = prices.get(0);
					int index = buysells.indexOf("B");
					double buyPrice = prices.get(index);
					double temp = (sellPrice - buyPrice) / sellPrice;
					returns.add(temp);
					temp = temp * 100;
					System.out.println("Sold first at " + sellPrice + " and bought at " + buyPrice + " with a return of " + df.format(temp) + "%");
					prices.remove(index);
					prices.remove(0);
					buysells.remove(index);
					buysells.remove(0);
				}
			}
			
			for (Double indReturns : returns) {
				result += indReturns;
			}
			result = result * 100;
			System.out.println("Final return of given order list: " + df.format(result) + "%");
			
		} else {
			System.out.println("Wrong number of arguments supplied. Expected 1 (input file).");
		}

	}

}
