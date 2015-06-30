# Numeric Sequence Calculator

The GIT repository has 2 main directories:
- NumericSequenceCalculator which contains the **Numeric Sequence Calculator** and the **Unit Test** projects
- NumericSequenceCalculatorUITest which contains the **UI Test** project

All projects must be opened in Visual Studio 2013 or later.

### Numeric Sequence Calculator project
To start, open the solution file NumericSequenceCalculator.sln located in the NumericSequenceCalculator directory.
Then run the **Numeric Sequence Calculator** project to display the web page where numbers can be entered, and the 7 numeric sequence lists can be displayed, as required by the test.

### Unit Test project
The **Unit Test** project contains 6 case scenarios in order to verify if a number belongs to a specific list.

### UI Test project
To test the **UI Test** project, first make sure the **Numeric Sequence Calculator** project is running within Internet Explorer 11 (*the URL must be http://localhost:22657*).  
Then open the **UI Test** project and run the only test within it.
The test will demonstrate how the **Numeric Sequence Calculator** application generates the 7 numeric sequence lists soon after a valid number is submitted. At the end of the test, all lists are resetted.
