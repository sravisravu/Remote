using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
namespace CloudReplicationTests
{
    [TestClass]
    public class auditdim
    {
        List<string> Auditdimcolumn = CommonMethods.PopulateColumn(1);
        
        string source = CommonMethods.SourceCount(1);
        string target = CommonMethods.TargetCount(1);
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimByCounts()
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

        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationAuditDimCountsOfIndividualColumns()
        {
            if (source == target)
            {

                CommonMethods.CountDistinctColumn(1);
            }
            else
            {
                Assert.Fail();
            }


        }

        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimBySumOfIntColumns()
            {
           
            if (source == target)
            {
                CommonMethods.SumIntColumn(1);

            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimByTopRecordsInDesc()
        {
            if (source == target)
            {

                CommonMethods.DataValidationForEntireTable(1, "Auditdim", "select top 1000", "", "order by 1 desc", Auditdimcolumn);
                CommonMethods.DataValidationForEntireTable(1, "Auditdim", "select top 100", "where Auditkey not in (select top 100 Auditkey from dbo.Auditdim order by 1 desc)", "order by 1 desc", Auditdimcolumn); 
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimByTopRecordsInAsc()
        {
           
            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(1, "Auditdim", "select top 1000", "", "order by 1", Auditdimcolumn);             
            }
            else
            {
                Assert.Fail();
            }

        }
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimByCenterRecords()
        {

           
            if (source == target)
            {
                CommonMethods.DataValidationForEntireTable(1, "Auditdim", "select top 1000", "where auditkey <= (select count(*) / 2 from dbo.auditdim)", "order by 1 desc", Auditdimcolumn);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}



