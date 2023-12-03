package com.app.controller;

import java.time.LocalDate;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.format.annotation.DateTimeFormat;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import com.app.pojos.Player;
import com.app.pojos.Team;
import com.app.service.PlayerService;

@Controller
@RequestMapping("/player")
public class PlayerController {
    
	@Autowired
	PlayerService playerService;
	
	//myTeam ,fn,ln,dob,avg(double),wickets
	@PostMapping("/submit")   // player/submit
	public String playerSelectionResult(@RequestParam String myTeam,@RequestParam String fn, @RequestParam String ln, @RequestParam @DateTimeFormat(pattern = "yyyy-MM-dd") LocalDate dob,@RequestParam Double avg,@RequestParam Integer wickets, Model map)
	{
		String message="Failed to process request !!";
		   try {
	           Player  p = new Player(fn,ln,dob,avg,wickets);
			   map.addAttribute("result", playerService.addPlayerToTeam(p, myTeam));
			}catch (RuntimeException e) {
				// TODO: handle exception
				throw new RuntimeException(message);
			}
		   
		   return "/playerResult";
	}
	///player/getList
	@GetMapping("/getList")
	public String getAllSelectedPlayers(Model map )
	{
	   map.addAttribute("list", playerService.getAllPlayer());
		
		return "/ResultPage";
	}
	
	
}
