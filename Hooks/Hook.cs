using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using static System.Net.Mime.MediaTypeNames;


namespace SeleniumCSharpNetCore.Hooks
{
    [Binding]
    public sealed class Hook
    {
        private DriverHelper _driverHelper;
        private readonly ScenarioContext _scenarioContext;
        public Hook(DriverHelper driverHelper, ScenarioContext scenarioContext)
        {
            _driverHelper = driverHelper;
            _scenarioContext = scenarioContext;
        }
            

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            option.AddArguments("--disable-gpu");
            //option.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Console.WriteLine("Setup");           
            
            _driverHelper.Driver = new ChromeDriver(option);
            
            
        }

        public void TakeScreenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driverHelper.Driver).GetScreenshot();
                string path = Path.GetFullPath(@"..\..\..\");                
                string Runname = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");
                string screenshotfilename = path + "\\Screenshots\\" + Runname + ".png";
                ss.SaveAsFile(screenshotfilename, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }     



        [AfterScenario]
        public void AfterScenario()
        {
            if(_scenarioContext.TestError != null)
            {
                TakeScreenshot();
            }
            
            _driverHelper.Driver.Quit();
        }
    }
}
