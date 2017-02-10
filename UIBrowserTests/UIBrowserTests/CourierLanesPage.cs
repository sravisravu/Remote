using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace UIBrowserTests
{
    public class CourierLanesPage
    {
        public static string connStringdw = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";

        public CourierLanesPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[1]")]
        IWebElement Rank { get; set; }      

        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[2]")]
        IWebElement Score { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[3]")]
        IWebElement ShippingFacility { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[4]")]
        IWebElement DropoffCourierRegion { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[5]")]
        IWebElement Shipped { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[6]")]
        IWebElement NoDDUEntry { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[7]")]
        IWebElement NoDDUEntryPercent { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[8]")]
        IWebElement NoPackageScan { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[9]")]
        IWebElement ShippedContainers { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[10]")]
        IWebElement NoDDUEntryContainers { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[11]")]
        IWebElement NoPackageScanContainers { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='DataTables_Table_0']/thead/tr/th[12]")]
        IWebElement LateDDUEntry { get; set; }
        [FindsBy(How = How.LinkText, Using = "Table - Courier Lanes")]
        IWebElement CourierLanes { get; set; }


        public void VerifyElements()
        {
            CourierLanes.Click();
            Thread.Sleep(6000);
            //if (Rank.Text!="Rank"||Score.Text!="Score"||ShippingFacility.Text!="Shipping Facility"||Shipped.Text!="Shipped"||NoDDUEntry.Text!="No DDU Entry"||NoDDUEntryPercent.Text!="No DDU Entry %"||NoPackageScan.Text!="No Package Scan"||ShippedContainers.Text!="Shipped Containers"||NoDDUEntryContainers.Text!="No DDU Entry Containers"||NoPackageScanContainers.Text!="No Package Scan Containers"||LateDDUEntry.Text!="Late DDU Entry")
            if (Rank.Text != "Rank" || Score.Text != "Score")

            {
                Console.WriteLine(Rank.Text);
                Console.WriteLine(Score.Text);
                Console.WriteLine(ShippingFacility.Text);
                Console.WriteLine(DropoffCourierRegion.Text);
                Console.WriteLine(Shipped.Text);
                Console.WriteLine(NoDDUEntry.Text);
                Console.WriteLine(NoDDUEntryPercent.Text);
                Console.WriteLine(NoPackageScan.Text);
                Console.WriteLine(ShippedContainers.Text);
                Console.WriteLine(NoDDUEntryContainers.Text);
                Console.WriteLine(NoPackageScanContainers.Text);
                Console.WriteLine(LateDDUEntry.Text);
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Actual and Expected Values Match");
            }
        }

    }

}
