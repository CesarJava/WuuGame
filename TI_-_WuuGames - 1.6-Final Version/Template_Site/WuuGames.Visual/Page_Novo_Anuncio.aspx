<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Novo_Anuncio.aspx.cs" Inherits="NovoAnuncio" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="novo_anuncio">
    <span class="txtAnuncio">Cadastar Novo Produto</span>
    </br>
    </br>
    </br>
    <span class="txtAnuncio">Nome Produto:</span>
    </br>
        <asp:TextBox ID="txtNome" runat="server" CssClass="flds"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*Nome é Obrigatório" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
    </br>
    <span class="txtAnuncio">Descrição:</span>
    </br>
        <asp:TextBox ID="txtDesc" runat="server" CssClass="flds" Height="82px" 
            TextMode="MultiLine" Width="450px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ErrorMessage="*De Alguma Descrição!" ControlToValidate="txtDesc"></asp:RequiredFieldValidator>
    </br>
    <span class="txtAnuncio">Imagem:</span>
    </br>
        <asp:FileUpload ID="ImgUpload" runat="server" CssClass="flds" Width="262px" />
    </br>
    <span class="txtAnuncio">Formas de Pagamento</span>
    </br>
        <asp:CheckBox ID="chcbxCartao" runat="server" CssClass="flds" Text="Cartão" 
            ValidationGroup="CheckBoxes" 
            oncheckedchanged="chcbxCartao_CheckedChanged" />
        <asp:CheckBox ID="chcbxDeposito" runat="server" Text="Depósito Bancário" 
            ValidationGroup="CheckBoxes" 
            oncheckedchanged="chcbxDeposito_CheckedChanged" />
        <asp:CheckBox ID="chcbxTroca" runat="server" Text="Troca" 
            oncheckedchanged="CheckBox3_CheckedChanged" ValidationGroup="CheckBoxes" />
    </br>
    <span class="txtAnuncio">Valor:</span>
    </br>
        <asp:TextBox ID="txtValor" runat="server" CssClass="flds"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ErrorMessage="Determine um valor !" ControlToValidate="txtValor"></asp:RequiredFieldValidator>
    </br>
    <span class="txtAnuncio">Quantidade:</span>
    </br>
        <asp:TextBox ID="txtQte" runat="server" CssClass="flds"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ErrorMessage="*Pelo Menos uma unidade" ControlToValidate="txtQte"></asp:RequiredFieldValidator>
    </br>
    
    <span class="txtAnuncio">Tipo:</span>
    </br>
        <asp:RadioButton ID="RadioButton1" runat="server" CssClass="flds" 
            AutoPostBack="True" CausesValidation="True" GroupName="Tipos" 
            Text="Vestuário" Checked="True" ValidationGroup="rdBtnTipo" 
            oncheckedchanged="RadioButton1_CheckedChanged" />
        <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" 
            CausesValidation="True" GroupName="Tipos" Text="Objeto" 
            ValidationGroup="rdBtnTipo" 
            oncheckedchanged="RadioButton2_CheckedChanged" />
        <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" 
            CausesValidation="True" GroupName="Tipos" Text="Jogos" 
            ValidationGroup="rdBtnTipo" 
            oncheckedchanged="RadioButton3_CheckedChanged" />
        <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" 
            CausesValidation="True" GroupName="Tipos" Text="Cartas" 
            ValidationGroup="rdBtnTipo" 
            oncheckedchanged="RadioButton4_CheckedChanged" />
        </br>
        </br>
        <asp:Button ID="btnPublicar" runat="server" CssClass="btnCadastrarAnuncio" 
            Height="40px" Text="Publicar" Width="110px" onclick="btnPublicar_Click1" />
        <asp:Button ID="BtnCancelar" runat="server" Height="40px" 
            style="margin-left: 44px" Text="Cancelar" Width="110px" />
        </br>

    </div>
</asp:Content>


