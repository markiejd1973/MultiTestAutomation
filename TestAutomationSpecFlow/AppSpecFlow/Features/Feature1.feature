@all @Pipeline1 @pipeline2 @AA000010
Feature: AA000010-MenuTest
	Test the Menu Structure, which does seem to tbe the biggest issue


Scenario Outline: AA000010-0000 START
	Given Page "ToolsQA" Is Displayed
	Then Accordion "accordian" Is Displayed
	Then "Elements" In Accordion "accordian" Is Expanded
	
Scenario Outline: AA000010-0010 Click
	When I Click "Elements" In Accordion "accordian"
	Then Wait "1" Seconds
	Then "Elements" In Accordion "accordian" Is Not Expanded
	Then Wait "2" Seconds
	
Scenario Outline: AA000010-0020 Click
	When I Click "Elements" In Accordion "accordian"
	Then Wait "2" Seconds
	Then "Elements" In Accordion "accordian" Is Expanded