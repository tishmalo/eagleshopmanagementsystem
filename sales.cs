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
    public partial class sales : Form
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        public sales()
        {
            InitializeComponent();
            con = new SqlConnection(dbcon.MyConnection());
              
        }
        DataTable table = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            searchbypname(textBox1.Text.Trim());
        }
        protected void searchbypname(string searchText)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("No name to search!");

            }
            else
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                using (SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tishm\OneDrive\Desktop\eagleshiet10001\shopsystem\mercy.mdf;Integrated Security=True")) 
                {
                    string query = "SELECT pname,quantity,price FROM stocks WHERE pname = '" + textBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {

                        cmd.Parameters.AddWithValue("pname", textBox1.Text);

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            stocks Main = new stocks();
            Main.Show();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
               
            }
            catch {
                MessageBox.Show("No item to delete!!");
            }
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "UPDATE stocks SET  pname='" + textBox2.Text + "',quantity=quantity+'" + textBox3.Text + "'WHERE pname='" + textBox2.Text + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                 
               
                table.Rows.Add(textBox2.Text,textBox3.Text,textBox4.Text);
                dataGridView1.DataSource = table;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].Cells["amount"].Value = Double.Parse(dataGridView1.Rows[row.Index].Cells["quantity"].Value.ToString()) * Double.Parse( dataGridView1.Rows[row.Index].Cells["price"].Value.ToString());
                }
                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            
            
            }
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "UPDATE stocks SET  pname='" + textBox2.Text + "',quantity=quantity-'" + textBox3.Text + "'WHERE pname='" + textBox2.Text + "'";
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                sda.SelectCommand.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();

                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            stocks Main = new stocks();
            Main.Show();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {


                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells["amount"].Value);

            }



            textBox5.Text = sum.ToString();


            
            for (int n = 0; n < dataGridView1.Rows.Count; n++)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                DateTime time = DateTime.Now;              // Use current time
                string format = "yyyy-MM-dd HH:mm:ss";    // modify the format depending upon input required in the column in database 
                string insert = @" insert into stocks4(pname,quantity,price,Date) values ('" + dataGridView1.Rows[n].Cells["pname"].Value + "','" + dataGridView1.Rows[n].Cells["quantity"].Value + "','" + dataGridView1.Rows[n].Cells["price"].Value + "','" + time.ToString(format) + "')";
                SqlDataAdapter sda = new SqlDataAdapter(insert, con);
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("inserted sucessfully!!");
            }
            
            




        }

        private void sales_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = this.dataGridView1.Rows[e.RowIndex];

                    textBox2.Text = selectedRow.Cells["pname"].Value.ToString();
                    textBox3.Text = selectedRow.Cells["quantity"].Value.ToString();
                    textBox4.Text = selectedRow.Cells["price"].Value.ToString();
                   

                    table.Columns.Add("pname", typeof(string));
                    table.Columns.Add("quantity", typeof(double));
                    table.Columns.Add("price", typeof(double));
                  
                   
                   

                    dataGridView1.DataSource = table;
                } 
                
            }
            catch  {
                MessageBox.Show("Already selected!");
            }

            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "SELECT pname,quantity,price FROM stocks ";
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

      
        }
        }


            
        
