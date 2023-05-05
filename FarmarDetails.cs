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
    public partial class FarmarDetails : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public FarmarDetails()
        {
            InitializeComponent();
        }

        private void FarmarDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select farmusername,farmpass,farmemail,farmadd,farmdob,Farmpic from dbo.Farmer_info";
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
            foreach (DataRow drow in dt.Rows)
            {
                drow["Pic"] = File.ReadAllBytes(drow["FarmPic"].ToString());
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Do you delete this Farmar Account?", "Farmar Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {  
            SqlConnection con = new SqlConnection(cs);
            string user = (dataGridView1.Rows[e.RowIndex].Cells["FarmUsername"].FormattedValue.ToString());
            string query = "delete from dbo.Farmer_info where FarmUsername= @user;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@user", user);
            con.Open();
            cmd.ExecuteNonQuery();
                Application.Exit();
                th = new Thread(openNewFrom);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void openNewFrom()
        {
            Class1.farmDlt = true;
            Application.Run(new AdminHome());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
