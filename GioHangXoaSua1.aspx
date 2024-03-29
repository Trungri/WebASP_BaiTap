﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GioHangXoaSua1.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# Eval("mahang") %>' OnClick="LinkButton2_Click">Xoá</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="tenhang" HeaderText="Tên hàng" />
            <asp:BoundField DataField="mota" HeaderText="Mô tả" />
            <asp:BoundField DataField="dongia" HeaderText="Đơn giá" />
            <asp:TemplateField HeaderText="Số lượng">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("soluong") %>'></asp:TextBox>
                    <br />
                    <asp:Button ID="Button1" runat="server" CommandArgument='<%# Eval("mahang") %>' Text="Sửa" OnClick="Button1_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>

