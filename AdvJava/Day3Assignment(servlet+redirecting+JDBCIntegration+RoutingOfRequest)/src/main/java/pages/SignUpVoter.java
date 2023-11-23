package pages;

import java.io.IOException;
import java.lang.ProcessBuilder.Redirect;
import java.sql.Date;
import java.sql.SQLException;
import java.time.LocalDate;
import java.time.Period;
import java.time.format.DateTimeFormatter;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import dao.UserDao;
import dao.UserDaoImpl;
import pojos.User;

/**
 * Servlet implementation class SignUpVoter
 */
@WebServlet("/SignUp")
public class SignUpVoter extends HttpServlet {
	private static final long serialVersionUID = 1L;

	/**
	 * @see Servlet#init(ServletConfig)
	 */
	private UserDao userDAO; 
	public void init(ServletConfig config) throws ServletException {
		// TODO Auto-generated method stub
		// intialize DAO 
		  try {
			userDAO=new UserDaoImpl();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			throw new ServletException(e.getMessage());
		}
		
		
	}

	/**
	 * @see Servlet#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
		try {
			userDAO.cleanUp();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			throw new RuntimeException(e.getMessage());
		}
		
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		
		//  first_name | last_name | email | password | dob | status | role  |
		
		String firstName = request.getParameter("fname");
		String lastName =  request.getParameter("lname");
		String email = request.getParameter("em");
		String password = request.getParameter("pass");
		String date = request.getParameter("dob");
		LocalDate dob = LocalDate.parse(date);
		Date DOB = Date.valueOf(dob);
		  
		int age = Period.between(dob, LocalDate.now()).getYears();
		
		if (age<21)
		{
			response.sendRedirect("SignUp");
		}
		else 
		{
			
			//   firstName,  lastName, email, password, dob,  votingStatus, role
			User newUser = new User(firstName, lastName, email, password, DOB, false, "voter");
			try {
				userDAO.registerNewVoter(newUser);
				response.sendRedirect("candidate_list");
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				throw new ServletException(e.getMessage());
			}
		}
		
		
		
	}

}
