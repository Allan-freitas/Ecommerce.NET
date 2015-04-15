<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarItensVenda.aspx.cs" Inherits="Ecommerce.ADMIN.ListarItensVenda" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administração de Produtos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Administração Itens de Vendas</h2>
    </div>
    <br /><br />

    <asp:GridView ID="GrvItens" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black"
        GridLines="Vertical" DataKeyNames="IDT_VENDA" 
        onrowdatabound="GrvItens_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_VENDA" HeaderText="Código da Venda" />
            <asp:BoundField DataField="IDT_PRODUTO" HeaderText="Código Produto" />
            <asp:TemplateField HeaderText="Produto">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblProduto" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade" />
            <asp:BoundField DataField="VALOR_UNITARIO" DataFormatString="{0:C}" HeaderText="Valor Unit" />
            <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:C}" HeaderText="SubTotal" />
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
