namespace Project.Views.Employees
{
    partial class EmployeesView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeesView));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.CreateEm = new System.Windows.Forms.ToolStripButton();
            this.UpdateEm = new System.Windows.Forms.ToolStripButton();
            this.SttEm = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataEm = new System.Windows.Forms.DataGridView();
            this.SearchEm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEm)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(171)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(1, -1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(678, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhân Viên";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateEm,
            this.UpdateEm,
            this.SttEm,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(-4, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(683, 38);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // CreateEm
            // 
            this.CreateEm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CreateEm.Image = ((System.Drawing.Image)(resources.GetObject("CreateEm.Image")));
            this.CreateEm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateEm.Name = "CreateEm";
            this.CreateEm.Size = new System.Drawing.Size(23, 35);
            this.CreateEm.Text = "Tạo mới";
            this.CreateEm.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // UpdateEm
            // 
            this.UpdateEm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateEm.Image = ((System.Drawing.Image)(resources.GetObject("UpdateEm.Image")));
            this.UpdateEm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateEm.Name = "UpdateEm";
            this.UpdateEm.Size = new System.Drawing.Size(23, 35);
            this.UpdateEm.Text = "Cập nhật nhân viên";
            this.UpdateEm.Click += new System.EventHandler(this.UpdateEm_Click);
            // 
            // SttEm
            // 
            this.SttEm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SttEm.Image = ((System.Drawing.Image)(resources.GetObject("SttEm.Image")));
            this.SttEm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SttEm.Name = "SttEm";
            this.SttEm.Size = new System.Drawing.Size(23, 35);
            this.SttEm.Text = "Đag làm";
            this.SttEm.Click += new System.EventHandler(this.SttEm_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton1.Text = "Làm mới";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // dataEm
            // 
            this.dataEm.AllowUserToAddRows = false;
            this.dataEm.AllowUserToDeleteRows = false;
            this.dataEm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataEm.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataEm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEm.Location = new System.Drawing.Point(-4, 81);
            this.dataEm.Name = "dataEm";
            this.dataEm.ReadOnly = true;
            this.dataEm.Size = new System.Drawing.Size(683, 219);
            this.dataEm.TabIndex = 3;
            this.dataEm.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEm_CellClick);
            // 
            // SearchEm
            // 
            this.SearchEm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchEm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchEm.Location = new System.Drawing.Point(391, 17);
            this.SearchEm.Name = "SearchEm";
            this.SearchEm.Size = new System.Drawing.Size(189, 22);
            this.SearchEm.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(586, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Tìm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmployeesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SearchEm);
            this.Controls.Add(this.dataEm);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "EmployeesView";
            this.Text = "CustomersView";
            this.Load += new System.EventHandler(this.EmployeesView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton CreateEm;
        private System.Windows.Forms.ToolStripButton UpdateEm;
        private System.Windows.Forms.ToolStripButton SttEm;
        private System.Windows.Forms.DataGridView dataEm;
        private System.Windows.Forms.TextBox SearchEm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}