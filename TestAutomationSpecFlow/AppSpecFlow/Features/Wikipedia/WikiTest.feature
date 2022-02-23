@all @Pipeline1 @pipeline2 @WIKI0010
Feature: WIKI0010-Wikipedia Test
	Simple Check Wiki

Scenario Outline: WIKI0010-0000 START
	Given Page "WikiHome" Is Displayed
	Then Span "About Wikipedia" Is Displayed
	
Scenario Outline: WIKI0020-0000 Donate
	When I Click On Span "About Wikipedia"
	Then Page "WikiAbout" Is Displayed

