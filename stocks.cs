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
    public partial class stocks : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        dbconnection dbcon = new dbconnection();
        public stocks()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.MyConnection());
            cn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            products f = new products();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
        }

        private void stocks_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            sales f = new sales();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            salesreport f = new salesreport();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            Application.ExitThread();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            user f = new user();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            supplier f = new supplier();
            f.TopLevel = false;
            panel3.Controls.Add(f);
            f.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dashboard f = new dashboard();
            f.WindowState = FormWindowState.Maximized;
            f.Focus();
            f.Show();
            f.WindowState = FormWindowState.Normal;
            Application.Run(f);



        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void stocks_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuProgressBar2_progressChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCards1_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;

        }

        private void bunifuCards3_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;
        }

        private void bunifuCards2_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;
        }

        private void bunifuCards1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }

        private void bunifuCards3_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }

        private void bunifuCards2_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }

        private void stocks_MaximumSizeChanged(object sender, EventArgs e)
        {

        }
    }
}
