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
    public partial class ForgetPass : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public ForgetPass()
        {
            InitializeComponent();
        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ForgetPass_Load(object sender, EventArgs e)
        {

        }

        public static string emailid = string.Empty;

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text != "" )
            {

                SqlConnection con = new SqlConnection(cs);
                string query = "select * from dbo.Login_info where UserName = @user";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@user", textBoxUser.Text);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {
                    Class1.ForgetUser = textBoxUser.Text;
                    this.Close();
                    th = new Thread(openNewFrom);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();


                }
                else
                {
                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select * from dbo.Farmer_info where FarmUsername = @user";
                    SqlCommand cmd2 = new SqlCommand(query2, con2);
                    cmd2.Parameters.AddWithValue("@user", textBoxUser.Text);
                    con2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();
                    if (dr2.HasRows == true)
                    {
                        Class1.ForgetUser = textBoxUser.Text;
                        this.Close();
                        th = new Thread(openNewFrom);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else
                    {
                    MessageBox.Show("Username not found!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter your username", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void openNewFrom()
        {
            Application.Run(new forgetPass2());
        }

        private void btnRegPrev_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom2()
        {
            Application.Run(new Login());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if (textBoxUser.Text == "Username")
            {
                textBoxUser.Text = string.Empty;
                textBoxUser.ForeColor = Color.White;
            }
        }
    }
}
