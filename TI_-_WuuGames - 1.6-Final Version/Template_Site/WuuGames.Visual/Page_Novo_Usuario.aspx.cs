using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WuuGames.Modelo;
using WuuGames.Business;

public partial class CadastroUsuario : System.Web.UI.Page
{
    static string StringConexaoBanco = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString();

    public void Limpar()
    {
        txtconfirmarsenha.Text = "";
        txtCPF.Text = "";
        txtEmail.Text = "";
        txtInteresses.Text = "";
        txtlogin.Text = "";
        txtNome.Text = "";
        txtRg.Text = "";
        txtSenha.Text = "";
        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
    }

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
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
        ViewState["StringConexao"] = StringConexaoBanco;        
        if (!IsPostBack)
        {
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
            for (int i = Convert.ToInt32(DateTime.Now.ToString("yyyy")); i >=1930 ; i--)
            {
                anos.Add(i);
            }
            DropDia.DataSource = dias;
            DropDia.DataBind();
            DropMes.DataSource = meses;
            DropMes.DataBind();
            DropAno.DataSource = anos;
            DropAno.DataBind();
        }
        
        
    }
    protected void BtnCadastrar_Click(object sender, EventArgs e)
    {
        RequiredFieldValidator1.Enabled = true;
        RequiredFieldValidator2.Enabled = true;
        RequiredFieldValidator3.Enabled = true;
        RequiredFieldValidator4.Enabled = true;
        
        try
        {
            UsuarioModelo User = new UsuarioModelo();
            UsuarioLogica business = new UsuarioLogica(StringConexaoBanco);
            User.Advertencias = 0;
            if (business.ValidaCPF(txtCPF.Text) == true || string.IsNullOrWhiteSpace(txtCPF.Text))
                User.CPF = txtCPF.Text;
            else return;
            User.DataNasc = DateTime.Parse(DropDia.SelectedValue.ToString() + "/" + ConverteMes(DropMes.SelectedValue.ToString()).ToString() + "/" + DropAno.SelectedValue.ToString()).ToString("yyyy-MM-dd");
            User.Id = 0;
            User.IdEstado = 1;
            User.Interesses = txtInteresses.Text;            
            User.Login = txtlogin.Text;
            User.NivelAcessoId = 1;
            User.Nome = txtNome.Text;
            User.Pontos = 0;
            User.RG = txtRg.Text;
            if (CaminhoImagem.HasFile)
            {
                try
                {
                    ImagemModelo Imagem = new ImagemModelo();
                    CaminhoImagem.SaveAs(Server.MapPath("~/images/Usuarios/" + CaminhoImagem.FileName).ToString());
                    Imagem.NomeImagem = CaminhoImagem.FileName;
                    Imagem.CaminhoImagem = "~/images/Usuarios/" + CaminhoImagem.FileName;
                    ImagemLogica businessImagem = new ImagemLogica(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SiteConnectionString"].ToString());
                    businessImagem.CadastrarNova(Imagem);
                    User.IdImagem = businessImagem.RecuperarIdPorNome(Imagem.NomeImagem);
                }
                catch (Exception err)
                {
                    lblExcecao.Text = err.Message.ToString();
                }
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                throw new Exception("SENHA NÃO PODE FICAR EM BRANCO");
            }
            else if (txtSenha.Text == txtconfirmarsenha.Text)
            {
                User.Senha = txtSenha.Text;
            }
            else
            {
                throw new Exception("As senhas informadas são diferentes");
            }

                
            User.UltimoAcesso = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            User.Email = txtEmail.Text;
            business.RegistrarNovo(User);
            Limpar();
            lblExcecao.Text = "PARABÉNS! SEU CADASTRO FOI REALIZADO COM SUCESSO!";
        }
        catch (Exception ex)
        {
            lblExcecao.Text = ex.Message;
        }

        RequiredFieldValidator1.Enabled = false;
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;        
    }
}