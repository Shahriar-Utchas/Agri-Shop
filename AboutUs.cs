using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgriShop
{
    public partial class AboutUs : Form
    {
        Thread th;
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            if (Class1.farmabt)
            {
                ContactUsLabel.Visible = false;
                Numberlbl.Visible = false;
                label1.Visible = false;
                Class1.farmabt = false;
            }
        }
    }
}
