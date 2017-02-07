using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsFacilityServiceZip
    {
        CommonMethods ufsz = new CommonMethods();
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void UspsFacilityServiceZipReplicationValidation()
        {
            string UspsFacilityServiceZipcolumn = ufsz.ColumnNames("UspsFacilityServiceZip");
            
            ufsz.SourceTargetValidation(@"select top 100000" + " " + UspsFacilityServiceZipcolumn + " " + "from dbo.UspsFacilityServiceZip order by 1 desc");

        }
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationForUspsFacilityServiceZipByCounts()
        {
            CommonMethods STV = new CommonMethods();
            ufsz.SourceTargetValidation(@"select count(*) from dbo.UspsFacilityServiceZip");
        }
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationUspsFacilityServiceZipCountsOfIndividualColumns()
        {
            string columns = ufsz.ColumnNames("UspsFacilityServiceZip");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods STV = new CommonMethods();
                ufsz.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsFacilityServiceZip");
            }

        }

        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationForUspsFacilityServiceZipBySumOfIntColumns()
        {
            string columns = ufsz.IntColumnNames("UspsFacilityServiceZip");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods STV = new CommonMethods();
                ufsz.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsFacilityServiceZip");
            }

        }

    }
}



