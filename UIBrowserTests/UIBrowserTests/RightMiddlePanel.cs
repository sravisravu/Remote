using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UIBrowserTests
{
    public class RightMiddlePanel
    {
        public static string connStringdw = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";

        public RightMiddlePanel()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Table - Courier Lanes")]
        IWebElement CourierLanes { get; set; }
        [FindsBy(How = How.LinkText, Using = "Table - Courier Regions")]
        IWebElement CourierRegions { get; set; }
        [FindsBy(How = How.LinkText, Using = "Table - Facilities")]
        IWebElement Facilities { get; set; }
        [FindsBy(How = How.LinkText, Using = "Table - No ETA")]
        IWebElement TableNoETA { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".bg-light-blue > div:nth-child(1) > h3:nth-child(1)")]
        IWebElement TotalLanesinFilterCount { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".bg-light-blue > div:nth-child(1) > p:nth-child(2)")]
        IWebElement TotalLanesinFilter { get; set; }

       
        public void VerifyElements()
        {
            if(CourierLanes.Enabled && CourierRegions.Enabled && Facilities.Enabled && TableNoETA.Enabled)
            {
                Console.WriteLine("All links are enabled");
            }
            else
            {
                Assert.Fail();
            }
        }

    }

}
