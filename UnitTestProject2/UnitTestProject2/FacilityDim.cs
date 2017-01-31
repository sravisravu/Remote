using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class facilitydim
    {
        List<string> facilitydimcolumn = CommonMethods.PopulateColumn(2);

        string source = CommonMethods.SourceCount(2);
        string target = CommonMethods.TargetCount(2);
        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationForfacilitydimByCounts()
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

        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationfacilitydimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(2);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationForfacilitydimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(2);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationForfacilitydimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(2, "facilitydim", "select top 1000", "", "order by 1 desc", facilitydimcolumn);
                CommonMethods.DataValidationForEntireTable(2, "facilitydim", "select top 1000", "where facilitykey not in (select top 1000 facilitykey from dbo.facilitydim order by 1 desc)", "order by 1 desc", facilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationForfacilitydimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(2, "facilitydim", "select top 1000", "", "order by 1", facilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("facilitydim")]
        [TestMethod]
        public void DataValidationForfacilitydimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(2, "facilitydim", "select top 1000", "where facilitykey <= (select count(*) / 2 from dbo.facilitydim)", "order by 1 desc", facilitydimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}










