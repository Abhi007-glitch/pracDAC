package com.app.service;

import java.time.LocalDate;
import java.time.Period;
import java.util.List;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.app.dao.PlayerDAO;
import com.app.dao.TeamDAO;
import com.app.pojos.Player;
import com.app.pojos.Team;

@Service
@Transactional
public class PlayerServiceImpl implements PlayerService {
    
	@Autowired
	PlayerDAO playerDao;
	@Autowired
	TeamDAO teamDao;
	
	@Override
	public String addPlayerToTeam(Player toAdd, String teamAbbr) {
		// TODO Auto-generated method stub
		
		String message="Server Failed to add the player to the team";
		try {
			Team selectedTeam = teamDao.getTeam(teamAbbr);
			if (selectedTeam.getBattingAvg()<=toAdd.getBattingAvg() && selectedTeam.getMaxAge()>Period.between(toAdd.getDob(),LocalDate.now()).getYears() && selectedTeam.getWicketsTaken()<toAdd.getWicketsTaken())
			    message = playerDao.addPlayerToTeam(toAdd, selectedTeam);
			else 
				return "Sorry, "+toAdd.getFirstName() +" better luck next time !!";
		}catch (RuntimeException e) {
			// TODO: handle exception
			throw e;
		}
		return message;
	}

	@Override
	public List<Player> getAllPlayer() {
		// TODO Auto-generated method stub
		
		return playerDao.getAllPlayers();
	}

}
