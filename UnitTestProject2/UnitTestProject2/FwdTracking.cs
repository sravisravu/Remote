using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdTracking
    {
        [TestCategory("FwdTracking")]
        [TestMethod]
        public void FwdTrackingReplicationValidation()
        {
            string FwdTrackingcolumn = CommonMethods.ColumnNames("FwdTracking");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + FwdTrackingcolumn + " " + "from dbo.FwdTracking order by 1 desc");

        }
        [TestCategory("FwdTracking")]
        [TestMethod]
        public void DataValidationForFwdTrackingByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.FwdTracking");
        }
        [TestCategory("FwdTracking")]
        [TestMethod]
        public void DataValidationFwdTrackingCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("FwdTracking");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdTracking");
            }

        }

        [TestCategory("FwdTracking")]
        [TestMethod]
        public void DataValidationForFwdTrackingBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("FwdTracking");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdTracking");
            }

        }

    }
}



