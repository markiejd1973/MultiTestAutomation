@all @Pipeline1 @pipeline2 @QA000040
Feature: QA000040-RadioButtonTest
	Test RadioButtons


Scenario Outline: QA000040-0000 START
	Given Page "ToolsQA" Is Displayed
	When I Click Button "Radio Button" In Accordion "accordian"
	Then RadioButton "Yes" Is Displayed
	Then RadioButton "Impressive" Is Displayed
	Then RadioButton "No" Is Displayed
	
Scenario Outline: QA000040-0310 Radio Button Read Only
	Then RadioButton "No" Is Read Only
	Then RadioButton "Yes" Is Enabled
	Then RadioButton "Yes" Is Not Selected

Scenario Outline: QA000040-0320 Select The Other
	When I Click On RadioButton "Impressive"
	Then RadioButton "Impressive" Is Selected
	Then RadioButton "Yes" Is Not Selected	
