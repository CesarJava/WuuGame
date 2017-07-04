using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;

namespace WuuGames.DAO
{
    public class ComentarioDAO
    {
        Conexao conexao = null;
        UsuarioDAO usuarioDAO = null;
        public ComentarioDAO(string StringConexao)
        {
            conexao = new Conexao(StringConexao);
            usuarioDAO = new UsuarioDAO(StringConexao);
        }

        public void Inserir(ComentarioModelo comment)
        {
            string query = "insert into tb_Comentario values(";
            query += "0," + comment.IdUser + "," + comment.IdPost + ",'" +
                     comment.Data + "','" + comment.Corpo + "'," +
                     "0,0);";
            conexao.ExecutarSemRetorno(query);
        }

        public List<ComentarioModelo> RecuperarTodos()
        {            
            List<ComentarioModelo> listaComentarios = new List<ComentarioModelo>();
            string query = "select * from tb_comentario";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                ComentarioModelo comment = new ComentarioModelo();
                comment.Corpo = dr["Coment_Corpo"].ToString();
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Coment_Data"].ToString(), out dataCorreta);
                comment.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                comment.IdComentario = Convert.ToInt32(dr["Coment_Id"].ToString());
                comment.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                comment.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                comment.VotoNeg = Convert.ToInt32(dr["Coment_VotoNeg"].ToString());
                comment.VotoPos = Convert.ToInt32(dr["Coment_VotoPos"].ToString());
                comment.NomeUser = usuarioDAO.RecuperarNomePorId(comment.IdUser);
                string joinquery = "select p.Post_Titulo from " +
                                    "tb_comentario c inner join tb_postagem p on p.Post_Id = c.Post_Id " +
                                    "where c.Coment_Id =" + comment.IdComentario.ToString();
                foreach (DataRow titulo in conexao.ExecutarComRetorno(joinquery).AsEnumerable())
                {
                    comment.TituloPost = titulo["Post_Titulo"].ToString();
                }
                listaComentarios.Add(comment);
            }

            return listaComentarios;
        }

        public List<ComentarioModelo> RecuperarComentariosPorPost(string TituloPost)
        {
            List<ComentarioModelo> listaComentarios = new List<ComentarioModelo>();
            string query = "select c.Coment_Id, u.User_Login, c.Coment_data, c.coment_corpo, " + 
                           "c.Coment_votopos, c.Coment_Votoneg "+ 
                           "from tb_comentario c inner join tb_usuario u on u.User_id = c.User_Id "+ 
                           "inner join tb_postagem p on p.post_id = c.post_id " + 
                           "where p.Post_Titulo = '" + TituloPost + "';";

            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                ComentarioModelo comment = new ComentarioModelo();
                comment.Corpo = dr["Coment_Corpo"].ToString();
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Coment_Data"].ToString(), out dataCorreta);
                comment.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                comment.IdComentario = Convert.ToInt32(dr["Coment_Id"].ToString());
                comment.VotoNeg = Convert.ToInt32(dr["Coment_VotoNeg"].ToString());
                comment.VotoPos = Convert.ToInt32(dr["Coment_VotoPos"].ToString());
                comment.NomeUser = dr["User_Login"].ToString();
                listaComentarios.Add(comment);
            }

            return listaComentarios;
        }

        public void Deletar(int idComentario)
        {
            string query = "delete from tb_comentario where coment_id =" + idComentario;
            conexao.ExecutarSemRetorno(query);
        }
        public List<ComentarioModelo> RecuperarComentariosPorUsuario(string Login)
        {
            List<ComentarioModelo> listaComentarios = new List<ComentarioModelo>();
            string query = "select c.Coment_Id, u.User_Login, c.Coment_data, c.coment_corpo, " +
                           "c.Coment_votopos, c.Coment_Votoneg " +
                           "from tb_comentario c inner join tb_usuario u on u.User_id = c.User_Id " +
                           "inner join tb_postagem p on p.post_id = c.post_id " +
                           "where u.user_Login = '" + Login + "';";

            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                ComentarioModelo comment = new ComentarioModelo();

                comment.Corpo = dr["Coment_Corpo"].ToString();
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Coment_Data"].ToString(), out dataCorreta);
                comment.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                comment.IdComentario = Convert.ToInt32(dr["Coment_Id"].ToString());
                comment.VotoNeg = Convert.ToInt32(dr["Coment_VotoNeg"].ToString());
                comment.VotoPos = Convert.ToInt32(dr["Coment_VotoPos"].ToString());
                comment.NomeUser = dr["User_Login"].ToString();
                string joinquery = "select p.Post_Titulo from " +
                                    "tb_comentario c inner join tb_postagem p on p.Post_Id = c.Post_Id " +
                                    "where c.Coment_Id =" + comment.IdComentario.ToString();
                foreach (DataRow titulo in conexao.ExecutarComRetorno(joinquery).AsEnumerable())
                {
                    comment.TituloPost = titulo["Post_Titulo"].ToString();
                }
                listaComentarios.Add(comment);

            }

            return listaComentarios;
        }
    }
}
