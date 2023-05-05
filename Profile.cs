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

namespace AgriShop
{
    public partial class Profile : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        Thread th;
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            if(Class1.userName!= "User" && Class1.userName != "")
            {
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
                        label1.Text = p;
                        label2.Text = dr["E-mail"].ToString();
                        label3.Text = dr["DOB"].ToString();
                        label4.Text = dr["Address"].ToString();

                    }
                    else
                    {
                        string p2 = (Class1.userName);
                        SqlConnection con2 = new SqlConnection(connection);
                        string query2 = "select * from dbo.Farmer_info where FarmUsername = @user";
                        SqlCommand cmd2 = new SqlCommand(query2, con2);
                        cmd2.Parameters.AddWithValue("@user", p2);
                        con2.Open();
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if (dr2.Read())
                        {
                            Image im = Image.FromFile(@"" + dr2["FarmPic"]);
                            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                            pictureBox1.BackgroundImage = im;
                            label1.Text = p;
                            label2.Text = dr2["FarmEmail"].ToString();
                            label3.Text = dr2["FarmDOB"].ToString();
                            label4.Text = dr2["FarmAdd"].ToString();

                        }
                        else
                        {
                            con2.Close();
                        }

                    }
                    con.Close();

                }
                catch (Exception ee)
                {
                    MessageBox.Show(ee.Message);
                }
            }
            else
            {
                MessageBox.Show("You need to login first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void iconButtonAttach_Click(object sender, EventArgs e)
        {
            Class1.chngInfo = true;
            Application.Exit();
            th = new Thread(openNewFrom);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom()
        {
            Application.Run(new infoEdit());
        }
    }
}
