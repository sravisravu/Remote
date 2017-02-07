using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class PostalCodedim
    {
        CommonMethods pcd = new CommonMethods();
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void PostalCodeDimReplicationValidation()
        {
            string PostalCodedimcolumn = pcd.ColumnNames("PostalCodedim");
            
            pcd.SourceTargetValidation(@"select top 1000" + " " + PostalCodedimcolumn + " " + "from dbo.PostalCodedim order by 1 desc");

        }
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimByCounts()
        {
            
            pcd.SourceTargetValidation(@"select count(*) from dbo.PostalCodedim");
        }
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationPostalCodeDimCountsOfIndividualColumns()
        {
            string dimcolumns = pcd.ColumnNames("PostalCodedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                pcd.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "PostalCodedim");
            }

        }

        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimBySumOfIntColumns()
        {
            string dimcolumns = pcd.IntColumnNames("PostalCodedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                pcd.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "PostalCodedim");
            }

        }

        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimUsingChangeTracking()
        {

            string source = "DECLARE @minVersion bigint = CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('dbo.PostalCodeDim'));SELECT x.[postalcodeKey] FROM   CHANGETABLE(CHANGES[dbo].[postalcodedim], @minVersion) AS CT inner join[dbo].[postalcodedim] x on  CT.[postalcodeKey] = x.[postalcodeKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' and ct.SYS_CHANGE_VERSION not in (SELECT distinct top 1 ct.SYS_CHANGE_VERSION FROM   CHANGETABLE(CHANGES[dbo].[postalcodedim], @minVersion) AS CT inner join[dbo].[postalcodedim] x on  CT.[postalcodeKey] = x.[postalcodeKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' order by 1 desc);";
            
            pcd.SourceTargetChangeTracking(source, "select postalcodekey from dbo.postalcodedim where postalcodekey=");

        }

    }
}



