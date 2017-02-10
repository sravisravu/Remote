using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SeleniumSetMethods
{
    [TestClass]
    public class ExecuteAutomation
    {
        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://executeautomation.com/demosite/index.html?UserName=test&Password=test&Login=Login");
        }

        [TestMethod]
        public void ExecuteAutomation()
        {
            SeleniumSetMethods.SeleniumSetMethods.EnterText(driver, UserName, test, Name);
        }
    }
}