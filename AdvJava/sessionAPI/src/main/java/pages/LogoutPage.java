package pages;

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import dao.CandidateDAO;
import dao.UserDao;


@WebServlet("/logout")
public class LogoutPage extends HttpServlet{
	//doGet
	@Override
	public void doGet(HttpServletRequest rq,HttpServletResponse rs) throws ServletException,IOException
	{
		System.out.println("in logout page ");
		//1. set resp cont type
		rs.setContentType("text/html");
		//2. get PW : to send resp from servlet ---> web clnt
		try(PrintWriter pw=rs.getWriter()) {
			//generate dyn cont (add dyn contents to buffer of PW
		   
			HttpSession hs = rq.getSession();
			
			UserDao userDAO = (UserDao)hs.getAttribute("user_dao");
			CandidateDAO candidateDao = (CandidateDAO) hs.getAttribute("candidate_dao");
			String CandidateID = rq.getParameter("candidate_id");
			// how to get the user who made this request ---> main issue 
			
			
			pw.print("<h5>logging out ..... </h5>");
		}
		catch (Exception e) {
			// TODO: handle exception
			throw new ServletException("Exception occured in "+getClass(),e);
		}
	}

}
