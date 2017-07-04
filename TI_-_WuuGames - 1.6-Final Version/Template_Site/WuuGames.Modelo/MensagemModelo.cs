using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuuGames.Modelo
{
    public class MensagemModelo
    {
        public int IdMensagem { get; set; }
        public int IdUserManda { get; set; }
        public int IdUserRecebe { get; set; }
        public string NomeUserManda { get; set; }
        public string NomeUserRecebe { get; set; }
        public int IdTipoMensagem { get; set; }
        public string NomeTipoMensagem { get; set; }
        public string TextoMensagem { get; set; }
        public string AssuntoMensagem { get; set; }
        public DateTime DataMensagem { get; set; }
    }
}
