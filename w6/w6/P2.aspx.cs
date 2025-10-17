using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace w6
{
    public partial class P2 : System.Web.UI.Page
    {
        DBconnection obj = new DBconnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "select count(Id) from Table_1 where Username='"+TextBox1.Text+"'and Password='"+TextBox2.Text+"'";
            string str=obj.fn_scalar(s);
            if(str=="1")
                {
                string id = "select Id from Table_1 where Username='" + TextBox1.Text + "'and Password='" + TextBox2.Text + "'";
                string st = obj.fn_scalar(id);
                Session["uid"] =st;
                Response.Redirect("P3.aspx");
               
            }
            else
            {
                Label3.Text = "invalid";
            }
        }
    }
}