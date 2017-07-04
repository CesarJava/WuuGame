using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Business;
using WuuGames.Modelo;

public partial class NovoAnuncio : System.Web.UI.Page
{
    AnuncioLogica AnuncioBusiness = null;
    string NomeTipo = "Vestuario";

    protected void Page_Load(object sender, EventArgs e)
    {
        AnuncioBusiness = new AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
    }
    
    protected void btnPublicar_Click(object sender, EventArgs e)
    {

    }
    public void CriarCookie(string usuario, string senha)
    {
        HttpCookie cookie = new HttpCookie("Login");
        cookie.Values.Add("USUARIO", usuario);
        cookie.Values.Add("SENHA", senha);
        cookie.Expires = DateTime.Now.AddHours(1);
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
    protected void btnPublicar_Click1(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Enabled = true;
        RequiredFieldValidator2.Enabled = true;
        RequiredFieldValidator3.Enabled = true;
        RequiredFieldValidator4.Enabled = true;
        HttpCookie cookie = ReadCookie();
        AnuncioModelo anuncio = new AnuncioModelo();
        UsuarioLogica usuario = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        anuncio.DescricaoAnuncio = txtDesc.Text;
        anuncio.ValorUnidade = Convert.ToDouble(txtValor.Text);
        anuncio.QuantidadeEstoque = Convert.ToInt32(txtQte.Text);
        anuncio.IdVendedor = usuario.RecuperarUsuarioPorLogin(cookie["USUARIO"]).Id;
        anuncio.IdTipo = AnuncioBusiness.RecuperarIdTipoPorNome(NomeTipo);
        anuncio.NomeAnuncio = txtNome.Text;
        if (ImgUpload.HasFile)
        {
            ImagemModelo imagem = new ImagemModelo();
            ImgUpload.SaveAs(Server.MapPath("~/images/Anuncios/" + ImgUpload.FileName));
            imagem.NomeImagem = ImgUpload.FileName;
            imagem.CaminhoImagem = ("~/images/Anuncios/" + ImgUpload.FileName).ToString();
            ImagemLogica businessImagem = new ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            businessImagem.CadastrarNova(imagem);
            anuncio.IdImagem = businessImagem.RecuperarIdPorNome(imagem.NomeImagem);
        }

        if (RadioButton1.Checked)
            NomeTipo = "Vestuario";
        if (RadioButton2.Checked)
            NomeTipo = RadioButton2.Text;
        if (RadioButton3.Checked)
            NomeTipo = RadioButton3.Text;
        if (RadioButton4.Checked)
            NomeTipo = RadioButton4.Text;

        AnuncioBusiness.CadastrarNovo(anuncio);
        List<int> IdsPag = new List<int>();
        if (chcbxCartao.Checked)
            IdsPag.Add(1);
        if (chcbxDeposito.Checked)
            IdsPag.Add(2);
        if (chcbxTroca.Checked)
            IdsPag.Add(3);
        AnuncioBusiness.CadastrarFormasPagamento(AnuncioBusiness.RecuperarIdPorNome(anuncio.NomeAnuncio), IdsPag);
        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void RadioButton4_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void chcbxCartao_CheckedChanged(object sender, EventArgs e)
    {
        
    }
    protected void chcbxDeposito_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {

    }
}