using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSM_Trader
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "version " + RubberDuckyTrader.Properties.Settings.Default.version;
        }
    }
}
