<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="RecuperaSenha.aspx.cs" Inherits="Ecommerce.WEB.RecuperaSenha" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
    <ajaxToolkit:ToolkitScriptManager runat="server" ID="scriptManager" />
        <div class="center_title_bar">
            Recuperar Senha</div>
        <div class="prod_box_big">
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact">
                        <strong>Email:</strong></label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClassclass="contact_input"/>
                        <asp:RegularExpressionValidator ValidationGroup="Recupera" runat="server" ID="validadorEmail" ControlToValidate="txtEmail"
                            ErrorMessage="E-mail Inválido!!" 
                            ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$">
                        </asp:RegularExpressionValidator> 
                        <asp:RequiredFieldValidator runat="server" ID="emailValida" ControlToValidate="txtEmail" 
                            ErrorMessage="Campo necessário para recuperar a senha!"
                            ToolTip="Campo necessário para logar!" Display="Dynamic" ValidationGroup="Recupera">
                        </asp:RequiredFieldValidator>
                        <asp:Panel runat="server" ID="AvisoAjuda">
                            Digite e-mail corretamente de maneira a facilitar o processo de recuperação da senha.
                        </asp:Panel>
                        <ajaxToolkit:BalloonPopupExtender runat="server" ID="balaoAviso"
                        TargetControlID="txtEmail"
                        BalloonSize="Small"
                        BalloonPopupControlID="AvisoAjuda"
                        BalloonStyle="Cloud"/>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnRecupera" CssClass="contact" Text="Recuperar Senha" runat="server" 
                            onclick="btnRecupera_Click" ValidationGroup="Recupera"/>
                        <asp:ValidationSummary ID="sumario" runat="server" ValidationGroup="Recupera" DisplayMode="List" ShowMessageBox="true"/>
                    </div>
                    <br /><br />
                    <div class="form_row">
                        <label class="contact">
                        
                        </label>
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big">
                <strong><asp:Label runat="server" ID="lblMsg" /></strong>
            </div>
        </div>
    </div>
</asp:Content>
