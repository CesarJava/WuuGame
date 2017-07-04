<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Anuncio.aspx.cs" Inherits="Page_Anuncio" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id="Anuncio">
        <asp:Image ID="Image1"  runat="server" CssClass="img_Anuncio" Height="252px" 
            Width="201px" />
        <br />
       <span class="txtsAnuncio">Anunciante: </span> <a href="Page_Usuario.aspx?<%=lblAnunciante.Text %>">    <asp:Label ID="lblAnunciante" runat="server" Text="Label"></asp:Label>  </a>
       <br />
       <br />
       <span class="txtsAnuncio">Nome do Anuncio:</span> <asp:Label ID="lblNomeAnuncio" runat="server" Text="Label"></asp:Label>
       <br />
       <br />
       <span class="txtsAnuncio">Descrição:</span>
       <br />
        <asp:TextBox ID="txtDesc" runat="server" CssClass="lblDesc" Height="250px" 
            Width="349px" ontextchanged="txtDesc_TextChanged" TextMode="MultiLine" 
            Enabled="False"></asp:TextBox>
            <br />
        <br />
        <span class="txtPreço">Preço:</span><asp:Label ID="lblPreco" runat="server"></asp:Label>
        <br />
        <span class="txtsAnuncio">Quantidade:</span> <asp:Label ID="lblQte" 
            runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Negociar " CssClass="btnNegociar" 
            Height="38px" Width="123px" onclick="Button1_Click" />
    </div>
</asp:Content>


