using BupaUIAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharpNetCore.Pages;
using System;
using TechTalk.SpecFlow;

namespace SeleniumCSharpNetCore.Steps
{

    [Binding]
    public class GetQuoteStep
    {

        private DriverHelper _driverHelper;
        HomePage homePage;
        HealthInsuranceQuotePage healthInsuranceQuotePage;

        public GetQuoteStep(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            healthInsuranceQuotePage = new HealthInsuranceQuotePage(_driverHelper.Driver);  
        }

        [Given(@"the user navigate to the Bupa website")]
        public void GivenTheUserOpensAWebBrowser()
        {
            homePage.NavigateToURL();
           
        }

        [Given(@"the user accepts the cookies")]
        public void GivenTheUserAcceptsTheCookies()
        {
            homePage.AcceptCookies();
        }

        [When(@"the user hover over the health insurance under the mega menu to select get a quote sub menu")]
        public void WhenTheUserHoverOverTheHealthInsuranceUnderTheMegaMenuToSelectGetAQuoteSubMenu()
        {
            homePage.selectGetaQuoteSubMenu();  
           
        }

        [Then(@"the user can view the private health insurance quote page")]
        public void ThenTheUserCanViewThePrivateHealthInsuranceQuotePage()
        {
           
        }

        [Then(@"the user verify the text for privacy information")]
        public void ThenTheUserVerifyTheTextForPrivacyInformation()
        {
            healthInsuranceQuotePage.VerifyPrivacyInformationText();    
        }

        [Then(@"the user verify the field to enter title, firstname, lastname")]
        public void ThenTheUserVerifyTheFieldToEnterTitleFirstnameLastname()
        {
            healthInsuranceQuotePage.VerifyTitleFirstnameLastname();    
        }

        [Then(@"the user verify the next button is present and clickable")]
        public void ThenTheUserVerifyTheNextButtonIsPresentAndClickable()
        {
            healthInsuranceQuotePage.VerifyNextButton();
        }


        [When(@"the user selects title option (.*)")]
        public void WhenTheUserSelectsTitleOptionMrs(string yourTitle)
        {
           healthInsuranceQuotePage.SelectYourTitleOption(yourTitle);
        }

        [When(@"the user enters first name (.*)")]
        public void WhenTheUserEntersFirstName(string firstName)
        {
           healthInsuranceQuotePage.EnterFirstName(firstName);
        }

        [When(@"the user enters last name (.*)")]
        public void WhenTheUserEntersLastNameMoss(string lastName)
        {
          healthInsuranceQuotePage.EnterLastName(lastName);
        }

        [When(@"the user selects the next button")]
        public void WhenTheUserSelectsTheNextButton()
        {
            healthInsuranceQuotePage.SelectNextButton();
        }

        [Then(@"the user checks the validation message (.*),(.*),(.*)")]
        public void ThenTheUserChecksTheValidationMessage(string titleValidation, string firstNameValidation, string LastNameValidation)
        {
            healthInsuranceQuotePage.CheckValidationstring(titleValidation, firstNameValidation, LastNameValidation);
        }






    }
}
