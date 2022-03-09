@all @Pipeline1 @pipeline2 @NOTE0011
Feature: NOTE0011-Notepad Test
	A Quick walk through Notepad

	
Scenario Outline: NOTE0011-0010 Confirm Page
	Given Window "Notepad" Is Displayed
	When I Enter "HELLO THERE" In Document
	When I Enter " HELLO THERE Too" In Document
	
Scenario Outline: NOTE0011-9999 Close
	When I Close Window "Notepad"