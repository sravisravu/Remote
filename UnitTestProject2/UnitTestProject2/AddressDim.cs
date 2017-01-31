using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class Addressdim
    {
        List<string> Addressdimcolumn = CommonMethods.PopulateColumn(0);

        string source = CommonMethods.SourceCount(0);
        string target = CommonMethods.TargetCount(0);
        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationForAddressdimByCounts()
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

        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationAddressdimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(0);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationForAddressdimBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(0);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationForAddressdimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(0, "Addressdim", "select top 1", "", "order by 1 desc", Addressdimcolumn);
                CommonMethods.DataValidationForEntireTable(0, "Addressdim", "select top 1", "where addresskey not in (select top 1 addresskey from dbo.Addressdim order by 1 desc)", "order by 1 desc", Addressdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationForAddressdimByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(0, "Addressdim", "select top 1", "", "order by 1", Addressdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("Addressdim")]
        [TestMethod]
        public void DataValidationForAddressdimByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(0, "Addressdim", "select top 1", "where addresskey <= (select count(*) / 2 from dbo.Addressdim)", "order by 1 desc", Addressdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}







