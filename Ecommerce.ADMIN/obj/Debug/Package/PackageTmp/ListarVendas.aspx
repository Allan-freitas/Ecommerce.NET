<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListarVendas.aspx.cs" Inherits="Ecommerce.ADMIN.ListarVendas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Administração de Produtos</title>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <h2>Administração de Vendas</h2>
    </div>
    <br /><br />

    <asp:GridView ID="GrvVendas" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" ForeColor="Black"
        GridLines="Vertical" OnSelectedIndexChanged="GrvVendas_SelectedIndexChanged"
        DataKeyNames="IDT_VENDA" onrowdatabound="GrvVendas_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="IDT_VENDA" HeaderText="Código" />
            <asp:TemplateField HeaderText="Cliente">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("IDT_TIPO_VENDA") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCliente" runat="server" Text='<%# Bind("IDT_TIPO_VENDA") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="IDT_TIPO_VENDA" HeaderText="Tipo Venda" />
            <asp:BoundField DataField="DATA_VENDA" HeaderText="Data da Venda" />
            <asp:BoundField DataField="VALOR_TOTAL" DataFormatString="{0:C}" HeaderText="Valor Total" />
            <asp:BoundField DataField="STATUS" HeaderText="Status" />
            <asp:CommandField SelectText="[Visualizar]" ShowSelectButton="True" />
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

