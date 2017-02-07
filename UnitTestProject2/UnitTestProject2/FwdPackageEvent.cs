using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class FwdPackageEvent
    {
        CommonMethods fpe = new CommonMethods();
        [TestCategory("FwdPackageEvent")]
        [TestMethod]
        public void FwdPackageEventReplicationValidation()
        {
            string FwdPackageEventcolumn = fpe.ColumnNames("FwdPackageEvent");           
            fpe.SourceTargetValidation(@"select top 1000" + " " + FwdPackageEventcolumn + " " + "from dbo.FwdPackageEvent order by 1 desc");

        }
        [TestCategory("FwdPackageEvent")]
        [TestMethod]
        public void DataValidationForFwdPackageEventByCounts()
        {
            fpe.SourceTargetValidation(@"select count(*) from dbo.FwdPackageEvent");
        }
       /* [TestCategory("FwdPackageEvent")]
        [TestMethod]
        public void DataValidationFwdPackageEventCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("FwdPackageEvent");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "FwdPackageEvent");
            }

        }

        [TestCategory("FwdPackageEvent")]
        [TestMethod]
        public void DataValidationForFwdPackageEventBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("FwdPackageEvent");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "FwdPackageEvent");
            }

        }*/

    }
}



