using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwdpackage
    {
        List<string> fwdpackagecolumn = CommonMethods.PopulateColumn(4);

        string source = CommonMethods.SourceCount(4);
        string target = CommonMethods.TargetCount(4);
        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationForfwdpackageByCounts()
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

        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationfwdpackageCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(4);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationForfwdpackageBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(4);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationForfwdpackageByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(4, "fwdpackage", "select top 1000", "", "order by 1 desc", fwdpackagecolumn);
                CommonMethods.DataValidationForEntireTable(4, "fwdpackage", "select top 1000", "where fwdpackagekey not in (select top 1000 fwdpackagekey from dbo.fwdpackage order by 1 desc)", "order by 1 desc", fwdpackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationForfwdpackageByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(4, "fwdpackage", "select top 1000", "", "order by 1", fwdpackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackage")]
        [TestMethod]
        public void DataValidationForfwdpackageByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(4, "fwdpackage", "select top 1000", "where fwdpackagekey <= (select count(*) / 2 from dbo.fwdpackage)", "order by 1 desc", fwdpackagecolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







