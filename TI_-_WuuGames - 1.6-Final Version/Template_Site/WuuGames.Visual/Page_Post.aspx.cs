using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;
using System.Data;



public partial class Post : System.Web.UI.Page
{
    UsuarioLogica userlg = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    ComentarioLogica comlg = new ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    UsuarioModelo usuario = null;
    ComentarioModelo comentario = null;
    public HttpCookie ReadCookie()
    {
        try
        {
            return this.Page.Request.Cookies["Login"];
        }
        catch
        {
            return null;
        }
    }

    public bool UsuarioLogado()
    {
        HttpCookie cookie = ReadCookie();

        if (cookie != null && userlg.ValidacaoUsuario(cookie["USUARIO"]) == true)
            return true;
        else
            return false;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();

        if (cookie != null)
        {
            if(UsuarioLogado())
                PnlComent.Visible = true;
            else
                PnlComent.Visible = false;
        }
        else
            PnlComent.Visible = false;

        if (Request.QueryString["Titulo="] != "")
        {
            PostagemModelo post = new PostagemModelo();
            PostagemLogica postagem = new PostagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            post = postagem.RecuperarPostagemPorNome(Request.QueryString["Titulo"]);
            comlg.RecuperarComentariosPorPost(Request.QueryString["Titulo"]);
          
            lblTitulo.Text = post.Titulo;
            lblData.Text = post.Data;
            lblUser.Text = post.NomeUser;
            lblCorpoPost.Text = post.Conteudo.ToString();
        }
        //Ver se o usuario tá logado
    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();
        comentario = new ComentarioModelo();
        PostagemModelo post = new PostagemModelo();
        PostagemLogica postagem = new PostagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        post = postagem.RecuperarPostagemPorNome(Request.QueryString["Titulo"]);
        usuario = new UsuarioModelo();
        usuario = userlg.RecuperarUsuarioPorLogin(cookie["USUARIO"]);

        comentario.Corpo = txtboxCorpo.Text;
        comentario.Data = (DateTime.Now).ToString("yyyy-MM-dd");
        comentario.NomeUser = usuario.Nome;
        comentario.IdUser = usuario.Id;
        comentario.IdPost = post.IdPost;
        comlg.CadastrarComentario(comentario);
        txtboxCorpo.Text = "";
    }
}