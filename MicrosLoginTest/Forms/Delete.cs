using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MicrosLoginTest.Forms
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")//проверяем не пустые ли поля
            {
                DataBase dataBase = new DataBase();
                
                dataBase.OpenConnection();//открыть подкл

                MySqlCommand command = dataBase.GetConnection().CreateCommand();//создаём команду
                command.CommandType = CommandType.Text;//текстовая команда
                int idToDelete = Convert.ToInt32(textBox1.Text);
                //создаем Mysql query
                command.CommandText = "DELETE FROM IncomeOutcomeTable WHERE Id = '"+idToDelete+"'";//записываем команду
                command.ExecuteNonQuery();//выполнить query
                dataBase.CloseConnection();//закрыть базу

                MessageBox.Show("Deleted");
                this.Close();       //закрыть эту форму так как уже не нужна
            }
            
        }
    }
}
