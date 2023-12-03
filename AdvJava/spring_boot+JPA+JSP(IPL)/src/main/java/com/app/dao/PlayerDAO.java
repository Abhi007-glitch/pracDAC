package com.app.dao;

import java.util.List;

import com.app.pojos.Player;
import com.app.pojos.Team;

public interface PlayerDAO {
    
	public String addPlayerToTeam(Player toAdd,Team team);
	public List<Player> getAllPlayers();
}
