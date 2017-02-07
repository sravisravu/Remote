using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdPackage
    {
        CommonMethods fp = new CommonMethods();      

        [TestCategory("FwdPackage")]
        [TestMethod]
        public void FwdPackageReplicationValidation()
        {
            string FwdPackagecolumn = fp.ColumnNames("FwdPackage");
            fp.SourceTargetValidation(@"select top 100000" + " " + FwdPackagecolumn + " " + "from dbo.FwdPackage order by 1 desc");

        }
        [TestCategory("FwdPackage")]
        [TestMethod]
        public void DataValidationForFwdPackageByCounts()
        {
            fp.SourceTargetValidation(@"select count(*) from dbo.FwdPackage");
        }
       /* [TestCategory("FwdPackage")]
        [TestMethod]
        public void DataValidationFwdPackageCountsOfIndividualColumns()
        {
            string columns = CommonMethods.ColumnNames("FwdPackage");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdPackage");
            }

        }

        [TestCategory("FwdPackage")]
        [TestMethod]
        public void DataValidationForFwdPackageBySumOfIntColumns()
        {
            string columns = CommonMethods.IntColumnNames("FwdPackage");
            string[] words = columns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdPackage");
            }

        }*/

        [TestCategory("FwdPackage")]
        [TestMethod]
        public void DataValidationForFwdPackagesUsingChangeTracking()
        {
            
            string source = "DECLARE @CurrentTrackedVersion  bigint;SELECT @CurrentTrackedVersion = CHANGE_TRACKING_CURRENT_VERSION();DECLARE @LastTrackedVersion bigint = @CurrentTrackedVersion - 100;SELECT CT.FwdPackageKey FROM   CHANGETABLE(CHANGES[dbo].[FwdPackage], @LastTrackedVersion) AS CT left join[dbo].[FwdPackage] x on  CT.[FwdPackageKey] = x.[FwdPackageKey] WHERE CT.SYS_CHANGE_OPERATION = 'D' UNION SELECT CT.FwdPackageKey FROM   CHANGETABLE(CHANGES[dbo].[FwdPackage], @LastTrackedVersion) AS CT inner join[dbo].[FwdPackage] x on  CT.[FwdPackageKey] = x.[FwdPackageKey] WHERE CT.SYS_CHANGE_OPERATION != 'D' order by 1;";
            fp.SourceTargetChangeTracking(source, "select fwdpackagekey from dbo.fwdpackage where fwdpackagekey=");

        }

    }
}



