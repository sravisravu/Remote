using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwdpackageevent
    {
        List<string> fwdpackageeventcolumn = CommonMethods.PopulateColumn(15);

        string source = CommonMethods.SourceCount(15);
        string target = CommonMethods.TargetCount(15);
        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationForfwdpackageeventByCounts()
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

        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationfwdpackageeventCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(15);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationForfwdpackageeventBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(15);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationForfwdpackageeventByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(15, "fwdpackageevent", "select top 1000", "", "order by 1 desc", fwdpackageeventcolumn);
                CommonMethods.DataValidationForEntireTable(15, "fwdpackageevent", "select top 1000", "where fwdpackageeventkey not in (select top 1000 fwdpackageeventkey from dbo.fwdpackageevent order by 1 desc)", "order by 1 desc", fwdpackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationForfwdpackageeventByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(15, "fwdpackageevent", "select top 1000", "", "order by 1", fwdpackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdpackageevent")]
        [TestMethod]
        public void DataValidationForfwdpackageeventByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(15, "fwdpackageevent", "select top 1000", "where fwdpackageeventkey <= (select count(*) / 2 from dbo.fwdpackageevent)", "order by 1 desc", fwdpackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







