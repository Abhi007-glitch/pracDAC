import java.util.Scanner;
import java.util.Stack;

public class ReverseNumber {
	
	public static int reverse(int n)
	{
		Stack<Integer> st = new Stack<>();
		int pow=1;
		while(n!=0)
		{
			st.push(n%10);
			n/=10;
		}
		int ans=0;
		while(!st.isEmpty())
		{
			ans+=st.pop()*pow;
			pow*=10;
		}
		
		return ans;
	}
	public static void main(String [] args)
	{
		try(Scanner scn = new Scanner(System.in))
		{
			System.out.println("Enter a number to be reversed!!");
			
			int n = scn.nextInt();
			
			int temp = reverse(n);
			
			System.out.println("Reversed value is "+temp);
			
		}
	}

}
