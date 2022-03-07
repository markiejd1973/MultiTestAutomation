@all @Pipeline1 @pipeline2 @WIKI0020
Feature: WIKI0020-Wikipedia Test02
	Simple Check Wiki

Scenario Outline: WIKI0020-0000 START
	Given Page "WikiHome" Is Displayed
	Then Span "Contact us" Is Displayed
	
Scenario Outline: WIKI0020-0010 About
	When I Click On Span "Contact us"
	Then Page "WikiContactUs" Is Displayed
	
Scenario Outline: WIKI0020-0020 Links
	Then Link "Readers" Is Displayed
	Then Link "Article subjects" Is Displayed
	Then Link "Licensing" Is Displayed
	Then Link "Donors" Is Displayed
	Then Link "Press and partnerships" Is Displayed