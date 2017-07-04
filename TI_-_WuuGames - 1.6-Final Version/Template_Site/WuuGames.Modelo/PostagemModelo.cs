using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace WuuGames.Modelo
{
    public class PostagemModelo
    {
        public PostagemModelo() { }

        /*public PostagemModelo(int post_id, int user_id, int cat_id, int ast_id, string post_titulo,
                                string post_conteudo, int post_votopos, int post_votoneg, string post_data)
        {
            this.Conteudo.Append(post_conteudo);
            this.Data = post_data;
            this.IdAssunto = ast_id;
            this.IdCategoria = cat_id;
            this.IdPost = post_id;
            this.IdUser = user_id;
            this.Titulo = post_titulo;
            this.VotoNeg = post_votoneg;
            this.VotoPos = post_votopos;
        }*/
        
        public int IdPost { get; set; }
        public int IdUser { get; set; }
        public List<string> NomeGenero { get; set; }
        public List<string> NomeAssunto { get; set; }
        public string Titulo { get; set; }
        public StringBuilder Conteudo { get; set; }
        public int VotoPos { get; set; }
        public int VotoNeg { get; set; }
        public string Data { get; set; }
        public string NomeUser { get; set; }
        public string LinkPostagem { get; set; }
        public string CaminhoImagem { get; set; }
        public string Subtitulo { get; set; }
        public int IdImagem { get; set; }
    }
}
