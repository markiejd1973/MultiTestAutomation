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
	Then Group "Elements" In Accordion "accordian" Is Not Expanded
	Then Wait "1" Seconds
	
Scenario Outline: AA000010-0020 Click
	When I Click Group "Elements" In Accordion "accordian"
	Then Wait "2" Seconds
	Then Group "Elements" In Accordion "accordian" Is Expanded
	Then Button "Text Box" In Accordion "accordian" Displayed
	
Scenario Outline: AA000010-0030 Open Text Box
	When I Click Button "Text Box" In Accordion "accordian"
	Then TextBox "Full Name" Is Displayed
	
Scenario Outline: AA000010-0040 Confirm Page
	When I Enter "Mark Duffy" In TextBox "Full Name"
	Then Wait "2" Seconds
	Then TextBox "Full Name" Is Equal To "Mark Duffy"

Scenario Outline: AA000010-0050 Email
	When I Enter "mark.duffy@thisemail.com" Then Press "Enter" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "mark.duffy@thisemail.com"
	Then TextBox "Email" Is Not Equal To "Rubbish email"
	
Scenario Outline: AA000010-0060 Clear
	When I Clear Then Enter "joe.bloggs@email.com" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.com"
	
Scenario Outline: AA000010-0070 Append
	When I Enter "END" Then Press "Enter" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.comEND"

