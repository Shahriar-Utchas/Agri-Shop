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


namespace AgriShop
{
    public partial class FarmarHome : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        MemoryStream ms;
        Thread th;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public FarmarHome()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172, 126, 241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249, 118, 176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253, 138, 114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95, 77, 221);
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249, 88, 155);
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = System.Drawing.Color.MediumPurple;
            //labelHome.Text = "Home";
        }
        private void ActiveButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left Border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                iconPictureBox1.IconChar = currentBtn.IconChar;
                iconPictureBox1.IconColor = color;


            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;


            }
        }
        //Drag from
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int Iparam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }


        private void panelBtnPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FarmarHome_Load(object sender, EventArgs e)
        {
            hideSubMenu();
            openChildForm(new AddProducts());
            try
            {
                string p = (Class1.userName);
                labelUsrName.Text = p;
                SqlConnection con = new SqlConnection(connection);
                string query = "select FarmPic from dbo.Farmer_info where FarmUsername ='" + p + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                  
                    string path = dr["FarmPic"].ToString();
                    string filename = path;
                    pictureBoxUser.Image = Image.FromFile(filename);
                }
                else
                {
                    con.Close();
                }


            }
            catch (Exception)
            {

            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            labelHome.Text = "Add Product";
            hideSubMenu();
            openChildForm(new AddProducts());
        }
        private void hideSubMenu()
        {

            if (panel1.Visible == true)
                panel1.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            labelHome.Text = "Dashboard";
            hideSubMenu();
            Class1.farmDash = true;
            openChildForm(new orderDetails());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            labelHome.Text = "Profile";
            hideSubMenu();
            openChildForm(new Profile());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            labelHome.Text = "Settings";
            showSubMenu(panel1);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Reset();
            labelHome.Text = "Home";

        }

        private void iconBtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                th = new Thread(openNewFrom);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        private void openNewFrom()
        {
            Application.Run(new Login());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            openChildForm(new PassChng());
        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Delete your account parmanently? Think twice!!", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection con3 = new SqlConnection(connection);
                string query3 = "delete from dbo.Farmer_info where FarmUsername= @user;";
                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@user", Class1.userName);
                con3.Open();
                cmd3.ExecuteNonQuery();
                Application.Exit();
                th = new Thread(openNewFrom6);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void openNewFrom6()
        {
            Application.Run(new Login());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            Class1.farmabt = true;
            openChildForm(new AboutUs());
            //panel2.Visible = false;
        }
    }
}
