Getting Started with Contoso University UI Automation Project

This project uses Microsoft .NET C# and Selenium.
Test cases are created in BDD format using Gherkin language to verify the User story.

Test Charter for Exploratory testing:
The purpose of this exploratory testing is to verify create/edit/delete instructor page by paying particular attention to:
•	Check all the input fields for special character and numerical value
•	Check all the tick boxes within the create/edit/delete instructor pages.
•	Check all input fields should allow to enter max. no of character as mentioned in the acceptance criteria.
•	Check the text within create/edit/delete pages should be readable to the user.
•	Run the query in the database to verify the data when user create/edit /delete the instructor.
•	Check for any duplicate’s instructor within the list 
Using: Contoso University website, Database
looking for:
Deviation from the Acceptance Criteria.


Non-functional Testing:
•	Insert thousands of records in database and check the page load time.
•	Do cross browser testing 
•	Check this feature on mobile browser for both Android and IOS.
