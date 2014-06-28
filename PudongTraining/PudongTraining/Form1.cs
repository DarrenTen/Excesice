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
            // TODO: 这行代码将数据加载到表“productDBDataSet.Customer”中。您可以根据需要移动或删除它。
            this.customerTableAdapter.Fill(this.productDBDataSet.Customer);
            // TODO: 这行代码将数据加载到表“productDBDataSet.vwUserOrder”中。您可以根据需要移动或删除它。
            this.vwUserOrderTableAdapter.Fill(this.productDBDataSet.vwUserOrder);
           
           

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectCustomerID = comboBox1.SelectedValue;
            if (selectCustomerID==null)
            {
                return;
            }
            string cmd = "select * from vwUserOrder where CustomerID=@CustomerID";
            var dt= SQLHelper.ExecuteDatatable(cmd, new SqlParameter("@CustomerID", selectCustomerID));
            dataGridView1.DataSource = dt.DefaultView;
        }
    }
}
