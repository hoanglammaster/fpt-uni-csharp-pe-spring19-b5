using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Q2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadData();
            }
            
        }
        private void loadData()
        {
            string queryRegion = "select region_no, region_name from region";
            SqlCommand command1 = new SqlCommand(queryRegion, DAO.getConnection());
            DataTable table1 = DAO.getTableFromSql(command1);


            region.DataSource = table1;
            region.DataValueField = "region_no";
            region.DataTextField = "region_name";
            DataBind();
            string queryCorp = "select corp_no, corp_name from corporation where region_no = " + region.SelectedValue;
            SqlCommand command2 = new SqlCommand(queryCorp, DAO.getConnection());
            DataTable table2 = DAO.getTableFromSql(command2);
            corporation.DataSource = table2;
            corporation.DataValueField = "corp_no";
            corporation.DataTextField = "corp_name";
            DataBind();
        }

        protected void region_SelectedIndexChanged(object sender, EventArgs e)
        {
            string queryCorp = "select corp_no, corp_name from corporation where region_no = " + region.SelectedValue;
            SqlCommand command2 = new SqlCommand(queryCorp, DAO.getConnection());
            DataTable table2 = DAO.getTableFromSql(command2);
            corporation.DataSource = table2;
            corporation.DataValueField = "corp_no";
            corporation.DataTextField = "corp_name";
            DataBind();

        }

        protected void addMember_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(firstName.Text)&&!string.IsNullOrEmpty(lastName.Text))
            {
                int region_no = Convert.ToInt32(region.SelectedValue);
                int corp_no = Convert.ToInt32(corporation.SelectedValue);
                string firstname = firstName.Text;
                string lastname = lastName.Text;
                string query = "insert into member (firstname, lastname, corp_no, region_no,street,city, state_prov,country,mail_code,expr_dt,issue_dt,member_code)" +
                    " values( '" + firstname + "', '" + lastname + "', " + corp_no + ", " + region_no + ", '', '', '', '', '',DATEADD(MONTH,6,DATEADD(DAY,1,GETDATE())), DATEADD(DAY,1,GETDATE()), '')";
                DAO.insertDataToSql(new SqlCommand(query, DAO.getConnection()));
                region.SelectedIndex = 0;
                firstName.Text = "";
                lastName.Text = "";
                region_SelectedIndexChanged(null, null);
                messageLabel.Text = "Add successfully";
            }

        }
    }
}