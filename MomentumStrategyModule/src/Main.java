import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;


public class Main
{

	public static void main(String[] args) throws FileNotFoundException
	{
		Scanner CSVScanner = new Scanner(new File("src/bhp5Feb13.csv"));
        CSVScanner.useDelimiter("\n");
        
        while (CSVScanner.hasNext())
        {
        	String line = CSVScanner.next();
        	String recordType = line.split(",")[3];
        	
        	if (recordType.equalsIgnoreCase("TRADE"))
        	{
        		System.out.println(line);
        	}
        }
        
        CSVScanner.close();
	}

}
