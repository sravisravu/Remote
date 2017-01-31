using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class uspspricingcategorydim
    {
        List<string> uspspricingcategorydimcolumn = CommonMethods.PopulateColumn(12);

        string source = CommonMethods.SourceCount(12);
        string target = CommonMethods.TargetCount(12);
        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationForuspspricingcategorydimByCounts()
        {

            if (source == target)
            {
                Console.WriteLine("Source is:" + " " + source);
                Console.WriteLine("Target is:" + " " + target);
                Console.WriteLine("source and target counts are same");
            }
            else
            {
                Assert.Fail();
            }

        }

        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationuspspricingcategorydimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(12);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationForuspspricingcategorydimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(12);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationForuspspricingcategorydimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(12, "uspspricingcategorydim", "select top 1000", "", "order by 1 desc", uspspricingcategorydimcolumn);
                CommonMethods.DataValidationForEntireTable(12, "uspspricingcategorydim", "select top 1000", "where uspspricingcategorykey not in (select top 1000 uspspricingcategorykey from dbo.uspspricingcategorydim order by 1 desc)", "order by 1 desc", uspspricingcategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationForuspspricingcategorydimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(12, "uspspricingcategorydim", "select top 1000", "", "order by 1", uspspricingcategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspspricingcategorydim")]
        [TestMethod]
        public void DataValidationForuspspricingcategorydimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(12, "uspspricingcategorydim", "select top 1000", "where uspspricingcategorykey <= (select count(*) / 2 from dbo.uspspricingcategorydim)", "order by 1 desc", uspspricingcategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







