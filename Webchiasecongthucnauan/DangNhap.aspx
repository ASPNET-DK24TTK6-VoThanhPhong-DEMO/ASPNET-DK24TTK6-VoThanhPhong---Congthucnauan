<%@ Page Title="Đăng Nhập Hệ Thống" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Webchiasecongthucnauan.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row">
            <div class="col-md-5 mx-auto card p-4 shadow-sm">
                <h3 class="text-center mb-4 fw-bold text-danger">ĐĂNG NHẬP QUẢN TRỊ</h3>
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Tên đăng nhập</label>
                    <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Nhập tên đăng nhập..."></asp:TextBox>
                </div>
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Mật khẩu</label>
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control" placeholder="Nhập mật khẩu..."></asp:TextBox>
                </div>
                
                <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" CssClass="btn btn-danger w-100 fw-bold py-2 mt-2" OnClick="btnLogin_Click" />
                
                <asp:Label ID="lblThongBao" runat="server" CssClass="mt-3 d-block text-center fw-bold text-danger"></asp:Label>
                
                <div class="text-center mt-3">
                    <a href="Default.aspx" class="text-decoration-none text-muted">&larr; Quay lại trang chủ</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>