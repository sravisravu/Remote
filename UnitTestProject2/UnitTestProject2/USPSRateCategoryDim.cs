using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class uspsratecategorydim
    {
        List<string> uspsratecategorydimcolumn = CommonMethods.PopulateColumn(13);

        string source = CommonMethods.SourceCount(13);
        string target = CommonMethods.TargetCount(13);
        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationForuspsratecategorydimByCounts()
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

        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationuspsratecategorydimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(13);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationForuspsratecategorydimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(13);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationForuspsratecategorydimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(13, "uspsratecategorydim", "select top 1000", "", "order by 1 desc", uspsratecategorydimcolumn);
                CommonMethods.DataValidationForEntireTable(13, "uspsratecategorydim", "select top 1000", "where uspsratecategorykey not in (select top 1000 uspsratecategorykey from dbo.uspsratecategorydim order by 1 desc)", "order by 1 desc", uspsratecategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationForuspsratecategorydimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(13, "uspsratecategorydim", "select top 1000", "", "order by 1", uspsratecategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsratecategorydim")]
        [TestMethod]
        public void DataValidationForuspsratecategorydimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(13, "uspsratecategorydim", "select top 1000", "where uspsratecategorykey <= (select count(*) / 2 from dbo.uspsratecategorydim)", "order by 1 desc", uspsratecategorydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







