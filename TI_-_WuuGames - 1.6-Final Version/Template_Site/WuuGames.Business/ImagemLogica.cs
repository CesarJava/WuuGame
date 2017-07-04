using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;

namespace WuuGames.Business
{
    public class ImagemLogica
    {
        ImagemDAO dao = null;
        public ImagemLogica(string StringConexao)
        {
            dao = new ImagemDAO(StringConexao);
        }

        public void CadastrarNova(ImagemModelo Imagem)
        {
            dao.Inserir(Imagem);
        }

        public int RecuperarIdPorNome(string Caminho)
        {
            return dao.RecuperarIdPorNome(Caminho);
        }

        public string RecuperarNomePorId(int Id)
        {
           
            return dao.RecuperarNomePorId(Id);
        }

        public string RecuperarCaminhoPorTituloPost(string TituloPost)
        {
           
            return dao.RecuperarCaminhoPorTituloPost(TituloPost);
        }
        public string RecuperarNomePorTituloPost(string TituloPost)
        {
            return dao.RecuperarNomePorTituloPost(TituloPost);
        }

        public string RecuperarNomeImagemPorLogin(string Login)
        {
            return dao.RecuperarNomeImagemPorLogin(Login);
        }
    }
}
