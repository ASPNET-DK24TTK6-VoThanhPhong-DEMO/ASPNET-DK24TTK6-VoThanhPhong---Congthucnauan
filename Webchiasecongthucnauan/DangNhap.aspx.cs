using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;

namespace Webchiasecongthucnauan
{
    public partial class DangNhap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text.Trim();
            string pass = txtPass.Text.Trim();

            string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @User AND MatKhau = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@User", user);
                cmd.Parameters.AddWithValue("@Pass", pass);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                    Session["Username"] = user;

                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblThongBao.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                }
            }
        }
    }
}