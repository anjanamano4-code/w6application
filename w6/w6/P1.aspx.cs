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
    public partial class P1 : System.Web.UI.Page
    {
        DBconnection obj = new DBconnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string p = "~/phs/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            string strinsert = "insert into Table_1 values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + p + "','" + TextBox5.Text + "','" + TextBox6.Text + "')";
            int i = obj.fn_nonquery(strinsert);
            if(i!=0)
            {
                Label7.Text = "Inserted";
            }
        }
    }
}