package com.example.demo.Controllers;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("intro")
public class Controllers1 {

	@GetMapping("/name/{var1}")
	public String getName(@PathVariable String var1,@RequestParam String var2)
	{
      return ("The Path variable is "+var1 + " the Request param is "+var2);		
	}	
}
