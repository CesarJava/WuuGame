using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;

namespace WuuGames.DAO
{
    public class ImagemDAO
    {
        Conexao conexao = null;
        public ImagemDAO(string StringConexao)
        {
            conexao = new Conexao(StringConexao);
        }

        public void Inserir(ImagemModelo Imagem)
        {
            string query = "insert into tb_imagem values(" +
                           "0,'" + Imagem.NomeImagem + "');";
            conexao.ExecutarSemRetorno(query);
        }

        public int RecuperarIdPorNome(string Nome)
        {
            string query = "select img_id from tb_imagem where img_nome = '" + Nome + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return Convert.ToInt32(dr["img_id"].ToString());
            }
            throw new Exception("Imagem inexistente");
        }

        public string RecuperarNomePorId(int Id)
        {
            string query = "select img_nome from tb_imagem where img_id = '" + Id + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return dr["img_nome"].ToString();
            }
            throw new Exception("Imagem inexistente");
        }

        public string RecuperarCaminhoPorTituloPost(string TituloPost)
        {
            string query = "select img_caminho from tb_imagem im inner join tb_postagem p on im.img_id = p.img_id " +
                           "where p.post_titulo = '" + TituloPost + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return dr["img_caminho"].ToString();
            }
            throw new Exception("Imagem inexistente");
        }

        public string RecuperarNomePorTituloPost(string TituloPost)
        {

            string query = "select im.img_nome from tb_imagem im inner join tb_postagem p on p.img_id = im.img_id" +
                            " where p.post_titulo =" + "'" + TituloPost + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                ImagemModelo imagemnome = new ImagemModelo();
                imagemnome.NomeImagem = dr["img_nome"].ToString();
                return imagemnome.NomeImagem;
            }
            throw new Exception("Imagem inexistente");

        }

        public string RecuperarNomeImagemPorLogin(string Login)
        {
            string query = "select i.img_nome from tb_imagem i inner join tb_usuario u on u.img_id = i.img_id where u.user_login = '" + Login + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
                return dr["img_nome"].ToString();
            throw new Exception("Usuário não existe ou não possui imagem");
        }
    }
}
