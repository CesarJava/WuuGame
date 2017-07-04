<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminControl.aspx.cs" Inherits="AdminControl" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
      <div>

    <div id="ControlPanel">
    <div id="Controles" style="margin-right:30px">

        <asp:Button ID="btnNewPost" runat="server" CssClass="btnControles" 
            Text="Nova Postagens" onclick="btnNewPost_Click" BackColor="Transparent" 
            ForeColor="#0099FF" Width="200px" />
        <asp:Button ID="btnComents" runat="server" CssClass="btnControles" 
            Text="Comentários" onclick="btnComents_Click" BackColor="Transparent" 
            ForeColor="#0099FF" Width="200px" />
        <asp:Button ID="btnAnuncios" runat="server" CssClass="btnControles" 
            Text="Anuncios" onclick="btnAnuncios_Click" BackColor="Transparent" 
            ForeColor="#0099FF" Width="199px" />
        <asp:Button ID="btnUsers" runat="server" CssClass="btnControles" Text="Users" 
            onclick="btnUsers_Click" BackColor="Transparent" ForeColor="#0099FF" 
            Width="198px" />
            <br />
        <asp:Button ID="btnInfo" runat="server" Text="Informações Gerais" CssClass="btnControles" 
            Width="200px" BackColor="Transparent" ForeColor="#0099FF" 
            onclick="btnInfo_Click"/>
            <br />
            <asp:Button ID="btnGerenciar" runat="server" Text="Gerenciar Comentários"  CssClass="btnControles" 
            Width="200px" BackColor="Transparent" ForeColor="#0099FF" 
            onclick="btnGerenciar_Click"/>
            <br />
            <asp:Button ID="btnMensagens" runat="server" Text="Mensagens Pessoais" CssClass="btnControles" 
            Width="200px" BackColor="Transparent" ForeColor="#0099FF" 
            onclick="btnMensagens_Click"/>
            <br />
         <asp:Button ID="btnTrocarSenha1" runat="server" Text="Trocar Senha" 
            CssClass="btnControles" Width="200px" onclick="btnTrocarSenha_Click" 
            BackColor="Transparent" ForeColor="#0099FF" />        
        </br>
         <asp:Button ID="btnMeusAnuncios" runat="server" Text="Meus Anuncios" 
            CssClass="btnControles" Width="200px" onclick="btnMeusAnuncios_Click" 
            BackColor="Transparent" ForeColor="#0099FF"  />        
        </br>
        <asp:Button ID="btnNovoAnuncio" runat="server" Text="Novo Anuncios" 
            CssClass="btnControles" Width="200px" onclick="btnNovoAnuncio_Click" 
            BackColor="Transparent" ForeColor="#0099FF" />        
        </br>
        <asp:Button ID="btnLogout" runat="server" Text="Logout" 
            CssClass="btnControles" Width="200px" 
            BackColor="Transparent" ForeColor="#0099FF" onclick="btnLogout_Click" />
            <br />


    </div>
        <asp:Panel ID="PnlComents" runat="server" CssClass="pnlComents" >
            <asp:GridView ID="GrdVwComents" runat="server" CssClass="GrdVwComent" 
                AllowPaging="True" AutoGenerateColumns="False" 
                onselectedindexchanged="GrdVwComents_SelectedIndexChanged" 
                onrowcommand="GrdVwComents_RowCommand" >
                <Columns>
                    <asp:BoundField HeaderText="Id" DataField="IdComentario" />
                    <asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Text='<%# Bind("NomeUser") %>' NavigateUrl="~/Page_Usuario.aspx?Usuario= <%= HyperLink1.Text %>"  runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Data">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Data") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resumo">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("TituloPost")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:ButtonField ButtonType="Button" CommandName="Apagar" HeaderText="Apagar" 
                        Text="Apagar" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="PnlAnuncios" runat="server" CssClass="pnlComents" >
            <asp:GridView ID="GrdVwAnuncios" runat="server" CssClass="GrdVwComent" 
                AllowPaging="True" AutoGenerateColumns="False" 
                onrowcommand="GrdVwAnuncios_RowCommand" 
                onselectedindexchanged="GrdVwAnuncios_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="IdAnuncio" HeaderText="Id" />
                    <asp:TemplateField HeaderText="User">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# Bind("NomeVendedor") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Anuncio">
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" Text='<%# Bind("NomeAnuncio") %>' NavigateUrl="~/Page_Anuncio.aspx?AnuncioId= <%= IdAnuncio.Text %>"  runat="server"></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:ButtonField ButtonType="Button" CommandName="Apagar" HeaderText="Apagar" 
                        Text="Apagar" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="PnlUsers" runat="server" CssClass="pnlComents" >
            <asp:GridView ID="GrdVwUsuarios" runat="server" CssClass="GrdVwComent" 
                AllowPaging="True" AutoGenerateColumns="False" 
                onrowcommand="GrdVwUsuarios_RowCommand" 
                onselectedindexchanged="GrdVwUsuarios_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Login" HeaderText="Login" />
                    <asp:TemplateField HeaderText="Nome">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Nome") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NivelAcesso" HeaderText="Nivel Acesso" />
                    <asp:ButtonField ButtonType="Button" CommandName="AlterarNivel" 
                        Text="Alterar Nivel" />
                    <asp:ButtonField ButtonType="Button" CommandName="Apagar" Text="Apagar" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
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
                AllowPaging="True" onrowcommand="grdViewEmissorr_RowCommand" 
                style="margin-left: 142px">
                <Columns>
                    <asp:BoundField HeaderText="IdMensagem" DataField="IdMensagem" />
                    <asp:BoundField DataField="NomeTipoMensagem" HeaderText="Tipo" />
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
                    <asp:ButtonField ButtonType="Image" CommandName="Cancelar" 
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
                AllowPaging="True" style="margin-left: 126px">
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
                AutoGenerateColumns="False" AllowPaging="True" 
                onselectedindexchanged="grdGereAnuncios_SelectedIndexChanged" 
                style="margin-left: 112px">
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

         <asp:Panel ID="pnlGerenciarPostagens" runat="server" CssClass="pnlNegocicao" 
            Visible="False">
<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                 onselectedindexchanged="GridView2_SelectedIndexChanged1" 
                 style="margin-left: 112px" Width="795px">
          <Columns>
              <asp:BoundField DataField="IdPostagem" HeaderText="Id" />
              <asp:BoundField DataField="Titulo" HeaderText="Titulo" />
              <asp:BoundField DataField="Subtitulo" HeaderText="Subtitulo" />
              <asp:ButtonField ButtonType="Image" 
                  ImageUrl="~/css_pirobox/black/close_btn3.png" Text="Apagar" />
          </Columns>
          </asp:GridView>
          </asp:Panel>

        
    </div>
    </div>
          
    
    </div>
</asp:Content>


