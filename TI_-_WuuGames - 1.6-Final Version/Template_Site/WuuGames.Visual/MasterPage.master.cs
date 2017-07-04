using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;
using System.Text;

public partial class MasterPage : System.Web.UI.MasterPage
{
    UsuarioLogica userlg = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();

        if (cookie != null && userlg.ValidacaoUsuario(cookie["USUARIO"]) == true)
        {
            UsuarioLogado(cookie["USUARIO"]);
        }
    }

    protected void btnLogar_Click(object sender, EventArgs e)
    {
        UsuarioLogica userlg = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        if (userlg.ValidacaoLogin(txtboxUser.Text, txtboxSenha.Text))
        {
            CriarCookie(txtboxUser.Text);

            HttpCookie cookie = ReadCookie();
            UsuarioLogado(cookie["USUARIO"]);
        }
        else
            Response.Redirect(Request.Url.ToString());
    }
      
    

    public void CriarCookie(string usuario)
    {
        HttpCookie cookie = new HttpCookie("Login");
        cookie.Values.Add("USUARIO", usuario);
        cookie.Expires = DateTime.Now.AddMinutes(35);
        this.Page.Response.AppendCookie(cookie); 
    }

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

    public void UsuarioLogado(string usuario)
    {
        StringBuilder link = new StringBuilder();
        if (userlg.VerificarAdmin(usuario))
        {
            link.Append("<a href=\"AdminControl.aspx?Usuario=" + usuario + "\">" + usuario + "</a>");
        }
        else
        {
            link.Append("<a href=\"Page_Admin_Usuario.aspx?Usuario=" + usuario + "\">" + usuario + "</a>");
        }
        txtboxUser.Visible = false;
        txtboxSenha.Visible = false;
        lblSenha.Text = link.ToString() + " <- editar conta";
        lblUser.Text = "Bem-Vindo";
        btnLogar.Visible = false;
        btnSair.Visible = true;
    }


    protected void btnSair_Click1(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);
        Response.Redirect("Page_Home.aspx");
    }
}
