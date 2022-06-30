using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MicrosLoginTest
{
    public partial class CreateAccountForm : Form
    {
        
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();//чтобы использовать функции внутри этого класса
            if (loginBox.Text != "" && passwordBox.Text != "") //если боксы не пустые
            {
                dataBase.OpenConnection();//открыть базу
                
                MySqlCommand command = dataBase.GetConnection().CreateCommand();
                //создаём команду
                command.CommandType = CommandType.Text;

                //создаем mysql query
                command.CommandText = "INSERT INTO MicrosAccountTable VALUES (N'" + loginBox.Text + "',N'" + passwordBox.Text + "')";
                command.ExecuteNonQuery();//послать команду
                dataBase.CloseConnection();//закрыть базу

                MessageBox.Show("Создано");
                this.Close();       //закрыть эту форму так как уже не нужна
            }
        }

        private void accountTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.accountTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountsDataBaseDataSet);

        }

        private void CreateAccountForm_Load(object sender, EventArgs e)
        {
        }
    }
}
