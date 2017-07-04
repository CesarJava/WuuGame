using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Business;
using WuuGames.Modelo;

public partial class AdminControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        UsuarioLogica logica = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());

        HttpCookie cookie = ReadCookie();
        if (logica.VerificarAdmin(cookie["USUARIO"]))
        {
            PnlComents.Visible = false;
            PnlAnuncios.Visible = false;
            PnlUsers.Visible = false;
            PnlGereComent.Visible = false;
            pnlGerenciarAnuncios.Visible = false;
            PnlInfoGerais.Visible = false;
            pnlMsgsEmissora.Visible = false;
            pnlReceptor.Visible = false;
            PnlAlterarSenha.Visible = false;
        }
        else
            Response.Redirect("Page_Home.aspx");

    }
    protected void btnNewPost_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Novo_Postagem.aspx");
    }
    protected void btnComents_Click(object sender, EventArgs e)
    {
        ComentarioLogica coments = new ComentarioLogica(ConString);
        GrdVwComents.DataSource = coments.RecuperarTodos();
        GrdVwComents.DataBind();
   
        PnlComents.Visible = true;
        PnlAnuncios.Visible = false;
        PnlUsers.Visible = false;
        PnlGereComent.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
        pnlReceptor.Visible = false;      
        PnlAlterarSenha.Visible = false;
      

    }
    protected void btnAnuncios_Click(object sender, EventArgs e)
    {
        AnuncioLogica anuncios = new AnuncioLogica(ConString);
        GrdVwAnuncios.DataSource = anuncios.RecuperarTodos();
        GrdVwAnuncios.DataBind();
        PnlComents.Visible = false;
        PnlAnuncios.Visible = false;
        PnlUsers.Visible = false;
        PnlGereComent.Visible = false;
        pnlGerenciarAnuncios.Visible = true;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
        pnlReceptor.Visible = false;
        PnlAlterarSenha.Visible = false;
    }
    string ConString = System.Configuration.ConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString();
    protected void btnUsers_Click(object sender, EventArgs e)
    {
        UsuarioLogica usuarios = new UsuarioLogica(ConString);
        PnlComents.Visible = false;
        PnlAnuncios.Visible = false;
        PnlUsers.Visible = true;
        PnlGereComent.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
        pnlReceptor.Visible = false;
        PnlAlterarSenha.Visible = false;

        GrdVwUsuarios.DataSource = usuarios.RecuperarTodos();
        GrdVwUsuarios.DataBind();

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

    protected void GrdVwComents_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ComentarioLogica deletar = new ComentarioLogica(ConString);
        deletar.Deletar(Convert.ToInt32(GrdVwComents.SelectedRow.Cells[0].Text));
    }
    protected void GrdVwComents_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());



        if (e.CommandName == "Apagar")
        {
            HttpCookie cookie = ReadCookie();
            ComentarioLogica logica = new ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            logica.Deletar(Convert.ToInt32(GrdVwComents.Rows[index].Cells[0].Text));
            GrdVwComents.DataSource = logica.RecuperarTodos();
            GrdVwComents.DataBind();

            // Response.Redirect(Request.Url.ToString());
        }
    }
    protected void GrdVwAnuncios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());



        if (e.CommandName == "Apagar")
        {
            HttpCookie cookie = ReadCookie();
            AnuncioLogica logica = new AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            logica.Deletar(Convert.ToInt16(GrdVwAnuncios.Rows[index].Cells[0].Text));
            GrdVwAnuncios.DataSource = logica.RecuperarTodos();
            GrdVwAnuncios.DataBind();
        }
    }
    protected void GrdVwAnuncios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdVwUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument.ToString());



        if (e.CommandName == "Apagar")
        {
            HttpCookie cookie = ReadCookie();
            UsuarioLogica logica = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            logica.Deletar(Convert.ToInt32(GrdVwUsuarios.Rows[index].Cells[0].Text));
            GrdVwAnuncios.DataSource = logica.RecuperarTodos();
            GrdVwAnuncios.DataBind();
        }
        
        if (e.CommandName == "AlterarNivel")
        {
            UsuarioLogica logica = new UsuarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
            logica.alterarNivel(GrdVwUsuarios.Rows[index].Cells[1].Text , GrdVwUsuarios.Rows[index].Cells[3].Text);
            GrdVwUsuarios.DataSource = logica.RecuperarTodos();
            GrdVwUsuarios.DataBind();

        }
    }
    protected void GrdVwUsuarios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnInfo_Click(object sender, EventArgs e)
    {
        PnlInfoGerais.Visible = true;
        PnlGereComent.Visible = false;
        pnlMsgsEmissora.Visible = false; 
        pnlGerenciarAnuncios.Visible = false;
        PnlAlterarSenha.Visible = false;
        PnlAnuncios.Visible = false;
        pnlReceptor.Visible = false;
        PnlUsers.Visible = false;
        PnlComents.Visible = false;
       
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
    
    protected void btnGerenciar_Click(object sender, EventArgs e)
    {
        ComentarioLogica business = new ComentarioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        PnlComents.Visible = false;
        PnlAnuncios.Visible = false;
        PnlUsers.Visible = false;
        PnlGereComent.Visible = true;
        pnlGerenciarAnuncios.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
        pnlReceptor.Visible = false;
        PnlAlterarSenha.Visible = false;
        HttpCookie cookie = ReadCookie();
        GridView1.DataSource = business.RecuperarComentariosPorUsuario(cookie["USUARIO"]);
        GridView1.DataBind();
    }
    protected void btnMensagens_Click(object sender, EventArgs e)
    {
        HttpCookie cookie = ReadCookie();
        grdViewEmissorr.DataSource = mensagem.RecuperarMensagensPorUsuarioEmissor(cookie["USUARIO"]);
        grdViewEmissorr.DataBind();
        grdViewReceptor.DataSource = mensagem.RecuperarMensagensPorUsuarioReceptor(cookie["USUARIO"]);
        grdViewReceptor.DataBind();
        PnlComents.Visible = true;
        PnlAnuncios.Visible = false;
        PnlUsers.Visible = false;
        PnlGereComent.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = true;
        pnlReceptor.Visible = true;
        PnlAlterarSenha.Visible = false;
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
    protected void btnMeusAnuncios_Click(object sender, EventArgs e)
    {
        AnuncioLogica anuncios = new AnuncioLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
        HttpCookie cookie = ReadCookie();
        grdGereAnuncios.DataSource = anuncios.RecuperarAnunciosPorUsuario(cookie["USUARIO"]);
        grdGereAnuncios.DataBind();
        PnlComents.Visible = false;
        PnlAnuncios.Visible = true;
        PnlUsers.Visible = false;
        PnlGereComent.Visible = false;
        pnlGerenciarAnuncios.Visible = false;
        PnlInfoGerais.Visible = false;
        pnlMsgsEmissora.Visible = false;
        pnlReceptor.Visible = false;
        PnlAlterarSenha.Visible = false;
        pnlGerenciarAnuncios.Visible = true;
    }
    protected void btnNovoAnuncio_Click(object sender, EventArgs e)
    {
        Response.Redirect("Page_Novo_Anuncio.aspx");
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
    MensagemLogica mensagem = new MensagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
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

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void grdGereAnuncios_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        HttpCookie cookie = ReadCookie();
        cookie.Expires = DateTime.Now.AddDays(-1);
        Response.Cookies.Add(cookie);
        Response.Redirect("Page_Home.aspx");
    }
    protected void grdViewEmissorr_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}