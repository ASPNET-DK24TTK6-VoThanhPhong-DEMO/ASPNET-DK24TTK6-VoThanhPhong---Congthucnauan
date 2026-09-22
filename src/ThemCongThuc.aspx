<%@ Page Title="Thêm Món Ăn Mới" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" CodeBehind="ThemCongThuc.aspx.cs" Inherits="Webchiasecongthucnauan.ThemCongThuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4 fw-bold">Thêm Món Ăn Mới</h2>
        <div class="row">
            <div class="col-md-6 mx-auto card p-4 shadow-sm">
                
                <div class="mb-3">
                    <label class="form-label fw-bold">Tên món ăn</label>
                    <asp:TextBox ID="txtTenMon" runat="server" CssClass="form-control" placeholder="Ví dụ: Sườn xào chua ngọt..."></asp:TextBox>
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
                    <label class="form-label fw-bold">Tải lên hình ảnh</label>
                    <asp:FileUpload ID="fuHinhAnh" runat="server" CssClass="form-control" />
                </div>
                
                <!-- Nút Lưu có gắn sự kiện OnClick để chạy code C# -->
                <asp:Button ID="btnLuu" runat="server" Text="Lưu Công Thức" CssClass="btn btn-danger w-100 fw-bold mt-2" OnClick="btnLuu_Click" />
                
                <asp:Label ID="lblThongBao" runat="server" CssClass="mt-3 d-block text-center fw-bold"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>