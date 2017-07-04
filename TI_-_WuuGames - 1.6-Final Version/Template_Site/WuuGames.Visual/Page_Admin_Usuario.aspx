<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Admin_Usuario.aspx.cs" Inherits="PageAdminUser" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="Admin_user" style="height: 1269px">
    <div id="left_sidebar">
        <asp:Button ID="btnInfo" runat="server" Text="Informações Gerais" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="186px" onclick="Button2_Click" />        
        </br>
        <asp:Button ID="btnGerenciar" runat="server" Text="Gerenciar Comentários" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="188px" onclick="Button1_Click" />
        </br>
       
        <asp:Button ID="btnMensagens" runat="server" Text="Mensagens Pessoais" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="187px" onclick="btnMensagens_Click" />        
        </br>
        <asp:Button ID="btnTrocarSenha1" runat="server" Text="Trocar Senha" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="187px" onclick="btnTrocarSenha_Click" />        
        </br>
         <asp:Button ID="btnMeusAnuncios" runat="server" Text="Meus Anuncios" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="187px" onclick="btnMeusAnuncios_Click"  />        
        </br>
        <asp:Button ID="btnNovoAnuncio" runat="server" Text="Novo Anuncios" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="187px" onclick="btnNovoAnuncio_Click" />        
        </br>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" BorderColor="Transparent" 
            CssClass="btnopcadmins" Width="188px" onclick="btnLogout_Click" />
    </div>
     &nbsp;&nbsp;&nbsp;&nbsp;
    <div class="divadmin_user" 
            style="width: 1073px; height: 579px; margin-left: 0px; margin-top: 0px;">
       
        <asp:Panel ID="PnlInfoGerais" runat="server" CssClass="PlcInfogeral" Width="801px" 
            Height="561px" Visible="False">
            <div class="style1">
                <div class="style1">
                    <span class="cadastrotitle">Informações Gerais</span></div>
                </p>
                <div class="style1">
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
                </div>
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
                    &nbsp;</p>
                <p class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Localize ID="Localize3" runat="server"></asp:Localize>
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
                        Text="Salvar" onclick="BtnSalvar_Click" />
                </p>

&nbsp;&nbsp;</div>

            </asp:Panel>

            
        <asp:Panel ID="PnlGereComent" runat="server" CssClass="pnlComents" 
            Visible="False">
      
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AutoGenerateColumns="False" 
                CssClass="coments_admin" 
                onselectedindexchanged="GridView1_SelectedIndexChanged" Width="798px" 
                onrowcommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField  HeaderText="IdTbm" DataField="IdComentario" />                    
                    <asp:TemplateField HeaderText="Titulo Post">
                        <ItemTemplate>
                            <asp:Label ID="lblTituloPost" runat="server" Text='<%# Bind("TituloPost") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data">
                        <ItemTemplate>
                            <asp:Label ID="lblData" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" HeaderText="Apagar" 
                        ImageUrl="~/css_pirobox/black/close_btn3.png" CommandName="Apagar">
                    <ItemStyle BackColor="Transparent" />
                    </asp:ButtonField>
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnlMsgsEmissora" runat="server" CssClass="pnlNegocicao" 
            Visible="False">
            <br />
            <span style="margin-left:200px; ForeColor:#0099FF">Mensagens Enviadas: </span> 
             <br />
             <br />
            <asp:GridView ID="grdViewEmissorr" runat="server" AutoGenerateColumns="False" 
                Width="795px" onselectedindexchanged="GridView2_SelectedIndexChanged" 
                AllowPaging="True" onrowcommand="grdViewEmissorr_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="IdMensagem" DataField="IdMensagem"  />
                    <asp:BoundField DataField="NomeTipoMensagem" HeaderText="Tipo"  />
                    <asp:TemplateField HeaderText="Data ">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DataMensagem")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Para:">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NomeUserRecebe") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assunto">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("AssuntoMensagem") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" Text="Ler"  CommandName="LerMensagem"/>
                    <asp:ButtonField ButtonType="Image" CommandName="Apagar" 
                        ImageUrl="~/css_pirobox/white/close_btn3.png" HeaderText="Cancelar" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="pnlReceptor" runat="server" CssClass="pnlNegocicao" 
            Visible="False">
             <br />
            <span style="margin-left: 200px; ForeColor=#0099FF;"> Mensagens Recebidas:</span>
             <br />
             <br />

            <asp:GridView ID="grdViewReceptor" runat="server" AutoGenerateColumns="False" 
                Width="795px" onselectedindexchanged="GridView2_SelectedIndexChanged" 
                AllowPaging="True" onrowcommand="grdViewReceptor_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="IdMensagem" DataField="IdMensagem" />
                    <asp:BoundField DataField="NomeTipoMensagem" HeaderText="Tipo" />
                    <asp:TemplateField HeaderText="Data ">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("DataMensagem")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="De:">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NomeUserManda") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Assunto">
                        <ItemTemplate>
                            <asp:Label ID="Label4" runat="server" Text='<%# Bind("AssuntoMensagem") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="LerMensagem" Text="Ler" />
                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel ID="PnlAlterarSenha" runat="server" CssClass="pnlNegocicao" 
            Visible="False">
            <div id="AlterarSenha" style="width:262px; margin-left: 293px;">
            <span style="margin-left: 90px; ForeColor:#0099FF">Alterar Comentário: </span>
            <br />
             <br />
                <asp:Label ID="Label21" runat="server" Text="Label" Visible="False"></asp:Label>
             <br />
             <span style="margin-left: 55px; ForeColor:#0099FF">Senha Atual:</span> <br />
                <asp:TextBox ID="txtSenhaAtual" runat="server" 
                    style="margin-left: 65px; ForeColor:#0099FF" TextMode="Password"></asp:TextBox>
                    <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtSenhaAtual" ErrorMessage="*Senha é Necessaria"></asp:RequiredFieldValidator>
                <br />
             <span style="margin-left: 55px; ForeColor:#0099FF">Nova Senha:</span> <br />
                <asp:TextBox style="margin-left: 65px; ForeColor:#0099FF" ID="txtNovaSenha" 
                    runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*Nova senha é Nescessária" ControlToValidate="txtNovaSenha"></asp:RequiredFieldValidator>
                <br /> 
             <span style="margin-left: 55px; ForeColor:#0099FF">Confirmar Nova Senha:</span> <br />
                <asp:TextBox style="margin-left: 65px; ForeColor:#0099FF" 
                    ID="txtNovaSenhaConfirma" runat="server" TextMode="Password"></asp:TextBox>
                    <br />
                <asp:Label ID="Label22" runat="server" Text="Label" Visible="False"></asp:Label>
                <br />
                <br />
                <asp:Button ID="btnTrocarSenha12" runat="server" Text="Trocar Senha" 
                    style="margin-right: 60px; float:right;  ForeColor:#0099FF" 
                    Width="130px" onclick="btnTrocarSenha1_Click" />

            </div>

            </asp:Panel>


        <asp:Panel ID="pnlGerenciarAnuncios" runat="server" CssClass="pnlNegocicao" 
            Visible="False">
            <asp:GridView ID="grdGereAnuncios" runat="server" Width="795px" 
                AutoGenerateColumns="False" AllowPaging="True">
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="IdAnuncio"/>
                    <asp:TemplateField HeaderText="Nome Anuncio">
                        <ItemTemplate>
                            <asp:Label ID="Label23" runat="server" Text='<%# Bind("NomeAnuncio") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Preço">
                        <ItemTemplate>
                            <asp:Label ID="Label24" runat="server" Text='<%# Bind("ValorUnidade")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Image" HeaderText="Cancelar" 
                        ImageUrl="~/css_pirobox/white/close_btn3.png" Text="Button" />
                </Columns>
            </asp:GridView>

        </asp:Panel>

        
    </div>
        
    </div>
</asp:Content>


