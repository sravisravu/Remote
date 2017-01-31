using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class uspsfacilityservicezip
    {
        List<string> uspsfacilityservicezipcolumn = CommonMethods.PopulateColumn(11);

        string source = CommonMethods.SourceCount(11);
        string target = CommonMethods.TargetCount(11);
        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationForuspsfacilityservicezipByCounts()
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

        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationuspsfacilityservicezipCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(11);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationForuspsfacilityservicezipBySumOfIntColumns()
        {

            if (source == target)
            {
                CommonMethods.SumIntColumn(11);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationForuspsfacilityservicezipByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(11, "uspsfacilityservicezip", "select top 1000", "", "order by 1 desc", uspsfacilityservicezipcolumn);
                CommonMethods.DataValidationForEntireTable(11, "uspsfacilityservicezip", "select top 1000", "where facilitykey not in (select top 1000 facilitykey from dbo.uspsfacilityservicezip order by 1 desc)", "order by 1 desc", uspsfacilityservicezipcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationForuspsfacilityservicezipByTopRecordsInAsc()
        {

            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(11, "uspsfacilityservicezip", "select top 1000", "", "order by 1", uspsfacilityservicezipcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("uspsfacilityservicezip")]
        [TestMethod]
        public void DataValidationForuspsfacilityservicezipByCenterRecords()
        {


            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(11, "uspsfacilityservicezip", "select top 1000", "where facilitykey <= (select count(*) / 2 from dbo.uspsfacilityservicezip)", "order by 1 desc", uspsfacilityservicezipcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}










