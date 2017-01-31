using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwduspspackageevent
    {
        List<string> fwduspspackageeventcolumn = CommonMethods.PopulateColumn(6);

        string source = CommonMethods.SourceCount(6);
        string target = CommonMethods.TargetCount(6);
        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationForfwduspspackageeventByCounts()
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

        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationfwduspspackageeventCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(6);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationForfwduspspackageeventBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(6);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationForfwduspspackageeventByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(6, "fwduspspackageevent", "select top 1000", "", "order by 1 desc", fwduspspackageeventcolumn);
                CommonMethods.DataValidationForEntireTable(6, "fwduspspackageevent", "select top 1000", "where fwduspspackageeventkey not in (select top 1000 fwduspspackageeventkey from dbo.fwduspspackageevent order by 1 desc)", "order by 1 desc", fwduspspackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationForfwduspspackageeventByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(6, "fwduspspackageevent", "select top 1000", "", "order by 1", fwduspspackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwduspspackageevent")]
        [TestMethod]
        public void DataValidationForfwduspspackageeventByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(6, "fwduspspackageevent", "select top 1000", "where fwduspspackageeventkey <= (select count(*) / 2 from dbo.fwduspspackageevent)", "order by 1 desc", fwduspspackageeventcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







