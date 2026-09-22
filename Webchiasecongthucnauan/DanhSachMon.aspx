<%@ Page Title="" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" CodeFile="DanhSachMon.aspx.cs" Inherits="Webchiasecongthucnauan.DanhSachMon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <h2 class="text-center mb-4 fw-bold">Quản Lý Danh Sách Món Ăn Của Tôi</h2>
        
        <div class="text-end mb-3">
            <a href="ThemCongThuc.aspx" class="btn btn-success">+ Thêm món mới</a>
        </div>

        <div class="table-responsive">
            <asp:GridView ID="gvCongThuc" runat="server" CssClass="table table-bordered table-hover align-items-center bg-white shadow-sm" AutoGenerateColumns="False" DataKeyNames="MaCT" OnRowDeleting="gvCongThuc_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="MaCT" HeaderText="Mã" ItemStyle-Width="50px" />
                    
                    <asp:TemplateField HeaderText="Hình ảnh">
                        <ItemTemplate>
                            <img src='Images/<%# Eval("HinhAnh") %>' width="70" height="50" style="object-fit: cover; border-radius: 4px;" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="TenMon" HeaderText="Tên món ăn" />
                    <asp:BoundField DataField="MoTa" HeaderText="Mô tả" />

                    <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="160px">
                        <ItemTemplate>
                            <a href='SuaCongThuc.aspx?MaCT=<%# Eval("MaCT") %>' class="btn btn-warning btn-sm text-white">Sửa</a>
                            <asp:Button ID="btnXoa" runat="server" Text="Xóa" CommandName="Delete" CssClass="btn btn-danger btn-sm ms-1" OnClientClick="return confirm('Bạn có chắc chắn muốn xóa món này không?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>