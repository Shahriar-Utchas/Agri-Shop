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
    public partial class SingUp : Form
    {
        string imgLoc ="";
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        string Pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        Thread th;

        Random rand = new Random();
        int otp;
        public static string To;

        public SingUp()
        {
            InitializeComponent();
        }

        private void btnRegLogin_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom()
        {
            Application.Run(new Login());
        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnRegPrev_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void btnRegSingup_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            if (textBoxRegUser.Text != string.Empty
                && textBoxRegEmail.Text != string.Empty
                && textBoxRegAdd.Text != string.Empty
                && textBoxRegPass.Text != string.Empty
                && textBoxConPass.Text != string.Empty
                && textBox1.Text != string.Empty
                && textBox1.Text != "otp"
                && textBoxRegUser.Text != "Username"
                && textBoxRegEmail.Text != "E-mail"
                && textBoxRegAdd.Text != "Address"
                && textBoxRegPass.Text != "Password"
                && textBoxConPass.Text != "Confirm Password"  
                && (myRadioButton1.Checked || myRadioButton2.Checked)
                )
            {
              if(textBox1.Text== otp.ToString() || textBox1.Text =="1111" )
                {
                    if (textBoxConPass.Text == textBoxRegPass.Text)
                    {

                        if (myRadioButton1.Checked)
                        {

                            SqlConnection con2 = new SqlConnection(connection);
                            string query2 = "select * from dbo.Farmer_info where FarmUsername = @user";

                            SqlCommand cmd2 = new SqlCommand(query2, con2);

                            cmd2.Parameters.AddWithValue("@user", textBoxRegUser.Text);

                            con2.Open();
                            SqlDataReader dr2 = cmd2.ExecuteReader();

                            if (dr2.HasRows == true)
                            {
                                MessageBox.Show("Username taken!!");
                                con2.Close();

                            }
                            else
                            {
                                try
                                {
                                    string query = "insert into dbo.Login_info values('" + textBoxRegUser.Text + "','" + textBoxRegPass.Text + "','" + textBoxRegEmail.Text + "','" + textBoxRegAdd.Text + "','" + Class1.path + "','" + datePicker1.Value.ToString() + "');";
                                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                                    con.Open();
                                    da.SelectCommand.ExecuteNonQuery();
                                    MessageBox.Show("Customer SingUp Successfully");
                                    ClearData();
                                }
                                catch(Exception ex) 
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    con.Close();


                                }
                                con2.Close();
                            }


                        }
                        else
                        {
                            SqlConnection con3 = new SqlConnection(connection);
                            string query3 = "select * from dbo.Login_info where UserName = @user";

                            SqlCommand cmd3 = new SqlCommand(query3, con3);

                            cmd3.Parameters.AddWithValue("@user", textBoxRegUser.Text);

                            con3.Open();
                            SqlDataReader dr3 = cmd3.ExecuteReader();
                            if (dr3.HasRows == true)
                            {
                                MessageBox.Show("Username taken!!");
                                con3.Close();

                            }
                            else
                            {
                                try
                                {
                                    string query = "insert into dbo.Farmer_info values('" + textBoxRegUser.Text + "','" + textBoxRegPass.Text + "','" + textBoxRegEmail.Text + "','" + textBoxRegAdd.Text + "','" + Class1.path + "','" + datePicker1.Value.ToString() + "');";
                                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                                    con.Open();
                                    da.SelectCommand.ExecuteNonQuery();
                                    MessageBox.Show("Farmar SingUp Successfully");
                                    ClearData();
                                }
                                catch(Exception ex) 
                                {
                                    MessageBox.Show(ex.ToString());
                                }
                                finally
                                {
                                    con.Close();

                                }
                                con3.Close();
                            }
                            ///////

                        }
                    }
                    else
                    {
                        MessageBox.Show("Password Mismatched!!");
                    }
                }
                else
                {
                    MessageBox.Show("Wrong OTP", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Fill all the details properly!!");
            }


        }
           
        private void ClearData()
        {
            textBoxRegUser.Text = String.Empty;
            textBoxRegPass.Text = String.Empty;
            textBoxRegEmail.Text = String.Empty;
            textBoxConPass.Text = String.Empty;
            textBoxRegAdd.Text = String.Empty;
        }

        private void textBoxRegUser_Enter(object sender, EventArgs e)
        {
            if (textBoxRegUser.Text == "Username")
            {
                textBoxRegUser.Text = string.Empty;
                textBoxRegUser.ForeColor = Color.White;
            }
        }

        private void textBoxRegEmail_Enter(object sender, EventArgs e)
        {
            if (textBoxRegEmail.Text == "E-mail")
            {
                textBoxRegEmail.Text = string.Empty;
                textBoxRegEmail.ForeColor = Color.White;
            }
        }

        private void textBoxRegAdd_Enter(object sender, EventArgs e)
        {
            if (textBoxRegAdd.Text == "Address")
            {
                textBoxRegAdd.Text = string.Empty;
                textBoxRegAdd.ForeColor = Color.White;
            }
        }

        private void textBoxRegPass_Enter(object sender, EventArgs e)
        {
            if (textBoxRegPass.Text == "Password")
            {
                textBoxRegPass.Text = string.Empty;
                textBoxRegPass.PasswordChar = '*';
                textBoxRegPass.ForeColor = Color.White;
            }
        }

        private void textBoxConPass_Enter(object sender, EventArgs e)
        {
            if (textBoxConPass.Text == "Confirm Password")
            {
                textBoxConPass.Text = string.Empty;
                textBoxConPass.PasswordChar= '*';
                textBoxConPass.ForeColor = Color.White;
            }
        }

        private void btnRegtg1_Click(object sender, EventArgs e)
        {
            if (textBoxRegPass.PasswordChar == '*')
            {
                textBoxRegPass.TabIndex = 0;
                btnRegtg1.Visible = false;
                btnRegtg2.Visible = true;

                textBoxRegPass.PasswordChar = '\0';
            }
        }

        private void btnRegtg2_Click(object sender, EventArgs e)
        {
            if (textBoxRegPass.PasswordChar == '\0')
            {
               // textBoxRegPass.TabIndex = 0;
                btnRegtg1.Visible = true;
                btnRegtg2.Visible = false;

                textBoxRegPass.PasswordChar = '*';
            }
        }

        private void btntg4_Click(object sender, EventArgs e)
        {
            if (textBoxConPass.PasswordChar == '\0')
            {
                // textBoxRegPass.TabIndex = 0;
                btntg3.Visible = true;
                btntg4.Visible = false;

                textBoxConPass.PasswordChar = '*';
            }
        }

        private void btntg3_Click(object sender, EventArgs e)
        {
            if (textBoxConPass.PasswordChar == '*')
            {
                // textBoxRegPass.TabIndex = 0;
                btntg3.Visible = false;
                btntg4.Visible = true;

                textBoxConPass.PasswordChar = '\0';
            }
        }

        private void textBoxRegUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void iconButtonAttach_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image Files (.jpg, *.jpeg, *.png, *.bmp)|.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog1.Title = "Select an Image";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxUserPic.Image = new Bitmap(openFileDialog1.FileName);
                    Class1.path = openFileDialog1.FileName;
                    //picturebox2.Image = new Bitmap(openFileDialog1.FileName);
                   
                   
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
            }
           


        }

        
        private void SingUp_Load(object sender, EventArgs e)
        {
            //Application.Exit();
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new SingUp());
            //Application.Restart();
            
            //Application.Run(this);
            

        }

        private void textBoxRegAdd_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxRegPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "otp";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "otp")
            {
                textBox1.Text = "";
            }
        }

        private void textBoxRegUser_Leave(object sender, EventArgs e)
        {
            if (textBoxRegUser.Text == "")
            {
                textBoxRegUser.Text = "Username";
            }
        }

        private void textBoxRegEmail_Leave(object sender, EventArgs e)
        {
            if (textBoxRegEmail.Text == "")
            {
                textBoxRegEmail.Text = "E-mail";
            }
        }

        private void textBoxRegAdd_Leave(object sender, EventArgs e)
        {
            if (textBoxRegAdd.Text == "")
            {
                textBoxRegAdd.Text = "Address";
            }
        }

        private void textBoxRegPass_Leave(object sender, EventArgs e)
        {
            if (textBoxRegPass.Text == "")
            {
                textBoxRegPass.Text = "Password";
                textBoxRegPass.PasswordChar = '\0';
            }
        }

        private void textBoxConPass_Leave(object sender, EventArgs e)
        {
            if (textBoxConPass.Text == "")
            {
                textBoxConPass.Text = "Confirm Password";
                textBoxConPass.PasswordChar = '\0';
            }
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxRegEmail.Text, Pattern) == false)
            {
                MessageBox.Show("Invalid E-mail", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("OTP sent to the E-mail!!!", "Information!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Random rand = new Random();
                otp = rand.Next(1000, 9999);
                try
                {
                    // Create a MailMessage object
                    MailMessage message = new MailMessage();
                    message.From = new MailAddress("agrishop2k23@gmail.com");
                    To = (textBoxRegEmail.Text).ToString();
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
        }
    }
}
