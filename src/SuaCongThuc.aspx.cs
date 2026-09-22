using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Webchiasecongthucnauan
{
    public partial class SuaCongThuc : System.Web.UI.Page
    {
        string connString = ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
            {
                Response.Redirect("DangNhap.aspx");
                return;
            }
            {
                string maCT = Request.QueryString["MaCT"];
                if (string.IsNullOrEmpty(maCT))
                {
                    Response.Redirect("DanhSachMon.aspx");
                    return;
                }

                LoadDuLieuCu(maCT);
            }
        }

        // Đổ dữ liệu cũ của món ăn lên form để người dùng thấy và sửa
        private void LoadDuLieuCu(string maCT)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT * FROM CongThuc WHERE MaCT = @MaCT";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaCT", maCT);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    txtTenMon.Text = dt.Rows[0]["TenMon"].ToString();
                    ddlDanhMuc.SelectedValue = dt.Rows[0]["MaDM"].ToString();
                    txtMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                    imgHinhAnhCu.ImageUrl = "Images/" + dt.Rows[0]["HinhAnh"].ToString();

                    // Lưu tên file ảnh cũ vào ViewState để phòng hờ người dùng không đổi ảnh mới
                    ViewState["HinhAnhCu"] = dt.Rows[0]["HinhAnh"].ToString();
                }
            }
        }

        // Sự kiện khi bấm nút Lưu Thay Đổi
        protected void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maCT = Request.QueryString["MaCT"];
            string tenHinhAnh = ViewState["HinhAnhCu"].ToString();

            // Nếu người dùng chọn file ảnh mới thì lưu ảnh mới đè lên
            if (fuHinhAnhMoi.HasFile)
            {
                tenHinhAnh = Path.GetFileName(fuHinhAnhMoi.FileName);
                string duongDan = Server.MapPath("~/Images/") + tenHinhAnh;
                fuHinhAnhMoi.SaveAs(duongDan);
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE CongThuc SET TenMon = @TenMon, MaDM = @MaDM, MoTa = @MoTa, HinhAnh = @HinhAnh WHERE MaCT = @MaCT";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@TenMon", txtTenMon.Text);
                cmd.Parameters.AddWithValue("@MaDM", ddlDanhMuc.SelectedValue);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@HinhAnh", tenHinhAnh);
                cmd.Parameters.AddWithValue("@MaCT", maCT);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblThongBao.Text = "Cập nhật món ăn thành công!";
            lblThongBao.CssClass = "text-success mt-3 d-block text-center fw-bold";
        }
    }
}