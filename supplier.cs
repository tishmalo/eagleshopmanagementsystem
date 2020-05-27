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
    public partial class supplier : Form
    {
         SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        public supplier()
        {
            InitializeComponent();
              con = new SqlConnection(dbcon.MyConnection());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

                con.Open();
                var sql = "INSERT INTO suppliers(sname, oamount,pamount) VALUES(@sname, @oamount,@pamount)";
                using (var com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddWithValue("@sname", textBox1.Text);
                    com.Parameters.AddWithValue("@oamount", textBox2.Text);
                    com.Parameters.AddWithValue("@pamount", textBox4.Text);
                    com.ExecuteNonQuery();
                    

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                }


                MessageBox.Show("SUPPLIER ADDED SUCCESSFULLY!");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "SELECT sname,oamount,pamount  FROM suppliers ";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dt;
                dataGridView1.DataSource = bsource;
                sda.Update(dt);
                con.Close();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].Cells["balance"].Value = Double.Parse(dataGridView1.Rows[row.Index].Cells["oamount"].Value.ToString()) - Double.Parse(dataGridView1.Rows[row.Index].Cells["pamount"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "DELETE FROM suppliers WHERE sname= '" + textBox1.Text + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("SUPPLIER DELETED SUCCESSFULLY!");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Already selected!!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }
    }
}
