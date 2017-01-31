using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class trackingeventdim
    {
        List<string> trackingeventdimcolumn = CommonMethods.PopulateColumn(9);

        string source = CommonMethods.SourceCount(9);
        string target = CommonMethods.TargetCount(9);
        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationFortrackingeventdimByCounts()
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

        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationtrackingeventdimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(9);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationFortrackingeventdimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(9);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationFortrackingeventdimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(9, "trackingeventdim", "select top 1000", "", "order by 1 desc", trackingeventdimcolumn);
                CommonMethods.DataValidationForEntireTable(9, "trackingeventdim", "select top 1000", "where trackingeventkey not in (select top 1000 trackingeventkey from dbo.trackingeventdim order by 1 desc)", "order by 1 desc", trackingeventdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationFortrackingeventdimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(9, "trackingeventdim", "select top 1000", "", "order by 1", trackingeventdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("trackingeventdim")]
        [TestMethod]
        public void DataValidationFortrackingeventdimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(9, "trackingeventdim", "select top 1000", "where trackingeventkey <= (select count(*) / 9 from dbo.trackingeventdim)", "order by 1 desc", trackingeventdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}










