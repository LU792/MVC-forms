using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace ViewChanger.controller
{
    class asseco_ao_banco
    {
        private MySqlConnection conn;
        private MySqlCommand Command;
        private DataTable data;
        private MySqlDataAdapter da;
        private MySqlDataReader dr;
        private MySqlCommandBuilder cb;

        string strSQL;
        string server = "localhost";
        string user = "root";
        string password = "root";
        string database = "cadastro";
        public void conectar()
        {
            if (conn != null)
                conn.Close();
            {
                string connStr = string.Format("Server={0};user id={1};Password={2};Database={3}; ", server, user, password, database);
                try
                {
                    conn = new MySqlConnection(connStr);
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                 throw new Exception(ex.Message);
                }
            }
        }

        public void ExecutarComandSQL(string comandoSql)
        {
            MySqlCommand comando = new MySqlCommand(comandoSql, conn);
            comando.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable RetDataTable(string sql)
        {
            data = new DataTable();
            da = new MySqlDataAdapter(sql, conn);
            cb = new MySqlCommandBuilder(da);
            da.Fill(data);
            return data;
        }


        public MySqlDataReader RetDataReader(string sql)
        {
            MySqlCommand comando = new MySqlCommand(sql,conn);
            MySqlDataReader dr = comando.ExecuteReader();
            dr.Read();
            return dr;
        }
     
    
    }


 }


