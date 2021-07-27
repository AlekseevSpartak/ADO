﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindingSimple
{
    public partial class Form1 : Form
    {
        private BindingSource productsBindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void ProductIDTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ProductNameTextBox_TextChanged(object sender, EventArgs e)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "northwindDataSet.Products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            productsTableAdapter.Fill(northwindDataSet.Products);
            productsBindingSource = new BindingSource(northwindDataSet, "Products");
            ProductIDTextBox.DataBindings.Add("Text", productsBindingSource, "ProductID");
            ProductNameTextBox.DataBindings.Add("Text", productsBindingSource, "ProductName");

        }

        private void productsBindingSource1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource1.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);

        }
    }
}
