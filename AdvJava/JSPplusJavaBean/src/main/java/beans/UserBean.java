package beans;

import java.sql.SQLException;

import dao.UserDao;
import dao.UserDaoImpl;
import pojos.User;

public class UserBean {
	
	UserDaoImpl userDao;
	User userDetails;
	
	public UserBean() throws SQLException {
		// TODO Auto-generated constructor stub
		userDao = new UserDaoImpl();
		System.out.println("User bean's constructor got called !!");
	}
	
	private String email;
	private String pass;
	private String name;

	public User getUserDetails() {
		return userDetails;
	}
	public void setUserDetails(User userDetails) {
		this.userDetails = userDetails;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getPass() {
		return pass;
	}
	public void setPass(String pass) {
		this.pass = pass;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	
	
	public String validateUser() throws SQLException
	{
		User curUser = userDao.authenticateUser(email, pass);
		
		if (curUser==null)
		{
			return "login";
		}
		else 
		{
			if (curUser.getRole().equals("admin"))
			{
				return "adminPage.jsp";
			}
			else 
			{
				return (" candidateListPage.jsp"+curUser.toString()) ;
			}
		}
	}
	
	

}
