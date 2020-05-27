using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace shopsystem
{
    public partial class ledger : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();

        public ledger()
        {
            InitializeComponent();
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            con.Open();
            string query = "SELECT date FROM stocks ";
            try
            {
                DateTime dj = DateTime.Now;
                DateTime dateOnly = dj.Date;
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
                sda.Update(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
