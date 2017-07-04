using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PostagemLogica postBusiness = new PostagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        List<PostagemModelo> ListaModelo = null;
        ListaModelo = postBusiness.RecuperarRecentes();
        PostagemModelo[] Posts = new PostagemModelo[ListaModelo.Count];
        int ind = 0;
        foreach (PostagemModelo p in ListaModelo)
        {
            Posts[ind] = p;
            ind++;
        }

        foreach (string s in Posts[0].NomeGenero)
        {
            lblCategoriapost1.Text += s + "  ";
        }
        lbldatapost1.Text = Posts[0].Data;
        lblresumopost1.Text = Posts[0].Subtitulo;
        lblTituloPost1.Text = Posts[0].Titulo;
        lbluserpost1.Text = Posts[0].NomeUser;
        foreach (string s in Posts[1].NomeGenero)
        {
            lblCategoriapost2.Text += s + "  ";
        }
        lblDatapost2.Text = Posts[1].Data;
        lblResumoPost2.Text = Posts[1].Subtitulo;
        lblTitulopost2.Text = Posts[1].Titulo;
        lblUserpost2.Text = Posts[1].NomeUser;

        
    }
    protected void LkbtnPost1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Post.aspx?Titulo=" + lblTituloPost1.Text);
        
    }
    protected void LkbtnPost2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Post.aspx?Titulo=" + lblTitulopost2.Text);
    }
}