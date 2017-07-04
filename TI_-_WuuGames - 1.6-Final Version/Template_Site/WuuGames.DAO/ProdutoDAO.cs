using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;

namespace WuuGames.DAO
{
    public class ProdutoDAO
    {
        Conexao conexao = null;
        public ProdutoDAO(string StringConexao)
        {
            conexao = new Conexao(StringConexao);
        }

        public void Inserir(ProdutoModelo produto)
        {
            string query = "insert into tb_produto values(" +
                           "0,'" + produto.NomeProduto + "','" +
                           produto.DescricaoProduto + "'," +
                           produto.IdTipo + "," +
                           produto.IdFormaPagamento + ",'" +
                           produto.LinkImagem + "',";
            foreach (char c in produto.ValorUnidade.ToString().ToCharArray())
            {
                if (c == ',')
                    query += ".";
                else
                    query += c.ToString();
            }
                   query += "," + produto.QuantidadeEstoque + ");";

                   conexao.ExecutarSemRetorno(query);
        }
    }
}
