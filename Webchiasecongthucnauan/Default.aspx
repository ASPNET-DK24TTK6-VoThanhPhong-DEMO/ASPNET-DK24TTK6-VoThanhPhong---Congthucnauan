<%@ Page Title="Trang Chủ" Language="C#" MasterPageFile="~/Giaodien.Master" AutoEventWireup="true" Codefile="Default.aspx.cs" Inherits="Webchiasecongthucnauan.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="p-5 text-center bg-light mb-4 hero-banner">
        <div class="container">
            <h1 class="display-4 fw-bold">Khám phá hương vị mỗi ngày</h1>
            <p class="lead">Hàng ngàn công thức nấu ăn ngon, đơn giản dễ làm tại nhà đang chờ bạn.</p>
        </div>
    </div>
    
    <div class="container">
        <h2 class="mb-4 text-center border-bottom pb-2">Món ngon nổi bật</h2>
        <div class="text-center mb-4">
            <a href="Default.aspx" class="btn btn-secondary mx-1">Tất cả</a>
            <a href="Default.aspx?MaDM=1" class="btn btn-outline-danger mx-1">Món Mặn</a>
            <a href="Default.aspx?MaDM=2" class="btn btn-outline-danger mx-1">Món Canh</a>
            <a href="Default.aspx?MaDM=3" class="btn btn-outline-danger mx-1">Tráng Miệng</a>
        </div>
        <div class="row justify-content-center mb-4">
            <div class="col-md-6">
                <div class="input-group">
                    <asp:TextBox ID="txtTuKhoa" runat="server" CssClass="form-control" placeholder="Nhập tên món ăn cần tìm..."></asp:TextBox>
                    <asp:Button ID="btnTimKiem" runat="server" Text="Tìm kiếm" CssClass="btn btn-danger" OnClick="btnTimKiem_Click" />
                </div>
            </div>
        </div>
        <div class="row">
            <asp:Repeater ID="rptCongThuc" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <img src='Images/<%# Eval("HinhAnh") %>' class="card-img-top" alt='<%# Eval("TenMon") %>'>
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("TenMon") %></h5>
                                <p class="card-text text-muted"><%# Eval("MoTa") %></p>
                            </div>
                            <div class="card-footer bg-white border-top-0">
                                <a href='ChiTiet.aspx?MaCT=<%# Eval("MaCT") %>' class="btn btn-outline-danger w-100">Xem công thức</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>