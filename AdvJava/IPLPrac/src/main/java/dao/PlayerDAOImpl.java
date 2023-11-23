package dao;

import java.security.PKCS12Attribute;
import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import dbUtils.DBUtils;

import static dbUtils.DBUtils.*;
import pojos.Player;

public class PlayerDAOImpl implements PlayerDAO{
    
	Connection cn;
	PreparedStatement ps1;
	PreparedStatement ps2;
	PreparedStatement ps3;
	public PlayerDAOImpl() throws SQLException {
		// TODO Auto-generated constructor stub
		cn = DBUtils.getConnection();
	    ps1 = cn.prepareStatement("SELECT * from players where team_id=-1");
		ps2 = cn.prepareStatement("SELECT * from players where player_id=?");
	    ps3 = cn.prepareStatement("UPDATE players SET team_id=? where player_id=?");
	    
	}
	
	@Override
// player_id, first_name, last_name, Date dob, double batting_avg,  wickets_taken, team_id
	public List<Player> getPlayersList() throws SQLException {
		// TODO Auto-generated method stub
		List<Player> list = new ArrayList<Player>();
	    try(ResultSet rst = ps1.executeQuery())
	    {
	    	Player p1;
	    	while(rst.next()!=false)
	    	{   LocalDate dob = LocalDate.parse(rst.getString(4));
	    	    Date date = Date.valueOf(dob);
	    		p1 = new Player(rst.getInt(1),rst.getString(2), rst.getString(3), date, rst.getDouble(5), rst.getInt(6), rst.getInt(7));
	    		list.add(p1);
	    	}
	    }
	    return list;
	}

	@Override
	public Player getPlayer(int id) throws SQLException {
		// TODO Auto-generated method stub
		Player cur=null;
		ps2.setInt(1, id);
		try(ResultSet rst = ps2.executeQuery())
		{
			if(rst.next())
			{
				LocalDate dob = LocalDate.parse(rst.getString(4));
	    	    Date date = Date.valueOf(dob);
	    		cur = new Player(rst.getInt(1),rst.getString(2), rst.getString(3), date, rst.getDouble(5), rst.getInt(6), rst.getInt(7));
			}
		}
		return cur;
	}

	@Override
	public void updatePlayerTeam(Player pl, int teamID) throws SQLException {
		// TODO Auto-generated method stub
		ps3.setInt(1,teamID);
		ps3.setInt(2,pl.getPlayerId());
		
		int id = ps3.executeUpdate();
		
		if (id==1)
		{
			System.out.println("Updated player data successfully!! ");
		}
	}

	@Override
	public void cleanUp() throws SQLException {
		// TODO Auto-generated method stub
		ps1.close();
		ps2.close();
		ps3.close();	
	}
	
	
	

}
