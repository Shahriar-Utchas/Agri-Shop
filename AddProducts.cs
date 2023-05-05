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
using System.Windows.Media;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using AgriShop.CustomControls;
using System.Windows.Controls;


namespace AgriShop
{
    public partial class AddProducts : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public AddProducts()
        {
            InitializeComponent();
        }

        private void Amount_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if(textBox.Text == "Product Name")
            {
                textBox.Text = string.Empty;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Product ID")
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Product Price")
            {
                textBox2.Text = string.Empty;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {

            if (textBox3.Text == "Quantity")
            {
                textBox3.Text = string.Empty;
            }
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = "Product Name";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "Product ID";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "Product Price";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "Quantity";
            }
        }

        private void iconAttachbtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files (.jpg, *.jpeg, *.png, *.bmp)|.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog1.Title = "Select an Image";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    Class1.ProductPath = openFileDialog1.FileName;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Confirmbtn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            try
            {
                if (textBox.Text != string.Empty
               && textBox1.Text != string.Empty
               && textBox2.Text != string.Empty
               && textBox3.Text != string.Empty
               && textBox.Text != "Product Name"
               && textBox1.Text != "Product ID"
               && textBox2.Text != "Product Price"
               && textBox3.Text != "Quantity"
               && Class1.ProductPath != "")
                {
                    string query = "insert into dbo.products values('" + textBox1.Text + "','" + textBox.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + Class1.ProductPath + "');";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    con.Open();
                    da.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Product Added!!");
                }
                else
                {
                    MessageBox.Show("Fill all the details!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch 
            {
                MessageBox.Show("Already has a product by this product id, change it!");

            }
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
