using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BupaUIAutomation.Pages
{
    public class HealthInsuranceQuotePage
    {
        private IWebDriver Driver;

        public HealthInsuranceQuotePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebElement yourTitleOption => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_TitleCode"));        
        IWebElement firstNameTextBox => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_FirstName"));
        IWebElement lastNameTextBox => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_LastName"));
        IWebElement privacyInformationLink => Driver.FindElement(By.XPath("//a[@data-tracking-id='Privacy Information']"));
        IWebElement titleValidationMessage => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_TitleCode-error"));
        IWebElement firstNameValidationMessage => Driver.FindElement(By.XPath("//div[@id='Prospect_ApplicantDetails_FirstName-error']"));
        IWebElement lastNameValidationMessage => Driver.FindElement(By.XPath("//div[@id='Prospect_ApplicantDetails_LastName-error']"));
        IWebElement nextButton => Driver.FindElement(By.XPath("//button[contains(.,'Next')]"));       

        public void VerifyTitleFirstnameLastname()
        {
            Assert.AreEqual(true, yourTitleOption.Enabled);
            Assert.AreEqual(true, firstNameTextBox.Enabled);
            Assert.AreEqual(true, lastNameTextBox.Enabled);
        }
        
        public void SelectYourTitleOption(string yourTitle)
        {
            SelectElement element = new SelectElement(yourTitleOption);
            element.SelectByText(yourTitle);
            element.SelectedOption.Click();            
        }

        public void EnterFirstName(string firstName)
        {
            firstNameTextBox.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            lastNameTextBox.SendKeys(lastName);
        }

        public void VerifyPrivacyInformationText()
        {
            Assert.AreEqual(true, privacyInformationLink.Enabled);
            Assert.AreEqual("Privacy Information",privacyInformationLink.Text);
        }
        public void VerifyNextButton()
        {
            Assert.AreEqual(true, nextButton.Enabled);
        }

        public void SelectNextButton()
        {
            nextButton.Click(); 
        }

        public void VerifyValidationMessage(string expextedTitleValidationMessage, string expectedFirstNameValidationMessage, string expectedLastNameValidationMessage)
        {

            if (!string.IsNullOrEmpty(expextedTitleValidationMessage)){ 

            Assert.AreEqual(expextedTitleValidationMessage, titleValidationMessage.Text, "Expected and actual validation message do not match for Title");
            }
            
            if (!string.IsNullOrEmpty(expectedFirstNameValidationMessage))
            {
                Assert.AreEqual(expectedFirstNameValidationMessage, firstNameValidationMessage.Text, "Expected and actual validation message do not match for First Name");
            }

             if (!string.IsNullOrEmpty(expectedLastNameValidationMessage))
            {
                Assert.AreEqual(expectedLastNameValidationMessage, lastNameValidationMessage.Text, "Expected and actual validation message do not match for Last Name");
            }

             if(string.IsNullOrEmpty(expextedTitleValidationMessage) && string.IsNullOrEmpty(expectedFirstNameValidationMessage) && string.IsNullOrEmpty(expectedLastNameValidationMessage))
            {                
                Assert.AreEqual("quote-cover-for", Driver.Title);
            }
        }
    }
}
