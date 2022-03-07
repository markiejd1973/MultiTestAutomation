@all @Pipeline1 @pipeline2 @QA000020
Feature: QA000020-TextBox
	Testing Text Box Entry


Scenario Outline: QA000020-0000 START
	Given Page "ToolsQA" Is Displayed
	When I Click Button "Text Box" In Accordion "accordian"
	Then TextBox "Full Name" Is Displayed
	
Scenario Outline: QA000020-0140 Confirm Page
	When I Enter "Mark Duffy" In TextBox "Full Name"
	Then Wait "2" Seconds
	Then TextBox "Full Name" Is Equal To "Mark Duffy"

Scenario Outline: QA000020-0150 Email
	When I Enter "mark.duffy@thisemail.com" Then Press "Enter" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "mark.duffy@thisemail.com"
	Then TextBox "Email" Is Not Equal To "Rubbish email"
	
Scenario Outline: QA000020-0160 Clear
	When I Clear Then Enter "joe.bloggs@email.com" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.com"
	
Scenario Outline: QA000020-0170 Append
	When I Enter "END" Then Press "Enter" In TextBox "email"
	Then TextBox "EMAIL" Is Equal To "joe.bloggs@email.comEND"
