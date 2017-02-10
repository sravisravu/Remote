using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace UIBrowserTests
{
    class LeftPanel
    {
       
        public LeftPanel()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.Id, Using = "qvwk")]
        IWebElement oneweek { get; set; }

        [FindsBy(How = How.Id, Using = "qv2d")]
        IWebElement twodays { get; set; }

        [FindsBy(How = How.Id, Using = "qvmo")]
        IWebElement onemonth { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]/div/div/div/div/div")]
        IWebElement fromdropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[3]/div/div/div/div/div")]
        IWebElement todropdown { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[2]")]
        IWebElement fromdropdowntext { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[@type='text'])[4]")]
        IWebElement todropdowntext { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[8]/div/div/div")]
        IWebElement courierx { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[10]/div/div/div")]
        IWebElement courierregionx { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[12]/div/div/div")]
        IWebElement merchant { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[14]/div/div/div")]
        IWebElement ngsoutboundfacility { get; set; }
        [FindsBy(How = How.Id, Using = "switcher")]
        IWebElement circlesize { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".js-irs-2 > span:nth-child(3)")]
        IWebElement undeliveredvolume { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".js-irs-1 > span:nth-child(3)")]
        IWebElement dduentryvolume { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".js-irs-0 > span:nth-child(1) > span:nth-child(1) > span:nth-child(2)")]
        IWebElement nodduentrycompliance { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".js-irs-3 > span:nth-child(3)")]
        IWebElement colorpctthreshold{ get; set; }

        

        public void CheckElements()
        {
            bool oneweekenabled=oneweek.Enabled;
            bool twodaysenabled = twodays.Enabled;            
            bool onemonthenabled = onemonth.Enabled;            
            bool fromdropdowntest=fromdropdown.Enabled;                      
            bool fromdropdowntexttest =fromdropdowntext.Enabled;           
            bool todropdowntest =todropdown.Enabled;            
            bool todropdowntexttest= todropdowntext.Enabled;            
            bool courierxtest = courierx.Enabled;            
            bool courierregionxtest = courierregionx.Enabled;            
            bool merchanttest = merchant.Enabled;           
            bool ngsoutboundfacilitytest = ngsoutboundfacility.Enabled;            
            bool circlesizetest = circlesize.Enabled;           
            bool undeliveredvolumetest = undeliveredvolume.Enabled;            
            bool dduentryvolumetest = dduentryvolume.Enabled;            
            bool nodduentrycompliancetest = nodduentrycompliance.Enabled;           
            bool colorpctthresholdtest = colorpctthreshold.Enabled;

            if (oneweekenabled.Equals(true) && twodaysenabled.Equals(true) && onemonthenabled.Equals(true) && fromdropdowntest.Equals(true) && fromdropdowntexttest.Equals(true) && todropdowntest.Equals(true) && todropdowntexttest.Equals(true) && courierxtest.Equals(true) && courierregionxtest.Equals(true) && merchanttest.Equals(true) && ngsoutboundfacilitytest.Equals(true) && circlesizetest.Equals(true) && undeliveredvolumetest.Equals(true) && dduentryvolumetest.Equals(true) && nodduentrycompliancetest.Equals(true) && colorpctthresholdtest.Equals(true))
            {
                Console.WriteLine("All Elements are Enabled");
            }
            else
            {
                Assert.Fail();
            }
                

        }
        public void ClickOneWeekElement()
        {
             oneweek.Click();
        }
        public void ClickTwoDayElement()
        {
            twodays.Click();
        }


    }

}
