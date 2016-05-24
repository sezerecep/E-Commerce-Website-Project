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
    public partial class siparislerim : System.Web.UI.Page
    {
        string email = "";
        string loggedstatus = "";
        protected void Page_Load(object sender, EventArgs e)
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
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                SqlCommand cmd = new SqlCommand("EXEC GetUsersOrders'" + email + "'", conn);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                DataList1.DataSource = rd;
                DataList1.DataBind();
                rd.Close();
                conn.Close();
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