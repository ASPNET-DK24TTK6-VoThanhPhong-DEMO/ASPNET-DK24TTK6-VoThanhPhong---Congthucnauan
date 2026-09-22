<%@ Page Title="Chi Tiết Công Thức" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="Webchiasecongthucnauan.ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <!-- Thông tin chung của món ăn -->
                <asp:Repeater ID="rptChiTiet" runat="server">
                    <ItemTemplate>
                        <h2 class="fw-bold mb-3"><%# Eval("TenMon") %></h2>
                        <p class="text-muted lead"><%# Eval("MoTa") %></p>
                        <img src='Images/<%# Eval("HinhAnh") %>' class="img-fluid rounded mb-4 shadow-sm w-100" alt='<%# Eval("TenMon") %>'>
                    </ItemTemplate>
                </asp:Repeater>

                <!-- PHẦN 1: NGUYÊN LIỆU -->
                <h4 class="fw-bold mt-4 border-bottom pb-2">Nguyên liệu chuẩn bị</h4>
                <ul class="list-group list-group-flush mb-4 shadow-sm rounded">
                    <asp:Repeater ID="rptNguyenLieu" runat="server">
                        <ItemTemplate>
                            <li class="list-group-item d-flex justify-content-between align-items-center py-3">
                                <span class="fw-medium"><%# Eval("TenNguyenLieu") %></span>
                                <span class="badge bg-danger rounded-pill px-3 py-2"><%# Eval("SoLuong") %></span>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>

                <!-- PHẦN 2: CÁC BƯỚC THỰC HIỆN -->
                <h4 class="fw-bold border-bottom pb-2">Các bước thực hiện</h4>
                <div class="mb-4">
                    <asp:Repeater ID="rptCacBuoc" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3 border-0 shadow-sm">
                                <div class="card-body">
                                    <h5 class="fw-bold text-danger">Bước <%# Eval("SoThuTu") %></h5>
                                    <p class="card-text mb-0 text-secondary"><%# Eval("NoiDung") %></p>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                
                <a href="Default.aspx" class="btn btn-outline-secondary mt-3">&larr; Quay lại trang chủ</a>
            </div>
        </div>
    </div>
</asp:Content>