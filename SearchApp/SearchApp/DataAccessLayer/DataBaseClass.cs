using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
namespace SearchApp.DataAccessLayer
{
    public class DataBaseClass
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SearchConnectionString"].ConnectionString);

        public DataSet GetAccounts()
        {
            try
            {
                SqlCommand com = new SqlCommand("SP_GET_ACCOUNT_DATA", conn);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch(Exception e)
            {
                return null;
            }
    }
}