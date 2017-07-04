using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuuGames.Modelo
{
    public class ProdutoModelo
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int IdTipo { get; set; }
        public string NomeTipo { get; set; }
        public int IdFormaPagamento { get; set; }
        public double ValorUnidade { get; set; }
        public int QuantidadeEstoque { get; set; }
        public string LinkImagem { get; set; }
    }
}
