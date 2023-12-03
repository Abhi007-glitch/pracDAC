package com.app.dao;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;

import org.springframework.stereotype.Repository;

import com.app.pojos.Team;

@Repository
public class TeamDAOImpl implements TeamDAO {
   
	@PersistenceContext
	EntityManager mgr;
	
	@Override
	public List<String> getTeamAbbrivation() {

		return mgr.createQuery("select t.abbreviation  from Team t").getResultList();
	}

	@Override
	public String addTeam(Team t) {
		// TODO Auto-generated method stub
		mgr.persist(t);
		return "Team Added Successfully";
	}

	@Override
	public Team getTeam(String abbr) {
		// TODO Auto-generated method stub
		return (Team) mgr.createQuery("select t from Team t where t.abbreviation=:nm").setParameter("nm", abbr).getSingleResult();
		
	}

}
