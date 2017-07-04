using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WuuGames.Modelo
{
    public class UsuarioModelo
    {
        public UsuarioModelo()
        {
        }
	
	    //GO! GO! POWER RANGERS!
        public UsuarioModelo(   int id, string nome, string login, string senha, string email, string rg, string cpf,
                                string datanasc, int pontos, string ultimoacesso, int nivelacesso, string interesses,
                                int idestado, int advertencias, int idImagem)
        {
            this.Advertencias = advertencias;
            this.CPF = cpf;
            this.DataNasc = datanasc;
            this.Email = email;
            this.Id = id;
            this.IdEstado = idestado;
            this.Interesses = interesses;
            this.IdImagem = idImagem;
            this.Nome = nome;
            this.Pontos = pontos;
            this.RG = rg;
            this.Senha = senha;
            this.UltimoAcesso = ultimoacesso;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string DataNasc { get; set; }
        public int Pontos { get; set; }
        public string UltimoAcesso { get; set; }
        public string Interesses { get; set; }
        public int IdEstado { get; set; }
        public int Advertencias { get; set; }
        public int IdImagem { get; set; }
        public DateTime DataNascDT { get; set; }
        public string NivelAcesso { get; set; }
        public int NivelAcessoId{get; set;}
    }
}
