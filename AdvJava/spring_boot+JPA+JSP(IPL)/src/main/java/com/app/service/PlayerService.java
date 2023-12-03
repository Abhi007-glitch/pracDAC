package com.app.service;

import java.util.List;

import com.app.pojos.Player;

public interface PlayerService {

	
	public String addPlayerToTeam(Player toAdd, String teamAbbr);
	
	public List<Player> getAllPlayer();
}
