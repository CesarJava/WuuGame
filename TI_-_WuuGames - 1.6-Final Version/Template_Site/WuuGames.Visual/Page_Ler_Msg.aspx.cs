using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class Page_Ler_Msg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MensagemLogica msgs = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        MensagemModelo mensagem = new MensagemModelo();
        mensagem = msgs.RecuperarMensagensPorUsuario(Request.QueryString["Usuario"]).First<MensagemModelo>();
        lblUsuario.Text = mensagem.NomeUserManda;
        txtAssunto.Enabled = false;
        txtAssunto.Text = mensagem.AssuntoMensagem;
        txtMensagem.Enabled = false;
        txtMensagem.Text = mensagem.TextoMensagem;

    }
}