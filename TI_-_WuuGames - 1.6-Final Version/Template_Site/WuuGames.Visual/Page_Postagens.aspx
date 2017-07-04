<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Page_Postagens.aspx.cs" Inherits="Postagens" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
    <h1 style ="margin-left:500px">Postagens </h1>

    <div id=postagens>
    
    <% WuuGames.Business.PostagemLogica postagens = new WuuGames.Business.PostagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>
    <%WuuGames.Business.ImagemLogica business = new WuuGames.Business.ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>
  <%if(Request.QueryString["Genero"] != "") { %>
            <%if (Request.QueryString["Genero"] == "Todos")
              { %>
              <%foreach (WuuGames.Modelo.PostagemModelo Post in postagens.RecuperarTodos())
                { %>
              
              </br>
            </br>
         
        <a href ="Page_Post.aspx?Titulo=<%=Post.Titulo %>" class="titlesPost">
        <span>
        <img src="images/Post/<%=business.RecuperarNomePorTituloPost(Post.Titulo) %>" alt=<%=Post.Titulo%> 
            class="imgsPosts" />
        </span>             
        <span class="titlesPosts">
           <span><%=Post.Titulo%></span>           
         </span>
            
         </a>
         <br />
         <span>Sobre</span><!--Botar um foreach para categorias??-->
        
         <%foreach (string i in Post.NomeGenero)
           { %>
         <a href ="Page_Postagens.aspx?Genero=<%= i %>">
             <span><%=i%>  </span></a>
         <%} %>
         em 
             <span><%=Post.Data%></span> 
             <br/>
            <br/>
            <br/>
            <br/>
            
          

         <%} %>
            <%} %>
           <%else
                { %>
           <%  %>
        <%foreach (WuuGames.Modelo.PostagemModelo Post in postagens.RecuperarPostagensPorGenero(Request.QueryString["Genero"]))
          { %>
              
              </br>
            </br>
         
        <a href ="Page_Post.aspx?Titulo=<%=Post.Titulo %>" class="titlesPost">
        <span><img src=<%=Post.CaminhoImagem %> alt=<%=Post.Titulo%> 
            class="imgsPosts" />
        </span>             
        <span class="titlesPosts">
           <span><%=Post.Titulo%></span>           
         </span>
            
         </a>
         <br />
         <span>Sobre</span><!--Botar um foreach para categorias??-->
        
         <%foreach (string i in Post.NomeGenero)
           { %>
         <a href ="Page_Postagens.aspx?Genero=<%= i %>">
             <span><%=i%>  </span></a>
         <%} %>
         em 
             <span><%=Post.Data%></span> 
             <br/>
            <br/>
            <br/>
            <br/>
            
          

         <%} %>

         <%} %>


            <%} %>


            
    
    </div>
    
   
</asp:Content>




