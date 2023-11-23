package servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.SQLException;
import java.util.List;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import dao.PlayerDAO;
import dao.PlayerDAOImpl;
import dao.TeamDAO;
import dao.TeamDAOImpl;
import pojos.Team;

import static dbUtils.DBUtils.*;

/**
 * Servlet implementation class IPLAuctionForm
 */
@WebServlet("/IPLAuctionForm")
public class IPLAuctionForm extends HttpServlet {
	private static final long serialVersionUID = 1L;

	private PlayerDAO playerDao;
	private TeamDAO teamDao;
	
	/**
	 * @see Servlet#init(ServletConfig)
	 */
	public void init() throws ServletException {
		// TODO Auto-generated method stub
		try {
			openConnection();
		    playerDao= new PlayerDAOImpl();
		    teamDao = new TeamDAOImpl();
		    
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			throw new ServletException("Exception occured in IPLAuctionFORM : ",e);
		}
	}

	/**
	 * @see Servlet#destroy()
	 */
	public void destroy() {
		// TODO Auto-generated method stub
		try {
			closeConnection();
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			throw new RuntimeException(e.getMessage());
		}
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	
	@Override 
	public void doGet(HttpServletRequest request,HttpServletResponse response) throws ServletException,IOException
	{

		HttpSession hs = request.getSession();	
		
		hs.setAttribute("player_dao", playerDao);
		hs.setAttribute("team_dao", teamDao);
		
		response.setContentType("text/html");
		
	    try {
			List<Team>teams = teamDao.getTeamList();
			
			try(PrintWriter pw = response.getWriter())
			{
				pw.write("<form action='ValidateAndUpdatePlayer' method='post'>");
				pw.write("Team : ");
				pw.write(" <input type='text' list=\"team\" name=\"teamAbbri\" />");
				pw.write("<datalist id=\"team\">");
				for (Team t : teams)
				{
					pw.write("<option>" +t.getAbbrevation()+"</option>");
				}
				pw.write("</datalist> <br>");
				
				pw.write("<label for=\"name\" > name:</label>");
				pw.write("  <input type=\"text\" id=\"name\" name=\"name\" value=\"\"><br>");
				pw.write(" <label for=\"battingAvg\">Batting Avg:</label>");
				pw.write(" <input type=\"text\"  name=\"battingAvg\" value=\"\"><br>");
				pw.write(" <label for=\"DOB\">DOB :</label>");
				pw.write(" <input type=\"date\"  name=\"dob\" ><br>");
				pw.write(" <label for=\"wicketTaken\">wicketTaken:</label>");
				pw.write(" <input type=\"text\"  name=\"wicketTaken\" ><br>");
				pw.write(" <input type=\"submit\" >");
				pw.write("</form>");
			
				
			}
			
			
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			throw new ServletException("Error occured in do-post method of the Auction form!!",e);
		}
	}
	
	

}
