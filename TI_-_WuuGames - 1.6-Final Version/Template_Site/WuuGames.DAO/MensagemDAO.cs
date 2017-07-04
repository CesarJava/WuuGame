using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;

namespace WuuGames.DAO
{
    public class MensagemDAO
    {
        Conexao conexao = null;
        public MensagemDAO(string StringConexao)
        {
            conexao = new Conexao(StringConexao);
        }

        public void Inserir(MensagemModelo Mensagem)
        {
            string query = "insert into tb_mensagem values(0," +
                           Mensagem.IdUserManda + "," +
                           Mensagem.IdUserRecebe + "," +
                           Mensagem.IdTipoMensagem + ",'" +
                           Mensagem.AssuntoMensagem + "','" +
                           Mensagem.TextoMensagem + "','" +
                           DateTime.Now.Date.ToString("yyyy-MM-dd") + "');";
            conexao.ExecutarSemRetorno(query);
        }

        public List<MensagemModelo> RecuperarMensagensPorUsuario(string Login)
        {
            List<MensagemModelo> listaMensagens = new List<MensagemModelo>();
            string query = "select m.msg_id, m.user_1, m.user_2, m.msg_texto, tp.tpmsg_nome, m.tpmsg_id, u1.user_Login as envia, u2.user_Login as recebe ,m.Data,m.Msg_Ast " +
                           "from tb_Mensagem m inner join tb_tipomensagem tp on tp.tpmsg_id = m.tpmsg_id " +
                           "inner join tb_usuario u1 on u1.user_id = m.user_1 " +
                           "inner join tb_usuario u2 on u2.user_id = m.user_2 " +
                           "where u1.user_login = '" + Login + "' or u2.user_login = '" + Login + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                MensagemModelo msg = new MensagemModelo();
                msg.IdMensagem = Convert.ToInt32(dr["msg_id"].ToString());
                msg.IdTipoMensagem = Convert.ToInt32(dr["tpmsg_id"].ToString());
                msg.IdUserManda = Convert.ToInt32(dr["user_1"].ToString());
                msg.IdUserRecebe = Convert.ToInt32(dr["user_2"].ToString());
                msg.NomeTipoMensagem = dr["tpmsg_nome"].ToString();
                msg.NomeUserManda = dr["envia"].ToString();
                msg.NomeUserRecebe = dr["recebe"].ToString();
                msg.TextoMensagem = dr["msg_texto"].ToString();
                msg.DataMensagem = DateTime.Parse( DateTime.Parse(dr["Data"].ToString()).ToString("dd/MM/yyyy"));
                msg.AssuntoMensagem = dr["Msg_Ast"].ToString();
                listaMensagens.Add(msg);
            }

            return listaMensagens;
        }

        public List<MensagemModelo> RecuperarMensagensPorUsuarioEmissor(string Login)
        {
            List<MensagemModelo> listaMensagens = new List<MensagemModelo>();
            string query = "select m.msg_id, m.user_1, m.user_2, m.msg_texto, tp.tpmsg_nome, m.tpmsg_id, u1.user_login as envia, u2.user_login as recebe ,m.Data,m.Msg_Ast " +
                           "from tb_Mensagem m inner join tb_tipomensagem tp on tp.tpmsg_id = m.tpmsg_id " +
                           "inner join tb_usuario u1 on u1.user_id = m.user_1 " +
                           "inner join tb_usuario u2 on u2.user_id = m.user_2 " +
                           "where u1.user_login = '" + Login + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                MensagemModelo msg = new MensagemModelo();
                msg.IdMensagem = Convert.ToInt32(dr["msg_id"].ToString());
                msg.IdTipoMensagem = Convert.ToInt32(dr["tpmsg_id"].ToString());
                msg.IdUserManda = Convert.ToInt32(dr["user_1"].ToString());
                msg.IdUserRecebe = Convert.ToInt32(dr["user_2"].ToString());
                msg.NomeTipoMensagem = dr["tpmsg_nome"].ToString();
                msg.NomeUserManda = dr["envia"].ToString();
                msg.NomeUserRecebe = dr["recebe"].ToString();
                msg.TextoMensagem = dr["msg_texto"].ToString();
                msg.DataMensagem = DateTime.Parse(DateTime.Parse(dr["Data"].ToString()).ToString("dd/MM/yyyy"));
                msg.AssuntoMensagem = dr["Msg_Ast"].ToString();
                listaMensagens.Add(msg);
            }

            return listaMensagens;
        }
        public List<MensagemModelo> RecuperarMensagensPorUsuarioReceptor(string Login)
        {
            List<MensagemModelo> listaMensagens = new List<MensagemModelo>();
            string query = "select m.msg_id as id, m.user_1, m.user_2, m.msg_texto, tp.tpmsg_nome, m.tpmsg_id, u1.user_login as envia, u2.user_login as recebe, m.Data,m.Msg_Ast " +
                           "from tb_Mensagem m inner join tb_tipomensagem tp on tp.tpmsg_id = m.tpmsg_id " +
                           "inner join tb_usuario u1 on u1.user_id = m.user_1 " +
                           "inner join tb_usuario u2 on u2.user_id = m.user_2 " +
                           "where u2.user_login = '" + Login + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                MensagemModelo msg = new MensagemModelo();
                msg.IdMensagem = Convert.ToInt32(dr["id"].ToString());
                msg.IdTipoMensagem = Convert.ToInt32(dr["tpmsg_id"].ToString());
                msg.IdUserManda = Convert.ToInt32(dr["user_1"].ToString());
                msg.IdUserRecebe = Convert.ToInt32(dr["user_2"].ToString());
                msg.NomeTipoMensagem = dr["tpmsg_nome"].ToString();
                msg.NomeUserManda = dr["envia"].ToString();
                msg.NomeUserRecebe = dr["recebe"].ToString();
                msg.TextoMensagem = dr["msg_texto"].ToString();
                msg.DataMensagem = DateTime.Parse(DateTime.Parse(dr["Data"].ToString()).ToString("dd/MM/yyyy"));
                msg.AssuntoMensagem = dr["Msg_Ast"].ToString();
                listaMensagens.Add(msg);
            }

            return listaMensagens;
        }
       /* public List<MensagemModelo> RecuperarNegociacaoPorUsuario(string Login)
        {
            List<MensagemModelo> listaMensagens = new List<MensagemModelo>();
            string query = "select m.msg_id, m.user_1, m.user_2, m.msg_texto, tp.tpmsg_nome, m.tpmsg_id, u1.user_nome, u2.user_nome " +
                           "from tb_Mensagem m inner join tb_tipomensagem tp on tp.tpmsg_id = m.tpmsg_id " +
                           "inner join tb_usuario u1 on u1.user_id = m.user_1 " +
                           "inner join tb_usuario u2 on u2.user_id = m.user_2 " +
                           "where u1.user_login = '" + Login + "' or u2.user_login = '" + Login +
                           " and "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                MensagemModelo msg = new MensagemModelo();
                msg.IdMensagem = Convert.ToInt32(dr["msg_id"].ToString());
                msg.IdTipoMensagem = Convert.ToInt32(dr["tpmsg_id"].ToString());
                msg.IdUserManda = Convert.ToInt32(dr["user_1"].ToString());
                msg.IdUserRecebe = Convert.ToInt32(dr["user_2"].ToString());
                msg.NomeTipoMensagem = dr["tpmsg_nome"].ToString();
                msg.NomeUserManda = dr["u1.user_login"].ToString();
                msg.NomeUserRecebe = dr["u2.User_login"].ToString();
                msg.TextoMensagem = dr["msg_texto"].ToString();
                listaMensagens.Add(msg);
            }

            return listaMensagens;
        }*/

        public void CancelarMensagem(int IdMensagem)
        {
            string query = "Delete from tb_mensagem where msg_id = " + IdMensagem.ToString() + ";";
            conexao.ExecutarSemRetorno(query);
        }
    }
}
