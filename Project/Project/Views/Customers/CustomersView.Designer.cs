namespace Project.Views.Customers
{
    partial class CustomersView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomersView));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DataCus = new System.Windows.Forms.DataGridView();
            this.UpdateCus = new System.Windows.Forms.ToolStripButton();
            this.SttCus = new System.Windows.Forms.ToolStripButton();
            this.HistoryOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataCus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(171)))), ((int)(((byte)(38)))));
            this.label1.Location = new System.Drawing.Point(1, 2);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(783, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khác Hàng";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateCus,
            this.SttCus,
            this.HistoryOrder});
            this.toolStrip1.Location = new System.Drawing.Point(-1, 43);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 37);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DataCus
            // 
            this.DataCus.AllowUserToAddRows = false;
            this.DataCus.AllowUserToDeleteRows = false;
            this.DataCus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataCus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataCus.Location = new System.Drawing.Point(5, 83);
            this.DataCus.Name = "DataCus";
            this.DataCus.ReadOnly = true;
            this.DataCus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataCus.Size = new System.Drawing.Size(778, 240);
            this.DataCus.TabIndex = 2;
            this.DataCus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataCus_CellClick);
            // 
            // UpdateCus
            // 
            this.UpdateCus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UpdateCus.Image = ((System.Drawing.Image)(resources.GetObject("UpdateCus.Image")));
            this.UpdateCus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpdateCus.Name = "UpdateCus";
            this.UpdateCus.Size = new System.Drawing.Size(23, 34);
            this.UpdateCus.Text = "Chỉnh sửa";
            // 
            // SttCus
            // 
            this.SttCus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SttCus.Image = ((System.Drawing.Image)(resources.GetObject("SttCus.Image")));
            this.SttCus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SttCus.Name = "SttCus";
            this.SttCus.Size = new System.Drawing.Size(23, 34);
            this.SttCus.Text = "Đã thanh toán";
            // 
            // HistoryOrder
            // 
            this.HistoryOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HistoryOrder.Image = ((System.Drawing.Image)(resources.GetObject("HistoryOrder.Image")));
            this.HistoryOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HistoryOrder.Name = "HistoryOrder";
            this.HistoryOrder.Size = new System.Drawing.Size(23, 34);
            this.HistoryOrder.Text = "Lịch sử đặt phòng";
            // 
            // CustomersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 325);
            this.Controls.Add(this.DataCus);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Name = "CustomersView";
            this.Load += new System.EventHandler(this.CustomersView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataCus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UpdateCus;
        private System.Windows.Forms.ToolStripButton SttCus;
        private System.Windows.Forms.DataGridView DataCus;
        private System.Windows.Forms.ToolStripButton HistoryOrder;
    }
}