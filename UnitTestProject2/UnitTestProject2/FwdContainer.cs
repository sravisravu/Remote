using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class fwdcontainer
    {
        List<string> fwdcontainercolumn = CommonMethods.PopulateColumn(3);

        string source = CommonMethods.SourceCount(3);
        string target = CommonMethods.TargetCount(3);
        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationForfwdcontainerByCounts()
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

        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationfwdcontainerCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(3);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationForfwdcontainerBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(3);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationForfwdcontainerByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(3, "fwdcontainer", "select top 1000", "", "order by 1 desc", fwdcontainercolumn);
                CommonMethods.DataValidationForEntireTable(3, "fwdcontainer", "select top 1000", "where fwdcontainerkey not in (select top 1000 fwdcontainerkey from dbo.fwdcontainer order by 1 desc)", "order by 1 desc", fwdcontainercolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationForfwdcontainerByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(3, "fwdcontainer", "select top 1000", "", "order by 1", fwdcontainercolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("fwdcontainer")]
        [TestMethod]
        public void DataValidationForfwdcontainerByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(3, "fwdcontainer", "select top 1000", "where fwdcontainerkey <= (select count(*) / 2 from dbo.fwdcontainer)", "order by 1 desc", fwdcontainercolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







