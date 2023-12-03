package com.app.service;

import java.util.List;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.app.dao.TeamDAO;
import com.app.pojos.Team;

@Service
@Transactional
public class TeamServiceImpl implements TeamService {

	@Autowired
	TeamDAO dao;
	@Override
	public List<String> getTeamAbberivationList() {
		// TODO Auto-generated method stub
		return dao.getTeamAbbrivation();
	}
	@Override
	public String addTeam(Team t) {
		return dao.addTeam(t);
	}

}
