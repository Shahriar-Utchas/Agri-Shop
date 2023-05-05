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
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Controls.Primitives;

namespace AgriShop
{
    public partial class item : UserControl
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public item()
        {
            InitializeComponent();
        }
        public  item(int ID, string PNAME, string PRICE, int QTY, Image IM)
        {
            InitializeComponent();
            iD = ID;
            Pname = PNAME;
            Price = PRICE;
            qTY = QTY;
            iM = IM;

        }
        public int iD { get; set; }
        public string Pname {
            get => label4.Text;
            set => label4.Text = value;
        }
        public string Price {
            get => label5.Text;
            set => label5.Text = value;
        
        }
        public int qTY {
            get => int.Parse(label3.Text);
            set => label3.Text = value + ""; 
        }
        public Image iM
        {
            get => pictureBox1.Image;
            set => pictureBox1.Image = value;
        }
        

      
        private void item_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void iconButtonOrder_Click(object sender, EventArgs e)
        {
            if(Class1.userName != "User" && Class1.userName != "")
            {
                SqlConnection con = new SqlConnection(connection);
                int key = iD;
                string query = "select * from dbo.products where id = @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", key);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string im = dr["photo"].ToString();
                    string p = dr["pname"].ToString();
                    string pr = dr["price"].ToString();
                    string q = dr["qty"].ToString();
                    
                    try
                    {
                        SqlConnection con2 = new SqlConnection(connection);
                        string query2 = "insert into dbo.cart values('" + Class1.userName + "','" + key + "','" + p + "','" + pr + "','" + im + "','" + q + "');";
                        SqlDataAdapter da2 = new SqlDataAdapter(query2, con2);
                        con2.Open();
                        da2.SelectCommand.ExecuteNonQuery();
                        con2.Close();
                        MessageBox.Show("Added to cart!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch(Exception ee) 
                    {
                        MessageBox.Show(ee.ToString());
                    
                    }
                    con.Close();

                }
            }
            else
            {
                MessageBox.Show("You need to login first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
