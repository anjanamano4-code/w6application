using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace w6
{
    public class DBconnection
    {
        SqlConnection con;
        SqlCommand cmd;

        public DBconnection()
        {
            con = new SqlConnection(@"Server=LAPTOP-NM0FPR5F\SQLEXPRESS;Database=Twolayer;Integrated Security=true");
        }
           
            public int fn_nonquery(string sqlquery)//insert/delete/update
            {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            cmd = new SqlCommand(sqlquery, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }
            public string fn_scalar(string sqlquery)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(sqlquery, con);
                con.Open();
                string s = cmd.ExecuteScalar().ToString();
                con.Close();
                return s;
            }
            public SqlDataReader fn_reader(string sqlquery)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;

            }
            public DataSet fn_adapter(string sqlquery)
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        public DataTable fn_adapterdatatable(string sqlquery)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }   
    }
}