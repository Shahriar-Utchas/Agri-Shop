using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;

namespace AgriShop
{
    public partial class forgetPass3 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th; 
        public forgetPass3()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            
            if (textBoxNewPass.Text != "" && textBoxNewConPass.Text!="")
            {
                if (textBoxNewPass.Text == textBoxNewConPass.Text)
                {
                    if(Class1.cusChng== true){
                        SqlConnection con = new SqlConnection(cs);
                        string query = "update dbo.Login_info set password = @pass where UserName = @user";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@pass", textBoxNewPass.Text);
                        cmd.Parameters.AddWithValue("@user", Class1.ForgetUser);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                        MessageBox.Show("Password Changed Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Password();
                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "update dbo.Farmer_info set Farmpass= @pass where FarmUsername = @user;";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@pass", textBoxNewPass.Text);
                        cmd2.Parameters.AddWithValue("@user", Class1.ForgetUser);
                        con2.Open();
                        cmd2.ExecuteReader();
                        con2.Close();
                        MessageBox.Show("Password Changed Successfully!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Password();
                    }

                   
                }
                else
                {
                    MessageBox.Show("Password MisMatched!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Fill All the box", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

                    
        }
        private void openNewFrom()
        {
             Application.Run(new Login());
        }
        private void Password()
        {
            this.Close();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
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
            Application.Run(new forgetPass2());
        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

   







        private void forgetPass3_Load(object sender, EventArgs e)
        {
           
        }

        private void textBoxNewPass_Enter(object sender, EventArgs e)
        {
            if (textBoxNewPass.Text == "Password")
            {
                textBoxNewPass.Text = string.Empty;
                textBoxNewPass.PasswordChar = '*';
                textBoxNewPass.ForeColor = Color.White;
            }
        }

        private void textBoxNewConPass_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBoxNewConPass_Enter(object sender, EventArgs e)
        {
            if (textBoxNewConPass.Text == "Confirm Password")
            {
                textBoxNewConPass.Text = string.Empty;
                textBoxNewConPass.PasswordChar = '*';
                textBoxNewConPass.ForeColor = Color.White;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBoxNewPass.PasswordChar == '*')
            {
                button4.Visible = true;
                button3.Visible = false;

                textBoxNewPass.PasswordChar = '\0';
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxNewPass.PasswordChar == '\0')
            {
                //textBoxNewPass.TabIndex = 0;
                button3.Visible = true;
                button4.Visible = false;

                textBoxNewPass.PasswordChar = '*';
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBoxNewConPass.PasswordChar == '*')
            {
                //textBoxNewConPass.TabIndex = 0;
                button6.Visible = true;
                button5.Visible = false;

                textBoxNewConPass.PasswordChar = '\0';
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBoxNewConPass.PasswordChar == '\0')
            {
                //textBoxNewConPass.TabIndex = 0;
                button6.Visible = false;
                button5.Visible = true;

                textBoxNewConPass.PasswordChar = '*';
            }
        }
    }
}
