using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsFacilityServiceZip
    {
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void UspsFacilityServiceZipReplicationValidation()
        {
            string UspsFacilityServiceZipcolumn = CommonMethods.ColumnNames("UspsFacilityServiceZip");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + UspsFacilityServiceZipcolumn + " " + "from dbo.UspsFacilityServiceZip order by 1 desc");

        }
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationForUspsFacilityServiceZipByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.UspsFacilityServiceZip");
        }
        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationUspsFacilityServiceZipCountsOfIndividualColumns()
        {
            string columns = CommonMethods.ColumnNames("UspsFacilityServiceZip");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsFacilityServiceZip");
            }

        }

        [TestCategory("UspsFacilityServiceZip")]
        [TestMethod]
        public void DataValidationForUspsFacilityServiceZipBySumOfIntColumns()
        {
            string columns = CommonMethods.IntColumnNames("UspsFacilityServiceZip");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsFacilityServiceZip");
            }

        }

    }
}



