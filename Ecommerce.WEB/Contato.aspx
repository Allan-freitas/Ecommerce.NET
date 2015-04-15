<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true"
    CodeBehind="Contato.aspx.cs" Inherits="Ecommerce.WEB.Contato" %>
<%@ MasterType VirtualPath="~/Layout.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center_content">
        <div class="center_title_bar">
            <asp:Label runat="server" ID="lblContato" />
            <asp:Label runat="server" ID="lblMensagem" />
            <asp:Label runat="server" ID="lblEmail" />
            <asp:Label runat="server" ID="lblTelefone" />
            <asp:Label runat="server" ID="lblNome" />
        </div>
        <div class="prod_box_big">
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <asp:ScriptManager ID="ScriptManager1" EnableCdn="true" Runat="Server" />
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact">
                        <strong>Name:</strong></label>
                        <asp:TextBox ID="txtNome" MaxLength="15" runat="server" CssClass="textbox"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                        <strong>Email:</strong></label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                         <strong>Telefone:</strong></label>
                        <asp:TextBox ID="txtTelefone" MaxLength="13" runat="server" CssClass="textbox"/>
                    </div>
                    <div class="form_row">
                        <label class="contact">
                        <strong>Message:</strong></label>
                        <asp:TextBox ID="txtMensagem" runat="server" TextMode="MultiLine" CssClass="contact_textarea"/>
                        
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" 
                            CssClass="contact_input" onclick="btnEnviar_Click"/>
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big">

            </div>
        </div>
    </div>
    <script type="text/javascript">
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(registraScript);

        function registraScript(sender, args) {
            MascaraTelefone();
        }
    </script>
</asp:Content>
