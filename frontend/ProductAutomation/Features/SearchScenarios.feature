@Chrome
Feature: Search Scenarios

As a user of Google, I want to be able to search for stuff

Scenario: 01. Search and select a result
   Given an internet user is on the search page
   When they search for "Twitter homepage"
   And they view the first result
   Then they see the Twitter homepage