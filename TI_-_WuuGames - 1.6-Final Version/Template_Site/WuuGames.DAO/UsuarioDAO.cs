using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.Modelo;
using System.Data;


namespace WuuGames.DAO
{
    public class UsuarioDAO
    {
        Conexao conexao = null;
        public UsuarioDAO(string stringConexao)
        {
            conexao = new Conexao(stringConexao);
        }

        public void Inserir(UsuarioModelo User)
        {            
            if (string.IsNullOrEmpty(VerificaLogin(User)))
            {
                string query = "insert into tb_usuario values( " +
                           "null, '" +
                           User.Nome + "','" +
                           User.Login + "','" +
                           User.Senha + "','" +
                           User.Email + "','" +
                           User.RG + "','" +
                           User.CPF + "','" +
                           User.DataNasc + "','" +
                           User.Pontos + "'," + 
                           User.IdImagem + ",0,1);";

                conexao.ExecutarSemRetorno(query);
            }
        }


        public List<UsuarioModelo> RecuperarTodos()
        {
            string query = "Select * from tb_usuario where user_id < 99999999";
            List<UsuarioModelo> Listadeusuarios = new List<UsuarioModelo>();
            foreach(DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                
                UsuarioModelo user = new UsuarioModelo();
                user.Id = Convert.ToInt32(dr["User_Id"]);
                user.Nome = dr["User_Nome"].ToString();
                user.Login = dr["User_Login"].ToString();
                user.Senha = dr["User_Senha"].ToString();
                user.Email = dr["User_Email"].ToString();
                user.RG = dr["User_RG"].ToString();
                user.CPF = dr["User_CPF"].ToString();
                DateTime data = DateTime.Parse(dr["user_DataNasc"].ToString());
                user.DataNasc = data.ToString("dd/MM/yyyy");
                user.Pontos = Convert.ToInt32(dr["User_Pontos"]);
                user.IdImagem = Convert.ToInt32(dr["Img_Id"]);
                user.Advertencias = Convert.ToInt32(dr["User_Advertencias"]);
                user.NivelAcessoId = Convert.ToInt32(dr["NivelAcesso_Id"]);
                string join = " select nv.NivelAcesso_Nome from tb_NivelAcesso nv inner join tb_Usuario u on u.NivelAcesso_Id=nv.NivelAcesso_Id where u.User_Login ='" + user.Login + "';";

                foreach (DataRow nvname in conexao.ExecutarComRetorno(join).AsEnumerable())
                {
                    user.NivelAcesso = nvname["NivelAcesso_Nome"].ToString();
                }
              
                Listadeusuarios.Add(user);
            }
            return Listadeusuarios;

        }

        public List<UsuarioDadosUnicos> SelecionarDados()
        {
            string query = "select User_Login, User_Email, User_RG, User_Cpf from tb_usuario";
            List<UsuarioDadosUnicos> ListaDados = new List<UsuarioDadosUnicos>();
            
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                UsuarioDadosUnicos User = new UsuarioDadosUnicos();
                User.CPF = dr["User_CPF"].ToString();
                User.Email = dr["User_Email"].ToString();
                User.Login = dr["User_Login"].ToString();
                User.RG = dr["User_RG"].ToString();
                ListaDados.Add(User);                
            }
            return ListaDados;
        }

        private string VerificaLogin(UsuarioModelo User)
        {
            string Erros = "";
            foreach (UsuarioDadosUnicos us in SelecionarDados())
            {
                if (us.CPF == User.CPF)
                    Erros += "c";
                if (us.Email == User.Email)
                    Erros += "e";
                if (us.Login == User.Login)
                    Erros += "l";
                if (us.RG == User.RG)
                    Erros += "r";
            }
            return Erros;
        }

        public string RecuperarNomePorId(int idUser)
        {
            string query = "select User_Login from tb_usuario where user_id = " + idUser + ";";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return dr["User_Login"].ToString();
            }
            throw new Exception("Usuário inexistente");
        }

        public void AtualizarDados(UsuarioModelo user)
        {
            string query = "update tb_usuario set user_nome = '" + user.Nome + "', " +
                           "user_login = '" + user.Login + "', " +
                           "user_senha = '" + user.Senha + "', " +
                           "user_email = '" + user.Email + "', " +
                           "user_Rg = '" + user.RG + "', " +
                           "user_CPF = '" + user.CPF + "', " +
                           "user_DataNasc = '" + user.DataNasc + "', " +
                           "img_id = " + user.IdImagem + " ," +
                           "NivelAcesso_Id =" + user.NivelAcessoId + " "+
                           "where user_Id = " + user.Id + ";";

            conexao.ExecutarSemRetorno(query);
        }

        public UsuarioModelo RecuperarUsuarioPorId(int IdUser)
        {
            UsuarioModelo user = new UsuarioModelo();
            string query = "select * from tb_usuario where user_id = " + IdUser + ";";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                DateTime data = new DateTime();
                user.Advertencias = Convert.ToInt32(dr["User_Advertencias"].ToString());
                user.CPF = dr["User_CPF"].ToString();
                DateTime.TryParse(dr["User_DataNasc"].ToString(), out data);
                user.DataNasc = data.ToString("dd/MM/yyyy");
                user.Email = dr["User_Email"].ToString();
                user.Id = Convert.ToInt32(dr["User_Id"].ToString());
                user.IdEstado = Convert.ToInt32(dr["Est_Id"].ToString());
                user.Login = dr["User_Login"].ToString();
                //user.NivelAcesso = Convert.ToInt32(dr["User_NivelAcesso"].ToString());
                user.Nome = dr["User_Nome"].ToString();
                user.Pontos = Convert.ToInt32(dr["User_Pontos"].ToString());
                user.RG = dr["User_RG"].ToString();
                user.Senha = dr["User_Senha"].ToString();
                DateTime.TryParse(dr["User_UltimoAcesso"].ToString(), out data);
                user.UltimoAcesso = data.ToString("dd/MM/yyyy hh:mm:ss");
                user.IdImagem = Convert.ToInt32(dr["img_id"].ToString());
                user.NivelAcessoId = Convert.ToInt32(dr["NivelAcesso_Id"]);
                string join = " select nv.NivelAcesso_Nome from tb_NivelAcesso nv inner join tb_Usuario u on u.NivelAcesso_Id=nv.NivelAcesso_Id where u.User_Id = '" + IdUser + "';";
                foreach (DataRow nvname in conexao.ExecutarComRetorno(join).AsEnumerable())
                    user.NivelAcesso = nvname["NivelAcesso_Nome"].ToString();
            }
            return user;
        }

        public UsuarioModelo RecuperarUsuarioPorLogin(string LoginUser)
        {
            UsuarioModelo user = new UsuarioModelo();
            string query = "select * from tb_usuario where user_Login = '" + LoginUser + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                DateTime data = new DateTime();
                user.Advertencias = Convert.ToInt32(dr["User_Advertencias"].ToString());
                user.CPF = dr["User_CPF"].ToString();
                DateTime.TryParse(dr["User_DataNasc"].ToString(), out data);
                user.DataNasc = data.ToString("dd/MM/yyyy");
                user.Email = dr["User_Email"].ToString();
                user.Id = Convert.ToInt32(dr["User_Id"].ToString());
                //user.IdEstado = Convert.ToInt32(dr["Est_Id"].ToString());
                user.Login = dr["User_Login"].ToString();
                //user.NivelAcesso = Convert.ToInt32(dr["User_NivelAcesso"].ToString());
                user.Nome = dr["User_Nome"].ToString();
                user.Pontos = Convert.ToInt32(dr["User_Pontos"].ToString());
                user.RG = dr["User_RG"].ToString();
                user.Senha = dr["User_Senha"].ToString();
                //DateTime.TryParse(dr["User_UltimoAcesso"].ToString(), out data);
                user.UltimoAcesso = data.ToString("dd/MM/yyyy hh:mm:ss");
                user.IdImagem = Convert.ToInt32(dr["img_id"].ToString());
                user.NivelAcessoId = Convert.ToInt32(dr["NivelAcesso_Id"]);
                string join = " select nv.NivelAcesso_Nome from tb_NivelAcesso nv inner join tb_Usuario u on u.NivelAcesso_Id=nv.NivelAcesso_Id where u.User_Login = '" + LoginUser + "';";
                foreach (DataRow nvname in conexao.ExecutarComRetorno(join).AsEnumerable())
                {
                    user.NivelAcesso = nvname["NivelAcesso_Nome"].ToString();
                }
            }
            
            return user;
        }

        public bool ValidacaoLogin(string Login, string Senha)
        {
            string query = "select user_login, user_senha from tb_usuario where user_login = '" + Login.ToLower() +
                           "' and user_senha = '" + Senha + "';";
            foreach(DataRow dr in (conexao.ExecutarComRetorno(query).AsEnumerable()))
            {
                return true;
            }

            return false;
        }

        public bool ValidacaoUsuario(string Login)
        {
            string query = "select user_login from tb_usuario where user_Login = '" + Login.ToLower() + "';";

            foreach (DataRow dr in (conexao.ExecutarComRetorno(query).AsEnumerable()))
            {
                return true;
            }

            return false;
        }

        public void Deletar(int id)
        {
            string updatepost = " update tb_postagem set= 99999999 where User_Id =" + id + ";";
            conexao.ExecutarSemRetorno(updatepost);

            string updateAnuncio = "update tb_anuncio set=99999999 where User_Id=" + id + ";";
            conexao.ExecutarSemRetorno(updateAnuncio);

            string updateMensagem1 = "update tb_mensagem set = 99999999 where User_1=" + id + ";";
            conexao.ExecutarSemRetorno(updateMensagem1);

            string updateMensagem2 = "update tb_mensagem set = 99999999 where User_2=" + id + ";";
            conexao.ExecutarSemRetorno(updateMensagem2);

            string updateComentario = "update tb_comentario set=99999999 where User_Id=" + id + ";";
            conexao.ExecutarSemRetorno(updateComentario);


            string deleterUsuario = "delete from tb_usuario where User_id=" + id + ";";
            conexao.ExecutarSemRetorno(deleterUsuario);
        }

        public void alterarNivel(string Login,string NivelAcesso)
        {
            if (NivelAcesso == "Administrador")
            {
                string update = "update tb_usuario set Nivelacesso_Id=1 where User_Login ='" + Login + "';";
                conexao.ExecutarSemRetorno(update);
            }
            else if (NivelAcesso == "Usuario")
            {
                string update = "update tb_usuario set Nivelacesso_Id=2 where User_Login ='" + Login + "';";
                conexao.ExecutarSemRetorno(update);
            }
        }

        public bool VerificarAdmin(string Login)
        {
            string query = " select NivelAcesso_Id from tb_Usuario where User_Login='" + Login + "';";

            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                UsuarioModelo usuario = new UsuarioModelo();
                usuario.NivelAcessoId = Convert.ToInt32(dr["NivelAcesso_Id"]);
                if (usuario.NivelAcessoId == 2)
                {
                    return true;
                }
              

            }
            return false;
        }
    }
}
