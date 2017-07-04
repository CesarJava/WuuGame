using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class Page_Anuncio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Request.QueryString["AnuncioId"] != "")
        {
            AnuncioLogica anun = new AnuncioLogica(System.Configuration.ConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            AnuncioModelo anuncio = new AnuncioModelo();
            anuncio.IdAnuncio = Convert.ToInt32(Request.QueryString["AnuncioId"]);

            var i = from x in anun.RecuperarTodos()
                    where x.IdAnuncio == Convert.ToInt32(Request.QueryString["AnuncioId"])
                    select x;

            anuncio = i.First<AnuncioModelo>();
     
                    lblNomeAnuncio.Text = anuncio.NomeAnuncio;
                    lblAnunciante.Text = anuncio.NomeVendedor;
                    lblPreco.Text += anuncio.ValorUnidade;
                    lblQte.Text += anuncio.QuantidadeEstoque;
                    txtDesc.Text = anuncio.DescricaoAnuncio;
                    Image1.ImageUrl = "images/Anuncios/" + anuncio.NomeImagem;
            
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {        
        Response.Redirect("Page_Novo_Mensagem.aspx?Usuario=" + lblAnunciante.Text);
    }
    protected void txtDesc_TextChanged(object sender, EventArgs e)
    {

    }
}