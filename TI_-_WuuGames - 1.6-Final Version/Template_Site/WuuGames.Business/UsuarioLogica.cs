using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;
using System.Data;

namespace WuuGames.Business
{
    public class UsuarioLogica
    {
        UsuarioDAO dao = null;
        public UsuarioLogica(string StringConexao)
        {
            dao = new UsuarioDAO(StringConexao);
        }

        public void RegistrarNovo(  int id, string nome, string login, string senha, string email, string rg, string cpf,
                                    string datanasc, int pontos, string ultimoacesso, int nivelacesso, string interesses,
                                    int idestado, int advertencias, int idImagem)
        {
            UsuarioModelo user = new UsuarioModelo(id, nome, login, senha, email, rg, cpf, datanasc,
                                                    pontos, ultimoacesso, nivelacesso, interesses, idestado,
                                                    advertencias, idImagem);
            dao.Inserir(user);
        }

        public void RegistrarNovo(UsuarioModelo user)
        {
            dao.Inserir(user);
        }

        public List<UsuarioModelo> SelecionarTodos()
        {
            return dao.RecuperarTodos();            
        }

        public bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;          

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;
        }

        public void AtualizaDados(UsuarioModelo user)
        {
            dao.AtualizarDados(user);
        }

        public UsuarioModelo RecuperarUsuarioPorId(int id)
        {
            return dao.RecuperarUsuarioPorId(id);
        }

        public UsuarioModelo RecuperarUsuarioPorLogin(string login)
        {
            return dao.RecuperarUsuarioPorLogin(login);
        }

        public bool ValidacaoLogin(string Login, string Senha)
        {
            return dao.ValidacaoLogin(Login, Senha);
        }

        public bool ValidacaoUsuario(string Login)
        {
            return dao.ValidacaoUsuario(Login);
        }
        public void Deletar(int id)
        {
            dao.Deletar(id);
        }
        public List<UsuarioModelo> RecuperarTodos()
        {
           return dao.RecuperarTodos();
        }
         
        public bool VerificarAdmin(string Login)
        {
            return dao.VerificarAdmin(Login);

        }

  
        public void alterarNivel(string Login,string NivelAcesso)
        {
            dao.alterarNivel(Login,NivelAcesso);
        }
    }
}
