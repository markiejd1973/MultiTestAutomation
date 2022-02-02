@all @Pipeline1 @pipeline2 @AA000010
Feature: AA000010-MenuTest
	Test the Menu Structure, which does seem to tbe the biggest issue


Scenario Outline: AA000010-0000 START
	Given Page "ToolsQA" Is Displayed
	Then Accordion "accordian" Is Displayed
	Then Group "Elements" In Accordion "accordian" Is Expanded
	Then Group "Forms" In Accordion "accordian" Is Not Expanded
	
Scenario Outline: AA000010-0010 Click
	When I Click Group "Elements" In Accordion "accordian"
	Then Wait "1" Seconds
	#Then Group "Elements" In Accordion "accordian" Is Not Expanded
	Then Wait "1" Seconds
	
Scenario Outline: AA000010-0020 Click
	When I Click Group "Elements" In Accordion "accordian"
	Then Wait "2" Seconds
	Then Group "Elements" In Accordion "accordian" Is Expanded
	Then Button "Text Box" In Accordion "accordian" Displayed
	
Scenario Outline: AA000010-0030 Open Text Box
	When I Click Button "Text Box" In Accordion "accordian"
	
Scenario Outline: AA000010-0040 Confirm Page
	Then TextBox "Full Name" Is Displayed 