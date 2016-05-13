<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bundesliga.Web._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="gvStandings" runat="server" BorderWidth="1px" CellSpacing="10" HorizontalAlign="Center" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" CellPadding="5">
        <Columns>
            <asp:BoundField HeaderText="Team" DataField="TeamName" ReadOnly="true" />
            <asp:BoundField HeaderText="Matches" DataField="PlayedGames" ReadOnly="true" />
            <asp:BoundField HeaderText="W" DataField="Wins" ReadOnly="true" />
            <asp:BoundField HeaderText="D" DataField="Draws" ReadOnly="true" />
            <asp:BoundField HeaderText="L" DataField="Losses" ReadOnly="true" />
            <asp:BoundField HeaderText="P" DataField="Points" ReadOnly="true" />
        </Columns>
        <HeaderStyle BackColor="#999999" BorderWidth="2px" />
    </asp:GridView>
</asp:Content>
