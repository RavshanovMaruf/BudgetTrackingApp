using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MicrosLoginTest.Forms;
using MySql.Data.MySqlClient;

namespace MicrosLoginTest
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }
        
        private void createBtn_Click(object sender, EventArgs e)
        {
            CreateAccountForm accountForm = new CreateAccountForm();
            accountForm.Show();//показать форму для создания аккаунта
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void lognBtn_Click(object sender, EventArgs e)
        {
            if (loginBox.Text != "" && passwordBox.Text != "")//если не пусто
            {
                DataBase dataBase = new DataBase();
                dataBase.OpenConnection();//открыть подключение
                string userid = loginBox.Text;//получить текст от бокса
                string password = passwordBox.Text;//получить текст от бокса

                //создаем mysql query
                MySqlCommand command = new MySqlCommand("select password, login from MicrosAccountTable where password='" + password + "'and login='" + userid + "'", dataBase.GetConnection());
                
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                dataAdapter.Fill(dataTable);//заполняем таблицу 

                if (dataTable.Rows.Count > 0)//если логин и пароль подходят к инфе в базе данных
                {
                    DashboardForm boardForm = new DashboardForm();
                    boardForm.Show();           //показать главную форму
                    this.Visible = false;       //скрыть логинформу
                }
                else
                {
                    MessageBox.Show("Invalid login");//показать то что неправильно ввели
                }
                command.ExecuteNonQuery();//послать команду
                dataBase.CloseConnection();//закрыть подкл
            }
        }
    }
}
