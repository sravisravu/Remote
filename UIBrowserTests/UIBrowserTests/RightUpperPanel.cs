using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Configuration;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UIBrowserTests
{
    public class RightUpperPanel
    {
        public static string connStringdw = "Server = tcp:" + ConfigurationManager.AppSettings["dDBServer"] + ",1433;Initial Catalog = DWCloud; Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=Active Directory Integrated";
       
        public RightUpperPanel()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = ".bg-olive > div:nth-child(1) > h3:nth-child(1)")]
        IWebElement TotalShippedVolumeCount { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".bg-olive > div:nth-child(1) > p:nth-child(2)")]
        IWebElement TotalShippedVolume { get; set; }
        [FindsBy(How = How.XPath, Using = " //*[@id='avgScanComp']/div/div[1]/h3")]
        IWebElement averagenodduCount { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='avgScanComp']/div/div[1]/p")]
        IWebElement averagenoddu { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".bg-light-blue > div:nth-child(1) > h3:nth-child(1)")]
        IWebElement TotalLanesinFilterCount { get; set; }
        [FindsBy(How = How.CssSelector, Using = ".bg-light-blue > div:nth-child(1) > p:nth-child(2)")]
        IWebElement TotalLanesinFilter { get; set; }       
        
        public void VerifyTwoDaysElements()
        {
            string ShippedVolumeCount=TotalShippedVolumeCount.Text;
            string ReplacedShippedVolumeCount = ShippedVolumeCount.Replace(",", "");
            string vol = "DECLARE  @MinCheckpointDate date; Declare @maxcheckpointdate date; DECLARE @StartPartitionDateKey int; SET @StartPartitionDateKey = (SELECT MAX(PartitionDateKey) FROM ldw.FwdCheckpoint); SET @MinCheckpointDate = DATEADD(day, -2, CONVERT(datetime, CAST(@StartPartitionDateKey as varchar), 112)); SET @StartPartitionDateKey = CAST(CONVERT(varchar, @MinCheckpointDate, 112) as int);   set @MaxCheckpointDate = dateadd(dd, 0, @mincheckpointdate); CREATE TABLE #TempTable(shippedvolume int);insert into #TempTable(shippedvolume) SELECT COUNT(*) ShippedVolume   FROM    ldw.FwdCheckpoint c  inner join OrgDim od on od.OrgKey = c.MerchantOrgKey inner join FacilityDim sf on c.ShipFromFacilityKey = sf.FacilityKey  inner join FacilityDim uef on uef.FacilityKey = c.USPSEntryFacilityKey inner join USPSPricingCategoryDim upcd on upcd.USPSPricingCategoryKey = c.USPSPricingCategoryKey  WHERE   c.PlannedPostalDeliveryDate >= @MinCheckpointDate and c.PlannedPostalDeliveryDate <= @maxcheckpointdate    and c.OutboundShipDate is NOT NULL and upcd.USPSEntryType = 'DDU' GROUP BY c.MerchantOrgKey, od.OrgName, c.PlannedPostalDeliveryDate,c.ShipFromFacilityKey,sf.FacilityName,LEFT(sf.GeogPostalCode, 5), uef.DropoffCarrier, uef.DropoffCarrierRegion;select sum(shippedvolume)from #TempTable;";
            string lane = "DECLARE  @MinCheckpointDate date; Declare @maxcheckpointdate date; DECLARE @StartPartitionDateKey int; SET @StartPartitionDateKey = (SELECT MAX(PartitionDateKey) FROM ldw.FwdCheckpoint); SET @MinCheckpointDate = DATEADD(day, -2, CONVERT(datetime, CAST(@StartPartitionDateKey as varchar), 112)); SET @StartPartitionDateKey = CAST(CONVERT(varchar, @MinCheckpointDate, 112) as int);   set @MaxCheckpointDate = dateadd(dd, 0, @mincheckpointdate); CREATE TABLE #TempTable(lane varchar(8000));insert into #TempTable(lane) SELECT distinct uef.DropoffCarrierRegion lane   FROM    ldw.FwdCheckpoint c  inner join OrgDim od on od.OrgKey = c.MerchantOrgKey inner join FacilityDim sf on c.ShipFromFacilityKey = sf.FacilityKey  inner join FacilityDim uef on uef.FacilityKey = c.USPSEntryFacilityKey inner join USPSPricingCategoryDim upcd on upcd.USPSPricingCategoryKey = c.USPSPricingCategoryKey  WHERE   c.PlannedPostalDeliveryDate >= @MinCheckpointDate and c.PlannedPostalDeliveryDate <= @maxcheckpointdate    and c.OutboundShipDate is NOT NULL and upcd.USPSEntryType = 'DDU' GROUP BY c.MerchantOrgKey,        od.OrgName,        c.PlannedPostalDeliveryDate,        c.ShipFromFacilityKey,  sf.FacilityName, LEFT(sf.GeogPostalCode, 5), uef.DropoffCarrier, uef.DropoffCarrierRegion; select count(lane)from #TempTable;";
            string percentagenoddu = "DECLARE  @MinCheckpointDate date; Declare @maxcheckpointdate date; DECLARE @StartPartitionDateKey int; SET @StartPartitionDateKey = (SELECT MAX(PartitionDateKey) FROM ldw.FwdCheckpoint); SET @MinCheckpointDate = DATEADD(day, -2, CONVERT(datetime, CAST(@StartPartitionDateKey as varchar), 112)); SET @StartPartitionDateKey = CAST(CONVERT(varchar, @MinCheckpointDate, 112) as int);   set @MaxCheckpointDate = dateadd(dd, 0, @mincheckpointdate);CREATE TABLE #TempTable(shippedvolume decimal);insert into #TempTable(shippedvolume) SELECT ((100*(COUNT(*) - SUM(CASE WHEN c.PostalAcceptanceDate is NOT NULL THEN 1 ELSE 0 END)))/COUNT(*))	FROM	ldw.FwdCheckpoint c			inner join OrgDim od on od.OrgKey = c.MerchantOrgKey inner join FacilityDim sf on c.ShipFromFacilityKey = sf.FacilityKey inner join FacilityDim uef on uef.FacilityKey = c.USPSEntryFacilityKey inner join USPSPricingCategoryDim upcd on upcd.USPSPricingCategoryKey = c.USPSPricingCategoryKey WHERE	 c.PlannedPostalDeliveryDate >= @MinCheckpointDate and c.PlannedPostalDeliveryDate <= @maxcheckpointdate 	and c.OutboundShipDate is NOT NULL 	and upcd.USPSEntryType = 'DDU' GROUP BY uef.DropoffCarrierRegion; select sum(shippedvolume)/count(*) from #TempTable;";
            DataTable result = CommonMethods.SourceTargetValidation(vol);
            DataTable lanecount = CommonMethods.SourceTargetValidation(lane);
            DataTable percentagenodduentry = CommonMethods.SourceTargetValidation(percentagenoddu);
            string tocompare = "";
            string lanecounttocompare = "";
            string percentagenodduentrytocompare = "";
            string averagenodduCountTest = averagenodduCount.Text;
            string TotalLanesinFilterCountTest = TotalLanesinFilterCount.Text;
            foreach (DataRow row in result.Rows)
            {
                for (int x = 0; x < result.Columns.Count; x++)
                {
                   tocompare=row[x].ToString();
                                   
                    
                }
                
            }
            foreach (DataRow row in lanecount.Rows)
            {
                for (int x = 0; x < lanecount.Columns.Count; x++)
                {
                    lanecounttocompare = row[x].ToString();                  
                }

            }
            foreach (DataRow row in percentagenodduentry.Rows)
            {
                for (int x = 0; x < percentagenodduentry.Columns.Count; x++)
                {
                    percentagenodduentrytocompare = row[x].ToString();
                }

            }
            if ((ReplacedShippedVolumeCount != tocompare)|| (lanecounttocompare != TotalLanesinFilterCountTest)|| percentagenodduentrytocompare!= averagenodduCountTest)
            {
                
                Console.WriteLine("Actual Value:"+ReplacedShippedVolumeCount+" "+"Expected Value:"+tocompare);
                Console.WriteLine("Actual Value:"+lanecounttocompare +" "+ "Expected Value:" +TotalLanesinFilterCountTest);
                Console.WriteLine("Actual Value:"+percentagenodduentrytocompare +" "+ "Expected Value:" +averagenodduCountTest);
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Actual Volume and Expected Volume are the same");
            } 
        }

        public void VerifyElements()
        {
            string ShippedVolume = TotalShippedVolume.Text;            
            string averagenodduTest = averagenoddu.Text;
            string TotalLanesinFilterTest = TotalLanesinFilter.Text;
            if ((ShippedVolume !="Total Shipped Volume") ||(TotalLanesinFilterTest!="Total Lanes in Filter")||(averagenodduTest!= "Average No DDU Entry %"))
            {
                Assert.Fail();
            }
            else
            {
                Console.WriteLine("Actual Values and Expected Values are the same");
            }
        }
        
}

}
