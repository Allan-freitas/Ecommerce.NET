<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AlterarDetalhes.aspx.cs" Inherits="Ecommerce.WEB.AlterarDetalhes" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="center_content">
        <div class="center_title_bar">
            <asp:Label runat="server" ID="lblMsgTitutlo" />
            <asp:Label runat="server" ID="lblAviso" />
        </div>
        <div class="prod_box_big">
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact">
                        <strong>Nome:</strong></label>
                        <asp:TextBox runat="server" ID="txtNome" MaxLength="100" CssClassclass="contact_input"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                        <strong>Email:</strong></label>
                        <asp:TextBox runat="server" ID="txtEmail" MaxLength="100" CssClassclass="contact_input"/>
                    </div>
                    <div class="form_row    ">
                        <label class="contact">
                         <strong>Senha:</strong></label>
                        <asp:TextBox runat="server" ID="txtSenha" MaxLength="8" TextMode="Password" CssClassclass="contact_input"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                        <strong>Confirmar Senha:</strong></label>
                        <asp:TextBox runat="server" ID="txtConfirmaSenha" MaxLength="8" TextMode="Password" CssClassclass="contact_input"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                         <strong>Telefone:</strong></label>
                        <asp:TextBox ID="txtTelefone" MaxLength="13" runat="server" CssClass="textbox"/>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnAlteraCadastro" Text="Alterar" runat="server" 
                            CssClass="contact" onclick="btnAlterarCadastro_Click" />
                    </div>
                    <br /><br />
                    <div class="form_row">
                        
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big">
            </div>
        </div>
    </div>
</asp:Content>
