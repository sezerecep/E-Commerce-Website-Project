using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
namespace RSezer_ETicaret
{
    public partial class siparisdetay : System.Web.UI.Page
    {
        string cartid="";
        string email = "";
        string loggedstatus = "";
        string userid = "";
        string orderid = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BTonay_Click(object sender, EventArgs e)
        {
            try
            {
                email = Session["email"].ToString();
                loggedstatus = Session["loggedstatus"].ToString();
                cartid = Session["usercart"].ToString();
            }
            catch (Exception)
            {

            }
            if (loggedstatus.Equals("ok"))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                SqlCommand cmd = new SqlCommand("select U_ID from Tbl_Users where U_Email='" + email + "';", conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    userid = rd[0].ToString();
                }
                rd.Close();
                if (userid.Equals(""))
                { }
                else
                {
                    int y = 0;
                    int x = 0;
                    SqlCommand cmd2 = new SqlCommand("insert into Tbl_Orders (O_UID,O_PaymentType,O_Status,O_Country,O_Region,O_City,O_Address,O_Postcode) values(" + userid + ",'" + DDLpayment.SelectedItem.Value.ToString() + "','Hazırlanıyor..','" + TBcountry.Text + "','" + TBregion.Text + "','" + TBcity.Text + "','" + TBaddress.Text + "','" + TBpostcode.Text + "');", conn);
                    x = cmd2.ExecuteNonQuery();
                    SqlCommand cmd3 = new SqlCommand("select O_ID from Tbl_Orders where O_UID=" + userid, conn);
                    SqlDataReader rd1 = cmd3.ExecuteReader();
                    while (rd1.Read())
                    {
                        orderid = rd1[0].ToString();
                    }
                    rd1.Close();
                    ArrayList pidler = new ArrayList();
                    ArrayList count = new ArrayList();
                    SqlCommand cmd4 = new SqlCommand("select P_ID,CP_Count from Tbl_Carts_Products where C_ID=" + cartid, conn);
                    SqlDataReader rd2 = cmd4.ExecuteReader();
                    while (rd2.Read())
                    {
                        pidler.Add(rd2[0].ToString());
                        count.Add(rd2[1].ToString());
                    }
                    rd2.Close();
                    for (int i = 0; i < pidler.Count; i++)
                    {
                        SqlCommand cmd5 = new SqlCommand("insert into Tbl_Orders_Products values(" + orderid + "," + pidler[i].ToString() + "," + count[i].ToString() + ");", conn);
                        y = cmd5.ExecuteNonQuery();
                    }
                    SqlCommand cmd6 = new SqlCommand("delete from Tbl_Carts_Products where C_ID=" + cartid+";",conn);
                    cmd6.ExecuteNonQuery();
                    if (x == 1 && y == 1)
                    {
                        string script = "alert(\"Sipariş kaydedildi.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                    else
                    {
                        string script = "alert(\"Sipariş kaydedilirken bir sorun oluştu.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(),
                                              "ServerControlScript", script, true);
                    }
                }
            }
            else
            {
                string script = "alert(\"Siparişlerinizi görmek için lütfen giriş yapın.\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                                      "ServerControlScript", script, true);
            }
        }
    }
}