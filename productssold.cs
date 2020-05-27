using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Windows.Forms;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace shopsystem
{
    public partial class productssold : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        public productssold()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());
        }
        DataTable table = new DataTable();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void productssold_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\mercy.mdf;Integrated Security=True"))
            {
                string query = "SELECT pname,quantity,price,Date FROM stocks4 WHERE Date >= DATEADD(day, -1, GETDATE()) ";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {


                    SqlDataAdapter sda = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dt);

                    if (dt.Rows.Count > 0)
                    { //check if the query returns any data
                        dataGridView1.DataSource = dt;
                        //dg1.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Record not found!");
                    }
                }
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\mercy.mdf;Integrated Security=True"))
            {
                string query = "SELECT pname,quantity,price,Date FROM stocks4 WHERE Date >= DATEADD(day, -7, GETDATE()) ";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {


                    SqlDataAdapter sda = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dt);

                    if (dt.Rows.Count > 0)
                    { //check if the query returns any data
                        dataGridView1.DataSource = dt;
                        //dg1.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Record not found!");
                    }
                }
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\mercy.mdf;Integrated Security=True"))
            {
                string query = "SELECT* FROM stocks4 WHERE DATEPART(m, Date) = DATEPART(m, DATEADD(m, -1, getdate())) AND DATEPART(yyyy, Date) = DATEPART(yyyy, DATEADD(m, -1, getdate()))";


                using (SqlCommand cmd = new SqlCommand(query, cn))
                {


                    SqlDataAdapter sda = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    BindingSource bsource = new BindingSource();
                    bsource.DataSource = dt;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dt);

                    if (dt.Rows.Count > 0)
                    { //check if the query returns any data
                        dataGridView1.DataSource = dt;
                        //dg1.DataBind();
                    }
                    else
                    {
                        MessageBox.Show("Record not found!");
                    }
                }
            }
        }
    }
}

