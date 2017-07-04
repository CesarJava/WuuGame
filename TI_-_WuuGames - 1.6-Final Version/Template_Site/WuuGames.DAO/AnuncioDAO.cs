using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;

namespace WuuGames.DAO
{
    public class AnuncioDAO
    {
        Conexao conexao = null;
        public AnuncioDAO(string StringConexao)
        {
            conexao = new Conexao(StringConexao);
        }

        public void Inserir(AnuncioModelo anuncio)
        {
            
            string query = "insert into tb_anuncio values(0," +
                           anuncio.IdVendedor + "," +
                           anuncio.IdTipo + ",'" + 
                           anuncio.NomeAnuncio + "','" +
                           anuncio.DescricaoAnuncio + "','" +
                           anuncio.IdImagem + "',"; 
        
            foreach (char c in anuncio.ValorUnidade.ToString().ToCharArray())
            {
                if (c == ',')
                    query += ".";
                else
                    query += c.ToString();
            }
                  query += "," + anuncio.QuantidadeEstoque + ");";

            conexao.ExecutarSemRetorno(query);
        }

        public List<AnuncioModelo> RecuperarTodos()
        {
            string query = "select * from tb_anuncio;";
            List<AnuncioModelo> listaAnuncios = new List<AnuncioModelo>();
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                AnuncioModelo Anun = new AnuncioModelo();
                Anun.DescricaoAnuncio = dr["Anu_Descricao"].ToString();
                Anun.IdAnuncio = Convert.ToInt32(dr["Anu_Id"].ToString());
                //Anun.IdFormaPagamento = Convert.ToInt32(dr["Pag_Id"].ToString());
                Anun.IdTipo = Convert.ToInt32(dr["Tipo_Id"].ToString());
                Anun.IdVendedor = Convert.ToInt32(dr["User_Id"].ToString());
                //Anun.IdImagem = Convert.ToInt32(dr["Img_Id"].ToString());
                Anun.NomeAnuncio = dr["Anu_Nome"].ToString();
                Anun.QuantidadeEstoque = Convert.ToInt32(dr["Anu_QtdEstoque"].ToString());
                Anun.ValorUnidade = Convert.ToDouble(dr["Anu_Valor"].ToString());
                string queryJoin = " select  u.User_Login, tp.Tipo_Nome, pg.Pag_Nome , img.Img_Nome from " +
                                    "tb_usuario u inner join tb_anuncio a on a.User_Id = u.User_id " +
                                     "inner join tb_tipo tp on tp.Tipo_Id = a.Tipo_Id " +
                                    "inner join tb_InterAnuncio ia on ia.Anu_Id = a.Anu_Id "+
                                     "inner join tb_FormasPagamento pg on pg.Pag_Id = ia.Pag_Id "+
                                    " inner Join tb_imagem img on a.Img_Id = img.Img_Id " +
                                    "where a.Anu_Id =" +Anun.IdAnuncio +";"; 
                foreach (DataRow join in conexao.ExecutarComRetorno(queryJoin).AsEnumerable())
                {
                    Anun.NomeFormaPagamento = join["Pag_Nome"].ToString();
                    Anun.NomeTipo = join["Tipo_Nome"].ToString();
                    Anun.NomeVendedor = join["User_Login"].ToString();
                    Anun.NomeImagem = join["Img_Nome"].ToString();

                }

                listaAnuncios.Add(Anun);
            }

            return listaAnuncios;
        }

        public int RecuperarIdTipoPorNome(string nome)
        {
            string query = "select tipo_id from tb_tipo where tipo_nome = '" + nome + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return Convert.ToInt32(dr["Tipo_Id"].ToString());
            }
            throw new Exception("Tipo inexistente.");
        }

        public int RecuperarIdFormaPagamentoPorNome(string nome)
        {
            string query = "select pag_id from tb_Formaspagamento where pag_Nome = '" + nome + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return Convert.ToInt32(dr["Pag_Id"].ToString());
            }
            throw new Exception("Forma de Pagamento inexistente");
        }

        public void CadastrarFormasPagamento(int IdAnuncio, List<int> IdsFormasPag)
        {
            foreach (int i in IdsFormasPag)
            {
                string query = "insert into tb_interanuncio values(" + IdAnuncio + "," + i + ");";
                conexao.ExecutarSemRetorno(query);
            }
        }

        public int RecuperarIdPorNome(string NomeAnuncio)
        {
            string query = "select anu_id from tb_anuncio where anu_nome = '" + NomeAnuncio + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                return Convert.ToInt32(dr["anu_id"].ToString());
            }
            throw new Exception("Anúncio inexistente");
        }

        public List<AnuncioModelo> RecuperarAnunciosPorUsuario(string Login)
        {
            string query = "select a.* from tb_anuncio a inner join tb_usuario u on a.user_Id=u.User_Id where u.User_Login='"+Login+ "' ;";
            List<AnuncioModelo> listaAnuncios = new List<AnuncioModelo>();
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                AnuncioModelo Anun = new AnuncioModelo();
                Anun.DescricaoAnuncio = dr["Anu_Descricao"].ToString();
                Anun.IdAnuncio = Convert.ToInt32(dr["Anu_Id"].ToString());
                //Anun.IdFormaPagamento = Convert.ToInt32(dr["Pag_Id"].ToString());
                Anun.IdTipo = Convert.ToInt32(dr["Tipo_Id"].ToString());
                Anun.IdVendedor = Convert.ToInt32(dr["User_Id"].ToString());
                //Anun.IdImagem = Convert.ToInt32(dr["Img_Id"].ToString());
                Anun.NomeAnuncio = dr["Anu_Nome"].ToString();
                Anun.QuantidadeEstoque = Convert.ToInt32(dr["Anu_QtdEstoque"].ToString());
                Anun.ValorUnidade = Convert.ToDouble(dr["Anu_Valor"].ToString());
                string queryJoin = " select  u.User_Login, tp.Tipo_Nome, pg.Pag_Nome , img.Img_Nome from " +
                                    "tb_usuario u inner join tb_anuncio a on a.User_Id = u.User_id " +
                                     "inner join tb_tipo tp on tp.Tipo_Id = a.Tipo_Id " +
                                    "inner join tb_InterAnuncio ia on ia.Anu_Id = a.Anu_Id " +
                                     "inner join tb_FormasPagamento pg on pg.Pag_Id = ia.Pag_Id " +
                                    " inner Join tb_imagem img on a.Img_Id = img.Img_Id " +
                                    "where a.Anu_Id =" + Anun.IdAnuncio + ";";
                foreach (DataRow join in conexao.ExecutarComRetorno(queryJoin).AsEnumerable())
                {
                    Anun.NomeFormaPagamento = join["Pag_Nome"].ToString();
                    Anun.NomeTipo = join["Tipo_Nome"].ToString();
                    Anun.NomeVendedor = join["User_Login"].ToString();
                    Anun.NomeImagem = join["Img_Nome"].ToString();

                }

                listaAnuncios.Add(Anun);
            }

            return listaAnuncios;
        }

        public void deletar(int idAnuncio)
        {
            string queryintermedio = "delete from tb_interanuncio where anu_id=" + idAnuncio + ";";
            conexao.ExecutarSemRetorno(queryintermedio);
            string queryanuncio = " delete from tb_anuncio where anu_Id=" + idAnuncio +";" ;
            conexao.ExecutarSemRetorno(queryanuncio);
        }

    }
}
