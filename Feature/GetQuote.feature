Feature: Get Bupa new Health insurance quote 	

@NewInsuranceQuoteUTest

Scenario Outline: Verify the fields on the health insurance quote page and the validation messages.
Given the user navigates to the Bupa website
And the user accepts the cookies
When the user hovers over the health insurance under the mega menu to select get a quote sub menu
Then the user can view the private health insurance quote page
And the user verifies the text for privacy information 
And the user verifies the field to enter title, firstname, lastname
And the user verifies the next button is present and clickable
When the user selects title option <YourTitle>
And the user enters first name <FirstName>
And the user enters last name <LastName>
And the user selects the next button
Then the user checks the validation message <TitleValidationMessage>,<FirstNameValidationMessage>,<LastNameValidationssage>

Examples:
 | Description                | YourTitle | FirstName                                                                                                                                                | LastName                                                                                                                                                 | TitleValidationMessage | FirstNameValidationMessage                         | LastNameValidationssage                            |
 | Empty title                |           | Mark                                                                                                                                                     | Moss                                                                                                                                                     | Please select a title. |                                                    |                                                    |
 | Empty FirstName            | Mr        |                                                                                                                                                          | Moss                                                                                                                                                     |                        | Please enter your first name.                      |                                                    |
 | Empty LastName             | Mrs       | Mark                                                                                                                                                     |                                                                                                                                                          |                        |                                                    | Please enter your last name.                       |
 | Empty title & FirstName    |           |                                                                                                                                                          | Ross                                                                                                                                                     | Please select a title. | Please enter your first name.                      |                                                    |
 | Empty title & LastName     |           | Mark                                                                                                                                                     |                                                                                                                                                          | Please select a title. |                                                    | Please enter your last name.                       |
 | Empty FirstName & LastName | Mrs       |                                                                                                                                                          |                                                                                                                                                          |                        | Please enter your first name.                      | Please enter your last name.                       |
 | All fields empty           |           |                                                                                                                                                          |                                                                                                                                                          | Please select a title. | Please enter your first name.                      | Please enter your last name.                       |
 | Special char FirstName     | Miss      | @                                                                                                                                                        | Moss                                                                                                                                                     |                        | Please re-enter your first name using only letters |                                                    |
 | Special char LastName      | Ms        | Mark                                                                                                                                                     | @                                                                                                                                                        |                        |                                                    | Please re-enter your last name using only letters. |
 | Numbers FirstName          | Dr        | 123                                                                                                                                                      | Moss                                                                                                                                                     |                        | Please re-enter your first name using only letters |                                                    |
 | Numbers lastName           | Professor | Mark                                                                                                                                                     | 456                                                                                                                                                      |                        |                                                    | Please re-enter your last name using only letters. |
 | All OK                     | Reverend  | Mark                                                                                                                                                     | Moss                                                                                                                                                     |                        |                                                    |                                                    |
 
 # Negative Validation Test Cases

 # Fails with error - Cannot locate element with text: sss
 | Non existing title         | sss       | Mark                                                                                                                                                     | Moss                                                                                                                                                     | Please select a title. |                                                    |                                                    |
 # Long first name is accepted but a very small part of the name is displayed in next dialog
 | Long firstname             | Mr        | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccddddddddddddddddddddddddddddd | Moss                                                                                                                                                     |                        |                                                    |                                                    |
 | Long Last Name             | Mr        | Mark                                                                                                                                                     | aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbcccccccccccccccccccccddddddddddddddddddddddddddddd |                        |                                                    |                                                    |





