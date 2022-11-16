using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage
    {
        private IWebDriver Driver;
        private const string LoginUrl = "https://www.bupa.co.uk/";
        private const string PageTitle = "Private healthcare | Bupa UK";

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }
        IWebElement healthInsuranceMainMenu => Driver.FindElement(By.XPath("(//a[@href='/health/health-insurance?intcmp=megamenu'])[1]"));   
        IWebElement getAQuoteSubMenu => Driver.FindElement(By.XPath("(//a[@class='btn-masthead-menu'])[1]"));   
        IWebElement acceptAllCookies => Driver.FindElement(By.XPath("//button[@id='onetrust-accept-btn-handler']"));   
        public void NavigateToURL()
        {
            Driver.Navigate().GoToUrl(LoginUrl);
            EnsurePageLoaded();
        }
        private void EnsurePageLoaded()
        {
            bool pageHasLoaded = (Driver.Url == LoginUrl) && (Driver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Fail to load page.LoginUrl = '{Driver.Url}' Page Source:\r\n{Driver.PageSource}");
            }
        }

        public void AcceptCookies()
        {
            acceptAllCookies.Click();
        }
        public void selectGetaQuoteSubMenu()
        {
            //Assert.AreEqual("Health Insurance", healthInsuranceMainMenu.Text);
            Actions action = new Actions(Driver);
            action.MoveToElement(healthInsuranceMainMenu).Perform();
            //Assert.AreEqual(true, getAQuoteSubMenu.Displayed);
            action.MoveToElement(getAQuoteSubMenu).Perform();
            action.Click().Build().Perform();
        }

       





    }
}
