using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;


public partial class Usuario : System.Web.UI.Page
{
    UsuarioLogica userlg = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    MensagemLogica msglg = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    MensagemModelo mensagem;

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
        
        if (Request.QueryString["Usuario"] != "")
        {
            UsuarioLogica user = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            UsuarioModelo usuario = new UsuarioModelo();
            usuario = user.RecuperarUsuarioPorLogin(Request.QueryString["Usuario"]);
            lblNomeUsuario.Text = usuario.Nome;
            lblLoginUsuario.Text = usuario.Login;
            lblInteressesUsuarios.Text = usuario.Interesses;
            DateTime data = DateTime.Parse(usuario.DataNasc);
            int idade = DateTime.Now.Year - data.Year;
            lblIdadeUsuario.Text = idade.ToString();          
        }

        if (UsuarioLogado())
            btnEnviarMensagem.Enabled = true;
        else
            btnEnviarMensagem.Enabled = false;
    }
    protected void btnEnviarMensagem_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Novo_Mensagem.aspx?Usuario=" + Request.QueryString["Usuario"]);
    }
    protected void btnEnviarMensagem_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Page_Novo_Mensagem.aspx?Usuario=" + Request.QueryString["Usuario"]);
    }
}