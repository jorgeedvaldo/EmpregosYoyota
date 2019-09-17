using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpregosYoyota.Models
{
    public class VerEmprego
    {
        public int IdEmprego { get; set; }
        public int IdCategoria { get; set; }
        public String Titulo { get; set; }
        public String Empresa { get; set; }
        public String Provincia { get; set; }
        public DateTime DataPublicado { get; set; }
        public DateTime DataExpira { get; set; }
        public String Email { get; set; }
        public String Descricao { get; set; }
        public String Foto { get; set; }
        public String Nome { get; set; }

        public DataTable Exibir()
        {

            MySqlConnection cn = new MySqlConnection();
            try
            {
                cn.ConnectionString = Conexao.StrConexao;
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT * FROM VerEmprego;";
                MySqlDataAdapter Dados = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                Dados.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public IEnumerable<VerEmprego> TodosEmpregos()
        {
            var retorno = new Collection<VerEmprego>();
            DataTable dt = new DataTable();
            VerEmprego verEmprego = new VerEmprego();
            dt = verEmprego.Exibir();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                VerEmprego empregoActual = new VerEmprego();
                empregoActual.IdEmprego = Convert.ToInt32(dt.Rows[i]["IdEmprego"]);
                empregoActual.IdCategoria = Convert.ToInt32(dt.Rows[i]["IdCategoria"]);
                empregoActual.Titulo = Convert.ToString(dt.Rows[i]["Titulo"]);
                empregoActual.Empresa = Convert.ToString(dt.Rows[i]["Empresa"]);
                empregoActual.Provincia = Convert.ToString(dt.Rows[i]["Provincia"]);
                empregoActual.DataPublicado = DateTime.Now;//Convert.ToDateTime(dt.Rows[i]["DataExpira"]);
                empregoActual.DataExpira = DateTime.Now;//Convert.ToDateTime(dt.Rows[i]["DataExpira"]);
                empregoActual.Descricao = Convert.ToString(dt.Rows[i]["Descricao"]);
                empregoActual.Foto = Convert.ToString(dt.Rows[i]["Foto"]);
                empregoActual.Nome = Convert.ToString(dt.Rows[i]["Nome"]);

                retorno.Add(empregoActual);
            }
            return retorno;
        }
    }
}