package dao;

import java.sql.SQLException;
import java.util.List;

import pojos.Player;

public interface PlayerDAO {
    
	List<Player> getPlayersList() throws SQLException;
	
	Player getPlayer(int id) throws SQLException;
	
	void updatePlayerTeam(Player pl,int teamID) throws SQLException;
	
	void cleanUp() throws SQLException;
	
}
