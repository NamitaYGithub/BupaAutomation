Feature: Health insurance quote 
	

@mytag

Scenario Outline: Verify the fileds on the health insurance quote page and the validation messages.
Given the user navigate to the Bupa website
And the user accepts the cookies
When the user hover over the health insurance under the mega menu to select get a quote sub menu
Then the user can view the private health insurance quote page
And the user verify the text for privacy information 
And the user verify the field to enter title, firstname, lastname
And the user verify the next button is present and clickable
When the user selects title option <YourTitle>
And the user enters first name <FirstName>
And the user enters last name <LastName>
And the user selects the next button
Then the user checks the validation message <TitleValidationMessage>,<FirstNameValidationMessage>,<LastNameValidationssage>


Examples:
 |Description        | YourTitle | FirstName | LastName | TitleValidationMessage  | FirstNameValidationMessage    | LastNameValidationssage |
 | Empty title       |           |           | Moss     | Please select a title.  | Please enter your first name. |                    |
 | Empty FirstName   | Mr        |           | Moss     |                         | Please enter your first name. |                    |

