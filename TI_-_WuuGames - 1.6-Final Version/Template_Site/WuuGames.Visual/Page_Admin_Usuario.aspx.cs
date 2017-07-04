using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class PageAdminUser : System.Web.UI.Page
{
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

    UsuarioModelo UsuarioAtualiza = null;

    public string ConverteMes(int NumeroMes)
    {
        switch (NumeroMes)
        {
            case 1:
                return "Janeiro";
            case 2:
                return "Fevereiro";
            case 3:
                return "Março";
            case 4:
                return "Abril";
            case 5:
                return "Maio";
            case 6:
                return "Junho";
            case 7:
                return "Julho";
            case 8:
                return "Agosto";
            case 9:
                return "Setembro";
            case 10:
                return "Outubro";
            case 11:
                return "Novembro";
            case 12:
                return "Dezembro";
            default:
                throw new Exception("Mês inválido");
        }
    }

    public int ConverteMes(string NomeMes)
    {
        switch (NomeMes)
        {
            case "Janeiro":
                return 1;
            case "Fevereiro":
                return 2;
            case "Março":
                return 3;
            case "Abril":
                return 4;
            case "Maio":
                return 5;
            case "Junho":
                return 6;
            case "Julho":
                return 7;
            case "Agosto":
                return 8;
            case "Setembro":
                return 9;
            case "Outubro":
                return 10;
            case "Novembro":
                return 11;
            case "Dezembro":
                return 12;
            default:
                throw new Exception("Mês inválido");
        }
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator5.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
        RequiredFieldValidator6.Enabled = false;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        PnlInfoGerais.Visible = true;
        PnlGereComent.Visible = false;
        pnlMsgsEmissora.Visible = false;
        GridView1.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
       grdViewEmissorr.Visible = false;
        HttpCookie cookie = ReadCookie();
        UsuarioLogica userBusiness = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        UsuarioAtualiza = userBusiness.RecuperarUsuarioPorLogin(cookie["USUARIO"]);
        txtCPF.Text = UsuarioAtualiza.CPF;
        txtEmail.Text = UsuarioAtualiza.Email;      
        txtlogin.Text = UsuarioAtualiza.Login;
        txtNome.Text = UsuarioAtualiza.Nome;
        txtRg.Text = UsuarioAtualiza.RG;

        List<int> dias = new List<int>();
        for (int i = 1; i < 32; i++)
        {
            dias.Add(i);
        }
        List<string> meses = new List<string>();
        #region Adicionar meses
        {
            meses.Add("Janeiro");
            meses.Add("Fevereiro");
            meses.Add("Março");
            meses.Add("Abril");
            meses.Add("Maio");
            meses.Add("Junho");
            meses.Add("Julho");
            meses.Add("Agosto");
            meses.Add("Setembro");
            meses.Add("Outubro");
            meses.Add("Novembro");
            meses.Add("Dezembro");
        }
        #endregion

        List<int> anos = new List<int>();
        for (int i = Convert.ToInt32(DateTime.Now.ToString("yyyy")); i >= 1930; i--)
        {
            anos.Add(i);
        }
        DropDia.DataSource = dias;
        DropDia.DataBind();
        DropMes.DataSource = meses;
        DropMes.DataBind();
        DropAno.DataSource = anos;
        DropAno.DataBind();
        DateTime dataNascimento = DateTime.Parse(UsuarioAtualiza.DataNasc);
        DropAno.SelectedValue = dataNascimento.Year.ToString();
        DropDia.SelectedValue = dataNascimento.Day.ToString();
        DropMes.SelectedValue = ConverteMes(dataNascimento.Month);        
    }
    ComentarioLogica business = new ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    protected void Button1_Click(object sender, EventArgs e)
    {
        PnlGereComent.Visible = true;
        GridView1.Visible = true;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
       grdViewEmissorr.Visible = false;
       PnlAlterarSenha.Visible = false;
       pnlGerenciarAnuncios.Visible = false;
        HttpCookie cookie = ReadCookie();
        GridView1.DataSource = business.RecuperarComentariosPorUsuario(cookie["USUARIO"]);
        GridView1.DataBind();
    }

    protected void BtnSalvar_Click(object sender, EventArgs e)
    {
        try
        {
            UsuarioLogica userBusiness = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            HttpCookie cookie = ReadCookie();
            UsuarioAtualiza = userBusiness.RecuperarUsuarioPorLogin(cookie["USUARIO"]);
            UsuarioAtualiza.CPF = txtCPF.Text;
            UsuarioAtualiza.Email = txtEmail.Text;         
            UsuarioAtualiza.Login = txtlogin.Text;
            UsuarioAtualiza.Nome = txtNome.Text;
            UsuarioAtualiza.RG = txtRg.Text;
            DateTime dataNasci = DateTime.Parse(DropDia.SelectedValue + DropMes.SelectedValue + DropAno.SelectedValue);
            UsuarioAtualiza.DataNasc = dataNasci.ToString("yyyy-MM-dd");
            userBusiness.AtualizaDados(UsuarioAtualiza);
        }
        catch (Exception ex)
        {

        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("Postagem.aspx?Titulo=" + GridView1.SelectedRow.Cells[1].Text);
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnNegociação_Click(object sender, EventArgs e)
    {
        PnlGereComent.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = true;
        GridView1.Visible = false;
       grdViewEmissorr.Visible = false;
       pnlReceptor.Visible = false;
       PnlAlterarSenha.Visible = false;
       pnlGerenciarAnuncios.Visible = false;
        
    }
    MensagemLogica mensagem = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
    protected void btnMensagens_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();
        grdViewEmissorr.DataSource = mensagem.RecuperarMensagensPorUsuarioEmissor(cookie["USUARIO"]);
        grdViewEmissorr.DataBind();
        grdViewReceptor.DataSource = mensagem.RecuperarMensagensPorUsuarioReceptor(cookie["USUARIO"]);
        grdViewReceptor.DataBind();
        PnlGereComent.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlReceptor.Visible = true;
        pnlMsgsEmissora.Visible = true;
        GridView1.Visible = false;
        grdViewEmissorr.Visible = true;
        grdViewReceptor.Visible = true;
        PnlAlterarSenha.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       
      
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument.ToString());
        if (e.CommandName == "Apagar")
        {
            HttpCookie cookie = ReadCookie();
            ComentarioLogica logica = new ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            logica.Deletar(Convert.ToInt32(GridView1.Rows[index].Cells[0].Text));
            GridView1.DataSource = business.RecuperarComentariosPorUsuario(cookie["USUARIO"]);
            GridView1.DataBind();
            
           // Response.Redirect(Request.Url.ToString());
        }
    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);
        Response.Redirect("Page_Home.aspx");
        
    }
    public void CriarCookie(string usuario)
    {
        HttpCookie cookie = new HttpCookie("Login");
        cookie.Values.Add("USUARIO", usuario);
        cookie.Expires = DateTime.Now.AddMinutes(35);
        this.Page.Response.AppendCookie(cookie);
    }
    protected void grdViewEmissorr_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         int index = Convert.ToInt32(e.CommandArgument.ToString());
         if (e.CommandName == "lerMensagem")
         {
             Response.Redirect("Page_Ler_Msg.aspx?Usuario=" + grdViewEmissorr.Rows[index].Cells[3].Text);

         }
         if (e.CommandName == "Cancelar")
         {
             HttpCookie cookie = ReadCookie();
           MensagemLogica msg = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
             msg.CancelarMensagem(Convert.ToInt32(grdViewEmissorr.Rows[index].Cells[0].Text));
             grdViewEmissorr.DataSource = msg.RecuperarMensagensPorUsuario(cookie["USUARIO"]);
             grdViewEmissorr.DataBind();
         }
    }
    protected void btnTrocarSenha_Click(object sender, EventArgs e)
    {
        PnlAlterarSenha.Visible = true;
        PnlGereComent.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlReceptor.Visible = false;
        pnlMsgsEmissora.Visible = false;
        GridView1.Visible = false;
        grdViewEmissorr.Visible = false;
        grdViewReceptor.Visible = false;
        Label21.Visible = false;
        Label22.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
        
      
      
        
    }
    protected void btnTrocarSenha1_Click(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Enabled = true;
        RequiredFieldValidator5.Enabled = true;
        RequiredFieldValidator2.Enabled = true;
        RequiredFieldValidator4.Enabled = true;
        RequiredFieldValidator6.Enabled = true;
        UsuarioLogica userBusiness = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        HttpCookie cookie = ReadCookie();
        if (txtSenhaAtual.Text == userBusiness.RecuperarUsuarioPorLogin(cookie["USUARIO"]).Senha)
        {
            if (txtNovaSenha.Text == txtNovaSenhaConfirma.Text)
            {
                try
                {
                    UsuarioModelo usuario = new UsuarioModelo();
                    usuario = userBusiness.RecuperarUsuarioPorLogin(cookie["USUARIO"]);
                    DateTime datauser = DateTime.Parse(usuario.DataNasc);
                    usuario.DataNasc = datauser.ToString("yyyy-MM-dd");
                    usuario.Senha = txtNovaSenha.Text;
                    userBusiness.AtualizaDados(usuario);
                    Label21.Visible = true;
                    Label21.Text = " Senha Alterada";
                }
                catch (Exception mula)
                {
                    throw mula;
                }
            }
            else
                Label22.Visible = true;
                Label22.Text = "*Senhas Não Batem";
        }
        else
            Label22.Visible = true;
            Label22.Text = "*Senha Atual Errada!";


            RequiredFieldValidator1.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
    }
    protected void btnMeusAnuncios_Click(object sender, EventArgs e)
    {
        AnuncioLogica anuncios = new AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        HttpCookie cookie = ReadCookie();
        grdGereAnuncios.DataSource = anuncios.RecuperarAnunciosPorUsuario(cookie["USUARIO"]);
        grdGereAnuncios.DataBind();
        PnlGereComent.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlReceptor.Visible = false;
        pnlMsgsEmissora.Visible = false;
        GridView1.Visible = false;
        grdViewEmissorr.Visible = false;
        grdViewReceptor.Visible = false;
        PnlAlterarSenha.Visible = false;
        pnlGerenciarAnuncios.Visible = true;

    }
    protected void btnNovoAnuncio_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Novo_Anuncio.aspx");
    }
    protected void grdViewReceptor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());

        if (e.CommandName == "lerMensagem")
        {
            Response.Redirect("Page_Ler_Msg.aspx?Usuario=" + grdViewReceptor.Rows[index].Cells[3].Text);

        }
    }
}