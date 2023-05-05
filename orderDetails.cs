using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Controls.Primitives;
using System.IO;

namespace AgriShop
{
    public partial class orderDetails : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public orderDetails()
        {
            InitializeComponent();
        }

        private void orderDetails_Load(object sender, EventArgs e)
        {
            if(Class1.farmDash== true)
            {
                labelRegEmail.Text = "Sold Items";
                Class1.farmDash = false;
            }
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from dbo.[order] ";
                SqlCommand cm = new SqlCommand(query, con);
                con.Open();
                SqlDataAdapter sd = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                dt.Columns.Add("image", Type.GetType("System.Byte[]"));
                foreach (DataRow drow in dt.Rows)
                {
                    drow["image"] = File.ReadAllBytes(drow["photo"].ToString());
                }
                dataGridView1.DataSource = dt;
        }

        private void labelRegEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
