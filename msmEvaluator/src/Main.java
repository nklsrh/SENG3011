import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
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
	 * @throws IOException 
	 */
	public static void main(String[] args) throws IOException {
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
				return;
			}
			
			FileWriter writer = new FileWriter("eval.txt");
			DecimalFormat df = new DecimalFormat("#.##");
			
			while (prices.size() > 1) {
				if (buysells.get(0).equalsIgnoreCase("B")) {
					double buyPrice = prices.get(0);
					int index = buysells.indexOf("A");
					double sellPrice = prices.get(index);
					double temp = (sellPrice - buyPrice) / buyPrice;
					returns.add(temp);
					temp = temp * 100;
					writer.write("Bought first at " + buyPrice + " and sold at " + sellPrice + " with a return of " + df.format(temp) + "%" + System.getProperty( "line.separator" ));
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
					writer.write("Sold first at " + sellPrice + " and bought at " + buyPrice + " with a return of " + df.format(temp) + "%" + System.getProperty( "line.separator" ));
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
			writer.write("Final return of given order list: " + df.format(result) + "%");
			System.out.println("Successfully calculated returns.");
			writer.close();
		} else {
			System.out.println("Wrong number of arguments supplied. Expected 1 (input file).");
		}

	}

}
