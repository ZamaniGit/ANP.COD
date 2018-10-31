using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace ANP.Data
{
    public class DBConnector
    {
        string DatabaseConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string DatabaseConnectionString172 = System.Configuration.ConfigurationManager.ConnectionStrings["dbcs172"].ConnectionString;

        public string ConnectionString { get { return DatabaseConnectionString; } }

        public void SqlExecute(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(FilteringQuery(sql), conn);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public object SqlReturn(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(FilteringQuery(sql), conn);
                object result = (object)cmd.ExecuteScalar();
                return result;
            }
        }

        public string FilteringQuery(string st)
        {
            return st;
            //string Result = "";
            //string tmp = "";
            //string[] Arr = st.Split();
            //foreach (string item in Arr)
            //{
            //    tmp = item.ToLower();
            //    if (item.Length == ";".Length) tmp = tmp.Replace(";", "  ");
            //    if (item.Length == "truncate".Length) tmp = tmp.Replace("truncate", " ");
            //    if (item.Length == "update".Length) tmp = tmp.Replace("update", " ");
            //    if (item.Length == "delete".Length) tmp = tmp.Replace("delete", " ");
            //    if (item.Length == "drop".Length) tmp = tmp.Replace("drop", " ");
            //    if (item.Length == "alter".Length) tmp = tmp.Replace("alter", " ");
            //    if (item.Length == "dbo".Length) tmp = tmp.Replace("dbo", " ");
            //    if (item.Length == "schema".Length) tmp = tmp.Replace("schema", " ");
            //    Result += " "+tmp;
            //}
            //return Result;
        }

        public DataTable SqlDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(FilteringQuery(sql), conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

        public DataSet SqlDataSet(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    SqlCommand cmd = new SqlCommand(FilteringQuery(sql), conn);
                    cmd.Connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    return ds;
                }
                catch
                {
                    return ds;
                }
            }
        }

        public DataTable SqlDataTable172(string sql)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString172))
            {
                SqlCommand cmd = new SqlCommand(FilteringQuery(sql), conn);
                cmd.Connection.Open();
                DataTable TempTable = new DataTable();
                TempTable.Load(cmd.ExecuteReader());
                return TempTable;
            }
        }

        public object SqlStoredProcedure(string StoredProcedure, SqlParameter[] pa)
        {
            using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
            {
                SqlCommand cmd = new SqlCommand(StoredProcedure, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter p in pa)
                {
                    cmd.Parameters.Add(p);
                }
                cmd.Connection.Open();
                object obj = new object();
                obj = cmd.ExecuteScalar();
                return obj;
            }
        }



    }
}
