namespace AgriShop
{
    partial class CusDashboard
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
            this.pic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.labelRegEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pic,
            this.pname,
            this.price,
            this.qty,
            this.image});
            this.dataGridView1.Location = new System.Drawing.Point(1, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.Size = new System.Drawing.Size(915, 428);
            this.dataGridView1.TabIndex = 50;
            // 
            // pic
            // 
            this.pic.DataPropertyName = "pid";
            this.pic.HeaderText = "pid";
            this.pic.MinimumWidth = 8;
            this.pic.Name = "pic";
            this.pic.Width = 150;
            // 
            // pname
            // 
            this.pname.DataPropertyName = "pname";
            this.pname.HeaderText = "Name";
            this.pname.MinimumWidth = 8;
            this.pname.Name = "pname";
            this.pname.Width = 150;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "price";
            this.price.MinimumWidth = 8;
            this.price.Name = "price";
            this.price.Width = 150;
            // 
            // qty
            // 
            this.qty.DataPropertyName = "qty";
            this.qty.HeaderText = "qty";
            this.qty.MinimumWidth = 8;
            this.qty.Name = "qty";
            this.qty.Width = 150;
            // 
            // image
            // 
            this.image.DataPropertyName = "image";
            this.image.HeaderText = "image";
            this.image.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.image.MinimumWidth = 8;
            this.image.Name = "image";
            this.image.Width = 150;
            // 
            // labelRegEmail
            // 
            this.labelRegEmail.AutoSize = true;
            this.labelRegEmail.BackColor = System.Drawing.Color.Transparent;
            this.labelRegEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRegEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(143)))), ((int)(((byte)(217)))));
            this.labelRegEmail.Location = new System.Drawing.Point(273, 8);
            this.labelRegEmail.Name = "labelRegEmail";
            this.labelRegEmail.Size = new System.Drawing.Size(290, 36);
            this.labelRegEmail.TabIndex = 49;
            this.labelRegEmail.Text = "Your Ordered items";
            // 
            // CusDashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(32)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(916, 556);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelRegEmail);
            this.Name = "CusDashboard";
            this.Text = "CusDashboard";
            this.Load += new System.EventHandler(this.CusDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pic;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.Label labelRegEmail;
    }
}