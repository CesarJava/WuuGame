using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;

namespace WuuGames.Business
{
    public class ComentarioLogica
    {
        ComentarioDAO dao = null;
        public ComentarioLogica(string StringConexao)
        {
            dao = new ComentarioDAO(StringConexao);
        }

        public void CadastrarComentario(ComentarioModelo comentario)
        {
            dao.Inserir(comentario);
        }

        public List<ComentarioModelo> RecuperarComentariosPorPost(string TituloPost)
        {
            return dao.RecuperarComentariosPorPost(TituloPost);            
        }

        public List<ComentarioModelo> RecuperarComentariosPorUsuario(string Login)
        {
            return dao.RecuperarComentariosPorUsuario(Login);
        }
        public List<ComentarioModelo> RecuperarTodos()
        {
            return dao.RecuperarTodos();
        }
        public void Deletar(int idComentario)
        {
            dao.Deletar(idComentario);
        }
    }
}
