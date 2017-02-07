using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class orgdim
    {
        CommonMethods od = new CommonMethods();
        [TestCategory("OrgDim")]
        [TestMethod]
        public void OrgDimReplicationValidation()
        {
            string orgdimcolumn = od.ColumnNames("orgdim");            
            od.SourceTargetValidation(@"select top 1000"+" " + orgdimcolumn + " " + "from dbo.orgdim order by 1 desc");

        }
        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationForOrgDimByCounts()
        {
            
            od.SourceTargetValidation(@"select count(*) from dbo.Orgdim");
        }
        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationOrgDimCountsOfIndividualColumns()
        {
            string dimcolumns = od.ColumnNames("Orgdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
               od.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "Orgdim");
            }

        }

        [TestCategory("OrgDim")]
        [TestMethod]
        public void DataValidationForOrgDimBySumOfIntColumns()
        {
            string dimcolumns = od.IntColumnNames("Orgdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                od.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "Orgdim");
            }

        }

    }
}



