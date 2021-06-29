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
    public partial class Form2 : Form
    {
        private Corporation corporation;
        public Form2(Corporation corporation)
        {
            InitializeComponent();
            this.corporation = corporation;
            textBox1.Text = corporation.CorName;
            textBox2.Text = corporation.Street;
            dateTimePicker1.Value = corporation.ExpDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string[] nameArray = name.Split(' ');
            if (nameArray[0].Equals("Corp."))
            {
                string query = "update corporation set corp_name = @name, street = @street, expr_dt = @expr where corp_no = @no";
                SqlCommand sqlCommand = new SqlCommand(query,DAO.getConnection());
                List<SqlParameter> listParameter = new List<SqlParameter>();
                listParameter.Add(new SqlParameter("@name", textBox1.Text));
                listParameter.Add(new SqlParameter("@street", textBox2.Text));
                listParameter.Add(new SqlParameter("@expr", dateTimePicker1.Value));
                listParameter.Add(new SqlParameter("@no", corporation.CorNo));
                sqlCommand.Parameters.AddRange(listParameter.ToArray());
                DAO.updateDataToSql(sqlCommand);
                Program.Form1s.loadData();
                MessageBox.Show("Edit successfully!");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Corporation name is not satisfied");
                return;
            }
        }
    }
}
