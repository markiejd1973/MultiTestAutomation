@all @Pipeline1 @pipeline2 @QA000030
Feature: QA000030-CheckBoxTests
	Testing Checkboxes


Scenario Outline: QA000030-0000 START
	Given Page "ToolsQA" Is Displayed
	When I Click Button "Check Box" In Accordion "accordian"
	Then Tree "CheckBox" Is Displayed
	
Scenario Outline: QA000030-0210 Confirm Tree
	Then Tree "Checkbox" Top Node Is Equal To "Home"
	Then Tree "Checkbox" Has 1 Nodes Displayed
	
Scenario Outline: QA000030-0220 Expand Node
	When I Toggle Tree "Checkbox" Node "Home"
	When I Toggle Tree "Checkbox" Node "Documents"
	Then Tree "Checkbox" Displays Node "WorkSpace"

Scenario Outline: QA000030-0230 Expand Node
	When I Toggle Tree "Checkbox" Node "WorkSpace"
	Then Tree "Checkbox" Node "Documents" Is Expanded
	Then Tree "Checkbox" Node "WorkSpace" Is Expanded
	Then Tree "Checkbox" Displays Node "Office"
	Then Tree "Checkbox" Node "Office" Is Not Expanded
	Then Tree "Checkbox" Node "Office" Is Contracted

Scenario Outline: QA000030-0240 CheckBox Untick
	When I Click Tree "Checkbox" Node "Office" CheckBox
	Then Tree "Checkbox" Node "Office" CheckBox Is Ticked
	Then Tree "Checkbox" Node "Documents" CheckBox Is Half Ticked
	Then Tree "Checkbox" Node "Home" CheckBox Is Half Ticked
	Then Tree "Checkbox" Node "WorkSpace" CheckBox Is Not Ticked
	
Scenario Outline: QA000030-0250 Expand All
	When I Click Expand All Tree "CheckBox"
	Then Tree "Checkbox" Has 17 Nodes Displayed
	
Scenario Outline: QA000030-0260 Collapse All
	When I Click Collapse All Tree "CheckBox"
	Then Tree "Checkbox" Has 1 Nodes Displayed