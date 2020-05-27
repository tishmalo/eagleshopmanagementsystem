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
    public partial class login : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();

        public login()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            com.Connection=con;
            com.CommandText = "Select * from login11";
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            { 
            if (textBox1.Text.Equals(dr["username"].ToString())&& textBox2.Text.Equals(dr["password"].ToString()))
                {
                MessageBox.Show("WElCOME ADMIN","Congrats",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                stocks Main = new stocks();
                Main.Show();

                }
                else{
                MessageBox.Show("Wrong username or password","error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            dr.Close();
            com.Dispose();
         con.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
        
    }
}
