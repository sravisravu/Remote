using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UIBrowserTests
{
    public class MapPage
    {
        public static string connStringdw = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";

        public MapPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='mymap']/div[1]/div[2]/div[3]/img[3]")]
        IWebElement MapLocation { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='mymap']/div[1]/div[2]/div[4]/div/div[1]")]
        IWebElement MapPopUp { get; set; }
        [FindsBy(How = How.Id, Using = "qv2d")]
        IWebElement twodays { get; set; }



        public void VerifyElements()
        {
            twodays.Click();
            string test=CommonMethods.ClickAndSwitchWindow(MapLocation, PropertiesCollection.driver, 2000);
            Console.WriteLine(test);
            MapPopUp.Click();
            string text=MapPopUp.Text;
            Console.WriteLine(text);
        }

    }

}
