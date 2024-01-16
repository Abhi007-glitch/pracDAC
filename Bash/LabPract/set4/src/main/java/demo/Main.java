package demo;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.chrome.ChromeDriver;

public class Main {
	public static void main(String[] args) throws InterruptedException {
		// Create a new instance of the ChromeDriver
        WebDriver driver = new ChromeDriver();

        // a. Navigate to https://mail.rediff.com/cgi-bin/login.cgi
        driver.get("https://mail.rediff.com/cgi-bin/login.cgi");

        // b. Enter Username, password, and click on Login
        WebElement usernameField = driver.findElement(By.id("login1"));
        WebElement passwordField = driver.findElement(By.id("password"));
        WebElement loginButton = driver.findElement(By.name("proceed"));

        usernameField.sendKeys("your_username"); // Replace with your Rediffmail username
        passwordField.sendKeys("your_password"); // Replace with your Rediffmail password
        loginButton.click();
        
        Thread.sleep(10000);

        // c. Verify the error message
        WebElement errorMessageElement = driver.findElement(By.id("div_login_error"));
        String errorMessage = errorMessageElement.getText();

        if (errorMessage.contains("Temporary Issue")) {
            System.out.println("Login failed. Error message: " + errorMessage);
        } else {
            System.out.println("Login successful.");
        }

        // Close the browser
        driver.quit();
    }
}
