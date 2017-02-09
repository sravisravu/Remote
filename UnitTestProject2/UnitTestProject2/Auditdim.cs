using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CloudReplicationTests
{
    [TestClass]
    public class auditdim
    {
        CommonMethods ad = new CommonMethods();
        [TestCategory("AuditDim")]
        [TestMethod]
        public void AuditDimReplicationValidation()
        {
            
            ad.SourceTargetValidation(@"select * from dbo.auditdim order by 1 desc");
        }
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimByCounts()
        {
            
            ad.SourceTargetValidation(@"select count(*) from dbo.auditdim");
        }
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationAuditDimCountsOfIndividualColumns()
        {
            string dimcolumns = ad.ColumnNames("AuditDim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                ad.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "auditdim");
            }           

        }    
        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForAuditDimBySumOfIntColumns()
        {
            string dimcolumns = ad.IntColumnNames("auditdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods auditdim = new CommonMethods();
                auditdim.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "auditdim");
            }


        }

        [TestCategory("AuditDim")]
        [TestMethod]
        public void DataValidationForauditsUsingChangeTracking()
        {          
            string source = "DECLARE @minVersion bigint = CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('dbo.auditDim'));SELECT x.[auditKey] FROM   CHANGETABLE(CHANGES[dbo].[auditdim], @minVersion) AS CT inner join[dbo].[auditdim] x on  CT.[auditKey] = x.[auditKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' and ct.SYS_CHANGE_VERSION not in (SELECT distinct top 1 ct.SYS_CHANGE_VERSION FROM   CHANGETABLE(CHANGES[dbo].[auditdim], @minVersion) AS CT inner join[dbo].[auditdim] x on  CT.[auditKey] = x.[auditKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' order by 1 desc);";
            
            ad.SourceTargetChangeTracking(source, "select auditkey from dbo.auditdim where auditkey=");

        }
    }
}



