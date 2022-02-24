@all @Pipeline1 @pipeline2 @CGI00010
Feature: CGI00010-CGI Welcome
	BDD CGI Welcome


Scenario Outline: CGI00010-0000 START
	Given Page "CGIWelcome" Is Displayed
	Given Page Size 1800 x 1000
	
Scenario Outline: CGI00010-0010 Confirm Page
	Then Button "Menu" Is Displayed
	Then Button "SHOW ME MORE" Is Displayed
	
Scenario Outline: CGI00010-0020 Mouse Over Button
	When I Mouse Over Button "menu"
	Then SubMenu Item "Login" Is Displayed
	
Scenario Outline: CGI00010-0030 Login Presented
	When I Click On SubMenu "Login"
	Then TextBox "Username" Is Displayed
	Then TextBox "Password" Is Displayed
	Then Button "LOGIN" Is Displayed
	
Scenario Outline: CGI00010-0040 Login Entered
	When I Enter "cgiadmin" In TextBox "Username"
	When I Enter "password=1" In TextBox "Password"
	When I Click On Button "LOGIN"
	Then Wait "1" Seconds
	
Scenario Outline: CGI00010-0050 Confirm login
	When I Mouse Over Button "menu"
	Then SubMenu Item "Login" Is Not Displayed
	Then SubMenu Item "Cars" Is Displayed
	Then SubMenu Item "Services" Is Displayed
	Then SubMenu Item "About" Is Displayed
	Then SubMenu Item "Team" Is Displayed
	Then SubMenu Item "Contact" Is Displayed
	Then SubMenu Item "Logout" Is Displayed
	
Scenario Outline: CGI00010-0060 Go To Cars
	When I Click On SubMenu "Cars"
	Then Table "cars" Is Displayed
	