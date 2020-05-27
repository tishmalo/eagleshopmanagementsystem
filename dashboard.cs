using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopsystem
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void bunifuCards2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void bunifuCards2_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;
        }

        private void bunifuCards2_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
            
        }

        private void bunifuCards1_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;
           

        }

        private void bunifuCards1_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }

        private void bunifuCards3_MouseEnter(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = true;
            bunifuCircleProgressbar2.animated = true;

        }

        private void bunifuCards3_MouseLeave(object sender, EventArgs e)
        {
            bunifuCircleProgressbar1.animated = false;
            bunifuCircleProgressbar2.animated = false;
        }
    }
}
