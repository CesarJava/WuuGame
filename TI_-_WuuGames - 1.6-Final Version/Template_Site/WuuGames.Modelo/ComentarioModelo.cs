using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuuGames.Modelo
{
   public class ComentarioModelo
    {
        public int IdComentario { get; set; }
        public int IdUser { get; set; }
        public string NomeUser { get; set; }
        public int IdPost { get; set; }
        public string Data { get; set; }
        public string Corpo { get; set; }
        public int VotoPos { get; set; }
        public int VotoNeg { get; set; }
        public string TituloPost { get; set; }
        }
}
