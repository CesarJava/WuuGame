using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;

namespace WuuGames.Business
{
    public class ProdutoBusiness
    {
        ProdutoDAO dao = null;
        public ProdutoBusiness(string StringConexao)
        {
            dao = new ProdutoDAO(StringConexao);
        }

        public void CadastrarNovo(ProdutoModelo produto)
        {
            dao.Inserir(produto);
        }

    }
}
