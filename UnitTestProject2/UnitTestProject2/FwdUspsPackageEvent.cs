using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdUspsPackageEvent
    {
        [TestCategory("FwdUspsPackageEvent")]
        [TestMethod]
        public void FwdUspsPackageEventReplicationValidation()
        {
            string FwdUspsPackageEventcolumn = CommonMethods.ColumnNames("FwdUspsPackageEvent");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + FwdUspsPackageEventcolumn + " " + "from dbo.FwdUspsPackageEvent order by 1 desc");

        }
        [TestCategory("FwdUspsPackageEvent")]
        [TestMethod]
        public void DataValidationForFwdUspsPackageEventByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.FwdUspsPackageEvent");
        }
        [TestCategory("FwdUspsPackageEvent")]
        [TestMethod]
        public void DataValidationFwdUspsPackageEventCountsOfIndividualColumns()
        {
            string columns = CommonMethods.ColumnNames("FwdUspsPackageEvent");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdUspsPackageEvent");
            }

        }
        [TestCategory("FwdUspsPackageEvent")]
        [TestMethod]
        public void DataValidationForFwdUspsPackageEventBySumOfIntColumns()
        {
            string columns = CommonMethods.IntColumnNames("FwdUspsPackageEvent");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdUspsPackageEvent");
            }

        }

    }
}



