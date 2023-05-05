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

namespace AgriShop
{
    
    public partial class Login : Form
    {
        
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public bool userLogin = false;
        public bool farmLogin = false;
        public bool adminLogin = false;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btntg1.Visible = false;
            this.linkLabelSingup.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabelForgetPass.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void labelUser_Click(object sender, EventArgs e)
        {

        }

        private void labelPass_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //SingUp s1 = new SingUp();
            //this.Close();
            //s1.Show();
            this.Close();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            

        }
        private void openNewFrom()
        {
            Application.Run(new SingUp());
        }
        private void openNewFrom2()
        {
            Application.Run(new HomePage());
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void btntg1_Click(object sender, EventArgs e)
        {
            
            if (textBoxPass.PasswordChar == '\0')
            {
                textBoxPass.TabIndex = 0;
                btntg1.Visible = false;
                btntg2.Visible = true;
                textBoxPass.PasswordChar = '*';
            }
           
        }

        private void btntg2_Click(object sender, EventArgs e)
        {
            if (textBoxPass.PasswordChar == '*')
            {
                textBoxPass.TabIndex = 0;
                btntg1.Visible = true;
                btntg2.Visible = false;

                textBoxPass.PasswordChar = '\0';
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            Class1.skip = true;
            Class1.userName = "User";
            this.Close();
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void textBoxUser_Enter(object sender, EventArgs e)
        {
            if(textBoxUser.Text == "Username")
            {
                textBoxUser.Text = string.Empty;
                textBoxUser.ForeColor = Color.White;
            }
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {

            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabelForgetPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            th = new Thread(openNewFrom3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom3()
        {
            Application.Run(new ForgetPass());
        }

        private void textBoxPass_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBoxPass_Enter_1(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "Password")
            {
                textBoxPass.Text = string.Empty;
                textBoxPass.PasswordChar = '*';
                textBoxPass.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text != "" && textBoxPass.Text != "" && textBoxUser.Text != "Username" && textBoxPass.Text != "Password")
            {
                
                SqlConnection con = new SqlConnection(cs);
                string query = "select * from dbo.Login_info where UserName = @user and Password = @pass";
          
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@user", textBoxUser.Text);
                cmd.Parameters.AddWithValue("@pass", textBoxPass.Text);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                {
                    userLogin = true;
                    LoginPage();
                   
                }
             
                else if(dr.HasRows== false)
                {

                    SqlConnection con2 = new SqlConnection(cs);
                    string query2 = "select * from dbo.Farmer_info where FarmUsername = @user1 and FarmPass = @pass1";

                    SqlCommand cmd2 = new SqlCommand(query2, con2);

                    cmd2.Parameters.AddWithValue("@user1", textBoxUser.Text);
                    cmd2.Parameters.AddWithValue("@pass1", textBoxPass.Text);

                    con2.Open();
                    SqlDataReader dr2 = cmd2.ExecuteReader();

                    if (dr2.HasRows == true)
                    {
                        farmLogin = true;
                        LoginPage();
                     
                    }
                    else
                    {
                        SqlConnection con3 = new SqlConnection(cs);
                        string query3 = "select * from dbo.Admin_Info where AdminName = @user2 and AdminPass = @pass2";

                        SqlCommand cmd3 = new SqlCommand(query3, con3);

                        cmd3.Parameters.AddWithValue("@user2", textBoxUser.Text);
                        cmd3.Parameters.AddWithValue("@pass2", textBoxPass.Text);

                        con3.Open();
                        SqlDataReader dr3 = cmd3.ExecuteReader();

                        if (dr3.HasRows == true)
                        {
                            adminLogin = true;
                            LoginPage();

                        }
                        else
                        {
                            MessageBox.Show("Login Failed", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        con3.Close();
                    }
                    con2.Close();
                }
                
                con.Close();

            }
            else
            {
                MessageBox.Show("Fill all the details", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void LoginPage()
        {
            if(userLogin == true)
            {
                Class1.userName = textBoxUser.Text;
                this.Close();
                th = new Thread(openNewFrom2);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else if(farmLogin == true)
            {
                Class1.userName = textBoxUser.Text;
                this.Close();
                th = new Thread(openNewFrom4);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else if (adminLogin == true)
            {
                Class1.userName = textBoxUser.Text;
                this.Close();
                th = new Thread(openNewFrom5);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        public void openNewFrom4()
        {
            Application.Run(new FarmarHome());
        }
        public void openNewFrom5()
        {
            Application.Run(new AdminHome());
        }

        private void textBoxUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUser.Text))
            {
                textBoxUser.Text = "Username";
            }
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPass.Text))
            {
                textBoxPass.Text = "Password";
                textBoxPass.PasswordChar = '\0';
            }
        }
    }
}
