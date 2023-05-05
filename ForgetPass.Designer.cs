namespace AgriShop
{
    partial class ForgetPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRegExit = new System.Windows.Forms.Button();
            this.btnRegPrev = new System.Windows.Forms.Button();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxUser = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(448, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "Reset Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 36);
            this.label2.TabIndex = 26;
            this.label2.Text = "Your Username";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnRegExit
            // 
            this.btnRegExit.BackColor = System.Drawing.Color.Transparent;
            this.btnRegExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegExit.FlatAppearance.BorderSize = 0;
            this.btnRegExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegExit.Image = global::AgriShop.Properties.Resources.Exit;
            this.btnRegExit.Location = new System.Drawing.Point(1016, 705);
            this.btnRegExit.Name = "btnRegExit";
            this.btnRegExit.Size = new System.Drawing.Size(86, 58);
            this.btnRegExit.TabIndex = 28;
            this.btnRegExit.UseVisualStyleBackColor = false;
            this.btnRegExit.Click += new System.EventHandler(this.btnRegExit_Click);
            // 
            // btnRegPrev
            // 
            this.btnRegPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnRegPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRegPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegPrev.FlatAppearance.BorderSize = 0;
            this.btnRegPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegPrev.Image = global::AgriShop.Properties.Resources.Previous;
            this.btnRegPrev.Location = new System.Drawing.Point(-2, 708);
            this.btnRegPrev.Name = "btnRegPrev";
            this.btnRegPrev.Size = new System.Drawing.Size(86, 58);
            this.btnRegPrev.TabIndex = 27;
            this.btnRegPrev.UseVisualStyleBackColor = false;
            this.btnRegPrev.Click += new System.EventHandler(this.btnRegPrev_Click);
            // 
            // iconButton2
            // 
            this.iconButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Forward;
            this.iconButton2.IconColor = System.Drawing.Color.WhiteSmoke;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(834, 411);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(162, 51);
            this.iconButton2.TabIndex = 23;
            this.iconButton2.Text = "Next";
            this.iconButton2.UseVisualStyleBackColor = true;
            this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AgriShop.Properties.Resources.forgot_user;
            this.pictureBox1.Location = new System.Drawing.Point(27, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 503);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.textBoxUser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(488, 299);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 89);
            this.panel2.TabIndex = 29;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(281, 57);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(244, 2);
            this.panel4.TabIndex = 9;
            // 
            // textBoxUser
            // 
            this.textBoxUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.textBoxUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUser.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxUser.Location = new System.Drawing.Point(281, 17);
            this.textBoxUser.Name = "textBoxUser";
            this.textBoxUser.Size = new System.Drawing.Size(244, 37);
            this.textBoxUser.TabIndex = 5;
            this.textBoxUser.Text = "Username";
            this.textBoxUser.Enter += new System.EventHandler(this.textBoxUser_Enter);
            // 
            // ForgetPass
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1092, 766);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnRegExit);
            this.Controls.Add(this.btnRegPrev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ForgetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgetPass";
            this.Load += new System.EventHandler(this.ForgetPass_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRegPrev;
        private System.Windows.Forms.Button btnRegExit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBoxUser;
    }
}