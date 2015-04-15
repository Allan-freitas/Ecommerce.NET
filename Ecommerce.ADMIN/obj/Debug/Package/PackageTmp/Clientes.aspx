<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="Ecommerce.ADMIN.Clientes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administração de Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Administração de Clientes</h2>
            
        <asp:Label ID="lblIdClientes" runat="server" Text="Código Cliente"></asp:Label>
        <br />
        <asp:TextBox ID="TxtIdCliente" runat="server" ReadOnly="True" Width="29px"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Label ID="lblNomeCliente" runat="server" Text="Nome do Cliente"></asp:Label>
        <br />
        <asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox>
        <br />
    </div>
    <br />
    <asp:Label ID="lblEmail" runat="server" Text="E-mail"></asp:Label>
    <br />
    <asp:TextBox ID="txtEmail" runat="server" Height="22px" Width="133px"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblSenha" runat="server" Text="Senha"></asp:Label>
    <br />
    <asp:TextBox ID="TxtSenha" TextMode="Password" runat="server" Height="22px" Width="133px"></asp:TextBox>
    <br />
    <asp:CompareValidator ID="CompareValidator1" runat="server" 
        ControlToCompare="TxtSenha" ControlToValidate="txtConfirmaSenha" 
        Display="Dynamic" ErrorMessage="As senhas não conferem!" Font-Italic="True" 
        ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
    <br />
    <asp:Label ID="LabelConfirmaSenha" runat="server" Text="Confirmar Senha"></asp:Label>
    <br />
    <asp:TextBox ID="txtConfirmaSenha" TextMode="Password" runat="server" Height="22px" Width="133px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnSalvar" runat="server" OnClick="btnSalvar_Click" Text="Salvar" />
    <br />
    <br />
    <asp:GridView ID="GrvClientes" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black"
        GridLines="Vertical" OnSelectedIndexChanged="GrvClientes_SelectedIndexChanged"
        DataKeyNames="IDT_CLIENTE" OnRowDeleting="GrvClientes_RowDeleting">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_CLIENTE" HeaderText="Código" />
            <asp:BoundField DataField="NOME" HeaderText="Nome" />
            <asp:BoundField DataField="EMAIL" HeaderText="E-Mail" />
            <asp:BoundField DataField="DATA_CADASTRO" HeaderText="Data de Cadastro" />
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
