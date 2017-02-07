using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsFacilitydim
    {
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void UspsFacilityDimReplicationValidation()
        {
            string UspsFacilitydimcolumn = CommonMethods.ColumnNames("UspsFacilitydim");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + UspsFacilitydimcolumn + " " + "from dbo.UspsFacilitydim order by 1 desc");

        }
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationForUspsFacilityDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.UspsFacilitydim");
        }
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationUspsFacilityDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("UspsFacilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsFacilitydim");
            }

        }

        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationForUspsFacilityDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("UspsFacilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsFacilitydim");
            }

        }

    }
}



