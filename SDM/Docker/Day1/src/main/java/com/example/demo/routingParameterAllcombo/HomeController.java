package com.example.demo.routingParameterAllcombo;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class HomeController {
	
	@GetMapping("/home")
	public String Home()
	{
		return "Home!!";
	}
	
	

}
