package com.app.dao;

import java.util.List;

import com.app.pojos.Team;

public interface TeamDAO {
	public List<String> getTeamAbbrivation();
	
     public String addTeam(Team t);
     
     public Team getTeam(String abbr);
}
