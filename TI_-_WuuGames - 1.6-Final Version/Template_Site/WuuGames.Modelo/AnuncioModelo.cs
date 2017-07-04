using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuuGames.Modelo
{
    public class AnuncioModelo
    {
        public int IdAnuncio { get; set; }        
        public int IdVendedor { get; set; }
        public string NomeVendedor { get; set; }
        public int IdTipo { get; set; }
        public string NomeTipo { get; set; }
        public int IdFormaPagamento { get; set; }
        public string NomeFormaPagamento { get; set; }
        public string NomeAnuncio { get; set; }
        public string DescricaoAnuncio { get; set; }
        public int IdImagem { get; set; }
        public string NomeImagem { get; set; }
        public double ValorUnidade { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
