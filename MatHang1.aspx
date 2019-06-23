<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MatHang1.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="    font-size: 27px; margin-right: 200px; color: #23824c">
    DANH MỤC MẶT HÀNG</p>
<p>
    <asp:DataList ID="DataList2" runat="server" CellPadding="10" RepeatColumns="4" OnSelectedIndexChanged="DataList2_SelectedIndexChanged">
        <ItemTemplate>
            <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("mathang") %>' Height="200px" ImageUrl='<%# "~/image/"+Eval("hinh") %>' OnClick="ImageButton1_Click" Width="200px" />
            <br />
            <asp:LinkButton style="color: #e67300" ID="LinkButton2" runat="server" CommandArgument='<%# Eval("mathang") %>' OnClick="LinkButton2_Click" Text='<%# Eval("tenhang") %>'></asp:LinkButton>
            <br />
            <asp:LinkButton style="color: #e67300"  ID="LinkButton3" runat="server" CommandArgument='<%# Eval("mathang") %>' OnClick="LinkButton3_Click">Chi tiết ...</asp:LinkButton>
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
</p>
</asp:Content>

