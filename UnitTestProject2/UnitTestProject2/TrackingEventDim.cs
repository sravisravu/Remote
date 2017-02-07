using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace CloudReplicationTests
{
    [TestClass]
    public class TrackingEventdim
    {
        CommonMethods TED = new CommonMethods();
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void TrackingEventDimReplicationValidation()
        {
            string TrackingEventdimcolumn = TED.ColumnNames("TrackingEventdim");
           
            TED.SourceTargetValidation(@"select top 100000" + " " + TrackingEventdimcolumn + " " + "from dbo.TrackingEventdim order by 1 desc");

        }
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationForTrackingEventDimByCounts()
        {
            
            TED.SourceTargetValidation(@"select count(*) from dbo.TrackingEventdim");
        }
        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationTrackingEventDimCountsOfIndividualColumns()
        {
            string dimcolumns = TED.ColumnNames("TrackingEventdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                TED.SourceTargetValidation("select count( distinct " + word + ")" + " " + "from" + " " + "TrackingEventdim");
            }

        }

        [TestCategory("TrackingEventDim")]
        [TestMethod]
        public void DataValidationForTrackingEventDimBySumOfIntColumns()
        {
            string dimcolumns = TED.IntColumnNames("TrackingEventdim");
            string[] words = dimcolumns.Split(',');
            foreach (string word in words)
            {
                
                TED.SourceTargetValidation("select sum(cast(" + word + " as bigint))" + " " + "from" + " " + "TrackingEventdim");
            }

        }

    }
}



