using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class uspsfacilitydim
    {
        List<string> uspsfacilitydimcolumn = CommonMethods.PopulateColumn(10);

        string source = CommonMethods.SourceCount(10);
        string target = CommonMethods.TargetCount(10);
        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationForuspsfacilitydimByCounts()
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

        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationuspsfacilitydimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(10);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationForuspsfacilitydimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(10);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationForuspsfacilitydimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(10, "uspsfacilitydim", "select top 1000", "", "order by 1 desc", uspsfacilitydimcolumn);
                CommonMethods.DataValidationForEntireTable(10, "uspsfacilitydim", "select top 1000", "where uspsfacilitykey not in (select top 1000 uspsfacilitykey from dbo.uspsfacilitydim order by 1 desc)", "order by 1 desc", uspsfacilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationForuspsfacilitydimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(10, "uspsfacilitydim", "select top 1000", "", "order by 1", uspsfacilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilitydim")]
        [TestMethod]
        public void DataValidationForuspsfacilitydimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(10, "uspsfacilitydim", "select top 1000", "where uspsfacilitykey <= (select count(*) / 10 from dbo.uspsfacilitydim)", "order by 1 desc", uspsfacilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}










