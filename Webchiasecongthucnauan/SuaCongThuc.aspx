<%@ Page Title="Sửa Món Ăn" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" CodeBehind="SuaCongThuc.aspx.cs" Inherits="Webchiasecongthucnauan.SuaCongThuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4 fw-bold">Cập Nhật Thông Tin Món Ăn</h2>
        <div class="row">
            <div class="col-md-6 mx-auto card p-4 shadow-sm">
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Tên món ăn</label>
                    <asp:TextBox ID="txtTenMon" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Danh mục</label>
                    <asp:DropDownList ID="ddlDanhMuc" runat="server" CssClass="form-select">
                        <asp:ListItem Value="1">Món Mặn</asp:ListItem>
                        <asp:ListItem Value="2">Món Canh</asp:ListItem>
                        <asp:ListItem Value="3">Tráng Miệng</asp:ListItem>
                    </asp:DropDownList>
                </div>
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Mô tả ngắn</label>
                    <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
                </div>
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Hình ảnh hiện tại</label><br />
                    <asp:Image ID="imgHinhAnhCu" runat="server" Width="100" Height="70" CssClass="mb-2 rounded shadow-sm" />
                    <br />
                    <label class="form-label fw-bold">Chọn hình ảnh mới (nếu muốn thay đổi)</label>
                    <asp:FileUpload ID="fuHinhAnhMoi" runat="server" CssClass="form-control" />
                </div>
                
                <asp:Button ID="btnCapNhat" runat="server" Text="Lưu Thay Đổi" CssClass="btn btn-warning w-100 fw-bold text-white mt-2" OnClick="btnCapNhat_Click" />
                
                <div class="text-center mt-3">
                    <a href="DanhSachMon.aspx" class="text-decoration-none">&larr; Quay lại danh sách quản lý</a>
                </div>

                <asp:Label ID="lblThongBao" runat="server" CssClass="mt-3 d-block text-center fw-bold"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>