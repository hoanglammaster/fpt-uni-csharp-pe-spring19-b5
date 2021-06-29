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
        public void loadData()
        {
            dataGridView1.Columns.Clear();
            string query = "SELECT c.corp_no, c.corp_name, c.street ,c.expr_dt, r.region_name FROM corporation c JOIN region r ON c.region_no = r.region_no";
            SqlCommand command = new SqlCommand(query, DAO.getConnection());

            DataTable dataTable =  DAO.getTableFromSql(command);

            
            dataGridView1.AutoGenerateColumns = false;

            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            selectColumn.HeaderText = "Select";
            selectColumn.Name = "select";
            selectColumn.ValueType = typeof(bool);
            selectColumn.FalseValue = false;
            selectColumn.TrueValue = true;
            
            

            DataGridViewTextBoxColumn noColumn = new DataGridViewTextBoxColumn();
            noColumn.HeaderText = "Corporation No";
            noColumn.Name = "no";
            
            noColumn.DataPropertyName = "corp_no";

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.HeaderText = "Corporation Name";
            nameColumn.Name = "name";
            nameColumn.DataPropertyName = "corp_name";

            DataGridViewTextBoxColumn streetColumn = new DataGridViewTextBoxColumn();
            streetColumn.HeaderText = "Street";
            streetColumn.Name = "street";
            streetColumn.DataPropertyName = "street";

            DataGridViewTextBoxColumn regionName = new DataGridViewTextBoxColumn();
            regionName.HeaderText = "Region Name";
            regionName.Name = "regionName";
            regionName.DataPropertyName = "region_name";

            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Name = "edit";
            editColumn.Text = "Edit";
            editColumn.UseColumnTextForButtonValue = true;
            DataGridViewTextBoxColumn dateColumn = new DataGridViewTextBoxColumn();
            dateColumn.HeaderText = "Date";
            dateColumn.Name = "date";
            dateColumn.DataPropertyName = "expr_dt";
            dateColumn.Visible = false;

            dataGridView1.Columns.Add(selectColumn);
            dataGridView1.Columns.Add(noColumn);
            dataGridView1.Columns.Add(nameColumn);
            dataGridView1.Columns.Add(streetColumn);
            dataGridView1.Columns.Add(regionName);
            dataGridView1.Columns.Add(dateColumn);
            dataGridView1.Columns.Add(editColumn);
            
            dataGridView1.DataSource = dataTable;
            
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                dataGridView1[0, row.Index].Value = false;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.RowIndex != -1)
            {
                Form2 form2 = new Form2(new Corporation(Convert.ToInt32(dataGridView1[1, e.RowIndex].Value), dataGridView1[2, e.RowIndex].Value.ToString(), dataGridView1[3, e.RowIndex].Value.ToString(), dataGridView1[4, e.RowIndex].Value.ToString(), DateTime.Parse(dataGridView1[5, e.RowIndex].Value.ToString())));
                form2.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> listQuery = new List<string>();
            
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                if (cell.Value != null  && cell.TrueValue == cell.Value)
                {
                    DataGridViewTextBoxCell noCell = (DataGridViewTextBoxCell)row.Cells[1];
                    listQuery.Add("delete member where corp_no = "+noCell.Value+ " delete corporation where corp_no = " + noCell.Value );
                }
                
            }
            if (listQuery.Count > 0)
            {
                DAO.runBatchSql(listQuery);
                loadData();
                MessageBox.Show("Deleted "+listQuery.Count+" corporation(s)");
            }
            else
            {
                MessageBox.Show("You must select one corporation at least");
            }

        }
    }
}
