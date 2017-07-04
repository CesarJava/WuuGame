<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teste2.aspx.cs" Inherits="Teste2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .cadastrotitle
        {
        }
        .txtcadastro
        {
            margin-right: 10px;
            margin-left: 5px;
            left: 100px;
        }
        .btncadastro
        {
            margin-right: 250px;
            margin-left: 200px;
            margin-bottom: 10px;
        }
        .divcadastro
        {
        	width: 620px; 
        	margin-right: 0px; 
        	margin-left: 116px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div  
            class="divcadastro" >
        <p>
            <span class="cadastrotitle">Cadastro de USuario:</span></p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               <span>Nome:</span> <asp:TextBox ID="txtNome" runat="server" CssClass="txtcadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="*Nome é necessário" ControlToValidate="txtNome"></asp:RequiredFieldValidator>
        </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Login:<asp:TextBox ID="txtlogin" runat="server" CssClass="txtcadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtlogin" ErrorMessage="*Login é necessário"></asp:RequiredFieldValidator>
        </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Senha:<asp:TextBox ID="txtSenha" runat="server" CssClass="txtcadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtSenha" ErrorMessage="*Senha é necessária"></asp:RequiredFieldValidator>
        </p>
            <p>
               <span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Confirmar Senha:</span><asp:TextBox ID="txtconfirmarsenha" 
                    runat="server" CssClass="txtcadastro"></asp:TextBox>
        &nbsp;</p>
            <p>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                RG:<asp:TextBox ID="txtRg" runat="server" ValidationGroup="CPFouRG" 
                    CssClass="txtcadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtRg" ErrorMessage="*RG ou CPF são nescessários" 
                    ValidationGroup="CPFouRG"></asp:RequiredFieldValidator>
        </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                CPF:<asp:TextBox ID="txtCPF" runat="server" ValidationGroup="CPFouRG" 
                    CssClass="txtcadastro"></asp:TextBox>
        </p>
            <p>
                Data de Nascimento:&nbsp; 
                <asp:DropDownList ID="DropDia" runat="server" AutoPostBack="True" >
                  
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropMes" runat="server" style="margin-bottom: 0px" 
                    Width="88px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="DropAno" runat="server">
                </asp:DropDownList>
        </p>
            <p>
               Interesses:&nbsp;&nbsp;&nbsp;</p>
            <p>
               &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Localize ID="Localize3" runat="server"></asp:Localize>
                <asp:TextBox ID="txtInteresses" runat="server" Height="52px" Width="238px" 
                    CssClass="txtcadastro"></asp:TextBox>
        </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                imagem::<asp:Localize ID="Localize1" runat="server"></asp:Localize>
                <asp:Localize ID="Localize2" runat="server"></asp:Localize>
                <asp:Localize ID="Localize4" runat="server"></asp:Localize>
                <asp:FileUpload ID="CaminhoImagem" runat="server" CssClass="txtcadastro" />
        </p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="BtnCadastrar" runat="server" Text="Cadastrar" 
                    onclick="BtnCadastrar_Click" style="text-align: center" 
                    CssClass="btncadastro" />
        </p>
        </div>
    
    </div>
    </form>
</body>
</html>
