using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Webchiasecongthucnauan
{
    public partial class DanhSachMon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra bảo mật: Chưa đăng nhập bắt buộc chuyển về trang đăng nhập
            if (Session["Username"] == null)
            {
                Response.Redirect("DangNhap.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadDanhSach();
            }
        }

        // Hàm tải danh sách món ăn chỉ của riêng tài khoản đang đăng nhập
        private void LoadDanhSach()
        {
            string nguoiDungHienTai = Session["Username"].ToString();
            string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM CongThuc WHERE NguoiDung = @NguoiDung ORDER BY MaCT DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NguoiDung", nguoiDungHienTai);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCongThuc.DataSource = dt;
                gvCongThuc.DataBind();
            }
        }

        // Sự kiện xóa món ăn
        protected void gvCongThuc_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int maCT = Convert.ToInt32(gvCongThuc.DataKeys[e.RowIndex].Value);
            string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "DELETE FROM CongThuc WHERE MaCT = @MaCT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCT", maCT);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Tải lại danh sách sau khi xóa thành công
            LoadDanhSach();
        }
    }
}