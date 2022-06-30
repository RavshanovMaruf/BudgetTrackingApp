using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MicrosLoginTest
{
    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("server=sql11.freemysqlhosting.net;port=3306;username=sql11455096;password=aHdQXVcdYe;database=sql11455096");
        //наверху подключаемся к базе данных

        public void OpenConnection()//функция чтобы открыть доступ к базе данных
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {//если подключение не открыто
                connection.Open();//открыть подключение
            }
            
        }
        public void CloseConnection()//функция чтобы закрыть доступ к базе данных
        {
            if (connection.State != System.Data.ConnectionState.Closed)//если подключение не закрыто
                connection.Close();//открыть подключение
        }
        public MySqlConnection GetConnection()
        {
            return connection;//вернуть подключение
        }
       
    }
}
