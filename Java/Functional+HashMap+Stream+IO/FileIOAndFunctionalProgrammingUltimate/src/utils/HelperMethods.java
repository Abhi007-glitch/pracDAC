package utils;

import java.io.BufferedReader;
import java.io.FileReader;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.stream.Collectors;

public class HelperMethods {

	public static HashMap<String, List<?>> readData(String fileName) {

		try (BufferedReader br = new BufferedReader(new FileReader(fileName))) {
//			   ArrayList<String>[] l1 = new ArrayList<String>[3];
//			   
		//	ArrayList<List<?>> l2 = new ArrayList<List<?>>();
			HashMap<String, List<?>> map = new HashMap<>();

			// A Collector encapsulates the functions used as arguments to collect(Supplier
			// (ArryaList::new), (Accumulator)BiConsumer (ArrayList::add), (Combiner)
			// BiConsumer(ArrayList::addAll))
			List<String[]> l1 = br.lines().map((s) -> {
				return s.split(",");
			}).collect(Collectors.toList());
			
			String[] category = l1.remove(0);

			/// l1.stream().forEach(p->System.out.println((Arrays.toString(p))));

			List<LocalDate> TransitionDate = l1.stream().map((p) -> {
				return LocalDate.parse(p[0], DateTimeFormatter.ofPattern("dd-MM-yyyy"));
			}).collect(Collectors.toList());
			List<String> Narration = l1.stream().map((p) -> {
				return p[1];
			}).collect(Collectors.toList());
			List<Double> withdrawAmount = l1.stream().map((p) -> {
				return Double.parseDouble(p[2]);
			}).collect(Collectors.toList());
			List<Double> depositeAmount = l1.stream().map((p) -> {
				return Double.parseDouble(p[3]);
			}).collect(Collectors.toList());

			map.put(category[0], TransitionDate);
			map.put(category[1], Narration);
			map.put(category[2], withdrawAmount);
			map.put(category[3], depositeAmount);

//	          l2.add(TransitionDate);
//	          l2.add(Narration);
//	          l2.add(withdrawAmount);
//	          l2.add(depositeAmount);

			System.out.println("Data read and transformed successfully into a dictonary.");
			return map;

		} catch (Exception e) {
			// TODO: handle exception
			System.out.println(e.getStackTrace());
			System.out.println(e.getMessage());
			// withour return statement here gives error
			return new HashMap<>();
		}
	}

}
