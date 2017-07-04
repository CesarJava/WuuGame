using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.Modelo;
using WuuGames.DAO;

namespace WuuGames.Business
{
    public class AnuncioLogica
    {
        AnuncioDAO dao = null;
        public AnuncioLogica(string StringConexao)
        {
            dao = new AnuncioDAO(StringConexao);
        }

        public void CadastrarNovo(AnuncioModelo anuncio)
        {
            dao.Inserir(anuncio);
        }

        public List<AnuncioModelo> RecuperarTodos()
        {
            return dao.RecuperarTodos();
        }

        public int RecuperarIdTipoPorNome(string nome)
        {
            return dao.RecuperarIdTipoPorNome(nome);
        }

        public int RecuperarIdFormaPagamentoPorNome(string nome)
        {
            return dao.RecuperarIdFormaPagamentoPorNome(nome);
        }

        public void CadastrarFormasPagamento(int IdAnun, List<int> IdsPag)
        {
            dao.CadastrarFormasPagamento(IdAnun, IdsPag);
        }

        public int RecuperarIdPorNome(string NomeAnuncio)
        {
            return dao.RecuperarIdPorNome(NomeAnuncio);
        }

        public List<AnuncioModelo> RecuperarAnunciosPorUsuario(string Login)
        {
            return dao.RecuperarAnunciosPorUsuario(Login);
        }
        public void Deletar(int idAnuncio)
        {
            dao.deletar(idAnuncio);
        }
    }
}
