using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CloudReplicationTests
{

    [TestClass]

    public class SchemaTests
    {
        CommonMethods st = new CommonMethods();
        int i;
        public string schema = "dbo";
        [TestMethod]
        public void DDLValidationByColumnName()
        {
            st.Schema("column_name");       

        }

        [TestMethod]
        public void DDLValidationByDataType()
        {
            st.Schema("data_type");
        }
        [TestMethod]
        public void DDLValidationByColumnSize()
        {
            st.Schema("CHARACTER_MAXIMUM_LENGTH");
        }     
    
        [TestMethod]
        public void DDLValidationByISNullable()
        {
            st.Schema("is_nullable");
        }
    }
}
