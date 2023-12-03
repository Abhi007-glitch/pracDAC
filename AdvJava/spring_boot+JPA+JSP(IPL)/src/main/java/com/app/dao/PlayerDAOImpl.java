package com.app.dao;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Repository;

import com.app.pojos.Player;
import com.app.pojos.Team;
@Repository
public class PlayerDAOImpl implements PlayerDAO {
    
	@PersistenceContext
	EntityManager mgr;
	@Override
	public String addPlayerToTeam(Player toAdd, Team team) {
		// TODO Auto-generated method stub
		String message="Sorry Better luck next Time "+toAdd.getFirstName()+"!!";
		try {
			team.addPlayer(toAdd);
			mgr.persist(toAdd);
			message="Congratulation "+toAdd.getFirstName() +" for getting selected into "+team.getName()+" .";
		}catch(RuntimeException e)
		{
			throw e;
		}
		return message;
	}
	@Override
	public List<Player> getAllPlayers() {
		// TODO Auto-generated method stub
		
		return mgr.createQuery("Select p from Player p", Player.class).getResultList();
	}
	
	
	
	
	

}


