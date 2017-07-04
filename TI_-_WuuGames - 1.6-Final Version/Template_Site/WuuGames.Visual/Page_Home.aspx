<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master"AutoEventWireup="true" CodeFile="Page_Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <%WuuGames.Business.ImagemLogica business = new WuuGames.Business.ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());%>
    <div id="templatemo_main_wrapper">
	<div id="templatemo_main">
    
    	<div id="templatemo_content">
        
        	<div id="homepage_slider">
                <div id="slider">
                    <a href="Page_Postagens.aspx">
                    <img src="images/slideshow/assassinscreed-06.jpg" alt="Image 3" 
                        title="Wü Games" 
                        class="image_wrapper" /></a>
                    <a href="Page_Postagens.aspx">
                    <img src="images/slideshow/batman-arkham-asylum.jpg" alt="Image 4" 
                        title="Wü Games " class="image_wrapper" /></a>
                    <a href="Page_Postagens.aspx">
                    <img src="images/slideshow/captain-america-wallpaper.jpg" alt="Image 5" 
                        title="Wü Games " class="image_wrapper" /></a>
                        <a href="Page_Postagens.aspx">
                         <img src="images/slideshow/mass-effect-3-wallpaper-1.jpg" alt="Image 5" 
                        title="Wü Games" class="image_wrapper" /></a>
                        <a href="Page_Postagens.aspx">
                         <img src="images/slideshow/The-Elder-Scrolls-V-Skyrim-1680x1050-Widescreen-Wallpaper3.jpg" alt="Image 5" 
                        title="Wü Games " class="image_wrapper" /></a>
                </div>
			</div>
                	
                   
                    
        	<div class="post_box">
        		<a href="Page_Post.aspx?Titulo=<%=lblTituloPost1.Text %>"><img src="images/Post/<%= business.RecuperarNomePorTituloPost(lblTituloPost1.Text) %>" alt="Image 1" 
                    class="image_fl" /></a>
          <div class="post_box_right">
                    <asp:Label ID="lblCategoriapost1" runat="server"></asp:Label>
&nbsp;<h2>
                     <a href="Page_Post.aspx?Titulo=<%=lblTituloPost1.Text %>">   <asp:Label ID="lblTituloPost1" runat="server" Text="Label"></asp:Label> </a>
                    </h2>
					<div class="post_meta"><strong>Date:<asp:Label ID="lbldatapost1" runat="server" 
                            Text="Label"></asp:Label>
                        </strong> &nbsp;| <strong>Author:</strong>
                        <asp:Label ID="lbluserpost1" runat="server" Text="Label"></asp:Label>
&nbsp;</div>
                    <p>
                        <asp:Label ID="lblresumopost1" runat="server" Text="Label"></asp:Label>
                    </p>
            <div class="cleaner"></div>                   
                    <asp:LinkButton ID="LkbtnPost1" class="more float_r"
                        runat="server" onclick="LkbtnPost1_Click">Read More</asp:LinkButton>
    			</div>
                <div class="cleaner"></div>
            </div>

            <div class="post_box">
        		<a href="Page_Post.aspx?Titulo=<%=lblTitulopost2.Text %>"><img src="images/Post/<%= business.RecuperarNomePorTituloPost(lblTitulopost2.Text) %>" alt="Image 1" 
                    class="image_fl" /></a>
          <div class="post_box_right">
                    <asp:Label ID="lblCategoriapost2" runat="server"></asp:Label>
&nbsp;<h2>
                     <a href="Page_Post.aspx?Titulo=<%=lblTitulopost2.Text %>">   <asp:Label ID="lblTitulopost2" runat="server" Text="Label"></asp:Label> </a>
                    </h2>
					<div class="post_meta"><strong>Date:<asp:Label ID="lblDatapost2" runat="server" 
                            Text="Label"></asp:Label>
                        </strong> &nbsp;| <strong>Author:</strong>
                        <asp:Label ID="lblUserpost2" runat="server" Text="Label"></asp:Label>
&nbsp;</div>
                    <p>
                        <asp:Label ID="lblResumoPost2" runat="server" Text="Label"></asp:Label>
                    </p>
            <div class="cleaner"></div>                   
                    <asp:LinkButton ID="LinkButton1" class="more float_r"
                        runat="server" onclick="LkbtnPost2_Click">Read More</asp:LinkButton>
    			</div>
                <div class="cleaner"></div>
            </div>
            
            
        
            
      
        	
      </div>
        
        
    
    <div class="cleaner"></div>
    </div> <!-- end of main -->
</div> <!-- end of main wrapper -->

</asp:Content>

