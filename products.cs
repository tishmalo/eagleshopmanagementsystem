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
    public partial class products : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();

        public products()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO stocks(pname,quantity,price, description)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "')";
            
           try{
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
                con.Close();
                MessageBox.Show("INSERTED SUCCESSFULLY!");
                con.Close();
               
           }catch(Exception ex){
           
           MessageBox.Show(ex.Message);
           }
        }

        private void products_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            stocks Main = new stocks();
            Main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM stocks WHERE pname= '" + textBox1.Text + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
                con.Close();
                MessageBox.Show("RECORD DELETED SUCCESSFULLY!");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT pname,quantity,price,description FROM stocks ";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE stocks SET  pname='" + textBox1.Text + "',quantity='" + textBox2.Text + "',price='" + textBox3.Text + "',description='" + richTextBox1.Text + "'WHERE pname='" + textBox1.Text + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                richTextBox1.Clear();
                con.Close();
                MessageBox.Show("UPDATED SUCCESSFULLY!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            searchbypname(textBox4.Text.Trim());
        }
        protected void searchbypname(string searchText)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("No name to search!");

            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\ndanu.mdf;Integrated Security=True"))
                {
                    string query = "SELECT pname,quantity,price,description FROM stocks WHERE pname = '" + textBox4.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {

                        cmd.Parameters.AddWithValue("pname", textBox1.Text);

                        SqlDataAdapter sda = new SqlDataAdapter(query, con);
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
}
