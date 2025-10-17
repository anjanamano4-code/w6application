using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace w6
{
    public partial class P3 : System.Web.UI.Page
    {
        DBconnection obj = new DBconnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                


                string str = "select Name,Address,Photo from Table_1 where Id=" + Session["uid"] + "";
                SqlDataReader d = obj.fn_reader(str);
                while (d.Read())
                {


                    TextBox1.Text = d["Name"].ToString();

                    TextBox3.Text = d["Address"].ToString();
                    Image1.ImageUrl = d["Photo"].ToString();
                }
                    DataSet ds = obj.fn_adapter(str);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                DataTable dt = obj.fn_adapterdatatable(str);
                DataList1.DataSource = dt;
                DataList1.DataBind();



                    
                

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s1 = "update Table_1 set Address='" + TextBox3.Text + "' where Id=" + Session["uid"] + "";
           int i= obj.fn_nonquery(s1);
            if(i!=0)
            {
                Label8.Text = "edited";
            }
        }
    }
}