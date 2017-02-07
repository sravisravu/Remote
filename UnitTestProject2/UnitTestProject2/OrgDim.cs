using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class orgdim
    {
        [TestCategory("OrgDim")]
        [TestMethod]
        public void OrgDimReplicationValidation()
        {
            string orgdimcolumn = CommonMethods.ColumnNames("orgdim");
            CommonMethods.SourceTargetValidation(@"select"+" " + orgdimcolumn + " " + "from dbo.orgdim order by 1 desc");

        }
        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationForOrgDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.Orgdim");
        }
        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationOrgDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("Orgdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "Orgdim");
            }

        }

        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationForOrgDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("Orgdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "Orgdim");
            }

        }

    }
}



