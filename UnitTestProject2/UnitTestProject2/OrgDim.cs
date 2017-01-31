using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class orgdim
    {
        List<string> orgdimcolumn = CommonMethods.PopulateColumn(7);

        string source = CommonMethods.SourceCount(7);
        string target = CommonMethods.TargetCount(7);
        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationFororgdimByCounts()
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

        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationorgdimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(7);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationFororgdimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(7);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationFororgdimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(7, "orgdim", "select top 1000", "", "order by 1 desc", orgdimcolumn);
                CommonMethods.DataValidationForEntireTable(7, "orgdim", "select top 1000", "where orgkey not in (select top 1000 orgkey from dbo.orgdim order by 1 desc)", "order by 1 desc", orgdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationFororgdimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(7, "orgdim", "select top 1000", "", "order by 1", orgdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("orgdim")]
        [TestMethod]
        public void DataValidationFororgdimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(7, "orgdim", "select top 1000", "where orgkey <= (select count(*) / 2 from dbo.orgdim)", "order by 1 desc", orgdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







