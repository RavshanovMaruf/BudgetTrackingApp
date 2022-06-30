using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;   //чтобы использовать MYSQL


namespace MicrosLoginTest.Forms
{
    public partial class IncomeForm : Form
    {
        //SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C#\MicrosLoginTest\MicrosLoginTest\AccountsDataBase.mdf;Integrated Security=True");   //нужно поменять под свой проект путь
        DataBase dataBase = new DataBase();//чтобы использовать функции внутри этого класса


        public IncomeForm()
        {
            InitializeComponent();

        }

        private void Income_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sumBox.Text != "" && categoryBox.Text != "")//проверяем не пустые ли поля
            {
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");//перевести в нужную нам форму

                dataBase.OpenConnection();//открыть подкл

                MySqlCommand command = dataBase.GetConnection().CreateCommand();//создаём команду
                command.CommandType = CommandType.Text;//текстовая команда
                //создаем Mysql query
                command.CommandText = "INSERT INTO IncomeOutcomeTable VALUES (NULL,N'" + sumBox.Text + "','1', N'" + categoryBox.Text + "', '" + date + "', N'" + commentBox.Text + "')";//записываем команду
                command.ExecuteNonQuery();//выполнить query
                dataBase.CloseConnection();//закрыть базу

                MessageBox.Show("INSERTED");
                this.Close();       //закрыть эту форму так как уже не нужна
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();//закрыть это окно
        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
