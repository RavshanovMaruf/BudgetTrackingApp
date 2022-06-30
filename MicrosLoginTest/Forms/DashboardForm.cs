using System;
using System.Data;
using System.Windows.Forms;
using MicrosLoginTest.Forms;        //получить доступ к формам
using MySql.Data.MySqlClient;       //получить доступ к MYSQL

namespace MicrosLoginTest.Forms
{
    public partial class DashboardForm : Form
    {
        DataBase dataBase = new DataBase();//чтобы использовать функции внутри этого класса
        //переменные
        int income = 0;
        int outcome = 0;
        int balance = 0;
        Delete deleteForm;

        public DashboardForm()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Dash_closed);
            
        }
        void Dash_closed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();//выходим из приложения
        }
        void Delete_FormClosed(object sender, FormClosedEventArgs e)//handle event
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }
        void Income_formClosed(object sender, FormClosedEventArgs e)//handle event
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }
        void Outcome_formClosed(object sender, FormClosedEventArgs e)//handle event
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void dashboard_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IncomeForm incomeForm = new IncomeForm();
            incomeForm.Show();  //открыть окно добавления дохода
            incomeForm.FormClosed += new FormClosedEventHandler(Income_formClosed);
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

            dataBase.OpenConnection();//открыть подключение
            //послать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            //заполнить таблицу
            da.Fill(dt);
            //заполнить форму таблицы которая находится на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подключение
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OutcomeForm outcome = new OutcomeForm();
            outcome.Show();      //показать форму на затраты
            outcome.FormClosed += new FormClosedEventHandler(Outcome_formClosed);
        }

        private void incomeTableBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.incomeTableBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.accountsDataBaseDataSet);

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void incomeTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
        public void printData(DataTable dataTable)    //обновлять информацию
        {
            ReadIncome(dataTable);//получить и обновить доходы
            ReadOutcome(dataTable);//получить и обновить расходы
            ReadBalance();//получить баланс
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }
        private void ReadIncome(DataTable dataTable)
        {
            income = 0;//приравнять чтобы не увеличивалось
            dataBase.OpenConnection();//открыть подключение
            //полсать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //получаем все суммы где доход
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE incBool = 1";

            //пройти через все ряды и получить инфу
            foreach (DataRow row in dataTable.Rows)
            {
                
                bool incomeBool = Convert.ToBoolean(row["incBool"]);
                if (incomeBool)//выполнить если доход
                    income += Convert.ToInt32(row["sum"]);//прибавить после поиска
            }
            //изменить текст лейбла
            incomeLabel.Text = Convert.ToString(income) + "$";
            
            dataBase.CloseConnection();//закрыть подключение
        }
        private void ReadOutcome(DataTable dataTable)
        {
            outcome = 0;//приравнять чтобы не увеличивалось
            dataBase.OpenConnection();//открыть подкл
            //создать Mysql команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE incBool = 0";

            //пройти через все ряды и получить инфу
            foreach (DataRow row in dataTable.Rows)
            {
                bool outcomeBool = !Convert.ToBoolean(row["incBool"]);
                if (outcomeBool)//выполнить если расход
                    outcome += Convert.ToInt32(row["sum"]);//прибавить после поиска
            }
            //изменить текст лейбла
            outcomeLabel.Text = Convert.ToString(outcome) + "$";
            
            dataBase.CloseConnection();//закрыть подкл
        }
        private void ReadBalance()
        {

            balance = income - outcome;//получить баланс
            balanceLabel.Text = balance.ToString() + "$";///изменить текст лейбла
        }

        private void balanceLabel_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            
            dataBase.OpenConnection();
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE CONCAT(Id,sum,incBool,category,date,comment) LIKE '%" + searchBox.Text + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            da.Fill(dt);
            
            incomeTableDataGridView.DataSource = dt;
            dataBase.CloseConnection();
            ReadIncome(dt);
            ReadOutcome(dt);
            ReadBalance();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            
            da.Fill(dt);//заполнить таблицу
            
            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
            searchBox.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE incBool = 1";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE incBool = 0";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query где берем только в интервале месяц
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE date BETWEEN (CURRENT_DATE() - INTERVAL 1 MONTH) AND CURRENT_DATE()";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query где берем только в интервале год
            command.CommandText = "SELECT * FROM IncomeOutcomeTable WHERE date BETWEEN (CURRENT_DATE() - INTERVAL 1 YEAR) AND CURRENT_DATE()";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            dataBase.OpenConnection();//открыть подкл
            //создать команду
            MySqlCommand command = dataBase.GetConnection().CreateCommand();
            command.CommandType = CommandType.Text;
            //создать Mysql query где берем только в интервале год
            command.CommandText = "SELECT * FROM IncomeOutcomeTable";

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command);

            da.Fill(dt);//заполнить таблицу

            //заполнить таблицу на форме
            incomeTableDataGridView.DataSource = dt;

            printData(dt);    //показывать инфу
            dataBase.CloseConnection();//закрыть подкл
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteForm = new Delete();
            deleteForm.Show();
            deleteForm.FormClosed += new FormClosedEventHandler(Delete_FormClosed);
        }

    }
}
