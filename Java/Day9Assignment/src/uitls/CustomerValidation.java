package uitls;

import java.time.LocalDate;
import java.time.format.DateTimeParseException;
import java.util.*;
import coreClasses.Customer;
import customExceptions.CustomerException;
import enums.ServicePlan;

public class CustomerValidation {

	
	
	
	
	public static LocalDate formateDate(String str) throws CustomerException {
		try {
			LocalDate DOB = LocalDate.parse(str);
			return DOB;
		} catch (DateTimeParseException e) {
			throw new CustomerException("Unparsable date formate!!");
		}

	}
	
	


	public static Customer findIfPresent(String email, List<Customer> list) {
		Customer temp = new Customer(email);

		int val = list.indexOf(temp);
		if (val == -1) {
			return null;
		} else {
			return list.get(val);
		}
	}

	public static ServicePlan validatePlanAndReturn(String plan) throws IllegalArgumentException, CustomerException {

		try {
			ServicePlan PLAN = ServicePlan.valueOf(plan);
			return PLAN;
		} catch (IllegalArgumentException e) {
			throw new CustomerException("Invalid plan entered");
		}

	}

	public static void SignUp(String firstName, String lastName,String email, String password, double registerationAmount, String dob,
			String plan,List<Customer>list)
	{
		try {
			
			// checking if user with give email is already present  
			if(findIfPresent(email,list)!=null)
			{
				throw new CustomerException("Account with given email already exists");
			}
			
			LocalDate DOB = formateDate(dob);
			ServicePlan PLAN = validatePlanAndReturn(plan);
			System.out.println("Creating a new Customer");
 			Customer newCusotmer = new Customer(firstName, lastName, email, password, registerationAmount, DOB, PLAN);
 			System.out.println("adding new customer to the List ");
 			list.add(newCusotmer);
	    
		}catch(CustomerException e)
		{
			System.out.println(e.getMessage());
		}catch(Exception e)
		{  
			System.out.println("Caught in CatchALL Exception block");
			System.out.println(e.getMessage());
		}
		 
	}
	
	
	
	public static void changePlan(String email,String str,List<Customer>list) throws CustomerException
	{
	//checking if plan to which to be updated is valid or not 
	ServicePlan plan= validatePlanAndReturn(str);
	
		
	// finding account with given email 
	Customer cur = findIfPresent(email,list);	
	if (cur==null)
	{
		throw new CustomerException("Account linked to the entered Email does not exists");
	}
		
	//changing plan and simultaneously updating the amountFees
    cur.setPlan(plan);
    cur.setRegisterationAmount(plan.getAmount());
		
	}
	
	
	public static void changePassword(String email,String OldPass, String newPass,List<Customer>list) throws CustomerException
	{
		// finding account with given email 
		Customer cur = findIfPresent(email,list);	
		if (cur==null)
		{
			throw new CustomerException("Account linked to the entered Email does not exists");
		}
	   
		if (cur.getPassword().equals(OldPass))
		{
			
			cur.setPassword(newPass);
		}
		else 
		{
			System.out.println("Current password : "+cur.getPassword());
			System.out.println("Enterd Password : "+OldPass);
			throw new CustomerException("Authenthication failed !! Current password does not matches!!");
		}
		
	
	}
	
	
	public static boolean login(String email,String password, List<Customer>list)throws CustomerException
	{
	 //checking if account with given email exits;
		Customer cur = findIfPresent(email,list);	
		if (cur==null)
		{
			throw new CustomerException("Account linked to the entered Email does not exists");
		}
		if (!cur.getPassword().equals(password))
		{
		
			throw new CustomerException("Authenthication failed !! Password does not matches!!");
		}
		
		
		
		return true;
	}
	
	
	public static Customer unSubscriber(String email,List<Customer>list)throws CustomerException
	{
		//checking if account with given email exits;
		Customer temp = new Customer(email);
		int idx = list.indexOf(temp);
		if (idx==-1)
		{
			throw new CustomerException("Account with given email does not exists");
		}
		temp = list.remove(idx);
		return temp;
				
	}

}
