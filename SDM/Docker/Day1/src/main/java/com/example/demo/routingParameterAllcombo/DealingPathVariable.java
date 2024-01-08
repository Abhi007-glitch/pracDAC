package com.example.demo.routingParameterAllcombo;

import java.util.HashMap;
import java.util.Optional;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DealingPathVariable {
     
	
	@GetMapping("/")
	public String Alive()
	{
		return "Up and Running ";
	}
	
	//*********************************** Marking request parameter variable as optional 
	
	//Method 1:  @PathVariable (required=false)
	// a) add both the optional and without optional variable URL to the function's request mapping  
	// b) marks optional variable to be required=false 
	@GetMapping(value = {"/greet/user/{name}/{last}/{location}" , "/greet/user/{name}/{last}"})
	public @ResponseBody String hello( @PathVariable String name,@PathVariable String last, @PathVariable (required = false) String location)
	{
		if (location!=null)
		{
			return "Hi, "+ name +" "+last +", Welcome to " + location +"!!";
		}
		
		return "Hi, "+ name +" "+last +", Welcome to " + "India" +"!!";
		
	}
	
	// Method 2 : Passing PathVariable as Optional<> (java.util.Optional) variable 
	
	@GetMapping( value = {"greet/users/{name}/{last}","greet/user/{name}"})
	public String serveOptionalParamRequest( @PathVariable String name,@PathVariable Optional<String> last)
	{
		 if (last.isPresent())
		 {
			 return ("Hi "+ name+ ", Welcome to the function of " +last.get()+ " Family!!" );
		 }
		 return ("Hi "+name+ ", Welcome to the function !!");
	}

	
	
	//************************** Receving mutiple URL path variable and storing and accesing via hashmap ****************************
	@GetMapping("/list/users/{first}/{second}/{third}/{fourth}")
	public @ResponseBody String listUsers(@PathVariable HashMap<String, String>pathMap)
	{
		String ans="";
		for (String s : pathMap.keySet())
		{
		  ans+=pathMap.get(s)+"\n";
	
		}
		
		return ans;
	}
	
	
	@GetMapping("/temp")
	public String  temp()
	{
		return "temprory aPI"; 
	}
	
	
	
	//************** Setting Default value of path variable ****************************
	
	@GetMapping( value = {"greet/defaultParam/{name}/{last}","greet/defaultParam/{name}"})
	
	
	public String serveOptionalParamRequest2( @PathVariable String name,@PathVariable Optional<String> last)
	{
		
		 if (!last.isPresent())
		 {
			last = Optional.of("Default");  // defining defaul value for optional param 
		 }
		 
		 return ("Hi "+ name+ ", Welcome to the function of " +last.get()+ " Family!!" );
	}

	
	
	
}
