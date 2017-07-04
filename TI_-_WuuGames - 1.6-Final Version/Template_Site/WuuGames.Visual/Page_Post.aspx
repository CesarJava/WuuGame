<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="Page_Post.aspx.cs" Inherits="Post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%  %>
    <div id="templatemo_main_wrapper">
	<div id="templatemo_main">
    
    	<div id="templatemo_content">
        <%WuuGames.Business.ImagemLogica business = new WuuGames.Business.ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>
            <%WuuGames.Business.PostagemLogica posts = new WuuGames.Business.PostagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>        <%if(Request.QueryString["Titulo"] != "") {%>        <%foreach(string genero in posts.RecuperarPostagemPorNome(Request.QueryString["Titulo"]).NomeGenero){  %>
             
        	<div class="post_box">
              <a href="Postagens.aspx?Genero=<%=genero %>"> <span><%=genero %></span> <!--<asp:Label ID="lblGenero1" runat="server" Text="" Visible="true"></asp:Label>--> </a>             
                <%} %>
                                <h2>
                               <img src="images/Post/<%=business.RecuperarNomePorTituloPost(lblTitulo.Text) %>" />
                                    <asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label> </h2>
                
                <div class="post_meta"><strong>Data:</strong><asp:Label ID="lblData" runat="server" 
                        Text="Label"></asp:Label> | <strong>Autor:</strong> 
              <a href="Page_Usuario.aspx?Usuario=<%=lblUser.Text %>">  <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label></a>  | 
                    <asp:Label ID="lblContComent" runat="server" Text="Label"></asp:Label></div>                
                <asp:Label ID="lblCorpoPost" runat="server" Text="Label"></asp:Label>
		  </div>
            
            <h3>Comments</h3>

			<div id="comment_section">
                	<ol class="comments first_level">
                        <%WuuGames.Business.ComentarioLogica coments = new WuuGames.Business.ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString()); %>                                               
                          <%foreach(WuuGames.Modelo.ComentarioModelo comentario in coments.RecuperarComentariosPorPost(lblTitulo.Text))
                          { %>
                        
                        <li>
                            <div class="comment_box commentbox1">
                                    
                                <div class="gravatar">
                                    <img src="images/Usuarios/<%=business.RecuperarNomeImagemPorLogin(comentario.NomeUser) %>" alt="author" />
                                </div>
                                
                                <div class="comment_text">
                                  <a href="Page_Usuario.aspx?Usuario=<%=comentario.NomeUser %>">  <div class="comment_author"><%=comentario.NomeUser %><span class="date"><%=comentario.Data %></span></a>
                                    <p><%=comentario.Corpo %></p>
                                </div>
                                <div class="cleaner"></div>
                            </div>  
                            </li>                                                 
                        
                        <%} %>                        <%} %>
                       <!-- <li>
                            <div class="comment_box commentbox1">
                                    
                                     
                                <div class="gravatar">
                                    <img src="images/avator.png" alt="author" />
                                </div>
                                <div class="comment_text">
                                    <div class="comment_author">Magret<span class="date">May 30th, 2048</span><span class="time">5:20 pm</span></div>
                                    <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus dictum ornare nulla ac laoreet. Phasellus mattis tellus eu risus</p>
                                    <div class="btn_more float_r"><a href="#"><span>+</span> Reply</a></div>
                                </div>
                                
                                <div class="cleaner"></div>
                            </div>                                                  
                            
                        </li>
                        
                        <li>
                            <div class="comment_box commentbox1">
                                    
                                <div class="gravatar">
                                    <img src="images/avator.png" alt="author" />
                                </div>
                                <div class="comment_text">
                                    <div class="comment_author">Olivia<span class="date">May 31st, 2048</span><span class="time">11:29 am</span></div>
                                    <p>Sed volutpat urna vitae sapien sodales pellentesque.</p>
                                    <div class="btn_more float_r"><a href="#"><span>+</span> Reply</a></div>
                                </div>
                                
                                <div class="cleaner"></div>
                            </div>                        
                                                       
                        </li>-->
                        
                    </ol>
            </div> <!-- end of comment -->

            <asp:Panel ID="PnlComent" runat="server" CssClass="Pnl_NovoComent" 
                Visible="False" Height="406px">
        <div id="Comment_Div" >
                    <span class="Title_NovoComment">Deixe Seu Comentário:</span>
                    <br />   
                     <br />  
                                  
                        <div id="Novo_Coment">                         
                            <div id="div_CorpoNewComent">
                            <label class="Name_NewPost">Seu Comentário:</label>
                            <br />                           
                                <asp:TextBox ID="txtboxCorpo" runat="server" CssClass="txt_NewPost" 
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                                                       
                            &nbsp;<asp:Button ID="Button1" runat="server" Text="Enviar Comentário" 
                                CssClass="btn_NewPost" onclick="Button1_Click1" />
                   </div>                      
                    
            </div>
        </asp:Panel>
   
        </div> <!-- end of content -->
        

    
		<div class="cleaner"></div>
    </div> <!-- end of main -->
</div> <!-- end of main wrapper -->
    </a>
</asp:Content>

