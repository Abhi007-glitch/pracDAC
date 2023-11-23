package pages;

import java.io.IOException;
import java.io.PrintWriter;
import java.time.LocalDateTime;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import dao.CandidateDAO;
import dao.UserDao;
import pojos.Candidate;
import pojos.User;

@WebServlet("/candidate_list")
public class CandidateListPage extends HttpServlet {
	// doGet
	@Override
	public void doGet(HttpServletRequest rq, HttpServletResponse rs) throws ServletException, IOException {
		System.out.println("in candidate list page ");
		// 1. set resp cont type
		rs.setContentType("text/html");

//*********************accessing Session if already present or creating a new one *********************
		HttpSession hs = rq.getSession(); // if cookies send from client has mapping to any sessionID saved in server
											// then send the existing session else create a new session

		try {

			// ****** fetching userDAO and and candidateDAO from the saved session
			User curUser = (User) hs.getAttribute("user_info");

			

				UserDao userDAO = (UserDao) hs.getAttribute("user_dao");
				CandidateDAO candidateDAO = (CandidateDAO) hs.getAttribute("candidate_dao");

				List<Candidate> candidates = candidateDAO.getCandidates();

				// ******* generate dyn cont (add dyn contents to buffer of PW

				// 2. get PW : to send resp from servlet ---> web clnt
				try (PrintWriter pw = rs.getWriter()) {
					
					if (curUser != null) 
					{
						pw.print("<h5>Welcome " + curUser.getFirstName() + "</h5>");

						pw.print("<form action='logout'>");  // no method of submission mentioned so default get request is made

						for (Candidate c : candidates) {
							pw.print("<h3><input type='radio' name='candidate_id' value='" + c.getid() + "' />"
									+ c.getName() + "</h3>");
						}
  
						pw.print("<h3><input type='submit' name='submit vote'/> </h3>");
						rq.setAttribute("user_id", curUser.getUserId());
					}
					else 
					{
						pw.print("<h4> Session Tracking failed !!!!!!! No cookies.....</h4>");
					}
					
				}
			
		

		} catch (Exception e) {
			// TODO: handle exception

			throw new RuntimeException(e.getMessage());
		}

	}
}
