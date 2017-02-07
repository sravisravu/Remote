using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdUSPSPackage
    {
        [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void FwdUSPSPackageReplicationValidation()
        {
            string FwdUSPSPackagecolumn = CommonMethods.ColumnNames("FwdUSPSPackage");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + FwdUSPSPackagecolumn + " " + "from dbo.FwdUSPSPackage order by 1 desc");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + FwdUSPSPackagecolumn + " " + "from dbo.FwdUSPSPackage order by 1");

        }
        [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void DataValidationForFwdUSPSPackageByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.FwdUSPSPackage");
        }
       /* [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void DataValidationFwdUSPSPackageCountsOfIndividualColumns()
        {
            string columns = CommonMethods.ColumnNames("FwdUSPSPackage");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdUSPSPackage");
            }

        }

        [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void DataValidationForFwdUSPSPackageBySumOfIntColumns()
        {
            string columns = CommonMethods.IntColumnNames("FwdUSPSPackage");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdUSPSPackage");
            }

        }*/

    }
}



