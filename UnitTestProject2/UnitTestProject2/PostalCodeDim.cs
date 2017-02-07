using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class PostalCodedim
    {
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void PostalCodeDimReplicationValidation()
        {
            string PostalCodedimcolumn = CommonMethods.ColumnNames("PostalCodedim");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + PostalCodedimcolumn + " " + "from dbo.PostalCodedim order by 1 desc");

        }
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.PostalCodedim");
        }
        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationPostalCodeDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("PostalCodedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "PostalCodedim");
            }

        }

        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("PostalCodedim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "PostalCodedim");
            }

        }

        [TestCategory("PostalCodeDim")]
        [TestMethod]
        public void DataValidationForPostalCodeDimUsingChangeTracking()
        {

            string source = "DECLARE @minVersion bigint = CHANGE_TRACKING_MIN_VALID_VERSION(OBJECT_ID('dbo.PostalCodeDim'));SELECT x.[postalcodeKey] FROM   CHANGETABLE(CHANGES[dbo].[postalcodedim], @minVersion) AS CT inner join[dbo].[postalcodedim] x on  CT.[postalcodeKey] = x.[postalcodeKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' and ct.SYS_CHANGE_VERSION not in (SELECT distinct top 1 ct.SYS_CHANGE_VERSION FROM   CHANGETABLE(CHANGES[dbo].[postalcodedim], @minVersion) AS CT inner join[dbo].[postalcodedim] x on  CT.[postalcodeKey] = x.[postalcodeKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' order by 1 desc);";
            CommonMethods.SourceTargetChangeTracking(source, "select postalcodekey from dbo.postalcodedim where postalcodekey=");

        }

    }
}



