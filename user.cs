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
    public partial class user : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        public user()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Resize(object sender, EventArgs e)
        {

        }

        private void user_Resize(object sender, EventArgs e)
        {
            tabControl1.Left = (this.Width - tabControl1.Width) / 2;
            tabControl1.Top = (this.Height - tabControl1.Height) / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            try
            {
                if (textBox2.Text != textBox3.Text) {
                    MessageBox.Show("Passwords don't match!!");
                    return;

                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
               
                con.Open();
                var sql = "INSERT INTO login11(username, password) VALUES(@username, @password)";
                using (var com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddWithValue("@username", textBox1.Text);
                    com.Parameters.AddWithValue("@password", textBox2.Text);
               
                   

                    com.ExecuteNonQuery();
                     textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            
            textBox1.Focus();
        

                }

               
                MessageBox.Show("CREATED SUCCESSFULLY!");
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try { 
                if(textBox5.Text!=textBox6.Text){
                MessageBox.Show("Passwords do not match!!");
                    return;
                }
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
              
             
String str = "update login11 set password=@password where username=@username";
com = new SqlCommand(str, con);
com.Parameters.AddWithValue("password",textBox5.Text);

com.Parameters.AddWithValue("username",textBox4.Text);

con.Open();
com.ExecuteNonQuery();
textBox4.Clear();
textBox5.Clear();
textBox6.Clear();
con.Close();
MessageBox.Show("Password Changed");
            }

                catch(Exception ex)
                {
                MessageBox.Show(ex.Message);
                
                
                }
            
            
            }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "SELECT username,password FROM login11 ";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }

            con.Open();
            if (dataGridView1.RowCount > 2)
            {
                string query = "DELETE FROM login11 WHERE username= '" + textBox8.Text + "'";
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ACCOUNT DELETED SUCCESSFULLY!");
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                MessageBox.Show("Must have atleast one user");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch {
                MessageBox.Show("Already selected!!");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox8.Clear();
            textBox7.Clear();
            textBox7.Focus();
        }
        }
    

       
    }
