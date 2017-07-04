<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Novo_Postagem.aspx.cs" Inherits="NewPost" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

    <div class="divNewPost" style="width: 749px; height: 1324px">
    <asp:Label ID="LblSucesso" runat="server" style="margin-left: 0px" 
        Width="140px" CssClass="lblsCadastro"></asp:Label>
        <br />
        <br />
        <br />
        

       <span style="font-size: 18px">Título:</span>
       <br />
       <asp:TextBox ID="txtTitulo" runat="server" style="margin-left: 10px" 
            Width="400px" CssClass="txttitulo"></asp:TextBox>
            <br />
            <br />
            <span style="font-size: 18px"> Subtitulo: </span>
            <br />
            <asp:TextBox ID="txtSubtitulo" runat="server" style="margin-left: 10px" Width="400px" CssClass="txttitulo"></asp:TextBox>

        
        <br />
        <span style="font-size: 18px">
        <br />
        <br />
        Genero(s) :</span>
        <br />
        <asp:CheckBox ID="CheckAcao" runat="server" CssClass="cbCategorias" 
            Text="Ação" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckAventura" runat="server" CssClass="cbCategorias" 
            Text="Aventura" />
        &nbsp;
        <asp:CheckBox ID="CheckTerror" runat="server" CssClass="cbCategorias" 
            Text="Terror" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckFiccaoCie" runat="server" CssClass="cbCategorias" 
            Text="Ficção Cientifica" />
        <asp:CheckBox ID="CheckArcade" runat="server" CssClass="cbCategorias" 
            Text="Arcade" />
        <br />
        <asp:CheckBox ID="CheckCorrida" runat="server" CssClass="cbCategorias" 
            Text="Corrida" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckEstrategia" runat="server" CssClass="cbCategorias" 
            Text="Estratégia" />
&nbsp;<asp:CheckBox ID="CheckEsportes" runat="server" CssClass="cbCategorias" 
            Text="Esportes" />
        &nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckLuta" runat="server" CssClass="cbCategorias" 
            Text="Luta" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckMMORPG" runat="server" CssClass="cbCategorias" 
            Text=" MMORPG" />
        <br />
        <asp:CheckBox ID="CheckRaciocinioLogica" runat="server" CssClass="cbCategorias" 
            Text="Raciocínio e Lógica" />
        <asp:CheckBox ID="CheckRPG" runat="server" CssClass="cbCategorias" 
            Text="RPG" oncheckedchanged="CheckBox13_CheckedChanged" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:CheckBox ID="CheckSimuladores" runat="server" CssClass="cbCategorias" 
            Text="Simuladores" />
        <asp:CheckBox ID="CheckMultiPlayer" runat="server" CssClass="cbCategorias" 
            Text="Multi Player" />
        <br />
        <br />
        <span style="font-size: 18px">
        <br />
        <br />
        <br />
        Assunto:</span>
        <br />
        <asp:CheckBox ID="CheckAstNovidades" runat="server" CssClass="cbCategorias"  
            Text="Novidades" />
        <asp:CheckBox ID="CheckAstDicas" runat="server" Text="Dicas" />
        <asp:CheckBox ID="CheckAstDownloads" runat="server" Text="Downloads" />
        <asp:CheckBox ID="CheckAstForum" runat="server" Text="Forum" />
        <asp:CheckBox ID="CheckAstOutros" runat="server" Text="Outros" />

        
            <p style="font-size: 18px">
                &nbsp;</p>
        <p style="font-size: 18px">
                <span style="font-size: 18px">
                Imagem:</span>
        </p>
        <p style="font-size: 18px">
                <asp:FileUpload ID="FileUpload1" runat="server" style="margin-left: 30px" />
        </p>
        <p style="font-size: 18px">
                &nbsp;</p>
        <p style="font-size: 18px">
                Corpo:</p>
        <p>
                <asp:TextBox ID="txtConteudo" runat="server" CssClass="Corpopost" Height="313px" 
                    style="top: 195px" Width="610px" MaxLength="10000" TextMode="MultiLine"></asp:TextBox>
        </p>
        <p>
                <asp:Label ID="Label1" runat="server" CssClass="MaxCharacter" Text="Max. 10000"></asp:Label>
        </p>
        <p>
                &nbsp;</p>
        <p>
                <asp:Button ID="Button1" runat="server" BackColor="Transparent" 
                    CssClass="btnpost" Text="Postar" Height="50px" Width="114px" 
                    onclick="Button1_Click" />
                <asp:Button ID="Button2" runat="server" BackColor="Transparent" 
                    CssClass="btncancel" Text="Cancelar" Height="48px" Width="111px" />
        </p>

        
    </div>
</asp:Content>



