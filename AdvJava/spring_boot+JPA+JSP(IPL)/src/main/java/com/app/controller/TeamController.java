package com.app.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.app.pojos.Player;
import com.app.pojos.Team;
import com.app.service.TeamService;

@Controller
@RequestMapping("/Ipl")
public class TeamController{
     
	@Autowired
	TeamService ts;
	
	// get team abbrivation list 
	
	@GetMapping("/playerForm")
	public String getTeamList(Model map)
	{ 

		String message="Failed to fetch the Team abbrivation list data!!";
		try {
			map.addAttribute("abbrList",ts.getTeamAbberivationList());
		}catch (RuntimeException e) {
			// TODO: handle exception
			throw new RuntimeException(message);
		}
	   
		return "/playerForm";
		
	}
	
	// add a new team 
	//String name, String abbreviation, String owner, int maxAge, double battingAvg,int wicketsTaken
	@PostMapping("/addTeam")
	public String addTeam(@RequestParam String name,@RequestParam String abbreviation, @RequestParam String owner, @RequestParam Integer maxAge,Double battingAvg,@RequestParam Integer wicketsTaken)
	{
		String message="Failed to add Team !!";
	   try {
//String name, String abbreviation, String owner, int maxAge, double battingAvg, int wicketsTaken, List<Player> playersList
		   Team t = new Team(name,abbreviation,owner,maxAge,battingAvg,wicketsTaken);
		   message=ts.addTeam(t);	
		}catch (RuntimeException e) {
			// TODO: handle exception
			throw new RuntimeException(message);
		}
	   
	   return "redirect:/Ipl/playerForm";
	}
	
	
	@GetMapping("/team/register")
	public String registerTeam()
	{
	  return "/team/teamRegisterationForm";	
	}
	
	
	
}
