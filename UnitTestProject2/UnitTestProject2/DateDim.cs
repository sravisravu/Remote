using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class datedim
    {
        List<string> datedimcolumn = CommonMethods.PopulateColumn(16);

        string source = CommonMethods.SourceCount(16);
        string target = CommonMethods.TargetCount(16);
        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationFordatedimByCounts()
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

        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationdatedimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(16);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationFordatedimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(16);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationFordatedimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(16, "datedim", "select top 1000", "", "order by 1 desc", datedimcolumn);
                CommonMethods.DataValidationForEntireTable(16, "datedim", "select top 1000", "where datekey not in (select top 1000 datekey from dbo.datedim order by 1 desc)", "order by 1 desc", datedimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationFordatedimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(16, "datedim", "select top 1000", "", "order by 1", datedimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("datedim")]
        [TestMethod]
        public void DataValidationFordatedimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(16, "datedim", "select top 1000", "where datekey <= (select count(*) / 2 from dbo.datedim)", "order by 1 desc", datedimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







