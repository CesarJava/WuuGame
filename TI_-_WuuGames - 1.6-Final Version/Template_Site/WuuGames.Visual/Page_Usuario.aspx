<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Usuario.aspx.cs" Inherits="Usuario" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
      <%WuuGames.Business.ImagemLogica business = new WuuGames.Business.ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>
    <div id="recuperarUser" class="divPerfilUser">
    <span>Perfil de: <strong> 
        <asp:Label ID="lblNomeUsuario" runat="server" Text="Label"></asp:Label> </strong></span>
    </br>
    </br>
    </br>
    </br>
    <span>
    <img ID="Image1" src="images/Usuarios/<%=business.RecuperarNomeImagemPorLogin(lblLoginUsuario.Text) %>"  CssClass="IMgUserGet" Height="90px" 
            Width="126px" />
        

        Nome Usuario:<asp:Label ID="lblLoginUsuario" runat="server" Text="Label"></asp:Label> </span>
    </br>
    </br>
    <span>Idade: 
        <asp:Label ID="lblIdadeUsuario" runat="server" Text="Label"></asp:Label> </span>
    </br>
    </br>
    <span>Sexo:<asp:Label ID="lblSexoUsuario" runat="server" Text="Label"></asp:Label></span>
    </br>
    <span>Interesses: 
        <asp:Label ID="lblInteressesUsuarios" runat="server" Text="Label"></asp:Label></span>
    </br>
    </br>
    </br>
    <span>Votos:
    </br>
     Positivos:<asp:Label ID="lblVotosPosUsuario" runat="server" Text="Label"></asp:Label>
     </br>
     Negativos:<asp:Label ID="lvlVotosnegUsuario" runat="server" Text="Label"></asp:Label> </span>
    </br>
    </br>
    </br>
        <asp:Button ID="btnEnviarMensagem" runat="server" Text="Enviar Mensagem" 
            CssClass="btnEnviarMsgm" onclick="btnEnviarMensagem_Click1"  />
        
    </div>
</asp:Content>


