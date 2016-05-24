using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace RSezer_ETicaret
{
    
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try {
               
                string email = Session["email"].ToString();
                string loggedstatus = Session["loggedstatus"].ToString();
                LGuser.FailureText = "Oturum açma başarılı";
                LGuser.Enabled = false;
                BTlogout.Enabled = true;
                
            }
            catch(Exception)
            {
                LGuser.Enabled = true;
                BTlogout.Enabled = false;
            }
            
           
            if (!Page.IsPostBack)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
                DataTable categories = new DataTable();
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter("Select CAT_Name From Tbl_Categories", con);
                adapter.Fill(categories);

                DDLcat.DataSource = categories;
                DDLcat.DataTextField = "CAT_Name";
                DDLcat.DataBind();

                SqlCommand cmd = new SqlCommand("EXEC GetCathegorizedProducts'" + DDLcat.SelectedItem.Value.ToString() + "'", con);
                SqlDataReader rd2 = cmd.ExecuteReader();
                DataList1.DataSource = rd2;
                DataList1.DataBind();

                con.Close();
                
            }
           
        }

        protected void BTregister_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("EXEC InsertUser'" + LGuser.Password.ToString() +"','"+LGuser.UserName.ToString() + "';", con);
            SqlCommand comm = new SqlCommand("SELECT U_ID FROM Tbl_Users WHERE U_Email='" + LGuser.UserName.ToString() + "';",con);
            int x = com.ExecuteNonQuery();
            SqlDataReader rd = comm.ExecuteReader();
            SqlCommand com2 = null;
            while (rd.Read())
            {
                com2= new SqlCommand("INSERT INTO Tbl_Carts (U_ID) VALUES (" + rd[0].ToString() + ");", con);
            }
            rd.Close();
            int y = com2.ExecuteNonQuery();
            
            if (x==1&&y==1)
            {
                LGuser.FailureText = "Kayıt Tamamlandı, Lütfen tekrar giriş yapın.";
            }
            else
            {
                LGuser.FailureText = "Bir Hata oluştu!";
            }
            con.Close();
        }

        protected void BTlogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand("EXEC Getuserpassword'" + LGuser.UserName.ToString() + "';",con);
            com.CommandType = CommandType.Text;
            DataTable table = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter();
            adapt.SelectCommand=com; 
            adapt.Fill(table);
            String pass="";
            foreach (DataRow rw in table.Rows)
            {
                pass = rw[0].ToString();
            }
            if (pass.Equals(LGuser.Password.ToString()))
            {
                LGuser.Enabled = false;
                LGuser.FailureText = "Oturum açma başarılı";
                Session["email"] = LGuser.UserName.ToString();
                Session["loggedstatus"] = "ok";
                BTlogout.Enabled = true;
            }
            else
            {
                LGuser.FailureText = "Yanlış Parola/Email Kombinasyonu !";
            }


            
            con.Close();
        }

        protected void DDLcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString);
            SqlCommand cmd = new SqlCommand("EXEC GetCathegorizedProducts'"+DDLcat.SelectedItem.Value.ToString()+"'", conn);

            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            DataList1.DataSource = rd;
            DataList1.DataBind();

            conn.Close();
        }

        protected void BTlogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            LGuser.Enabled = true;
            LGuser.FailureText = "Çıkış Yapıldı";
        }
    }
}