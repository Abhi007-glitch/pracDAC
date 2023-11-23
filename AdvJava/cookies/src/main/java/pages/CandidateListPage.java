package pages;

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


@WebServlet("/candidate_list")
public class CandidateListPage extends HttpServlet{
	//doGet
	@Override
	public void doGet(HttpServletRequest rq,HttpServletResponse rs) throws ServletException,IOException
	{
		System.out.println("in candidate list page ");
		//1. set resp cont type
		rs.setContentType("text/html");
		
		
//*********************accessing Cookies received in request  header *********************
		Cookie [] coki = rq.getCookies();
		
		
		
		//2. get PW : to send resp from servlet ---> web clnt
		try(PrintWriter pw=rs.getWriter()) {
			pw.print("<h5>Welcome Voter : </h5>");
			if (coki!=null)
			{
		     for (  Cookie c : coki)
		     {
		    	 if (c.getName().equals("user_info"))
		    	 {
		    		 pw.print("<h1> user Details : " +c.getValue()+ " </h1>");
		    	 }
		     }
			}
			else 
			{
				System.out.println("Session management using cookies got failed!!");
				pw.write("<h2>Session management using cookies got failed!!</h2> ");
			}
			
			//generate dyn cont (add dyn contents to buffer of PW
			
		}
	}

}
