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
    public partial class Cart : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select pid,pname,price,qty,photo from dbo.cart where [user] = @user";
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from dbo.cart where [user] = @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", Class1.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string id = dr["pid"].ToString();
                    string im = dr["photo"].ToString();
                    string p = dr["pname"].ToString();
                    string pr = dr["price"].ToString();
                    string q = dr["qty"].ToString();

                    try
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "insert into dbo.[order] values('" + Class1.userName + "','" + id + "','" + p + "','" + pr + "','" + im + "','" + q + "');";
                        SqlDataAdapter da2 = new SqlDataAdapter(query2, con2);
                        con2.Open();
                        da2.SelectCommand.ExecuteNonQuery();
                        
                        string query3 = "delete from dbo.cart where [User] = @user;";
                        SqlCommand cmd3 = new SqlCommand(query3, con2);
                        cmd3.Parameters.AddWithValue("@user", Class1.userName);
                        cmd3.ExecuteNonQuery();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show(ee.ToString());

                    }

                }
                if (dr.HasRows)
                {
                    MessageBox.Show("Order Confirmed!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   conOrder();
                }
                else
                {
                    MessageBox.Show("Nothing in Cart!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        public void conOrder()
        {
            Class1.orderCon = true;
            Application.Exit();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        public void openNewFrom()
        {
            Class1.cartRmv = true;
            Application.Run(new HomePage());
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Do you want to remove this from cart?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(cs);
                string user = (dataGridView1.Rows[e.RowIndex].Cells["pid"].FormattedValue.ToString());
                string query = "delete from dbo.cart where pid = @user;";
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
    }
}
