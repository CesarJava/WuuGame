<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Teste_Admin.aspx.cs" Inherits="Teste_Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #left_sidebar
        {
            width: 187px;
            background-color: black;
            position: static;
            float: left;
        }
        .PlcInfogeral
        {
            margin-left: 80px;
        }
        .btnopcadmins
        {
            background-color: transparent;
            color: #0099FF;
        }
        .divadmin_user
        {
            margin-left: 20px;
        }
        .style1
        {
            text-align: center;
        }
        .pnlComents
        {
            width: 800px;
            margin-left: 80px;
        }
        .coments_admin
        {
        }
        .pnlNegocicao
        {
            margin-left: 80px;
            width: 800px;
        }
        #Admin_user
        {
            height: 836px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="Admin_user">
    <div id="left_sidebar">
        <asp:Button ID="Button2" runat="server" Text="Informações Gerais" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="186px" onclick="Button2_Click" />        
        </br>
        <asp:Button ID="Button1" runat="server" Text="Gerenciar Comentários" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="188px" />
        </br>
        <asp:Button ID="Button3" runat="server" Text="Negociações Em Andamento" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="186px" />
        </br>
        <asp:Button ID="Button4" runat="server" Text="Mensagens Pessoais" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="187px" />        
        </br>
        <asp:Button ID="Button7" runat="server" Text="Logout" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="182px" />
    </div>
     &nbsp;&nbsp;&nbsp;&nbsp;
    <div class="divadmin_user" 
            style="width: 1073px; height: 17px; margin-left: 0px; margin-top: 0px;">
       
        <asp:Panel ID="PnlInfoGerais" runat="server" CssClass="PlcInfogeral" Width="801px" 
            Height="561px" Visible="False">
            <div>
                <div class="style1">
                    <span class="cadastrotitle">Cadastro de USuario:</span></div>
                </p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span>Nome:</span>
                <asp:TextBox ID="txtNome" runat="server" CssClass="txtcadastro"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtNome" ErrorMessage="*Nome é necessário"></asp:RequiredFieldValidator>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Login:<asp:TextBox ID="txtlogin" 
                        runat="server" CssClass="txtcadastro"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtlogin" ErrorMessage="*Login é necessário"></asp:RequiredFieldValidator>
                </p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RG:<asp:TextBox ID="txtRg" runat="server" 
                        CssClass="txtcadastro" ValidationGroup="CPFouRG"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtRg" ErrorMessage="*RG ou CPF são nescessários" 
                        ValidationGroup="CPFouRG"></asp:RequiredFieldValidator>
                </p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CPF:<asp:TextBox ID="txtCPF" runat="server" CssClass="txtcadastro" 
                        ValidationGroup="CPFouRG"></asp:TextBox>
                </p>
                <p class="style1">
                    Data de Nascimento:&nbsp; Dia:<asp:DropDownList ID="DropDia" runat="server" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;Mês:&nbsp;&nbsp;
                    <asp:DropDownList ID="DropMes" runat="server" AutoPostBack="True" 
                        style="margin-bottom: 0px" Width="88px">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ano:<asp:DropDownList ID="DropAno" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; E-mail:
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </p>
                <p class="style1">
                    Interesses:&nbsp;&nbsp;&nbsp;</p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Localize ID="Localize3" runat="server"></asp:Localize>
                    <asp:TextBox ID="txtInteresses" runat="server" CssClass="txtcadastro" 
                        Height="52px" Width="238px"></asp:TextBox>
                </p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; imagem::<asp:Localize ID="Localize1" runat="server"></asp:Localize>
                    <asp:Localize ID="Localize2" runat="server"></asp:Localize>
                    <asp:Localize ID="Localize4" runat="server"></asp:Localize>
                    <asp:FileUpload ID="CaminhoImagem" runat="server" CssClass="txtcadastro" />
                </p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="BtnSalvar" runat="server" CssClass="btncadastro" 
                        onclick="BtnCadastrar_Click" style="text-align: center" Text="Salvar" />
                </p>
&nbsp;&nbsp;</div>
            </asp:Panel>
        <asp:Panel ID="PnlGereComent" runat="server" CssClass="pnlComents" 
            Visible="False">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                Width="798px" CssClass="coments_admin" 
                onselectedindexchanged="GridView1_SelectedIndexChanged">

                <Columns>
                    <asp:TemplateField HeaderText="Data Comentário">
                        <ItemTemplate>
                            <asp:Label ID="lblDataComent" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Inicio">
                        <ItemTemplate>
                            <asp:Label ID="lblResumo" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Postagem">
                        <ItemTemplate>
                            <asp:Label ID="lblPost" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apagar">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="39px" 
                                ImageUrl="~/css_pirobox/black/close_btn3.png" style="text-align: center" 
                                Width="60px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnlNegociacao" runat="server" CssClass="pnlNegocicao" 
            Visible="False">

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                Width="795px">
                <Columns>
                    <asp:TemplateField HeaderText="Data de Inicio">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ultima Mensagem">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Anunciante">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Anuncio">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cancelar">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" Height="48px" 
                                ImageUrl="~/css_pirobox/white/close_btn3.png" Width="54px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </asp:Panel>

    </div>
        
    </div>
    </form>
</body>
</html>
