<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Anuncios.aspx.cs" Inherits="Anuncios" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <div id= anuncios class="divAnuncios" style="margin-left: 77px">

    <span><strong class="titleAnuncios">Anuncios:</strong></span>
    </br>
    </br>
        <% WuuGames.Business.AnuncioLogica anuncios = new WuuGames.Business.AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>
  <%if (Request.QueryString["Tipo"] != "")
    { %>
            <%if (Request.QueryString["Tipo"] == "Todos")
              { %>
              <%foreach (WuuGames.Modelo.AnuncioModelo Anuncio in anuncios.RecuperarTodos())
                { %>
              
              
            </br>

         <div id="Anuncio">
        <a href ="Page_Anuncio.aspx?AnuncioId=<%=Anuncio.IdAnuncio %>" class="titlesPost">
        <span><img src="images/Anuncios/<%=Anuncio.NomeImagem %>" alt=<%=Anuncio.NomeAnuncio%> 
            class="imgsPosts" />
        </span>             
        <span class="titlesPosts">
           <span><%=Anuncio.NomeAnuncio%></span>           
         </span>
         <br />
         <span>Por: <%=Anuncio.NomeVendedor %> </span>
         <br />
         <span>Nome do Anuncio: <%=Anuncio.NomeAnuncio %></span>
         <br />
         <span>Descrição do Anuncio: <%=Anuncio.DescricaoAnuncio %></span>
         <br />
         <span>Valor: <%=Anuncio.ValorUnidade %>    Quantidade:<%=Anuncio.QuantidadeEstoque %></span>
        </div>
            
            
          

         <%} %>
            <%} %>
        
        <%} %>
    </div>
    </a>
</asp:Content>


