using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WuuGames.DAO;
using WuuGames.Modelo;

namespace WuuGames.Business
{
    public class MensagemLogica
    {
        MensagemDAO dao = null;
        public MensagemLogica(string StringConexao)
        {
            dao = new MensagemDAO(StringConexao);
        }

        public void CadastrarNova(MensagemModelo Mensagem)
        {
            dao.Inserir(Mensagem);
        }

        public List<MensagemModelo> RecuperarMensagensPorUsuario(string Login)
        {
            return dao.RecuperarMensagensPorUsuario(Login);
        }

        public void CancelarMensagem(int IdMenssagem)
        {
            dao.CancelarMensagem(IdMenssagem);
        }
        public List<MensagemModelo> RecuperarMensagensPorUsuarioEmissor(string Login)
        {
            return dao.RecuperarMensagensPorUsuarioEmissor(Login);
        }
        public List<MensagemModelo> RecuperarMensagensPorUsuarioReceptor(string Login)
        {
            return dao.RecuperarMensagensPorUsuarioReceptor(Login);
        }
    }
}
