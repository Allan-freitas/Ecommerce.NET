<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Autenticar.aspx.cs" Inherits="Ecommerce.WEB.Autenticar" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="Gerenciador2"/>
    <div class="center_content">
        <div class="center_title_bar">
            Login</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact">
                        <strong>Email:</strong></label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClassclass="contact_input"/>
                        <asp:RegularExpressionValidator ValidationGroup="Logar" runat="server" ID="validadorEmail" ControlToValidate="txtEmail" ErrorMessage="E-mail Inválido!!"
                            ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$">
                        </asp:RegularExpressionValidator> 
                        <asp:RequiredFieldValidator runat="server" ID="emailValida" ControlToValidate="txtEmail" ErrorMessage="Campo necessário para login"
                            ToolTip="Campo necessário para logar!" Display="Dynamic" ValidationGroup="Logar">
                        </asp:RequiredFieldValidator>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                         <strong>Senha:</strong></label>
                         <asp:RequiredFieldValidator runat="server" ID="validaSenha" ControlToValidate="txtSenha"
                            ErrorMessage="Campo da senha necessário para logar!"
                            ToolTip="Campo necessário para logar!" Display="Dynamic" ValidationGroup="Logar">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtSenha" runat="server" MaxLength="8" TextMode="Password" CssClassclass="contact_input"/>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnEntrar" CssClass="contact" Text="Entrar" runat="server" 
                            onclick="btnEntrar_Click" ValidationGroup="Logar"/>
                        <asp:ValidationSummary ID="sumario" runat="server" ValidationGroup="Logar" DisplayMode="List" ShowMessageBox="true"/>
                    </div>
                    <div class="form_row"> 
                        <a href="Cadastrar.aspx" class="contact">Cadastra-se!</a>
                    </div>
                    <br /><br />
                    <div class="form_row">
                        <label class="contact">
                        <strong><asp:Label runat="server" ID="lblMsg" /></strong>
                        </label>
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big">
            </div>
        </div>
    </div>
</asp:Content>
