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

namespace AgriShop
{
    public partial class products : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public products()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void products_Load_1(object sender, EventArgs e)
        {
            if (Class1.darkThm==true)
            {
                tableLayoutPanel1.BackColor = Color.Black;
                
            }
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from dbo.products";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                int x = 1, y = 1;
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string pname = dr["pname"].ToString();
                    string price = dr["price"].ToString();
                    int qty = int.Parse(dr["qty"] + "");
                    Image im = Image.FromFile(@"" + dr["photo"]);
                    //string path = dr["photo"].ToString();
                    item obj = new item(id, pname, price, qty, im);
                    tableLayoutPanel1.Controls.Add(obj, y, x);
                    y++;
                    if (y >= 4)
                    {
                        y = 1;
                        x++;
                    }
                }
                dr.Close();
                cmd.Clone();
            }catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
