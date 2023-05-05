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
    public partial class CusDashboard : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public CusDashboard()
        {
            InitializeComponent();
        }

        private void CusDashboard_Load(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select pid,pname,price,qty,photo from dbo.[order] where [user] = @user";
                SqlCommand cm = new SqlCommand(query, con);
                cm.Parameters.AddWithValue("@user", Class1.userName);
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
            else
            {
                MessageBox.Show("You need to login first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
