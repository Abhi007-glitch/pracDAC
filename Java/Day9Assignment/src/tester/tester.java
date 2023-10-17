package tester;


import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Scanner;
import static uitls.CustomerValidation.*;

import coreClasses.Customer;
import enums.ServicePlan;

public class tester {

	public static void main(String[] args) {

		ArrayList<Customer> list = new ArrayList<Customer>();

		try (Scanner scn = new Scanner(System.in)) {

			// creating user - SignUp
			
			//SignUp("abhi", "sharma", "abhi@123gamil.com", "abhi123", 1000, "2000-02-02", "SILVER", list);
//			//SignUp("aj9u", "glitch", "aj9uglitches@gmail.com","aj9u",5000,"2000-02-02", "DIAMOND",list);
			//SignUp("jatin","Lanje","jatin@123gmail.com", "jatin@123",10000,"2000-03-30","PLATINUM",list);

		// aj9u glitches aj9uglitches@gmail.com aj9u 5000 2000-02-02 DIAMOND
		// abhi Sharma abhi@123gmail.com abhi123 1000 2000-02-02 SILVER 
		//jaitn lanje jatin@123gmail.com jatin@123 10000 2000-03-30 PLATINUM	4
			
	// abhi@123gmail.com abhi@123

			boolean flag = false;
			while (!flag) {

				System.out.println("select one of the operations");
				System.out.println("1.SignUp");
				System.out.println("2.Login");
				System.out.println("3.Update Password");
				System.out.println("4.Unsubscribe ");
				System.out.println("5.End the program");
				
				try {

					switch (scn.nextInt()) {
					case 1:
						System.out.println(
								"Enter details for sign up : firstName, lastName, email,  password,  registerationAmount,  dob, plan");
						        SignUp(scn.next(), scn.next(), scn.next(), scn.next(), scn.nextDouble(), scn.next(), scn.next(), list);
						
						break;
					case 2:
                         System.out.println("Enter email and password to login ");
                         login(scn.next(),scn.next(),list);
                         System.out.println("Login in succesfully");
						break;
					case 3:
						System.out.println("Enter your email, current password and updated passowrd respectively");
						changePassword(scn.next(),scn.next(),scn.next(),list);
						System.out.println("Updated password successfully!!");
						break;
					case 4:
                         System.out.println("Enter your Email to UnSubscribe ");
                         unSubscriber(scn.next(), list);
                         System.out.println("Unsubscribed Successfully");
						break;

					case 5:
						flag = true;
						break;
					}

				} catch (Exception e) {
					String tp = scn.nextLine();// to clear scanner buffer after handling rhe exception for further run of the program 
					System.out.println(e.getMessage());
				}
			}

		} catch (Exception e) {
			System.out.println(e.getMessage());
		} finally {
			System.out.println("Finally got executed");
		}
	}

}
