namespace AgriShop
{
    partial class FarmarDetails
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FarmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pic = new System.Windows.Forms.DataGridViewImageColumn();
            this.FarmDOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelRegEmail = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FarmUserName,
            this.FarmPass,
            this.FarmEmail,
            this.FarmAdd,
            this.Pic,
            this.FarmDOB});
            this.dataGridView1.Location = new System.Drawing.Point(7, 65);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.Size = new System.Drawing.Size(885, 447);
            this.dataGridView1.TabIndex = 49;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FarmUserName
            // 
            this.FarmUserName.DataPropertyName = "FarmUserName";
            this.FarmUserName.HeaderText = "Username";
            this.FarmUserName.MinimumWidth = 8;
            this.FarmUserName.Name = "FarmUserName";
            this.FarmUserName.Width = 150;
            // 
            // FarmPass
            // 
            this.FarmPass.DataPropertyName = "FarmPass";
            this.FarmPass.HeaderText = "Password";
            this.FarmPass.MinimumWidth = 8;
            this.FarmPass.Name = "FarmPass";
            this.FarmPass.Width = 150;
            // 
            // FarmEmail
            // 
            this.FarmEmail.DataPropertyName = "FarmEmail";
            this.FarmEmail.HeaderText = "Email";
            this.FarmEmail.MinimumWidth = 8;
            this.FarmEmail.Name = "FarmEmail";
            this.FarmEmail.Width = 150;
            // 
            // FarmAdd
            // 
            this.FarmAdd.DataPropertyName = "FarmAdd";
            this.FarmAdd.HeaderText = "Address";
            this.FarmAdd.MinimumWidth = 8;
            this.FarmAdd.Name = "FarmAdd";
            this.FarmAdd.Width = 150;
            // 
            // Pic
            // 
            this.Pic.DataPropertyName = "pic";
            this.Pic.HeaderText = "Pic";
            this.Pic.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Pic.MinimumWidth = 8;
            this.Pic.Name = "Pic";
            this.Pic.Width = 200;
            // 
            // FarmDOB
            // 
            this.FarmDOB.DataPropertyName = "FarmDOB";
            this.FarmDOB.HeaderText = "DOB";
            this.FarmDOB.MinimumWidth = 8;
            this.FarmDOB.Name = "FarmDOB";
            this.FarmDOB.Width = 150;
            // 
            // labelRegEmail
            // 
            this.labelRegEmail.AutoSize = true;
            this.labelRegEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelRegEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.labelRegEmail.Location = new System.Drawing.Point(317, 5);
            this.labelRegEmail.Name = "labelRegEmail";
            this.labelRegEmail.Size = new System.Drawing.Size(236, 36);
            this.labelRegEmail.TabIndex = 48;
            this.labelRegEmail.Text = "Farmars Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.label1.Location = new System.Drawing.Point(150, 524);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 32);
            this.label1.TabIndex = 50;
            this.label1.Text = "N.B: For delete any user just select the user";
            // 
            // FarmarDetails
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(898, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelRegEmail);
            this.Name = "FarmarDetails";
            this.Text = "FarmarDetails";
            this.Load += new System.EventHandler(this.FarmarDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmAdd;
        private System.Windows.Forms.DataGridViewImageColumn Pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmDOB;
        private System.Windows.Forms.Label labelRegEmail;
        private System.Windows.Forms.Label label1;
    }
}