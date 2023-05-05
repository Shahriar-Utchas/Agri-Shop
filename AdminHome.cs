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
    public partial class AdminHome : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        MemoryStream ms;
        Thread th;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        public AdminHome()
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
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = System.Drawing.Color.MediumPurple;
            //labelHome.Text = "Home";
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
            panelBtnPage.Controls.Add(childForm);
            panelBtnPage.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

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

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color5);
            labelHome.Text = "Settings";
            showSubMenu(panel1);
        }

        private void FarmerDetailsbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
            labelHome.Text = "Farmar Details";
            hideSubMenu();
            openChildForm(new FarmarDetails());
        }

        private void CustomerDetailsbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            labelHome.Text = "Customer Details";
            hideSubMenu();
            openChildForm(new customerDetails());
        }

        private void Ordersbtn_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            labelHome.Text = "Products Details";
            hideSubMenu();
            openChildForm(new productsDetails());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            labelHome.Text = "Profile";
            hideSubMenu();
        }

        private void AdminHome_Load(object sender, EventArgs e)
        {
            if (Class1.farmDlt)
            {

            }
            openChildForm(new FarmarDetails());
            hideSubMenu();
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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            labelHome.Text = "Orders Details";
            hideSubMenu();
            openChildForm(new orderDetails());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            openChildForm(new PassChng());
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
