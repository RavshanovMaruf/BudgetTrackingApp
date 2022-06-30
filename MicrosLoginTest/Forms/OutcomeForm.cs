using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MicrosLoginTest.Forms
{
    public partial class OutcomeForm : Form
    {
        DataBase dataBase = new DataBase();//чтобы использовать функции внутри этого класса

        public OutcomeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sumBox.Text != "" && categoryBox.Text != "")//проверяем не пустые ли поля
            {
                string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");//перевести в нужную нам форму

                dataBase.OpenConnection();  //открыть базу
                MySqlCommand command = dataBase.GetConnection().CreateCommand();//создаём команду
                command.CommandType = CommandType.Text;//текстовая команда
                //создаем Mysql query
                command.CommandText = "INSERT INTO IncomeOutcomeTable VALUES (NULL,N'" + sumBox.Text + "','false', N'" + categoryBox.Text + "', '" + date + "', N'" + commentBox.Text + "')";//записываем команду
                command.ExecuteNonQuery();//выполнить query
                dataBase.CloseConnection();//закрыть базу

                MessageBox.Show("INSERTED");
                this.Close();       //закрыть эту форму так как уже не нужна

            }
        }

        private void categoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void commentBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void sumBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            this.Close();//закрыть это окно
        }

        private void OutcomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
