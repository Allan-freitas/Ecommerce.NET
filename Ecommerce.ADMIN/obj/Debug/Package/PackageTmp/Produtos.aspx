<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Ecommerce.ADMIN.Produtos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administração de Produtos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Administração de Produtos</h2>
            
        <asp:Label ID="lblIdCategoria" runat="server" Text="Código Produto"></asp:Label>
        <br />
        <asp:TextBox ID="TxtIdProduto" runat="server" ReadOnly="True" Width="29px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblCategoriaProdudo" runat="server" Text="Categoria Produto"></asp:Label>
        <br />
        <asp:DropDownList ID="dllCategoria" runat="server" Width="109px"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="lblNomeProduto" runat="server" Text="Nome do Produto"></asp:Label>
        <br />
        <asp:TextBox ID="txtNomeProduto" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lblFabricante" runat="server" Text="Fabricante"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlFabricante" runat="server" Width="109px"></asp:DropDownList>
        <br />
        <br />
    </div>
    <br />
    <asp:Label ID="lblDescricao" runat="server" Text="Descrição do Produto"></asp:Label>
    <br />
    <asp:TextBox ID="txtDescricao" runat="server" Height="22px" Width="133px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblFoto" runat="server" Text="Foto"></asp:Label>
    <br />
    <asp:FileUpload ID="fileFotoProduto" runat="server" />
    <br />
    <br />
    <asp:Image ID="imgProduto" runat="server" Height="100px" Width="100px" />
    <br />
    <br />
    <asp:FileUpload ID="Image1Produto" runat="server" />
    <br />
    <br />
    <asp:FileUpload ID="Image2Produto" runat="server"/>
    <br />
    <br />
    <asp:FileUpload ID="Image3Produto" runat="server" />
    <br />
    <br />
    <asp:Label ID="lblValor" runat="server" Text="Valor do Produto"></asp:Label>
    <br />
    <asp:TextBox ID="TxtValor" runat="server" Height="22px" Width="133px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblDestaque" runat="server" Text="Destaque:"></asp:Label>
    <br />
    <asp:CheckBox ID="chkDestaque" runat="server" Text="sim" />
    <br />
    <br />
    <asp:Button ID="btSalvar" runat="server" OnClick="btSalvar_Click" Text="Salvar" />
    <br />
    <br />
    <br />
    <asp:GridView ID="GrvProdutos" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
        GridLines="Vertical" OnSelectedIndexChanged="GrvProdutos_SelectedIndexChanged"
        DataKeyNames="IDT_PRODUTO" OnRowDeleting="GrvProdutos_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_PRODUTO" HeaderText="Código" />
            <asp:BoundField DataField="NOME" HeaderText="Nome" />
            <asp:BoundField DataField="DATA_CADASTRO" HeaderText="Data de Cadastro" />
            <asp:BoundField DataField="DESTAQUE" HeaderText="Destaque" />
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
