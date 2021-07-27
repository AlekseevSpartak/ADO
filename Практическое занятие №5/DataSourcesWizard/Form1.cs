using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourcesWizard
{
    public partial class Form1 : Form
    {
        private BindingSource productsBindingSource;
        public Form1()
        {
            InitializeComponent();
        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Order_Details". При необходимости она может быть перемещена или удалена.
            this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Customers". При необходимости она может быть перемещена или удалена.

            productsTableAdapter1.Fill(northwindDataSet.Products);
            productsBindingSource = new BindingSource(northwindDataSet, "Products");
            ProductIDTextBox.DataBindings.Add("Text", productsBindingSource, "ProductID");
            ProductNameTextBox.DataBindings.Add("Text", productsBindingSource, "ProductName");
        }

        private void ordersBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MovePrevious();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            productsBindingSource.MoveNext();
        }
    }
}
