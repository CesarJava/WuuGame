using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Business;
using WuuGames.Modelo;


public partial class TesteInserçõesBanco : System.Web.UI.Page
{
    public void Comentario()
    {

    }

    public void Postagem()
    {
        string stgConect = "server=localhost;User Id=root;password=RECHETER;Persist Security Info=True;database=db_wugames";
        PostagemModelo post = new PostagemModelo();
        PostagemLogica business = new PostagemLogica(stgConect);
        post.Conteudo = new System.Text.StringBuilder();
        post.Conteudo.Append("É um jogo divertido onde o objetivo é [...]");
        post.Data = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        //post.IdAssunto = 1;
        //post.IdCategoria = 1;
        post.IdPost = 1;
        post.IdUser = 1;
        post.Titulo = "Snake, o jogo";
        business.CadastrarPostagem(post);
    }

    public void RecuperarPosts()
    {
        PostagemLogica business = new PostagemLogica("server=localhost;User Id=root;password=RECHETER;Persist Security Info=True;database=db_wugames");
        business.RecuperarTodos();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        RecuperarPosts();
    }
}