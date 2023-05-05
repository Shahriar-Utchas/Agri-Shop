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
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AgriShop
{
    public partial class infoEdit : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        string Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public infoEdit()
        {
            InitializeComponent();
        }

        private void infoEdit_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel5.Visible = false;
            iconButton6.Visible = false;
            iconButton7.Visible = false;
          
            try
            {
                string p = (Class1.userName);
                SqlConnection con = new SqlConnection(connection);
                string query = "select * from dbo.Login_info where UserName = @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", p);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Image im = Image.FromFile(@"" + dr["Picture"]);
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    pictureBox1.BackgroundImage = im;
                    

                }
                else
                {
                    con.Close();
                   
                }


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewFrom3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom3()
        {
            Application.Run(new HomePage());
        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            iconButton6.Visible = true;
            iconButton7.Visible = true;
            pictureBox1.BackgroundImage = null;
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files (.jpg, *.jpeg, *.png, *.bmp)|.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog1.Title = "Select an Image";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    Class1.path = openFileDialog1.FileName;


                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton3.Visible = false;
            iconButton4.Visible = false;
            iconButton6.Visible = true;
            iconButton7.Visible = true;


        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text == "New Username")
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "New E-mail")
            {
                textBox2.Text = string.Empty;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "New Address")
            {
                textBox3.Text = string.Empty;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == string.Empty)
            {
                textBox3.Text = "New Address";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == string.Empty)
            {
                textBox2.Text = "New E-mail";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                textBox1.Text = "New Username";
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton3.Visible = false;
            iconButton4.Visible = false;
            iconButton6.Visible = true;
            iconButton7.Visible = true;

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panel5.Visible = true;
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton3.Visible = false;
            iconButton4.Visible = false;
            iconButton6.Visible = true;
            iconButton7.Visible = true;
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            
            iconButton1.Visible = false;
            iconButton2.Visible = false;
            iconButton3.Visible = false;
            iconButton4.Visible = false;
            iconButton6.Visible = true;
            iconButton7.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {
                if (textBox1.Text != string.Empty && textBox1.Text != "New Username")
                {
                    SqlConnection con = new SqlConnection(connection);
                    string query = "update dbo.Login_info set UserName = @user where UserName = @user2";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", textBox1.Text);
                    cmd.Parameters.AddWithValue("@user2", Class1.userName);
                    con.Open();
                    cmd.ExecuteReader();
                    con.Close();
                    MessageBox.Show("Username updated Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Class1.userName = textBox1.Text;
                    Class1.infoChng = true;
                    infochng();
                }
                else if (textBox2.Text != string.Empty && textBox2.Text != "New E-mail")
                {
                    if (Regex.IsMatch(textBox2.Text, Pattern) == false)
                    {
                        MessageBox.Show("Invalid E-mail", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(connection);
                        string query2 = "update dbo.Login_info set [E-mail] = @email where UserName = @user";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@email", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@user", Class1.userName);
                        con2.Open();
                        cmd2.ExecuteReader();
                        con2.Close();
                        MessageBox.Show("E-mail updated Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Class1.infoChng = true;
                        infochng();
                    }
                }
                else if (textBox3.Text != string.Empty && textBox3.Text != "New Address")
                {

                    SqlConnection con3 = new SqlConnection(connection);
                    string query3 = "update dbo.Login_info set Address = @add where UserName = @user";
                    SqlCommand cmd3 = new SqlCommand(query3, con3);
                    cmd3.Parameters.AddWithValue("@add", textBox3.Text);
                    cmd3.Parameters.AddWithValue("@user", Class1.userName);
                    con3.Open();
                    cmd3.ExecuteReader();
                    con3.Close();
                    MessageBox.Show("Address updated Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Class1.infoChng = true;
                    infochng();

                }else if (pictureBox1.Image != null)
                {

                    SqlConnection con4 = new SqlConnection(connection);
                    string query4 = "update dbo.Login_info set Picture = @pic where UserName = @user";
                    SqlCommand cmd4 = new SqlCommand(query4, con4);
                    cmd4.Parameters.AddWithValue("@pic", Class1.path);
                    cmd4.Parameters.AddWithValue("@user", Class1.userName);
                    con4.Open();
                    cmd4.ExecuteReader();
                    con4.Close();
                    MessageBox.Show("Picture updated Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Class1.infoChng = true;
                    infochng();
                }
                else
                {
                    MessageBox.Show("Please fill the box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("You need to login first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void infochng()
        {
            this.Close();
            th = new Thread(openNewFrom4);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom4()
        {
            Application.Run(new HomePage());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            //this.Close();
            Class1.infoChng = true;
            Application.Exit();
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom2()
        {
            Application.Run(new HomePage());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
