using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Q1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }
        private void loadData()
        {
            string query = "SELECT c.corp_no,c.corp_name,c.street,r.region_name FROM corporation c JOIN region r ON c.region_no = r.region_no  ";
            SqlCommand sqlCommand = new SqlCommand(query, DAO.getConnection());

            DataTable table = DAO.getTableFromSql(sqlCommand);
            
            dataGridView2.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.HeaderText = "Select";
            selectColumn.Name = "select";
            dataGridView2.Columns.Add(selectColumn);

            DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn();
            noColumn.HeaderText = "Corporation No";
            noColumn.Name = "no";
            noColumn.DataPropertyName = "corp_no";
            dataGridView2.Columns.Add(noColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Corporation Name";
            nameColumn.Name = "name";
            nameColumn.DataPropertyName = "corp_name";
            dataGridView2.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn street = new DataGridViewTextBoxColumn();
            street.HeaderText = "Street";
            street.Name = "street";
            street.DataPropertyName = "street";
            dataGridView2.Columns.Add(street);

            DataGridViewTextBoxColumn region = new DataGridViewTextBoxColumn();
            region.HeaderText = "Region Name";
            region.Name = "region";
            region.DataPropertyName = "region_name";
            dataGridView2.Columns.Add(region);

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Name = "edit";
            editColumn.Text = "Edit";
            editColumn.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Add(editColumn);

            dataGridView2.DataSource = table;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
