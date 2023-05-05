namespace AgriShop
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.textBoxUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSkip = new System.Windows.Forms.Button();
            this.linkLabelForgetPass = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btntg2 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btntg1 = new System.Windows.Forms.Button();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.linkLabelSingup = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxUser.Location = new System.Drawing.Point(176, 15);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(244, 37);
            this.textBoxUser.TabIndex = 5;
            this.textBoxUser.Text = "Username";
            this.textBoxUser.TextChanged += new System.EventHandler(this.textBoxUser_TextChanged);
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            this.textBoxUser.Leave += new System.EventHandler(this.textBoxUser_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(267, 693);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(440, 46);
            this.label3.TabIndex = 16;
            this.label3.Text = "Don\'t have an account?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnSkip
            // 
            this.btnSkip.BackColor = System.Drawing.Color.Transparent;
            this.btnSkip.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSkip.FlatAppearance.BorderSize = 0;
            this.btnSkip.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.btnSkip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkip.ForeColor = System.Drawing.Color.Yellow;
            this.btnSkip.Location = new System.Drawing.Point(903, 2);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(189, 37);
            this.btnSkip.TabIndex = 18;
            this.btnSkip.Text = "Continue as Guest>>";
            this.btnSkip.UseVisualStyleBackColor = false;
            this.btnSkip.Click += new System.EventHandler(this.btnSkip_Click);
            // 
            // linkLabelForgetPass
            // 
            this.linkLabelForgetPass.ActiveLinkColor = System.Drawing.Color.LightSkyBlue;
            this.linkLabelForgetPass.AutoSize = true;
            this.linkLabelForgetPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelForgetPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelForgetPass.LinkColor = System.Drawing.Color.Red;
            this.linkLabelForgetPass.Location = new System.Drawing.Point(332, 432);
            this.linkLabelForgetPass.Name = "linkLabelForgetPass";
            this.linkLabelForgetPass.Size = new System.Drawing.Size(221, 30);
            this.linkLabelForgetPass.TabIndex = 19;
            this.linkLabelForgetPass.TabStop = true;
            this.linkLabelForgetPass.Text = "Forgot Password?";
            this.linkLabelForgetPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelForgetPass_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkLabelForgetPass);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(154, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 662);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // iconButton1
            // 
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.RightToBracket;
            this.iconButton1.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(210, 524);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(440, 81);
            this.iconButton1.TabIndex = 22;
            this.iconButton1.Text = "Login";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Wide Latin", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(284, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 27);
            this.label2.TabIndex = 21;
            this.label2.Text = "Welcome to";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MV Boli", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(252, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 79);
            this.label1.TabIndex = 20;
            this.label1.Text = "AgriShop";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btntg2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.btntg1);
            this.panel5.Controls.Add(this.textBoxPass);
            this.panel5.Controls.Add(this.pictureBox3);
            this.panel5.Location = new System.Drawing.Point(159, 351);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(480, 92);
            this.panel5.TabIndex = 9;
            // 
            // btntg2
            // 
            this.btntg2.BackColor = System.Drawing.Color.Transparent;
            this.btntg2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntg2.FlatAppearance.BorderSize = 0;
            this.btntg2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntg2.Image = global::AgriShop.Properties.Resources.show;
            this.btntg2.Location = new System.Drawing.Point(406, 11);
            this.btntg2.Name = "btntg2";
            this.btntg2.Size = new System.Drawing.Size(70, 46);
            this.btntg2.TabIndex = 21;
            this.btntg2.UseVisualStyleBackColor = false;
            this.btntg2.Click += new System.EventHandler(this.btntg2_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Location = new System.Drawing.Point(178, 62);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(284, 2);
            this.panel6.TabIndex = 9;
            // 
            // btntg1
            // 
            this.btntg1.BackColor = System.Drawing.Color.Transparent;
            this.btntg1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btntg1.FlatAppearance.BorderSize = 0;
            this.btntg1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btntg1.Image = global::AgriShop.Properties.Resources.hide;
            this.btntg1.Location = new System.Drawing.Point(406, 11);
            this.btntg1.Name = "btntg1";
            this.btntg1.Size = new System.Drawing.Size(70, 45);
            this.btntg1.TabIndex = 20;
            this.btntg1.UseVisualStyleBackColor = false;
            this.btntg1.Click += new System.EventHandler(this.btntg1_Click);
            // 
            // textBoxPass
            // 
            this.textBoxPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxPass.Location = new System.Drawing.Point(176, 15);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.Size = new System.Drawing.Size(244, 37);
            this.textBoxPass.TabIndex = 5;
            this.textBoxPass.Text = "Password";
            this.textBoxPass.TextChanged += new System.EventHandler(this.textBoxPass_TextChanged_1);
            this.textBoxPass.Enter += new System.EventHandler(this.textBoxPass_Enter_1);
            this.textBoxPass.Leave += new System.EventHandler(this.textBoxPass_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::AgriShop.Properties.Resources.pass;
            this.pictureBox3.Location = new System.Drawing.Point(22, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(114, 71);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.textBoxUser);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(159, 234);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 89);
            this.panel2.TabIndex = 0;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(176, 55);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 2);
            this.panel4.TabIndex = 9;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.ErrorImage = global::AgriShop.Properties.Resources.userid;
            this.pictureBox1.Image = global::AgriShop.Properties.Resources.userid;
            this.pictureBox1.Location = new System.Drawing.Point(22, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 82);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Image = global::AgriShop.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(1032, 704);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(60, 58);
            this.btnExit.TabIndex = 22;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // linkLabelSingup
            // 
            this.linkLabelSingup.ActiveLinkColor = System.Drawing.Color.Navy;
            this.linkLabelSingup.AutoSize = true;
            this.linkLabelSingup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelSingup.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSingup.Image = global::AgriShop.Properties.Resources.Signup;
            this.linkLabelSingup.LinkColor = System.Drawing.Color.Transparent;
            this.linkLabelSingup.Location = new System.Drawing.Point(694, 683);
            this.linkLabelSingup.Name = "linkLabelSingup";
            this.linkLabelSingup.Size = new System.Drawing.Size(142, 69);
            this.linkLabelSingup.TabIndex = 1;
            this.linkLabelSingup.TabStop = true;
            this.linkLabelSingup.Text = "       ";
            this.linkLabelSingup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1092, 766);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.linkLabelSingup);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AgriShop";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabelSingup;
        private System.Windows.Forms.Button btnSkip;
        private System.Windows.Forms.LinkLabel linkLabelForgetPass;
        private System.Windows.Forms.Button btntg1;
        private System.Windows.Forms.Button btntg2;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

