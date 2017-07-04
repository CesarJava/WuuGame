using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Text.RegularExpressions;
using WuuGames.Business;
using WuuGames.Modelo;


public partial class NewPost : System.Web.UI.Page
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
        HttpCookie cookie = ReadCookie();
        if (userlg.VerificarAdmin(cookie["USUARIO"]))
        {
           
        }
        else
            Response.Redirect("Page_Home.aspx");
    }

   

    protected void Button1_Click(object sender, EventArgs e)
    {
        PostagemLogica businessPost = new PostagemLogica(WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        PostagemModelo postagem = new PostagemModelo();
        postagem.Conteudo = new System.Text.StringBuilder();
        postagem.Conteudo.Append(txtConteudo.Text);
        postagem.Data = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        HttpCookie cookie = ReadCookie();
        UsuarioLogica userBusiness = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        postagem.IdUser = 1000000;        
        postagem.NomeGenero = new List<string>();
        postagem.NomeAssunto = new List<string>();
        postagem.Titulo = txtTitulo.Text;
        postagem.VotoNeg = 0;
        postagem.VotoPos = 0;
        postagem.Subtitulo = txtSubtitulo.Text;


        #region Despolui
        if (CheckAcao.Checked)
            postagem.NomeGenero.Add("Acao");
        if (CheckArcade.Checked)
            postagem.NomeGenero.Add("Arcade");
        if (CheckAventura.Checked)
            postagem.NomeGenero.Add("Aventura");
        if (CheckCorrida.Checked)
            postagem.NomeGenero.Add("Corrida");
        if (CheckEsportes.Checked)
            postagem.NomeGenero.Add("Esportes");
        if (CheckEstrategia.Checked)
            postagem.NomeGenero.Add("Estrategia");
        if (CheckFiccaoCie.Checked)
            postagem.NomeGenero.Add("Ficcao Cientifica");
       
        if (CheckLuta.Checked)
            postagem.NomeGenero.Add("Luta");
        if (CheckMMORPG.Checked)
            postagem.NomeGenero.Add("MMORPG");
        if (CheckMultiPlayer.Checked)
            postagem.NomeGenero.Add("Multi Player");
        if (CheckRPG.Checked)
            postagem.NomeGenero.Add("RPG");
        if (CheckSimuladores.Checked)
            postagem.NomeGenero.Add("Simuladores");
        if (CheckTerror.Checked)
            postagem.NomeGenero.Add("Terror");

        if (CheckAstDicas.Checked)
            postagem.NomeAssunto.Add("Dicas");
        if (CheckAstDownloads.Checked)
            postagem.NomeAssunto.Add("Downloads");
        if (CheckAstForum.Checked)
            postagem.NomeAssunto.Add("Forum");
        if (CheckAstNovidades.Checked)
            postagem.NomeAssunto.Add("Novidades");
        if (CheckAstOutros.Checked)
            postagem.NomeAssunto.Add("Outros");
        #endregion

        if (FileUpload1.HasFile)
        {
            try
            {
                ImagemModelo Imagem = new ImagemModelo();
                FileUpload1.SaveAs(Server.MapPath("~/images/Post/" + FileUpload1.FileName));
                Imagem.NomeImagem = FileUpload1.FileName;
                Imagem.CaminhoImagem = "~/images/Post/" + FileUpload1.FileName;
                ImagemLogica businessImagem = new ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
                businessImagem.CadastrarNova(Imagem);
                postagem.IdImagem = businessImagem.RecuperarIdPorNome(Imagem.NomeImagem);
            }
            catch (Exception err)
            {

            }
        }

        businessPost.CadastrarPostagem(postagem);
        businessPost.CadastrarGeneroDePostagem(postagem.NomeGenero, businessPost.RecuperarIdPorTitulo(postagem.Titulo));
        businessPost.CadastrarAssuntoDePostagem(postagem.NomeAssunto, businessPost.RecuperarIdPorTitulo(postagem.Titulo));
        Response.Redirect("~/Page_Novo_Postagem.aspx");


    }
    String BBCode(string strTextToReplace)
    {

        ////Define regex 
        Regex regExp;

        ////Regex for URL tag without anchor 
        regExp = new Regex(@"\[url\]([^\]]+)\[\/url\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<a href=\"$1\">$1</a>");

        ////Regex for URL with anchor 
        regExp = new Regex(@"\[url=([^\]]+)\]([^\]]+)\[\/url\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<a href=\"$1\">$2</a>");

        ////Image regex 
        regExp = new Regex(@"\[img\]([^\]]+)\[\/img\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<img src=\"$1\" />");

        ////Bold text 
        regExp = new Regex(@"\[b\](.+?)\[\/b\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<b>$1</b>");

        ////Italic text 
        regExp = new Regex(@"\[i\](.+?)\[\/i\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<i>$1</i>");

        ////Underline text 
        regExp = new Regex(@"\[u\](.+?)\[\/u\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<u>$1</u>");

        ////Font size
        regExp = new Regex(@"\[size=([^\]]+)\]([^\]]+)\[\/size\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<span style=\"font-size: $1px\">$2</span>");

        ////Font color
        regExp = new Regex(@"\[color=([^\]]+)\]([^\]]+)\[\/color\]");
        strTextToReplace = regExp.Replace(strTextToReplace, "<span style=\"color: $1\">$2</span>");

        return strTextToReplace;
    }
    protected void CheckBox13_CheckedChanged(object sender, EventArgs e)
    {

    }
}