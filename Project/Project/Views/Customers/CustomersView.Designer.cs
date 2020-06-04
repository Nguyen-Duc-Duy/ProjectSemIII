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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.HistoryOrder = new System.Windows.Forms.ToolStripButton();
            this.GoToRoom = new System.Windows.Forms.ToolStripButton();
            this.SttCus = new System.Windows.Forms.ToolStripButton();
            this.DataCus = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Card = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_nation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumAdults = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumChildrent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStripButton1,
            this.HistoryOrder,
            this.GoToRoom,
            this.SttCus});
            this.toolStrip1.Location = new System.Drawing.Point(-1, 43);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(785, 37);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 34);
            this.toolStripButton1.Text = "Thêm mới";
            // 
            // HistoryOrder
            // 
            this.HistoryOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HistoryOrder.Image = ((System.Drawing.Image)(resources.GetObject("HistoryOrder.Image")));
            this.HistoryOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HistoryOrder.Name = "HistoryOrder";
            this.HistoryOrder.Size = new System.Drawing.Size(23, 34);
            this.HistoryOrder.Text = "Lịch sử đặt phòng";
            this.HistoryOrder.Click += new System.EventHandler(this.HistoryOrder_Click);
            // 
            // GoToRoom
            // 
            this.GoToRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoToRoom.Image = ((System.Drawing.Image)(resources.GetObject("GoToRoom.Image")));
            this.GoToRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoToRoom.Name = "GoToRoom";
            this.GoToRoom.Size = new System.Drawing.Size(23, 34);
            this.GoToRoom.Text = "Nhận phòng";
            this.GoToRoom.Click += new System.EventHandler(this.GoToRoom_Click);
            // 
            // SttCus
            // 
            this.SttCus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SttCus.Image = ((System.Drawing.Image)(resources.GetObject("SttCus.Image")));
            this.SttCus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SttCus.Name = "SttCus";
            this.SttCus.Size = new System.Drawing.Size(23, 34);
            this.SttCus.Text = "Đã thanh toán";
            this.SttCus.Click += new System.EventHandler(this.SttCus_Click);
            // 
            // DataCus
            // 
            this.DataCus.AllowUserToAddRows = false;
            this.DataCus.AllowUserToDeleteRows = false;
            this.DataCus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataCus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataCus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataCus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.STT,
            this.NameCus,
            this.Sex,
            this.Card,
            this.id_nation,
            this.NumAdults,
            this.NumChildrent,
            this.dateCreated,
            this.dateUpdate});
            this.DataCus.Location = new System.Drawing.Point(5, 83);
            this.DataCus.Name = "DataCus";
            this.DataCus.ReadOnly = true;
            this.DataCus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataCus.Size = new System.Drawing.Size(779, 240);
            this.DataCus.TabIndex = 2;
            this.DataCus.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DataCus_RowPrePaint);
            this.DataCus.SelectionChanged += new System.EventHandler(this.DataCus_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // STT
            // 
            this.STT.FillWeight = 40F;
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // NameCus
            // 
            this.NameCus.DataPropertyName = "name";
            this.NameCus.FillWeight = 150F;
            this.NameCus.HeaderText = "Tên Khách Hàng";
            this.NameCus.Name = "NameCus";
            this.NameCus.ReadOnly = true;
            // 
            // Sex
            // 
            this.Sex.DataPropertyName = "sex";
            this.Sex.FillWeight = 50F;
            this.Sex.HeaderText = "Giới tính";
            this.Sex.Name = "Sex";
            this.Sex.ReadOnly = true;
            // 
            // Card
            // 
            this.Card.DataPropertyName = "card";
            this.Card.HeaderText = "CMTND";
            this.Card.Name = "Card";
            this.Card.ReadOnly = true;
            // 
            // id_nation
            // 
            this.id_nation.DataPropertyName = "nation";
            this.id_nation.FillWeight = 80F;
            this.id_nation.HeaderText = "Quốc gia";
            this.id_nation.Name = "id_nation";
            this.id_nation.ReadOnly = true;
            // 
            // NumAdults
            // 
            this.NumAdults.DataPropertyName = "adult";
            this.NumAdults.FillWeight = 40F;
            this.NumAdults.HeaderText = "Số người lớn";
            this.NumAdults.Name = "NumAdults";
            this.NumAdults.ReadOnly = true;
            // 
            // NumChildrent
            // 
            this.NumChildrent.DataPropertyName = "childrent";
            this.NumChildrent.FillWeight = 40F;
            this.NumChildrent.HeaderText = "Số trẻ nhỏ";
            this.NumChildrent.Name = "NumChildrent";
            this.NumChildrent.ReadOnly = true;
            // 
            // dateCreated
            // 
            this.dateCreated.DataPropertyName = "date_created";
            this.dateCreated.HeaderText = "Ngày tạo";
            this.dateCreated.Name = "dateCreated";
            this.dateCreated.ReadOnly = true;
            // 
            // dateUpdate
            // 
            this.dateUpdate.DataPropertyName = "date_updated";
            this.dateUpdate.HeaderText = "Ngày cập nhật";
            this.dateUpdate.Name = "dateUpdate";
            this.dateUpdate.ReadOnly = true;
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
        private System.Windows.Forms.ToolStripButton SttCus;
        private System.Windows.Forms.DataGridView DataCus;
        private System.Windows.Forms.ToolStripButton HistoryOrder;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Card;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_nation;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumAdults;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumChildrent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdate;
        private System.Windows.Forms.ToolStripButton GoToRoom;
    }
}