<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true"
    CodeBehind="CarrinhoCompra.aspx.cs" Inherits="Ecommerce.WEB.CarrinhoCompra" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<%@ Register assembly="UOL.PagSeguro" namespace="UOL.PagSeguro" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <p>
            CARRINHO DE COMPRAS</p>
        <p>
            <asp:Image ID="Image1" runat="server" Height="150px" ImageUrl="~/images/carrinho_de_compras.png"
                Width="150px" />
        </p>
        <asp:label runat="server" id="lblMsg" ForeColor="Blue" />
        <p>
            <asp:GridView ID="grvCarrinho" runat="server" AutoGenerateColumns="False" CellPadding="4"
                DataKeyNames="IDT_PRODUTO" ForeColor="#333333" GridLines="None" OnRowDataBound="grvCarrinho_RowDataBound"
                ShowFooter="True" Width="580px" OnRowDeleting="grvCarrinho_RowDeleting">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ButtonType="Image" DeleteImageUrl="~/images/delete.png" ShowDeleteButton="True" />
                    <asp:TemplateField HeaderText="Descrição">
                        <ItemTemplate>
                            <asp:Label ID="lblDescricao" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="QUANTIDADE" HeaderText="Quantidade">
                        <HeaderStyle HorizontalAlign="Left" />
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="VALOR_UNITARIO" DataFormatString="{0:C}" HeaderText="Valor Unit.">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SUBTOTAL" DataFormatString="{0:C}" HeaderText="SubTotal">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </p>
        <br />
        <br />
        <asp:ImageButton runat="server" ID="btnPagar" 
            ImageUrl="images/120x53-pagar-roxo.gif" ImageAlign="Right" 
            ToolTip="Pagar os itens!" onclick="btnPagar_Click" />
        <cc1:VendaPagSeguro ID="VendaPagSeguro1" runat="server" EmailCobranca="freitas_allan@hotmail.com">
        </cc1:VendaPagSeguro>
    </div>
</asp:Content>
