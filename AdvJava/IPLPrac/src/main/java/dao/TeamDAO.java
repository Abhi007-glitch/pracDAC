package dao;

import java.sql.SQLException;
import java.util.List;

import pojos.Player;
import pojos.Team;

public interface TeamDAO {
	
	Team getTeam(String teamAbri) throws SQLException;
    void cleanUp() throws SQLException;
    List<Team> getTeamList() throws SQLException;
    
    
}
