package enums;

public enum ServicePlan {
	
	
	SILVER(1000),GOLD(2000),DIAMOND(5000),PLATINUM(10000);
	private int amount;
	
	// constructor is private for singleTon design
	private ServicePlan( int amount)
	{
	 this.amount=amount;
	}
	
	public int getAmount()
	{
		return this.amount;
	}
	
	public void setAmount(int val)
	{
	 this.amount=val;	
	}
	
	public String toString()
	{
	    return name()+" Plans amount is "+this.amount;	
	}
	
	
	

}
