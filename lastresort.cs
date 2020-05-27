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
    public partial class lastresort : Form
    {
        public lastresort()
        {
            InitializeComponent();
        }

        private void lastresort_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mercyDataSet2.stocks4' table. You can move, or remove it, as needed.
            //this.stocks4TableAdapter.Fill(this.mercyDataSet2.stocks4);

            this.reportViewer1.RefreshReport();
        }
    }
}
