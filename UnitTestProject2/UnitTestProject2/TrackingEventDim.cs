using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class TrackingEventdim
    {
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void TrackingEventDimReplicationValidation()
        {
            string TrackingEventdimcolumn = CommonMethods.ColumnNames("TrackingEventdim");
            CommonMethods.SourceTargetValidation(@"select top 100000" + " " + TrackingEventdimcolumn + " " + "from dbo.TrackingEventdim order by 1 desc");

        }
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationForTrackingEventDimByCounts()
        {
            CommonMethods.SourceTargetValidation(@"select count(*) from dbo.TrackingEventdim");
        }
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationTrackingEventDimCountsOfIndividualColumns()
        {
            string dimcolumns = CommonMethods.ColumnNames("TrackingEventdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "TrackingEventdim");
            }

        }

        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationForTrackingEventDimBySumOfIntColumns()
        {
            string dimcolumns = CommonMethods.IntColumnNames("TrackingEventdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                CommonMethods.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "TrackingEventdim");
            }

        }

    }
}



