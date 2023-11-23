package dao;

import pojos.Player;
import pojos.Team;

import static dbUtils.DBUtils.*;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
public class TeamDAOImpl implements TeamDAO{
    
	Connection cn;
	PreparedStatement ps1;
	PreparedStatement ps2;

	
	public TeamDAOImpl() throws SQLException {
		// TODO Auto-generated constructor stub
	cn= getConnection(); 
	ps1 = cn.prepareStatement("Select * from teams where abbrevation=?");
	ps2 = cn.prepareStatement("SELECT * from teams");
	}
	
	@Override
	public Team getTeam(String teamAbbri) throws SQLException{
		// TODO Auto-generated method stub
		ps1.setString(1, teamAbbri);
		Team curTeam=null;
		
		try(ResultSet rst = ps1.executeQuery())
		{
			
//teamId, String name, String abbrevation, String owner, int maxAge, double battingAvg,int wicketsTaken
			if (rst.next()!=false)
			{
				curTeam = new Team(rst.getInt(1), rst.getString(2), rst.getString(3), rst.getString(4),rst.getInt(5),rst.getInt(6),rst.getInt(7));	
			}
		}
		return curTeam;
	}

	@Override
	public void cleanUp() throws SQLException {
		// TODO Auto-generated method stub
		ps1.close();
		
	}

	@Override
	public List<Team> getTeamList() throws SQLException {
		// TODO Auto-generated method stub
	   
		 List<Team> list=null;
	    try(ResultSet rst = ps2.executeQuery())
	    {    list= new ArrayList<>();
	    	while(rst.next())
	    	{
	    		Team temp = new Team(rst.getInt(1), rst.getString(2), rst.getString(3), rst.getString(4),rst.getInt(5),rst.getInt(6),rst.getInt(7));
	    		list.add(temp);
	    	}
	    }
	    
		return list;
	}

}
