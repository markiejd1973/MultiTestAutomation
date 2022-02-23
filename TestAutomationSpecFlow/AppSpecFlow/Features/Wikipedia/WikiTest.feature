@all @Pipeline1 @pipeline2 @WIKI0010
Feature: WIKI0010-Wikipedia Test
	Simple Check Wiki

Scenario Outline: WIKI0010-0000 START
	Given Page "WikiHome" Is Displayed
	Then Span "About Wikipedia" Is Displayed
	
Scenario Outline: WIKI0010-0010 About
	When I Click On Span "About Wikipedia"
	Then Page "WikiAbout" Is Displayed
	
Scenario Outline: WIKI0010-0020 Search
	Given TextBox "Search" Is Displayed
	When I Enter "CGI" Then Press "Enter" In TextBox "Search"
	Then Page "Wiki Search Results" Is Displayed
	Then Header Is Equal To "Search results"
	
Scenario Outline: WIKI0010-0030 Go Into CGI Inc.
	When I Click On SubTitle "CGI Inc."
	Then Page "Wiki CGI" Is Displayed
	
Scenario Outline: WIKI0010-0040 Set CGI Page
	Given Page Size 1000 x 1000
	Then Image "CGI Logo" Is Displayed
