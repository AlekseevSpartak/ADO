using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataViewExample
{
    public partial class Form1 : Form

    {
        DataView customersDataView;
        DataView ordersDataView;


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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Orders". При необходимости она может быть перемещена или удалена.
            this.ordersTableAdapter.Fill(this.northwindDataSet.Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Customers". При необходимости она может быть перемещена или удалена.
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
            customersTableAdapter.Fill(northwindDataSet.Customers);
            ordersTableAdapter.Fill(northwindDataSet.Orders);

            customersDataView = new DataView(northwindDataSet.Customers);
            ordersDataView = new DataView(northwindDataSet.Orders);
            customersDataView.Sort = "CustomerID";
            CustomersGrid.DataSource = customersDataView;
        }

        private void SetDataViewPropertiesButton_Click(object sender, EventArgs e)
        {
            customersDataView.Sort = SortTextBox.Text;
            customersDataView.RowFilter = FilterTextBox.Text;

        }

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            DataRowView newCustomRow = customersDataView.AddNew();
            newCustomRow["CustomerID"] = "WINGT";
            newCustomRow["CompanyName"] = "Wing Tip Toys";
            newCustomRow.EndEdit();
        }

        private void GetOrdersButton_Click(object sender, EventArgs e)
        {
            string selectedCustomerID = (string)CustomersGrid.SelectedCells[0].OwningRow.Cells["CustomerID"].Value;

            DataRowView selectedRow =   customersDataView[customersDataView.Find(selectedCustomerID)];
            ordersDataView =selectedRow.CreateChildView(northwindDataSet.Relations["FK_Orders_Customers"]);
            OrdersGrid.DataSource = ordersDataView;


        }

        private void Orders_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
