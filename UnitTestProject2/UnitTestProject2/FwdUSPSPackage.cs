using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwduspspackage
    {
        List<string> fwduspspackagecolumn = CommonMethods.PopulateColumn(5);

        string source = CommonMethods.SourceCount(5);
        string target = CommonMethods.TargetCount(5);
        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationForfwduspspackageByCounts()
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

        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationfwduspspackageCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(5);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationForfwduspspackageBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(5);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationForfwduspspackageByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(5, "fwduspspackage", "select top 1000", "", "order by 1 desc", fwduspspackagecolumn);
                CommonMethods.DataValidationForEntireTable(5, "fwduspspackage", "select top 1000", "where fwduspspackagekey not in (select top 1000 fwduspspackagekey from dbo.fwduspspackage order by 1 desc)", "order by 1 desc", fwduspspackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationForfwduspspackageByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(5, "fwduspspackage", "select top 1000", "", "order by 1", fwduspspackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackage")]
        [TestMethod]
        public void DataValidationForfwduspspackageByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(5, "fwduspspackage", "select top 1000", "where fwduspspackagekey <= (select count(*) / 2 from dbo.fwduspspackage)", "order by 1 desc", fwduspspackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







