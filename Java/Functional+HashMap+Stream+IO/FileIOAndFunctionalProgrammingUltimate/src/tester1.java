import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.lang.reflect.Array;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Optional;
import java.util.OptionalInt;
import java.util.Scanner;
import java.util.stream.Collector;
import java.util.stream.Collectors;
import java.util.stream.IntStream;

import static utils.HelperMethods.*;

public class tester1 {

	@SuppressWarnings("unchecked")
	public static void main(String[] args) throws FileNotFoundException, IOException {
		try (Scanner scn = new Scanner(System.in)) {
			System.out.println("Enter the file path of bankTransition details ");

			HashMap<String, List<?>> data = readData(scn.nextLine());
			boolean flag = false;

			while (!flag) {
				System.out.println("Select one of the following options : ");
				System.out.println("1.Find Sum of all DepositAmount");
				System.out.println("2.Max deposite Amount");
				System.out.println("3.Shopping expenses (sum of withdrawals for shopping)");
				System.out.println("4. Find Date on which maximum amount withdrawn");
				System.out.println("Press Any other keyword to end the program.");

				try {

					switch (scn.nextInt()) {
					case 1:
						Double totalDepositAmount = data.get("DepositAmount").stream().map(p -> (Double) p).reduce(0.0,
								(result, element) -> result + element);
						System.out.println(
								"The total depositAmount transition in the data sheet is " + totalDepositAmount);
						break;
					case 2:
						Optional<Double> maxDepositAmount = data.get("DepositAmount").stream().map(p -> (Double) p)
								.max((d1, d2) -> d1.compareTo(d2));
						// (maxDepositAmount.isPresent()==true)?(System.out.println(maxDepositAmount.get())):(System.out.println("Some
						// error in data"));
						if (maxDepositAmount.isPresent()) {
							System.out.println("Max Deposited Amount is " + maxDepositAmount.get());
						} else {
							System.out.println("Some error in data");
						}
						break;
					case 3:
						List<String> list = (List<String>) data.get("Narration");
						List<Double> WithdrawList = (List<Double>) data.get("WithdrawalAmount");

						Double sum = IntStream.range(0, list.size()).filter((i) -> (list.get(i).equals("Shopping")))
								.mapToDouble(i -> WithdrawList.get(i)).sum();

						System.out.println("Shopping expenses (sum of withdrawals for shopping) = " + sum);
						// data.get("Narration").stream().filter((p)->p.equals("Shopping")).forEach(p->System.out.println(p));

						break;
					case 4:
						List<LocalDate> dates = (List<LocalDate>) data.get("TransactionDate");
						WithdrawList = (List<Double>) data.get("WithdrawalAmount");
						Double maxWithDrwaAmount = Collections.max(WithdrawList,(p1,p2)->(p1.compareTo(p2)));
						
						
						OptionalInt idx = IntStream.range(0, WithdrawList.size()).filter((i) ->(WithdrawList.get(i).equals(maxWithDrwaAmount))).min();  
						System.out.println(idx.getAsInt());
						
						if (idx.isPresent())
						{
						  
						  System.out.println(dates.get(idx.getAsInt())); 
						}
						else 
						{
							System.out.println("Some issue in Withdraw data, unable to processs!!");
						}
						break;

					default:
						flag = true;
						break;
					}

				} catch (Exception e) {
					scn.nextLine(); // important to flush the buffer of the Scanner
					System.out.println(e.getMessage());
					System.out.println(e.getStackTrace());
				}

			}

		}
	}

}
