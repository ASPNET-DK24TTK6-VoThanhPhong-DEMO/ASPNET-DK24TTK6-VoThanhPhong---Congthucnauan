using System;
using System.Web.UI;

namespace Webchiasecongthucnauan
{
    public partial class Giaodien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra xem đã đăng nhập tài khoản chưa
                if (Session["Username"] != null)
                {
                    pnlChuaDangNhap.Visible = false;
                    pnlDaDangNhap.Visible = true;
                    // Hiển thị tên tài khoản lên nhãn chào mừng
                    lblUser.Text = Session["Username"].ToString();
                }
                else
                {
                    pnlChuaDangNhap.Visible = true;
                    pnlDaDangNhap.Visible = false;
                }
            }
        }

        // Sự kiện khi bấm nút Đăng xuất
        protected void btnDangXuat_Click(object sender, EventArgs e)
        {
            // Xóa Session tài khoản
            Session.Remove("Username");
            Session.Clear();

            // Chuyển hướng về trang chủ
            Response.Redirect("Default.aspx");
        }
    }
}