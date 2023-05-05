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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace AgriShop
{
    public partial class forgetPass2 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        string Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        Random rand = new Random();
        int otp;
       public static  string mail;
        public static string To;
        public forgetPass2()
        {
            InitializeComponent();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (textBoxEmail.Text != "" && textBox1.Text != ""
               && textBoxEmail.Text != "E-mail"
                &&textBox1.Text != "otp")
            {

               if(textBox1.Text == otp.ToString())
                {
                        this.Close();
                        th = new Thread(openNewFrom);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                }
                else
                {
                    MessageBox.Show("Wrong OTP", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Fill All the details", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void openNewFrom()
        {
            Application.Run(new forgetPass3());
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
            Application.Run(new ForgetPass());
        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxEmail.Text == "E-mail")
            {
                textBoxEmail.Text = string.Empty;
                textBoxEmail.ForeColor = Color.White;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "otp")
            {
                textBox1.Text = string.Empty;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            
            if (Regex.IsMatch(textBoxEmail.Text, Pattern) == false)
            {
                MessageBox.Show("Invalid E-mail", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (textBoxEmail.Text != "" &&  textBoxEmail.Text != "E-mail")
                {
                    SqlConnection con = new SqlConnection(cs);
                    string query = "select * from dbo.Login_info where UserName = @user";
                    //string query = "select * from dbo.Login_info where [E-mail] = @email";
                    SqlCommand cmd = new SqlCommand(query, con);
                    //cmd.Parameters.AddWithValue("@email", textBoxEmail.Text);
                     cmd.Parameters.AddWithValue("@user", Class1.ForgetUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
             
                    if (dr.Read())
                    {
                        mail = dr[2].ToString();
                        //textBox1.Text =mail;
                        if(mail == textBoxEmail.Text)
                        {
                            Class1.cusChng = true;
                            MessageBox.Show("OTP sent to the E-mail!!!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Random rand = new Random();
                            otp = rand.Next(1000, 9999);
                            try
                            {
                                // Create a MailMessage object
                                MailMessage message = new MailMessage();
                                message.From = new MailAddress("agrishop2k23@gmail.com");
                                To = (textBoxEmail.Text).ToString();
                                message.To.Add(To);
                                message.Subject = "OTP Varification.";
                                message.Body = "Your OTP is: " + otp.ToString();

                                // Create a SmtpClient object
                                SmtpClient client = new SmtpClient();
                                client.Host = "smtp.gmail.com";
                                client.Port = 587;
                                client.EnableSsl = true;
                                client.Credentials = new NetworkCredential("agrishop2k23@gmail.com", "qkvwxidzljjqlfjr");

                                // Send the email
                                client.Send(message);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("E-mail not matched");
                        }

                    }
                    else
                    {
                        SqlConnection con2 = new SqlConnection(cs);
                        string query2 = "select * from dbo.Farmer_info where FarmUsername = @user";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@user", Class1.ForgetUser);
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Class1.farmChng = true;
                            mail = dr2["FarmEmail"].ToString();
                            //textBox1.Text = mail;
                            if (mail == textBoxEmail.Text)
                            {
                                MessageBox.Show("OTP sent to the E-mail!!!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Random rand = new Random();
                                otp = rand.Next(1000, 9999);
                                try
                                {
                                    // Create a MailMessage object
                                    MailMessage message = new MailMessage();
                                    message.From = new MailAddress("agrishop2k23@gmail.com");
                                    To = (textBoxEmail.Text).ToString();
                                    message.To.Add(To);
                                    message.Subject = "OTP Varification.";
                                    message.Body = "Your OTP is: " + otp.ToString();

                                    // Create a SmtpClient object
                                    SmtpClient client = new SmtpClient();
                                    client.Host = "smtp.gmail.com";
                                    client.Port = 587;
                                    client.EnableSsl = true;
                                    client.Credentials = new NetworkCredential("agrishop2k23@gmail.com", "qkvwxidzljjqlfjr");

                                    // Send the email
                                    client.Send(message);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("E-mail not matched");
                            }

                        }
                        else
                        {
                           
                        }
                        con2.Close();



                    }
                    con.Close();
                }

                }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void forgetPass2_Load(object sender, EventArgs e)
        {
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
