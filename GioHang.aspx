<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHang.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="mahang" HeaderText="Mã hàng" />
            <asp:BoundField DataField="tenhang" HeaderText="Tên hàng" />
            <asp:BoundField DataField="mota" HeaderText="Mô tả" />
            <asp:BoundField DataField="dongia" HeaderText="Đơn giá" />
            <asp:BoundField DataField="soluong" HeaderText="Số lượng" />
            <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>

