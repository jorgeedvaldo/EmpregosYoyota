using MySql.Data.MySqlClient;
using System;
namespace EmpregosYoyota.Models
{
    public class Mensagem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Assunto { get; set; }
        public string Msg { get; set; }

        public Mensagem()
        {
            this.Limpar();
        }

        public void Inserir(Mensagem mensagem)
        {
            MySqlConnection cn = new MySqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StrConexao;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "INSERT INTO Mensagem(Nome, Email, Assunto, Mensagem) VALUES(@Nome, @Email, @Assunto, @Mensagem);";
                cmd.Parameters.Add(new MySqlParameter("@Nome", mensagem.Nome));
                cmd.Parameters.Add(new MySqlParameter("@Email", mensagem.Email));
                cmd.Parameters.Add(new MySqlParameter("@Assunto", mensagem.Assunto));
                cmd.Parameters.Add(new MySqlParameter("@Mensagem", mensagem.Msg));
                cn.Open();
                cmd.ExecuteScalar();
            }
            catch
            {
                throw new Exception("Erro ao gravar, verifique se os dados foram inseridos correctamente!");
            }
            finally
            {
                cn.Close();
            }
        }

        public void Limpar()
        {
            this.Nome = string.Empty;
            this.Email = string.Empty;
            this.Assunto = string.Empty;
            this.Msg = string.Empty;
        }
    }
}