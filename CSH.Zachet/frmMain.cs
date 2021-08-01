using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CSH.Zachet
{

    public partial class frmMain : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private bool newRowAdding = false;




        public frmMain()
        {
            InitializeComponent();
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            sqlConnection  = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aleks\Desktop\CSH.Zachet\Northwind.mdf;Integrated Security=True;Connect Timeout=30");
            sqlConnection.Open();

            LoadData();
        }
        private void LoadData()
        {

            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT *, 'delete' AS [Delete] FROM Customers", sqlConnection);

                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "Customers");
                dataGridView1.DataSource = dataSet.Tables["Customers"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[11, i] = linkCell;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void ReLoadData()
            {

                try
                {
                dataSet.Tables["Customers"].Clear();
                    sqlDataAdapter.Fill(dataSet, "Customers");
                    dataGridView1.DataSource = dataSet.Tables["Customers"];

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {

                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[11, i] = linkCell;

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ReLoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 11)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
                    if (task == "Delete")
                    {
                        if (MessageBox.Show("Удалить эту строку?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                        {
                            int rowIndex = e.RowIndex;
                            dataGridView1.Rows.RemoveAt(rowIndex);
                            dataSet.Tables["Customers"].Rows[rowIndex].Delete();
                            sqlDataAdapter.Update(dataSet, "Customers");
                        }
                    }
                   else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        DataRow row = dataSet.Tables["Customers"].NewRow();
                        
                        row["CompanyName"] = dataGridView1.Rows[rowIndex].Cells["CompanyName"].Value;
                        row["ContactName"] = dataGridView1.Rows[rowIndex].Cells["ContactName"].Value;
                        row["ContactTitle"] = dataGridView1.Rows[rowIndex].Cells["ContactTitle"].Value;
                        row["Address"] = dataGridView1.Rows[rowIndex].Cells["Address"].Value;
                        row["City"] = dataGridView1.Rows[rowIndex].Cells["City"].Value;
                        row["Region"] = dataGridView1.Rows[rowIndex].Cells["Region"].Value;
                        row["PostalCode"] = dataGridView1.Rows[rowIndex].Cells["PostalCode"].Value;
                        row["Country"] = dataGridView1.Rows[rowIndex].Cells["Country"].Value;
                        row["Phone"] = dataGridView1.Rows[rowIndex].Cells["Phone"].Value;
                        row["Fax"] = dataGridView1.Rows[rowIndex].Cells["Fax"].Value;

                        dataSet.Tables["Customers"].Rows.Add(row);
                        dataSet.Tables["Customers"].Rows.RemoveAt(dataSet.Tables["Customers"].Rows.Count - 1);
                        dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                        dataGridView1.Rows[e.RowIndex].Cells[11].Value = "Delete";
                        sqlDataAdapter.Update(dataSet, "Customers");
                        newRowAdding = false;


                    }
                    else if (task == "Update")
                    {

                        int r = e.RowIndex;
                        dataSet.Tables["Customers"].Rows [r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["ContactName"] = dataGridView1.Rows[r].Cells["ContactName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["ContactTitle"] = dataGridView1.Rows[r].Cells["ContactTitle"].Value;
                        dataSet.Tables["Customers"].Rows[r]["Address"] = dataGridView1.Rows[r].Cells["Address"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;
                        dataSet.Tables["Customers"].Rows[r]["CompanyName"] = dataGridView1.Rows[r].Cells["CompanyName"].Value;


                    }
                    ReLoadData();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Row Failed");
            }

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;

                    int lastRow = dataGridView1.Rows.Count - 2;

                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[11, lastRow] = linkCell;
                    row.Cells["Delete"].Value = "Insert";

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                   
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[11, rowIndex] = linkCell;
                    editingRow.Cells["Delete"].Value = "Update";
                    sqlDataAdapter.Update(dataSet, "Customers");


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }

    }
