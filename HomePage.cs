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
    public partial class HomePage : Form
    {
        string connection = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        MemoryStream ms;
        Thread th;
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        
        public HomePage()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            //this.Text = string.Empty;
            //this.ControlBox = false;
            //this.DoubleBuffered = true;
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

        }
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.FromArgb(172,126,241);
            public static System.Drawing.Color color2 = System.Drawing.Color.FromArgb(249,118,176);
            public static System.Drawing.Color color3 = System.Drawing.Color.FromArgb(253,138,114);
            public static System.Drawing.Color color4 = System.Drawing.Color.FromArgb(95,77,221  );
            public static System.Drawing.Color color5 = System.Drawing.Color.FromArgb(249,88,155 );
            public static System.Drawing.Color color6 = System.Drawing.Color.FromArgb(24, 161, 251);
        }
        private void ActiveButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //button
                currentBtn =(IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.FromArgb(37,36,81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign= ContentAlignment.MiddleCenter;
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
            if(currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;


            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            if(Class1.skip)
            {
                iconBtnLogout.Hide();
            }
            else
            {
                btnPrev.Hide();
            }
            hideSubMenu();
            if (Class1.orderCon)
            {
                Class1.orderCon= false;
                openChildForm(new CusDashboard());
            }
            else if (Class1.cartRmv)
            {
                Class1.cartRmv = false;
                openChildForm(new Cart());
            }
            else if (Class1.infoChng)
            {
                Class1.infoChng = false;
                openChildForm(new Profile());
            }
            else
            {
                openChildForm(new products());
            }

            try
            {
                string p = (Class1.userName);
                labelUsrName.Text = p;
                SqlConnection con = new SqlConnection(connection);
                string query = "select picture from dbo.Login_info where UserName ='" + p + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                //cmd.Parameters.AddWithValue("@user", p);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //labelUsrName.Text = dr[0].ToString();
                    //byte[] img = (byte[])(dr[4]);
                    //if (img == null)
                    //{
                    //    pictureBoxUser.Image = null;
                    //}
                    //else
                    //{
                    //   ms = new MemoryStream(img);
                    //    pictureBoxUser.Image = Image.FromStream(ms);
                    //
                    //}
                    //pictureBoxUser.BackgroundImage = GetImage((byte[])row["images"]);

                    //string link = ""+dr[4];
                    string path = dr["picture"].ToString();
                    string filename = path;
                    pictureBoxUser.Image =Image.FromFile(filename);




                }
                else
                {
                    con.Close();
                    //MessageBox.Show("Image not exixt");
                }


            }
            catch(Exception )
            {
               // MessageBox.Show(ee.Message);
            }
            

        }

       

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color1);
            labelHome.Text = "Products";
            openChildForm(new products());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color2);
            labelHome.Text = "Cart";
            hideSubMenu();
            openChildForm(new Cart());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color3);
            labelHome.Text = "Dashboard";
            hideSubMenu();
            openChildForm(new CusDashboard());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color4);
            labelHome.Text = "Settings";
            showSubMenu(panel1);
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.color6);
            labelHome.Text = "Profile";
            openChildForm(new Profile());
            hideSubMenu();
        }


        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconPictureBox1.IconChar = IconChar.Home;
            iconPictureBox1.IconColor = System.Drawing.Color.MediumPurple;
            //labelHome.Text = "Home";
        }

        private void iconBtnLogout_Click(object sender, EventArgs e)
        { 
            if (MessageBox.Show("Do you want to Logout?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Class1.darkThm = false;
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

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Reset();
            labelHome.Text = "Home";
            openChildForm(new products());
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
              if(activeForm != null)
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

        private void panelBtnPage_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelUsrName_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            Class1.skip = false;
            this.Close();
            th = new Thread(openNewFrom2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openNewFrom2()
        {
            Application.Run(new Login());
        }
        private void customizeDesing()
        {
            panel1.Visible = false;
        }
        private void hideSubMenu()
        {

            if(panel1.Visible == true)
                panel1.Visible= false;
         }
        private void showSubMenu(Panel subMenu)
        {
            if(subMenu.Visible == false) 
            {
                hideSubMenu();
                subMenu.Visible= true;
            }
            else
            {
                subMenu.Visible= false;
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(toggleButton1.Checked)
            {
                //products.BackColor = Color.DarkCyan;
                Class1.darkThm = true;
                openChildForm(new products());
            }
            else
            {
                Class1.darkThm = false;
                openChildForm(new products());
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            openChildForm(new PassChng());
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            openChildForm(new AboutUs());
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            if (Class1.userName != "User" && Class1.userName != "")
            {
                if(MessageBox.Show("Do you want to Delete your account parmanently? Think twice!!", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    SqlConnection con3 = new SqlConnection(connection);
                    string query3 = "delete from dbo.Login_info where UserName= @user;";
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
            else
            {
                MessageBox.Show("You need to login first!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void openNewFrom6()
        {
            Application.Run(new Login());
        }
    }
}
