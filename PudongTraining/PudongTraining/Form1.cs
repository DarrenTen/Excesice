using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PudongTraining.Utility;
using System.Data.SqlClient;
using PudongTraining.DAL;

namespace PudongTraining
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cbCustomers.DataSource = new CustomerDAL().GetAll().DefaultView;
            cbCustomers.DisplayMember = "Name";
            cbCustomers.ValueMember = "CustomerID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectCustomerID = cbCustomers.SelectedValue;
            if (selectCustomerID == null)
            {
                return;
            }
            string cmd = "select * from vwUserOrder where CustomerID=@CustomerID";
            var dt = SQLHelper.ExecuteDatatable(cmd, new SqlParameter("@CustomerID", selectCustomerID));
            dataGridView1.DataSource = dt.DefaultView;
        }
    }
}
