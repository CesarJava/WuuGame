using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using System.Data;

namespace WuuGames.DAO
{
    public class Conexao
    {
        MySqlConnection conexao = null;

        public Conexao(string stringConexao)
        {
            conexao = new MySqlConnection(stringConexao);
        }

        public void ExecutarSemRetorno(string query)
        {
            if (conexao.State != System.Data.ConnectionState.Open)
            {
                conexao.Open();
            }

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.ExecuteNonQuery();

            if (conexao.State != System.Data.ConnectionState.Closed)
            { 
                conexao.Close(); 
            }
        }

        public DataTable ExecutarComRetorno(string query)
        {
            if (conexao.State != System.Data.ConnectionState.Open)
            {
                conexao.Open();
            }

            MySqlCommand comando = new MySqlCommand(query, conexao);
            MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            return ds.Tables[0];
        }
    }
}
