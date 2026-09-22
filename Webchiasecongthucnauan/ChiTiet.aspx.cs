using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Webchiasecongthucnauan
{
    public partial class ChiTiet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string maCT = Request.QueryString["MaCT"];
                if (string.IsNullOrEmpty(maCT))
                {
                    Response.Redirect("Default.aspx");
                    return;
                }

                string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    // 1. Lấy thông tin chung món ăn
                    string qryMonAn = "SELECT * FROM CongThuc WHERE MaCT = @MaCT";
                    SqlCommand cmd1 = new SqlCommand(qryMonAn, conn);
                    cmd1.Parameters.AddWithValue("@MaCT", maCT);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);

                    if (dt1.Rows.Count > 0)
                    {
                        rptChiTiet.DataSource = dt1;
                        rptChiTiet.DataBind();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                        return;
                    }

                    // 2. Lấy danh sách nguyên liệu
                    string qryNguyenLieu = "SELECT * FROM NguyenLieu WHERE MaCT = @MaCT";
                    SqlCommand cmd2 = new SqlCommand(qryNguyenLieu, conn);
                    cmd2.Parameters.AddWithValue("@MaCT", maCT);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);

                    rptNguyenLieu.DataSource = dt2;
                    rptNguyenLieu.DataBind();

                    // 3. Lấy danh sách các bước thực hiện
                    string qryCacBuoc = "SELECT * FROM CacBuoc WHERE MaCT = @MaCT ORDER BY SoThuTu ASC";
                    SqlCommand cmd3 = new SqlCommand(qryCacBuoc, conn);
                    cmd3.Parameters.AddWithValue("@MaCT", maCT);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);

                    rptCacBuoc.DataSource = dt3;
                    rptCacBuoc.DataBind();
                }
            }
        }
    }
}