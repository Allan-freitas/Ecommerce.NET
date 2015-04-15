<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fabricante.aspx.cs" Inherits="Ecommerce.ADMIN.Fabricante" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administração de Fabricantes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Administração de Fabricantes</h2>
            
        <asp:Label ID="lblIdFabricante" runat="server" Text="Código Produto"></asp:Label>
        <br />
        <asp:TextBox ID="TxtIdFabricante" runat="server" ReadOnly="True" Width="29px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblNomeFabricante" runat="server" Text="Nome do Fabricantes"></asp:Label>
        <br />
        <asp:TextBox ID="txtNomeFabricante" runat="server"></asp:TextBox>
    </div>
    <br />
    <br />
    <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GrvFabricantes" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
        GridLines="Vertical" OnSelectedIndexChanged="GrvFabricantes_SelectedIndexChanged"
        DataKeyNames="IDT_FABRICANTE" OnRowDeleting="GrvFabricantes_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_FABRICANTE" HeaderText="Código" />
            <asp:BoundField DataField="NOME" HeaderText="Nome" />
            <asp:CommandField SelectText="[Editar]" ShowSelectButton="True" />
            <asp:CommandField DeleteText="[Excluir]" ShowDeleteButton="True" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    </form>
</body>
</html>

