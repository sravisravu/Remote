using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class UspsFacilitydim
    {
        CommonMethods ufd = new CommonMethods();
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void UspsFacilityDimReplicationValidation()
        {
            string UspsFacilitydimcolumn = ufd.ColumnNames("UspsFacilitydim");
            
            ufd.SourceTargetValidation(@"select top 1000" + " " + UspsFacilitydimcolumn + " " + "from dbo.UspsFacilitydim order by 1 desc");

        }
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationForUspsFacilityDimByCounts()
        {
            
            ufd.SourceTargetValidation(@"select count(*) from dbo.UspsFacilitydim");
        }
        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationUspsFacilityDimCountsOfIndividualColumns()
        {
            string dimcolumns = ufd.ColumnNames("UspsFacilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                ufd.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "UspsFacilitydim");
            }

        }

        [TestCategory("UspsFacilityDim")]
        [TestMethod]
        public void DataValidationForUspsFacilityDimBySumOfIntColumns()
        {
            string dimcolumns = ufd.IntColumnNames("UspsFacilitydim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                ufd.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "UspsFacilitydim");
            }

        }

    }
}



