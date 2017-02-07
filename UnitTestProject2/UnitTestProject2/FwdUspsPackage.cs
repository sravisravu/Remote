using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdUSPSPackage
    {
        CommonMethods fup = new CommonMethods();
        
    [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void FwdUSPSPackageReplicationValidation()
        {
            string FwdUSPSPackagecolumn = fup.ColumnNames("FwdUSPSPackage");
            fup.SourceTargetValidation(@"select top 100000" + " " + FwdUSPSPackagecolumn + " " + "from dbo.FwdUSPSPackage order by 1 desc");            
            fup.SourceTargetValidation(@"select top 100000" + " " + FwdUSPSPackagecolumn + " " + "from dbo.FwdUSPSPackage order by 1");

        }
        [TestCategory("FwdUSPSPackage")]
        [TestMethod]
        public void DataValidationForFwdUSPSPackageByCounts()
        {
            fup.SourceTargetValidation(@"select count(*) from dbo.FwdUSPSPackage");
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



