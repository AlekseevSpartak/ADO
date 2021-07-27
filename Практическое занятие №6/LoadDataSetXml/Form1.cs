using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadDataSetXml
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        DataSet NorthwindDataSet = new DataSet();
        private void LoadSchemaButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.ReadXml("Northwind.xml");
        }

        private void LoadDataButton_Click(object sender, EventArgs e)
        {
            NorthwindDataSet.ReadXmlSchema("Northwind.xsd");
            CustomersGrid.DataSource = NorthwindDataSet.Tables["Customers"];
            OrdersGrid.DataSource = NorthwindDataSet.Tables["Orders"];

        }
    }
}
