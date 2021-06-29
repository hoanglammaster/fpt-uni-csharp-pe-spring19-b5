using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo
{
    public partial class WebForm2 : System.Web.UI.Page
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
        protected void reloadData()
        {
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
            reloadData();
        }

        protected void AddMember_Click(object sender, EventArgs e)
        {
            

        }
    }
}