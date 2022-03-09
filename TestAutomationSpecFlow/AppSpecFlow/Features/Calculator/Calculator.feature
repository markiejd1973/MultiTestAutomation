@all @Pipeline1 @pipeline2 @CALC0011
Feature: Calc0011-Calculator Test
	A Quick walk through Calculator
	
Scenario Outline: CALC0011-0010 Confirm Page
	Given Window "Calculator" Is Displayed
	Then Button "One" Is Displayed
	
Scenario Outline: CALC0011-0020 Hit Buttons
	When I Click On Button "Five"
	When I Click On Button "5"
	When I Click On Button "Multiply By"
	When I Click On Button "9"
	When I Click On Button "="
	Then TextBox "Text" Is Equal To "495"
	
Scenario Outline: CALC0011-9999 Close Window
	When I Close Window "Calculator"