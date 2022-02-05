@all @Pipeline1 @pipeline2 @AA000010
Feature: AA000010-MenuTest
	Test the Menu Structure, which does seem to tbe the biggest issue


Scenario Outline: AA000010-0000 START
	Given Page "ToolsQA" Is Displayed
	Then Accordion "accordian" Is Displayed
	Then Group "Elements" In Accordion "accordian" Is Expanded
	Then Group "Forms" In Accordion "accordian" Is Not Expanded
	
#Scenario Outline: AA000010-0010 Click
#	When I Click Group "Elements" In Accordion "accordian"
#	Then Wait "1" Seconds
#	Then Group "Elements" In Accordion "accordian" Is Not Expanded
#	Then Wait "1" Seconds
#
#Scenario Outline: AA000010-0030 Click
#	When I Click Group "Elements" In Accordion "accordian"
#	Then Wait "2" Seconds
#	
#Scenario Outline: AA000010-0040 Click
#	Then Group "Elements" In Accordion "accordian" Is Expanded
#	Then Button "Text Box" In Accordion "accordian" Displayed
#	
#Scenario Outline: AA000010-0100 Text Box
#	When I Click Button "Text Box" In Accordion "accordian"
#	Then TextBox "Full Name" Is Displayed
#	
#Scenario Outline: AA000010-0140 Confirm Page
#	When I Enter "Mark Duffy" In TextBox "Full Name"
#	Then Wait "2" Seconds
#	Then TextBox "Full Name" Is Equal To "Mark Duffy"
#
#Scenario Outline: AA000010-0150 Email
#	When I Enter "mark.duffy@thisemail.com" Then Press "Enter" In TextBox "email"
#	Then TextBox "EMAIL" Is Equal To "mark.duffy@thisemail.com"
#	Then TextBox "Email" Is Not Equal To "Rubbish email"
#	
#Scenario Outline: AA000010-0160 Clear
#	When I Clear Then Enter "joe.bloggs@email.com" In TextBox "email"
#	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.com"
#	
#Scenario Outline: AA000010-0170 Append
#	When I Enter "END" Then Press "Enter" In TextBox "email"
#	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.comEND"
	
#Scenario Outline: AA000010-0200 CheckBox
#	When I Click Button "Check Box" In Accordion "accordian"
#	Then Tree "CheckBox" Is Displayed
#	
#Scenario Outline: AA000010-0210 Confirm Tree
#	Then Tree "Checkbox" Top Node Is Equal To "Home"
#	Then Tree "Checkbox" Has 1 Nodes Displayed
#	
#Scenario Outline: AA000010-0220 Expand Node
#	When I Toggle Tree "Checkbox" Node "Home"
#	When I Toggle Tree "Checkbox" Node "Documents"
#	Then Tree "Checkbox" Displays Node "WorkSpace"
#
#Scenario Outline: AA000010-0230 Expand Node
#	When I Toggle Tree "Checkbox" Node "WorkSpace"
#	Then Tree "Checkbox" Node "Documents" Is Expanded
#	Then Tree "Checkbox" Node "WorkSpace" Is Expanded
#	Then Tree "Checkbox" Displays Node "Office"
#	Then Tree "Checkbox" Node "Office" Is Not Expanded
#	Then Tree "Checkbox" Node "Office" Is Contracted
#
#Scenario Outline: AA000010-0240 CheckBox Untick
#	When I Click Tree "Checkbox" Node "Office" CheckBox
#	Then Tree "Checkbox" Node "Office" CheckBox Is Ticked
#	Then Tree "Checkbox" Node "Documents" CheckBox Is Half Ticked
#	Then Tree "Checkbox" Node "Home" CheckBox Is Half Ticked
#	Then Tree "Checkbox" Node "WorkSpace" CheckBox Is Not Ticked
#	
#Scenario Outline: AA000010-0250 Expand All
#	When I Click Expand All Tree "CheckBox"
#	Then Tree "Checkbox" Has 17 Nodes Displayed
#	
#Scenario Outline: AA000010-0260 Collapse All
#	When I Click Collapse All Tree "CheckBox"
#	Then Tree "Checkbox" Has 1 Nodes Displayed
	
Scenario Outline: AA000010-0300 Radio Button
	When I Click Button "Radio Button" In Accordion "accordian"
	Then RadioButton "Yes" Is Displayed
	Then RadioButton "Impressive" Is Displayed
	Then RadioButton "No" Is Displayed
	
Scenario Outline: AA000010-0310 Radio Button Read Only
	Then RadioButton "No" Is Read Only
	Then RadioButton "Yes" Is Enabled
	Then RadioButton "Yes" Is Not Selected

Scenario Outline: AA000010-030 Select The Other
	When I Click On RadioButton "Impressive"
	Then RadioButton "Impressive" Is Selected
	Then RadioButton "Yes" Is Not Selected
	