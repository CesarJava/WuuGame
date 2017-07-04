using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class NovaMensagem : System.Web.UI.Page
{
    MensagemModelo mensagem = null;
    MensagemLogica msglg = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());

    UsuarioLogica userlg = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    UsuarioModelo usuario1 = null;
    UsuarioModelo usuario2 = null;
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
            lblUsuario.Text = (Request.QueryString["Usuario"]).ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (UsuarioLogado())
        {
            HttpCookie cookie = ReadCookie();
            mensagem = new MensagemModelo();

            usuario1 = userlg.RecuperarUsuarioPorLogin(lblUsuario.Text);
            mensagem.NomeUserRecebe = usuario1.Nome;
            mensagem.IdUserRecebe = usuario1.Id;

            usuario2 = userlg.RecuperarUsuarioPorLogin(cookie["USUARIO"]);
            mensagem.NomeUserManda = usuario2.Nome;
            mensagem.IdUserManda = usuario2.Id;

            mensagem.NomeTipoMensagem = DropDownList1.Text;
            mensagem.IdTipoMensagem = Convert.ToInt32(DropDownList1.SelectedValue);
            mensagem.TextoMensagem = txtMensagem.Text;
            mensagem.AssuntoMensagem = txtAssunto.Text;
            msglg.CadastrarNova(mensagem);
            Response.Redirect("Page_Usuario.aspx?Usuario=" + Request.QueryString["Usuario"]);
        }
        else
            Response.Redirect("Page_Usuario.aspx?Usuario=" + Request.QueryString["Usuario"]);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Limpar();
    }

    private void Limpar()
    {
        txtAssunto.Text = "";
        txtMensagem.Text = "";
        DropDownList1.Text = "";
    }
}