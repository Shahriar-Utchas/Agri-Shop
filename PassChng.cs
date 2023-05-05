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

namespace AgriShop
{
    public partial class PassChng : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;

        public PassChng()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PassChng_Load(object sender, EventArgs e)
        {
            if (Class1.userName == "User" || Class1.userName == "")
            {
                MessageBox.Show("You need to log in first!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Current Password")
            {
                textBox3.Text = string.Empty;
                textBox3.PasswordChar = '*';
                textBox3.ForeColor = System.Drawing.Color.White;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "New Password")
            {
                textBox1.Text = string.Empty;
                textBox1.PasswordChar = '*';
                textBox1.ForeColor = System.Drawing.Color.White;
            }
        }

        private void PassChng_Move(object sender, EventArgs e)
        {

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

            if (textBox2.Text == "Retype New Password")
            {
                textBox2.Text = string.Empty;
                textBox2.PasswordChar = '*';
                textBox2.ForeColor = System.Drawing.Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '*')
            {
                button1.Visible = true;
                button2.Visible = false;

                textBox3.PasswordChar = '\0';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.PasswordChar == '\0')
            {
                button2.Visible = true;
                button1.Visible = false;

                textBox3.PasswordChar = '*';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '*')
            {
                button3.Visible = true;
                button4.Visible = false;

                textBox1.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.PasswordChar == '\0')
            {
                button4.Visible = true;
                button3.Visible = false;

                textBox1.PasswordChar = '*';
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                button5.Visible = true;
                button6.Visible = false;

                textBox2.PasswordChar = '\0';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '\0')
            {
                button6.Visible = true;
                button5.Visible = false;

                textBox2.PasswordChar = '*';
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom()
        {
            Application.Run(new HomePage());
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Text = "Current Password";
                textBox3.PasswordChar = '\0';
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "New Password";
                textBox1.PasswordChar = '\0';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "Retype New Password";
                textBox2.PasswordChar = '\0';
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {
                if (textBox1.Text != "New Password"
                && textBox2.Text != "Retype New Password"
                && textBox3.Text != "Current Password")
                {
                    string p = (Class1.userName);
                    SqlConnection con = new SqlConnection(connection);
                    string query = "select * from dbo.Login_info where UserName = @user";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@user", p);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        if (textBox3.Text == dr["password"].ToString())
                        {
                            if (textBox1.Text == textBox2.Text)
                            {
                                SqlConnection con3 = new SqlConnection(connection);
                                string query3 = "update dbo.Login_info set password = @pass where UserName = @user;";
                                SqlCommand cmd3 = new SqlCommand(query3, con3);
                                cmd3.Parameters.AddWithValue("@pass", textBox1.Text);
                                cmd3.Parameters.AddWithValue("@user", Class1.userName);
                                con3.Open();
                                cmd3.ExecuteNonQuery();
                                MessageBox.Show("Password Changed successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("New Password mismatched,,please check properly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Current Password wrong!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(connection);
                        string query2 = "select * from dbo.Farmer_info where FarmUsername = @user";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@user", p);
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            if (textBox3.Text == dr2["FarmPass"].ToString())
                            {
                                if (textBox1.Text == textBox2.Text)
                                {
                                    SqlConnection con3 = new SqlConnection(connection);
                                    string query3 = "update dbo.Farmer_info set FarmPass= @pass where FarmUsername = @user;";
                                    SqlCommand cmd3 = new SqlCommand(query3, con3);
                                    cmd3.Parameters.AddWithValue("@pass", textBox1.Text);
                                    cmd3.Parameters.AddWithValue("@user", Class1.userName);
                                    con3.Open();
                                    cmd3.ExecuteNonQuery();
                                    MessageBox.Show("Password Changed successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("New Password mismatched,,please check properly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Current Password wrong!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            SqlConnection con3 = new SqlConnection(connection);
                            string query3 = "select * from dbo.Admin_Info where AdminName = @user";
                            SqlCommand cmd3 = new SqlCommand(query3, con3);
                            cmd3.Parameters.AddWithValue("@user", p);
                            con3.Open();
                            SqlDataReader dr3 = cmd3.ExecuteReader();
                            if (dr3.Read())
                            {
                                if (textBox3.Text == dr3["AdminPass"].ToString())
                                {
                                    if (textBox1.Text == textBox2.Text)
                                    {
                                        SqlConnection con4 = new SqlConnection(connection);
                                        string query4 = "update dbo.Admin_Info set AdminPass= @pass where AdminName = @user;";
                                        SqlCommand cmd4 = new SqlCommand(query4, con4);
                                        cmd4.Parameters.AddWithValue("@pass", textBox1.Text);
                                        cmd4.Parameters.AddWithValue("@user", Class1.userName);
                                        con4.Open();
                                        cmd4.ExecuteNonQuery();
                                        MessageBox.Show("Password Changed successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("New Password mismatched,,please check properly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Current Password wrong!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }

                    }
                    
                }
                else
                {
                    MessageBox.Show("Please fill all the details!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("You need to log in first!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            

        }
    }
}
