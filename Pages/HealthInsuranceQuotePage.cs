using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

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
        //IList<IWebElement> listOfCourses => Driver.FindElements(By.XPath("//input[@type='checkbox']"));
        IWebElement firstNameTextBox => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_FirstName"));
        IWebElement lastNameTextBox => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_LastName"));
        IWebElement privacyInformationLink => Driver.FindElement(By.XPath("//a[@data-tracking-id='Privacy Information']"));
        IWebElement titleValidationMessage => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_TitleCode-error"));
        IWebElement firstNameValidationMessage => Driver.FindElement(By.XPath("//div[@id='Prospect_ApplicantDetails_FirstName-error']"));
        IWebElement lastNameValidationMessage => Driver.FindElement(By.CssSelector("#Prospect_ApplicantDetails_LastName-error"));
        IWebElement nextButton => Driver.FindElement(By.CssSelector("button[type='submit']"));

       

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

        }
        public void VerifyNextButton()
        {
            Assert.AreEqual(true, nextButton.Enabled);  
        }

        public void SelectNextButton()
        {
            nextButton.Click(); 
        }

        public void CheckValidationstring (string titleValidation, string firstNameValidation, string LastNameValidation)
        {
            Select objSelect = new Select(developers_dropdown);

            string t = yourTitleOption.TagName;
            string f = firstNameTextBox.GetAttribute("value");  
            string l = lastNameTextBox.GetAttribute("value");

            if (string.IsNullOrEmpty(t))
            {
                Assert.AreEqual(titleValidation, titleValidationMessage.Text, "Expected and actual validation message doesn't match");

            }
            else if (string.IsNullOrEmpty(f))
            {
                Assert.AreEqual(firstNameValidation, firstNameValidationMessage.Text, "Expected and actual validation message doesn't match");
            }

            else if (!string.IsNullOrEmpty(l))
            {
                Assert.AreEqual(LastNameValidation, lastNameValidationMessage.Text, "Expected and actual validation message doesn't match");
            }


        }

    }
}
