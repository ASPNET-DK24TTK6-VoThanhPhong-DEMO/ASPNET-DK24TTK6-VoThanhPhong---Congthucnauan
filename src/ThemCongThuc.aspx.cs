using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Webchiasecongthucnauan
{
    public partial class ThemCongThuc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("DangNhap.aspx");
                return;
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem người dùng đã nhập tên món chưa
            if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                lblThongBao.Text = "Vui lòng nhập tên món ăn!";
                lblThongBao.CssClass = "text-danger mt-3 d-block text-center fw-bold";
                return;
            }

            // Lấy tên tài khoản đang đăng nhập từ Session
            string nguoiDangKy = Session["Username"].ToString();

            string tenHinhAnh = "";

            // 2. Xử lý lưu file ảnh vào thư mục Images của dự án
            if (fuHinhAnh.HasFile)
            {
                tenHinhAnh = Path.GetFileName(fuHinhAnh.FileName);
                string duongDan = Server.MapPath("~/Images/") + tenHinhAnh;
                fuHinhAnh.SaveAs(duongDan);
            }

            // 3. Kết nối CSDL và lưu dữ liệu bằng lệnh INSERT INTO (Bổ sung thêm cột NguoiDung)
            string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "INSERT INTO CongThuc (TenMon, MaDM, MoTa, HinhAnh, NguoiDung) VALUES (@TenMon, @MaDM, @MoTa, @HinhAnh, @NguoiDung)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@MaDM", ddlDanhMuc.SelectedValue);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@HinhAnh", tenHinhAnh);
                cmd.Parameters.AddWithValue("@NguoiDung", nguoiDangKy); // <--- Gán tên người đăng vào đây

                conn.Open();
                cmd.ExecuteNonQuery(); // Lệnh thực thi ghi vào database
            }

            // 4. Xóa trắng form và báo thành công
            txtTenMon.Text = "";
            txtMoTa.Text = "";
            lblThongBao.Text = "Thêm món ăn thành công! Bạn có thể về Trang Chủ để xem.";
            lblThongBao.CssClass = "text-success mt-3 d-block text-center fw-bold";
        }
    }
}