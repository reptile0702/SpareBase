using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace SparesBase
{
    public static class DatabaseWorker
    {
        static MySqlDataAdapter adapter;
        static MySqlConnection connection;

        // Конструктор
        static DatabaseWorker()
        {
            Connect();
        }

        // Коннект к базе
        private static void Connect()
        {
            try
            {
                MySqlConnectionStringBuilder mySql = new MySqlConnectionStringBuilder();
                mySql.Server = "server137.hosting.reg.ru";
                mySql.Database = "u0183148_default";
                mySql.UserID = "u0183148_default";
                mySql.Password = "Hym5hJeU";
                mySql.CharacterSet = "utf8";

                connection = new MySqlConnection(mySql.ConnectionString);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Обычный запрос в базу данных
        public static void SqlQuery(string query)
        {
            try
            {
                MySqlCommand comand = new MySqlCommand();
                comand.CommandText = query;
                comand.Connection = connection;
                connection.Open();
                comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);    
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // Запрос SQL с возвратом данных в DataTable
        public static DataTable SqlSelectQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                adapter = new MySqlDataAdapter(query, connection);
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                adapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                MessageBox.Show( e.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        // Запрос SQL с возвратом данных первой строчки и первого столбца
        public static object SqlScalarQuery(string query)
        {
            try
            {
                MySqlCommand comand = new MySqlCommand();
                comand.CommandText = query;
                comand.Connection = connection;
                connection.Open();
                
                return comand.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
