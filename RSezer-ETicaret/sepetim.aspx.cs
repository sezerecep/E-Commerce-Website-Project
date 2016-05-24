using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace RSezer_ETicaret
{
    public partial class sepetim : System.Web.UI.Page
    {
        string email="";
        string loggedstatus="";
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
                email = Session["email"].ToString();
                loggedstatus = Session["loggedstatus"].ToString();
            }
            catch(Exception)
            {
                BTsepetionayla.Enabled = false;
            }
            if(loggedstatus.Equals("ok"))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                SqlCommand cmd = new SqlCommand("EXEC GetUserCart'" +email+ "'", conn);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                DataList1.DataSource = rd;
                DataList1.DataBind();
                rd.Close();
                conn.Close();
                try
                {
                    string id = DataList1.Items[0].ID;
                    BTsepetionayla.Enabled = true;
                }
                catch(Exception)
                {
                    BTsepetionayla.Enabled = false;
                }

                //SİLMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
                try
                {
                    string Pid = "";
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                    SqlCommand silcmd = new SqlCommand("EXEC Getproductid @pname", con);
                    silcmd.Parameters.AddWithValue("@pname", Request.QueryString["P_Name"]);
                    con.Open();
                    SqlDataReader silrd = silcmd.ExecuteReader();
                    while (silrd.Read())
                    {
                        Pid = silrd[0].ToString();
                    }
                    silrd.Close();
                    if (Pid.Equals(""))
                    { }
                    else
                    {
                        SqlCommand silcmd2 = new SqlCommand("delete from Tbl_Carts_Products where P_ID='" + Pid + "';", con);
                        int stat = silcmd2.ExecuteNonQuery();
                        if(stat==1)
                        {
                            string script = "alert(\"Silme işlemi başarılı\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                            this.Page_Load(this, e);
                        }
                        else
                        {
                            string script = "alert(\"Silme işlemi başarısız\");";
                            ScriptManager.RegisterStartupScript(this, GetType(),
                                                  "ServerControlScript", script, true);
                        }
                    }
                    con.Close();                   
                }
                catch (Exception)
                {

                }
                //SİLMEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE
            }
            else
            {
                string script = "alert(\"Sepetinizi görmek için lütfen giriş yapın.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
                BTsepetionayla.Enabled = false;
            }

            

        }


        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BTsepetionayla_Click(object sender, EventArgs e)
        {

            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
            string email = Session["email"].ToString();
            SqlCommand com = new SqlCommand("EXEC Getusercartid '" + email + "';", con);
            con.Open();
            SqlDataReader rd = com.ExecuteReader();
            while (rd.Read())
            {
                Session["usercart"] = rd[0].ToString();
            }
            Response.Redirect("~/siparisdetay.aspx");
                
        }
    }
}