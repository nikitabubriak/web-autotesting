@Api
Feature: Test Twitter Tweets
 
Scenario: 01. Get recent tweets from my Home Timeline
    Given I post a tweet of "This tweet is for API testing."
    When I retrieve the response of the "home_timeline.json" resource
    Then the latest tweet is my message of "This tweet is for API testing."
