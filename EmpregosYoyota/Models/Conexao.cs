using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace EmpregosYoyota.Models
{
    public class Conexao
    {
        public static string StrConexao = "Server = localhost; Port=3306; Database=bdempregosyoyota;" +
            "Uid=root; Pwd=admin;";

        private MySqlConnection myConexao;

        public Conexao()
        {
            myConexao = new MySqlConnection();
            myConexao.ConnectionString = StrConexao;
        }

        internal MySqlConnection Abrir()
        {
            if (myConexao.State == ConnectionState.Closed)
            {
                myConexao.Open();
            }
            return myConexao;
        }

        internal void Fechar()
        {
            if (myConexao.State == ConnectionState.Open)
            {
                myConexao.Close();
            }
        }
    }
}