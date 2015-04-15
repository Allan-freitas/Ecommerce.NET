<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true"
    CodeBehind="Detalhes.aspx.cs" Inherits="Ecommerce.WEB.Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="center_title_bar">
            <asp:Label runat="server" ID="lblNomeProduto" Text="Motorola" />
        </div>
        <div class="prod_box_big">
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <div class="product_img_big">
                    <asp:HyperLink ID="LinkImgPrincipal" runat="server" rel="lightbox[roadtrip]" ImageUrl=""
                        NavigateUrl="">
                        <asp:Image ID="imgProduto" runat="server" with="99px" Height="87px" ImageUrl="images/laptop.gif"
                            BorderWidth="0" />
                    </asp:HyperLink>
                    <div class="thumbs">
                        <asp:HyperLink ID="lnkImg1Produto" runat="server" rel="lightbox[roadtrip]" ImageUrl=""
                            NavigateUrl="">
                            <asp:Image ID="Img1" runat="server" Width="29px" Height="29px" BorderStyle="None" />
						</asp:HyperLink>
                        <asp:HyperLink ID="lnkImg2Produto" runat="server" rel="lightbox[roadtrip]" ImageUrl=""
                            NavigateUrl="">
                            <asp:Image ID="Img2" runat="server" Width="29px" Height="29px" BorderStyle="None" /></asp:HyperLink>
                        <asp:HyperLink ID="lnkImg3Produto" runat="server" rel="lightbox[roadtrip]" ImageUrl=""
                            NavigateUrl="">
                            <asp:Image ID="Img3" runat="server" Width="29px" Height="29px" BorderStyle="None" /></asp:HyperLink>
                    </div>
                </div>
                <div class="details_big_box">
                    <div class="product_title_big">
                        <asp:Label runat="server" ID="lblDescricao" Text="My Cinema-U3000/DVBT, USB 2.0 TV BOX External, White" />
                    </div>
                    <div class="specifications">
                        Garantia: <span class="blue">
                            <asp:Label runat="server" ID="lblGarantia" /></span><br />
                        Disponibilidade: <span class="blue">In stoc</span><br />
                        Garantie: <span class="blue">24 luni</span><br />
                        Tip transport: <span class="blue">Mic</span><br />
                        Pretul include <span class="blue">TVA</span><br />
                    </div>
                    <div class="prod_price_big">
                        <span class="price">
                            <asp:Label runat="server" ID="lblValor" Text="R$ 270,00" /></span></div>
                    <asp:ImageButton ID="btnCarrinho" runat="server" ImageUrl="images/cart.gif" BorderWidth="0"
                        CssClass="addtocart" OnClick="btnCarrinho_Click" />
                </div>
            </div>
            <div class="bottom_prod_box_big">
            </div>
            <div class="center_title_bar">
               Produtos Similares</div>
        </div>
        <asp:DataList ID="dtlSimilar" runat="server" 
            onitemdatabound="dtlSimilar_ItemDataBound" 
            onitemcommand="dtlSimilar_ItemCommand" 
            AlternatingItemStyle-HorizontalAlign="Right" Width="190px" 
            HorizontalAlign="Justify" RepeatDirection="Horizontal">
        <ItemTemplate>
        <div class="prod_box">
            <div class="top_prod_box">
            </div>
            <div class="center_prod_box">
                <div class="product_title">
                    <asp:HyperLink ID="lnkLabel" runat="server" Text="Motorola 156 MX-VL" /></div>
                <div class="product_img">
                    <asp:HyperLink runat="server" ID="lnkImgProdSimilar">
                        <asp:Image ID="imgProdSimilar" runat="server" BorderWidth="0" ImageUrl="images/laptop.gif" Width="99px" Height="87px"/></asp:HyperLink></div>
                <div class="prod_price">
                    <span class="price"><asp:Label runat="server" ID="lblPrecoSimilar"/></span></div>
            </div>
            <div class="bottom_prod_box">
            </div>
            <div class="prod_details_tab">
                
            </div>
        </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
           <div class="prod_box">
            <div class="top_prod_box">
            </div>
            <div class="center_prod_box">
                <div class="product_title">
                    <asp:HyperLink ID="lnkLabel" runat="server" Text="Motorola 156 MX-VL" /></div>
                <div class="product_img">
                    <asp:HyperLink runat="server" ID="lnkImgProdSimilar">
                        <asp:Image ID="imgProdSimilar" runat="server" BorderWidth="0" ImageUrl="images/laptop.gif" Width="99px" Height="87px"/></asp:HyperLink></div>
                <div class="prod_price">
                    <span class="price"><asp:Label runat="server" ID="lblPrecoSimilar"/></span></div>
            </div>
            <div class="bottom_prod_box">
            </div>
            <div class="prod_details_tab">
               
            </div>
        </div>
        </AlternatingItemTemplate>
       </asp:DataList>
    </div>
</asp:Content>
