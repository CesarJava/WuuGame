using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;


namespace WuuGames.Business
{
    public class PostagemLogica
    {
        PostagemDAO dao = null;
        public PostagemLogica(string StringConexao)
        {
            dao = new PostagemDAO(StringConexao);
        }

        public void CadastrarPostagem(PostagemModelo Post)
        {
            dao.Inserir(Post);
        }

        public List<PostagemModelo> RecuperarTodos()
        {
            return dao.RecuperarTodos();
        }

        public List<PostagemModelo> RecuperarRecentes()
        {
            return dao.RecuperarRecentes();
        }

       

        public PostagemModelo RecuperarPostagemPorNome(string NomePost)
        {
            return dao.RecuperarPostagemPorNome(NomePost);
        }

        public List<PostagemModelo> RecuperarPostagensPorGenero(List<string> NomesGeneros)
        {
            return dao.RecuperarPostagensPorGenero(NomesGeneros);
        }

        public List<PostagemModelo> RecuperarPostagensPorGenero(string NomesGeneros)
        {
            return dao.RecuperarPostagensPorGenero(NomesGeneros);
        }
        public void CadastrarGeneroDePostagem(List<string> NomesGeneros, int IdPost)
        {
            dao.CadastrarGeneroDePostagem(NomesGeneros, IdPost);
        }

        public int RecuperarIdPorTitulo(string Titulo)
        {
            return dao.RecuperarIdPorTitulo(Titulo);
        }

        public void CadastrarAssuntoDePostagem(List<string> NomesAssunto, int IdPost)
        {
            dao.CadastrarAssuntoDePostagem(NomesAssunto, IdPost);
        }
    }
}
