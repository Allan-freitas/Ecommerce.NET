<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Ecommerce.WEB.Default" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="center_title_bar">
            Novidades
        </div>
        <asp:DataList runat="server" ID="dtlprodutos" RepeatColumns="3" OnItemDataBound="dtlProdutos_ItemDataBound" OnItemCommand="dtlProdutos_ItemCommand">
            <ItemTemplate>
                <div class="prod_box">
                    <div class="top_prod_box">
                    </div>
                    <div class="center_prod_box">
                        <div class="product_title">
                            <asp:HyperLink ID="lnkNomeProduto" runat="server" Text="Motorola" NavigateUrl="#" /></div>
                        <div class="product_img">
                            <asp:HyperLink ID="lnkImgProduto" runat="server" NavigateUrl="#">
                            <asp:Image ID="imgProduto" runat="server" with="99px" Height="87px" ImageUrl="images/laptop.gif" BorderWidth="0" />
                            </asp:HyperLink>
                        </div>
                        <div class="prod_price">
                            <span class="price">
                                <asp:Label runat="server" ID="lblPrecoProduto" Text="R$ 258,00" /></span><span class="price">
                            </span>
                        </div>
                    </div>
                    <div class="bottom_prod_box">
                    </div>
                    <div class="prod_details_tab">
                        <asp:ImageButton ID="btnCarrinho" runat="server" CommandName="carrinho" ImageUrl="images/cart.gif" BorderWidth="0" CssClass="left_bt" />                           
                    </div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="prod_box">
                    <div class="top_prod_box">
                    </div>
                    <div class="center_prod_box">
                        <div class="product_title">
                            <asp:HyperLink ID="lnkNomeProduto" runat="server" Text="Motorola" NavigateUrl="#" /></div>
                        <div class="product_img">
                            <asp:HyperLink ID="lnkImgProduto" runat="server" NavigateUrl="#">
                            <asp:Image ID="imgProduto" runat="server" with="99px" Height="87px" ImageUrl="images/laptop.gif" BorderWidth="0" />
                            </asp:HyperLink>
                        </div>
                        <div class="prod_price">
                            <span class="price">
                               <asp:Label runat="server" ID="lblPrecoProduto" Text="R$ 258,00" /></span><span class="price">
                                    
                            </span>
                        </div>
                    </div>
                    <div class="bottom_prod_box">
                    </div>
                    <div class="prod_details_tab">
                        <asp:ImageButton ID="btnCarrinho" runat="server" CommandName="carrinho" ImageUrl="images/cart.gif" BorderWidth="0" CssClass="left_bt" />
                    </div>
                </div>
            </AlternatingItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
