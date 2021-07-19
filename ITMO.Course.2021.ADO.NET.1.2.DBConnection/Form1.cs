using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBConnection
{

    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();

       
        string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=DESKTOP-NPLHRS3\SQLEXPRESS";
       
        public Form1()

        {
            InitializeComponent();

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void connectToToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void northwingToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch
            {
                MessageBox.Show("Ошибка соединения с базой данных");
            }

           
        }

        private void closeConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");

        }
    }
    }





