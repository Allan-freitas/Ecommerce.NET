<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true"
    CodeBehind="Cadastrar.aspx.cs" Inherits="Ecommerce.WEB.Cadastrar" %>

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
            <ajaxToolkit:ToolkitScriptManager ID="scriptManager" runat="server">
            </ajaxToolkit:ToolkitScriptManager>
            <div class="top_prod_box_big">
            </div>
            <div class="center_prod_box_big">
                <div class="contact_form">
                    <div class="form_row">
                        <label class="contact">
                            <strong>Nome:</strong></label>
                        <asp:RequiredFieldValidator ValidationGroup="Cadastro" ControlToValidate="txtNome"
                            ID="RequiredFieldValidator5" Display="None" runat="server" ErrorMessage="Digite o seu Nome corretamente!"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtNome" MaxLength="100" CssClassclass="contact_input" />
                    </div>
                    <div class="form_row">
                        <label class="contact">
                            <strong>Email:</strong></label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="E-mail inserido é Inválido!"
                            ControlToValidate="txtEmailCliente" Display="Dynamic" ValidationExpression="^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$"
                            ValidationGroup="Cadastrar"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ValidationGroup="Cadastro" ControlToValidate="txtEmailCliente"
                            ID="RequiredFieldValidator2" Display="None" runat="server" ErrorMessage="Preencher o campo de E-mail Corretamente!"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtEmailCliente" MaxLength="100" CssClassclass="contact_input" />
                    </div>                    
                    <div class="form_row    ">
                        <label class="contact">
                            <strong>Senha:</strong></label>
                        <asp:RequiredFieldValidator ValidationGroup="Cadastro" ControlToValidate="txtSenha"
                            ID="RequiredFieldValidator3" Display="None" runat="server" ErrorMessage="Digite a senha!!"></asp:RequiredFieldValidator>
                        <asp:TextBox runat="server" ID="txtSenha" MaxLength="8" TextMode="Password" CssClassclass="contact_input" />
                    </div>
                    <div class="form_row">
                        <label class="contact">
                            <asp:RequiredFieldValidator ValidationGroup="Cadastro" ControlToValidate="txtConfirmaSenha"
                                ID="RequiredFieldValidator4" Display="None" runat="server" ErrorMessage="Favor confirmar a senha da mesma maneira que no campo Senha!!">
                            </asp:RequiredFieldValidator>
                            <strong>Confirmar Senha:</strong></label>
                        <asp:CompareValidator ID="CompareValidator1" Display="None" runat="server" ErrorMessage="A senhas digitadas não são iguais!"
                            ControlToCompare="txtSenha" ControlToValidate="txtConfirmaSenha" ValidationGroup="Cadastro"></asp:CompareValidator>
                        <asp:TextBox runat="server" ID="txtConfirmaSenha" MaxLength="8" TextMode="Password"
                            CssClassclass="contact_input" />
                    </div>
                    <div class="form_row">
                        <label class="contact">
                            <strong>Telefone:</strong></label>
                        <asp:TextBox ID="txtTelefone" MaxLength="15" runat="server" CssClassclass="textbox" />
                        <ajaxToolkit:MaskedEditExtender runat="server" TargetControlID="txtTelefone" Mask="(99) 9999-9999" MessageValidatorTip="true" 
                            OnFocusCssClass="contact" MaskType="Number" InputDirection="LeftToRight" AcceptNegative="None" DisplayMoney="None" 
                            ErrorTooltipEnabled="true" ClearMaskOnLostFocus="false">
                        </ajaxToolkit:MaskedEditExtender>
                        <asp:Panel ID="aviso" runat="server">
                            Para apagar o telefone inserido selecione os numéros e digite o número correto. Obs: Chrome.
                        </asp:Panel>
                        <ajaxToolkit:BalloonPopupExtender runat="server" ID="balaoAviso"
                            TargetControlID="txtTelefone"
                            BalloonPopupControlID="aviso"
                            BalloonStyle="Cloud"
                            UseShadow="true"/>
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnCadastrar" Text="Cadastrar" runat="server" CssClassclass="contact"
                            OnClick="btnCadastrar_Click" ValidationGroup="Cadastro" />
                    </div>
                    <br />
                    <div class="form_row">
                        <asp:ValidationSummary ID="vldSumario1" runat="server" ValidationGroup="Cadastro"
                            DisplayMode="List" ShowMessageBox="true" Height="28px" Width="297px" />
                    </div>
                    <div class="form_row">
                        <asp:Button ID="btnRecuperaSenha" Text="Recuperar Senha" runat="server" CssClassclass="contact"
                            OnClick="btnRecuperaSenha_Click" />
                    </div>
                </div>
            </div>
            <div class="bottom_prod_box_big">
            </div>
        </div>
    </div>
</asp:Content>
