package coreClasses;

import java.time.LocalDate;

import enums.ServicePlan;

public class Customer {
  
	static int customerId;
	private String firstName;
	private String lastName;
	private String email;
	private String password;
	private double registerationAmount;
	private LocalDate dob;
	private ServicePlan plan;
	
	
	static {
		customerId=0;
	}
	
	



	public Customer(String firstName, String lastName,String email, String password, double registerationAmount, LocalDate dob,
			ServicePlan plan) {
		super();
		this.firstName = firstName;
		this.lastName = lastName;
		this.email = email;
		this.password = password;
		this.registerationAmount = registerationAmount;
		this.dob = dob;
		this.plan = plan;
		this.customerId=customerId++;
	}
	
	
	public double getRegisterationAmount() {
		return registerationAmount;
	}


	public void setRegisterationAmount(double registerationAmount) {
		this.registerationAmount = registerationAmount;
	}


	public String getPassword() {
		return password;
	}


	public void setPassword(String password) {
		this.password = password;
	}


	public ServicePlan getPlan() {
		return plan;
	}


	public void setPlan(ServicePlan plan) {
		this.plan = plan;
	}


	public Customer(String email)
	{
		super();
		this.email=email;
	}
	
	@Override
	public String toString()
	{
		return ("FirstName : "+firstName+" LastName "+ lastName +" email "+email+" registeration amount "+registerationAmount+" DOB "+dob); 
	}
	
	
	@Override
	public boolean equals(Object another)
	{
		if (!(another instanceof Customer))
		{
			return false;
		}
		
		Customer cur = (Customer) another;
		
		if (this.email.equals(cur.email))
		{
		return true;	
		}
		return false;
		
	}
	
	}
