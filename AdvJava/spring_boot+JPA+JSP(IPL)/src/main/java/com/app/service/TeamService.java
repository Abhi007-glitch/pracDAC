package com.app.service;

import java.util.List;

import com.app.pojos.Team;

public interface TeamService {
    
	List<String> getTeamAbberivationList();
	
	String addTeam(Team t);
	
}
