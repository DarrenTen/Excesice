using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace PudongTraining.Utility
{
    public class SQLHelper
    {
        private static readonly string ConnString = "Data Source=.;Initial Catalog=ProductDB;Integrated Security=True";
        public static int ExcuteNoQuery(string cmd,params SqlParameter[] pars){
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                conn.Open();
                SqlCommand scmd = new SqlCommand(cmd, conn);
                scmd.Parameters.AddRange(pars);
                return scmd.ExecuteNonQuery();
            
            }

        }

        public static DataTable ExecuteDatatable(string cmd, params SqlParameter[] pars)
        {
            using (SqlConnection conn=new SqlConnection(ConnString))
            {
                conn.Open();

                SqlCommand scmd = new SqlCommand(cmd, conn);
                scmd.Parameters.AddRange(pars);

                SqlDataAdapter sda = new SqlDataAdapter(scmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                return ds == null ? null : ds.Tables[0];
                
            }

        }
    }
}
