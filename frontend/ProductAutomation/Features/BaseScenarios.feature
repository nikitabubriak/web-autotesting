@Chrome
Feature: Base Scenarios

Automated tests of a Google start page

Background: Google user is already on the correct page
    Given a Google user is on the base page

Scenario: 01. Validate the title of a website
    Then they see the page title contains "Google"

Scenario: 02. Validate the URL of a webpage
    Then the page URL contains "https://www.google.com/"

Scenario: 03. Validate the PageSource string on a web page
    Then they see "Google" in the PageSource

Scenario: 04. Validate existence of multiple texts in PageSource
    Then they see
      | expected_text       |
      | search              |
      | Google Inc.         |
      | The Closure Library |
      