using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Webchiasecongthucnauan
{
    public partial class Default : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string maDM = Request.QueryString["MaDM"];
                string tuKhoa = Request.QueryString["timKiem"];

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    if (!string.IsNullOrEmpty(maDM))
                    {
                        query = "SELECT * FROM CongThuc WHERE MaDM = @MaDM ORDER BY MaCT DESC";
                        cmd.Parameters.AddWithValue("@MaDM", maDM);
                    }
                    else if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        query = "SELECT * FROM CongThuc WHERE TenMon LIKE @TuKhoa ORDER BY MaCT DESC";
                        cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                        txtTuKhoa.Text = tuKhoa;
                    }
                    else
                    {
                        query = "SELECT * FROM CongThuc ORDER BY MaCT DESC";
                    }

                    cmd.CommandText = query;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rptCongThuc.DataSource = dt;
                    rptCongThuc.DataBind();
                }
            }
        }

        protected void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTuKhoa.Text.Trim();
            Response.Redirect("Default.aspx?timKiem=" + Server.UrlEncode(tuKhoa));
        }
    }
}