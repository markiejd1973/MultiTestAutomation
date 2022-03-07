@all @Pipeline1 @pipeline2 @QA000050
Feature: QA000050-ButtonTest
	Test Buttons


Scenario Outline: QA000050-0000 START
	Given Page "ToolsQA" Is Displayed
	When I Click Button "Buttons" In Accordion "accordian"
	Then Button "Double Click Me" Is Displayed
	Then Button "Right Click Me" Is Displayed
	Then Button "Click Me" Is Displayed

Scenario Outline: QA000050-0410 Click Me
	When I Click On Button "Click Me"
	Then Page Displays Message "You have done a dynamic click"

Scenario Outline: QA000050-0420 Double Click Me
	When I Double Click On Button "Double Click Me"
	Then Page Displays Message "You have done a double click"

Scenario Outline: QA000050-0430 Right Click Me
	When I Right Click On Button "Right Click Me"
	Then Page Displays Message "You have done a dynamic click"
