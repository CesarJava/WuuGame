using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using WuuGames.Modelo;


namespace WuuGames.DAO
{
    public class PostagemDAO
    {
        Conexao conexao = null;
        UsuarioDAO usuarioDAO = null;
        public PostagemDAO(string stringConexao)
        {
            this.conexao = new Conexao(stringConexao);
            this.usuarioDAO = new UsuarioDAO(stringConexao);
        }

        public void Inserir(PostagemModelo Post)
        {
            string query = "insert into tb_postagem values(";
            query += "0," + Post.IdUser + ",'" +
                     Post.Titulo + "','" +
                     Post.Subtitulo + "','" +
                     Post.Conteudo + "'," +
                     "0,0,'" + Post.Data + "'," +
                     Post.IdImagem + ");";

            conexao.ExecutarSemRetorno(query);
        }

        public List<PostagemModelo> RecuperarTodos()
        {
            List<PostagemModelo> listaPostagens = new List<PostagemModelo>();
            string query = "Select * from tb_Postagem;";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                PostagemModelo post = new PostagemModelo();
                post.Conteudo = new StringBuilder();
                post.Conteudo.Append(dr["Post_Conteudo"].ToString());
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Post_Data"].ToString(), out dataCorreta);
                post.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                post.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                post.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                post.Titulo = dr["Post_Titulo"].ToString();
                post.VotoNeg = Convert.ToInt32(dr["Post_VotoNeg"].ToString());
                post.VotoPos = Convert.ToInt32(dr["Post_VotoPos"].ToString());
                post.NomeGenero = AssociaGeneros(post.IdPost);
                post.NomeUser = usuarioDAO.RecuperarNomePorId(post.IdUser);
                post.NomeAssunto = AssociarNomesAssuntos(post.IdPost);
                
                listaPostagens.Add(post);
            }

            return listaPostagens;            
        }

        private List<string> AssociaGeneros(int IdPostagem)
        {
            List<string> NomeGeneros = new List<string>();
            string query2 = "select Gen_nome from tb_InterGen it inner join tb_genero g on g.Gen_id = it.Gen_Id where it.post_id = " + IdPostagem + ";";
            foreach (DataRow row in conexao.ExecutarComRetorno(query2).AsEnumerable())
            {
                try
                {
                    string NomeGenero = row["Gen_Nome"].ToString();
                    NomeGeneros.Add(NomeGenero);
                }
                catch
                {
                    NomeGeneros.Add(null);
                }
            }
            return NomeGeneros;
        }

        public List<PostagemModelo> RecuperarRecentes()
        {
            string query = "select * from tb_postagem order by post_data desc";
            List<PostagemModelo> listaRecentes = new List<PostagemModelo>();
            int i = 1;
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                PostagemModelo post = new PostagemModelo();
                post.Conteudo = new StringBuilder();
                post.Conteudo.Append(dr["Post_Conteudo"].ToString());
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Post_Data"].ToString(), out dataCorreta);
                post.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                //post.IdAssunto = Convert.ToInt32(dr["Ast_Id"].ToString());
                //post.IdCategoria = Convert.ToInt32(dr["Cat_Id"].ToString());
                post.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                post.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                post.Titulo = dr["Post_Titulo"].ToString();
                post.VotoNeg = Convert.ToInt32(dr["Post_VotoNeg"].ToString());
                post.VotoPos = Convert.ToInt32(dr["Post_VotoPos"].ToString());
                post.NomeGenero = AssociaGeneros(post.IdPost);
                post.NomeUser = usuarioDAO.RecuperarNomePorId(post.IdUser);
                post.Subtitulo = dr["Post_Subtitulo"].ToString();
                post.NomeAssunto = AssociarNomesAssuntos(post.IdPost);
                
                if (i <= 2)
                {
                    i++;
                    listaRecentes.Add(post);
                }
                else
                    break;
            }
            return listaRecentes;
        }

        public PostagemModelo RecuperarPostagemPorNome(string NomePost)
        {
            PostagemModelo post = new PostagemModelo();
            string query = "select * from tb_postagem where post_Titulo = " +"'" + NomePost + "'";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                post.Conteudo = new StringBuilder();
                post.Conteudo.Append(dr["Post_Conteudo"].ToString());
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Post_Data"].ToString(), out dataCorreta);
                post.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                //post.IdAssunto = Convert.ToInt32(dr["Ast_Id"].ToString());
                //post.IdCategoria = Convert.ToInt32(dr["Cat_Id"].ToString());
                post.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                post.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                post.Titulo = dr["Post_Titulo"].ToString();
                post.VotoNeg = Convert.ToInt32(dr["Post_VotoNeg"].ToString());
                post.VotoPos = Convert.ToInt32(dr["Post_VotoPos"].ToString());
                post.NomeGenero = AssociaGeneros(post.IdPost);
                post.NomeUser = usuarioDAO.RecuperarNomePorId(post.IdUser);
                post.NomeAssunto = AssociarNomesAssuntos(post.IdPost);
            }

            return post;
        }

        public List<PostagemModelo> RecuperarPostagensPorGenero(List<string> NomesGeneros)
        {
            List<PostagemModelo> ListaPostagem = new List<PostagemModelo>();
            string query = "select p.post_id, p.post_titulo, p.post_conteudo, p.post_subtitulo, p.post_votopos, p.post_votoneg, " +
                            "p.post_data, p.user_id, g.Gen_Nome " +
                            "from tb_postagem p inner join tb_intergen ig on p.Post_id = ig.Post_Id " +
                            "inner join tb_genero g on g.Gen_Id = ig.Gen_Id " +
                            "where g.Gen_Nome in (";
            foreach (string s in NomesGeneros)
            {
                query += "'" + s + "',";
            }
            query += "'') group by post_titulo;";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                PostagemModelo post = new PostagemModelo();
                post.Conteudo = new StringBuilder();
                post.Conteudo.Append(dr["Post_Conteudo"].ToString());
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Post_Data"].ToString(), out dataCorreta);
                post.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                post.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                post.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                post.Titulo = dr["Post_Titulo"].ToString();
                post.VotoNeg = Convert.ToInt32(dr["Post_VotoNeg"].ToString());
                post.VotoPos = Convert.ToInt32(dr["Post_VotoPos"].ToString());
                post.NomeGenero = AssociaGeneros(post.IdPost);
                post.NomeUser = usuarioDAO.RecuperarNomePorId(post.IdUser);
                post.NomeAssunto = AssociarNomesAssuntos(post.IdPost);
                ListaPostagem.Add(post);
            }

            return ListaPostagem;
        }

        public List<PostagemModelo> RecuperarPostagensPorGenero(string NomesGeneros)
        {
            List<PostagemModelo> ListaPostagem = new List<PostagemModelo>();
            string query = "select p.post_id, p.post_titulo, p.post_conteudo, p.post_subtitulo, p.post_votopos, p.post_votoneg, " +
                            "p.post_data, p.user_id, g.Gen_Nome " +
                            "from tb_postagem p inner join tb_intergen ig on p.Post_id = ig.Post_Id " +
                            "inner join tb_genero g on g.Gen_Id = ig.Gen_Id " +
                            "where g.Gen_Nome ="+"'"+NomesGeneros+"';";
            
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                PostagemModelo post = new PostagemModelo();
                post.Conteudo = new StringBuilder();
                post.Conteudo.Append(dr["Post_Conteudo"].ToString());
                DateTime dataCorreta = new DateTime();
                DateTime.TryParse(dr["Post_Data"].ToString(), out dataCorreta);
                post.Data = dataCorreta.ToString("dd/MM/yyyy hh:mm:ss");
                post.IdPost = Convert.ToInt32(dr["Post_Id"].ToString());
                post.IdUser = Convert.ToInt32(dr["User_Id"].ToString());
                post.Titulo = dr["Post_Titulo"].ToString();
                post.VotoNeg = Convert.ToInt32(dr["Post_VotoNeg"].ToString());
                post.VotoPos = Convert.ToInt32(dr["Post_VotoPos"].ToString());
                post.NomeGenero = AssociaGeneros(post.IdPost);
                post.NomeUser = usuarioDAO.RecuperarNomePorId(post.IdUser);
                post.NomeAssunto = AssociarNomesAssuntos(post.IdPost);
                ListaPostagem.Add(post);
            }

            return ListaPostagem;
        }

        public void CadastrarGeneroDePostagem(List<string> NomesGeneros, int IdPost)
        {
            foreach (string s in NomesGeneros)
            {
                string query = "select gen_id from tb_genero where gen_nome = '" + s + "';";
                foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
                {
                    int IdGen = Convert.ToInt32(dr["Gen_Id"].ToString());
                    conexao.ExecutarSemRetorno("insert into tb_intergen values(" + IdPost + "," + IdGen + ");");
                }
            }
        }

        public int RecuperarIdPorTitulo(string Titulo)
        {
            string query = "select post_id from tb_postagem where post_Titulo = '" + Titulo + "';";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
                return Convert.ToInt32(dr["post_Id"].ToString());
            throw new Exception("Titulo inexistente");
        }

        public void CadastrarAssuntoDePostagem(List<string> NomesAssunto, int IdPost)
        {
            foreach (string s in NomesAssunto)
            {
                string query = "select ast_id from tb_assunto where ast_nome = '" + s + "';";
                foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
                {
                    int IdAst = Convert.ToInt32(dr["Ast_Id"].ToString());
                    conexao.ExecutarSemRetorno("insert into tb_interast values(" + IdPost + "," + IdAst + ");");
                }
            }
        }

        public List<string> AssociarNomesAssuntos(int idPost)
        {
            List<string> ListaAssuntos = new List<string>();
            string query = "select ast_nome from tb_assunto a inner join tb_interast ia on ia.ast_id = a.ast_id " +
                           "inner join tb_postagem p on p.post_id = ia.post_id " +
                           "where p.Post_id = " + idPost + ";";
            foreach (DataRow dr in conexao.ExecutarComRetorno(query).AsEnumerable())
            {
                ListaAssuntos.Add(dr["ast_Nome"].ToString());
            }

            return ListaAssuntos;
        }
    }
}
