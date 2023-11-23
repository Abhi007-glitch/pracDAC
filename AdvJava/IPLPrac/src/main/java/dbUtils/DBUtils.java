package dbUtils;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DBUtils {

	static Connection cn;
	
	public static Connection openConnection() throws SQLException
	{
	  cn = DriverManager.getConnection("jdbc:mysql://localhost:3306/advjava?useSSL=false&allowPublicKeyRetrieval=true", "springstudent", "springstudent");
	  return cn;
	}
	
	public static void closeConnection() throws SQLException
	{
		cn.close();
	}
	
	public static Connection getConnection()
	{
		return cn;
	}
}
