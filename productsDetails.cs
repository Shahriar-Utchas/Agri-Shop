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
    public partial class productsDetails : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public productsDetails()
        {
            InitializeComponent();
        }

        private void productsDetails_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string query = "select * from dbo.products";
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            SqlDataAdapter sd = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dt.Columns.Add("Pic", Type.GetType("System.Byte[]"));
            foreach (DataRow drow in dt.Rows)
            {
                drow["Pic"] = File.ReadAllBytes(drow["photo"].ToString());
            }
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Do you delete this product?", "Product Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(cs);
                int id =Convert.ToInt32 (dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString());
                string query = "delete from dbo.products where id= @id;";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
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
            Class1.productDlt = true;
            Application.Run(new AdminHome());
        }
    }
}
