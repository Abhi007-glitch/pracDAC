package core;

import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

import io.github.bonigarcia.wdm.WebDriverManager;

public class yelpSearch {
	WebDriver wd;

	@Test
	public void setUp() {
		WebDriverManager.chromedriver().setup();
		wd = new ChromeDriver();
		wd.navigate().to("https://www.yelp.com/");;
//		wd.get("https://www.yelp.com/");
		wd.manage().window().maximize();
		WebElement searchBox = wd.findElement(By.id("search_description"));
		searchBox.sendKeys("Restaurant");
		WebElement searchIcon = wd.findElement(By.cssSelector("#header_find_form > div.css-1qn0b6x > button"));
		searchIcon.click();
		
		String actTitle = wd.getTitle();
		if(actTitle.equals("TOP 10 BEST Restaurant in San Francisco, CA - January 2023 - Yelp")) {
			System.out.println("Title matches. Test case passed");
		}else {
			System.out.println("Title doesn't match. Test case failed!!");
		}
	}
}

/*
 * 
 * WebDriverManager.chromedriver().setup(); driver = new ChromeDriver();
 * 
 * driver.get("https://mail.rediff.com/cgi-bin/login.cgi");
 * driver.manage().window().maximize();
 * 
 * driver.findElement(By.id("login1")).sendKeys("email@email.com");
 * driver.findElement(By.id("password")).sendKeys("passwor
 * 
 */