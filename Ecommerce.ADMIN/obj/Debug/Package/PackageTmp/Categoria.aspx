<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="Ecommerce.ADMIN.Categoria" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblNomeCategoria0" runat="server" Text="Código Categoria"></asp:Label>
    
        <br />
        <asp:TextBox ID="TxtCodigo" runat="server" ReadOnly="True" Width="29px"></asp:TextBox>
        <br />
        <br />
    
        <asp:Label ID="lblNomeCategoria" runat="server" Text="Nome da Categoria"></asp:Label>
    
    </div>
    <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSalvar" runat="server" onclick="btnSalvar_Click" Text="Salvar" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GrvCategorias" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black" GridLines="Vertical" 
        onselectedindexchanged="GrvCategorias_SelectedIndexChanged" 
        DataKeyNames="IDT_CATEGORIA" onrowdeleting="GrvCategorias_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_CATEGORIA" HeaderText="Código" />
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
