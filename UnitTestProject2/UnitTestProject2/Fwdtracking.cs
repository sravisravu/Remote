using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwdtracking
    {
        List<string> fwdtrackingcolumn = CommonMethods.PopulateColumn(14);

        string source = CommonMethods.SourceCount(14);
        string target = CommonMethods.TargetCount(14);
        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationForfwdtrackingByCounts()
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

        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationfwdtrackingCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(14);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationForfwdtrackingBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(14);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationForfwdtrackingByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(14, "fwdtracking", "select top 1000", "", "order by 1 desc", fwdtrackingcolumn);
                CommonMethods.DataValidationForEntireTable(14, "fwdtracking", "select top 1000", "where fwdtrackingkey not in (select top 1000 fwdtrackingkey from dbo.fwdtracking order by 1 desc)", "order by 1 desc", fwdtrackingcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationForfwdtrackingByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(14, "fwdtracking", "select top 1000", "", "order by 1", fwdtrackingcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdtracking")]
        [TestMethod]
        public void DataValidationForfwdtrackingByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(14, "fwdtracking", "select top 1000", "where fwdtrackingkey <= (select count(*) / 2 from dbo.fwdtracking)", "order by 1 desc", fwdtrackingcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







