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
    public partial class urundetay : System.Web.UI.Page
    {
        string email = "";
        string loggedstatus = "";
        string Pname = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                SqlCommand cmd = new SqlCommand("EXEC GetProductDetail @pname", conn);
                cmd.Parameters.AddWithValue("@pname", Request.QueryString["P_Name"]);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Label2.Text = rd[0].ToString();
                    Label3.Text =rd[1].ToString();
                    Pname = rd[1].ToString();
                    Label4.Text = rd[2].ToString() + " ₺";
                    Label5.Text = rd[3].ToString();
                    Label6.Text = rd[4].ToString();

                }
          }
        

        protected void BTsepeteekle_Click(object sender, EventArgs e)
        {
            try
            {
                email = Session["email"].ToString();
                loggedstatus = Session["loggedstatus"].ToString();
            }
            catch (Exception)
            {

            }
            if (loggedstatus.Equals("ok"))
            {
                string Ucart="";
                string Pid="";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                SqlCommand cmd = new SqlCommand("EXEC Getusercartid'"+email+"';", conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while(rd.Read())
                {
                    Ucart = rd[0].ToString();
                }
                rd.Close();
                SqlCommand cmd1 = new SqlCommand("EXEC Getproductid'" + Pname + "';", conn);
                SqlDataReader rd1 = cmd1.ExecuteReader();
                while (rd1.Read())
                {
                    Pid = rd1[0].ToString();
                }
                rd1.Close();
                SqlCommand cmd2 = new SqlCommand("Insert into Tbl_Carts_Products Values("+Ucart.ToString()+","+Pid.ToString()+","+TBurunadedi.Text+")", conn);
                int x = 0;
                if (Ucart.Equals("")||Pid.Equals(""))
                {

                }
               
                else
                {
                    try
                    {
                        x = cmd2.ExecuteNonQuery();
                    }
                    catch(Exception)
                    {
                        string script = "alert(\"Bu ürün sepetinizde var, farklı adette eklemek için lütfen silip yeniden ekleyiniz...\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                     
                }
                
                conn.Close();
                if(x==1)
                {
                    string script = "alert(\"Ürün Sepete eklendi\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"Ürün Sepete eklenirken bir sorun oluştu..\");";
                    ScriptManager.RegisterStartupScript(this, GetType(),
                                          "ServerControlScript", script, true);
                }

            }
            else
            {
                Response.Redirect("~/default.aspx");
            }
        }
    }
}