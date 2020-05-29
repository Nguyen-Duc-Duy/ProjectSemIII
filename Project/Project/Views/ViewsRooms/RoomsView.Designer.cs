﻿namespace Project.Views
{
    partial class RoomsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsView));
            this.layoutRooms = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.createRoom = new System.Windows.Forms.ToolStripButton();
            this.updateRoom = new System.Windows.Forms.ToolStripButton();
            this.sttRoom = new System.Windows.Forms.ToolStripButton();
            this.comboFilter = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutRooms
            // 
            this.layoutRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutRooms.Location = new System.Drawing.Point(0, 73);
            this.layoutRooms.Name = "layoutRooms";
            this.layoutRooms.Size = new System.Drawing.Size(645, 311);
            this.layoutRooms.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGray;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createRoom,
            this.updateRoom,
            this.sttRoom});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(645, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createRoom
            // 
            this.createRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createRoom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.createRoom.Image = ((System.Drawing.Image)(resources.GetObject("createRoom.Image")));
            this.createRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createRoom.Name = "createRoom";
            this.createRoom.Size = new System.Drawing.Size(23, 22);
            this.createRoom.Text = "toolStripButton1";
            this.createRoom.Click += new System.EventHandler(this.createRoom_Click);
            // 
            // updateRoom
            // 
            this.updateRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateRoom.Image = ((System.Drawing.Image)(resources.GetObject("updateRoom.Image")));
            this.updateRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateRoom.Name = "updateRoom";
            this.updateRoom.Size = new System.Drawing.Size(23, 22);
            this.updateRoom.Text = "toolStripButton2";
            this.updateRoom.Click += new System.EventHandler(this.updateRoom_Click);
            // 
            // sttRoom
            // 
            this.sttRoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sttRoom.Image = ((System.Drawing.Image)(resources.GetObject("sttRoom.Image")));
            this.sttRoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sttRoom.Name = "sttRoom";
            this.sttRoom.Size = new System.Drawing.Size(23, 22);
            this.sttRoom.Text = "toolStripButton1";
            // 
            // comboFilter
            // 
            this.comboFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFilter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboFilter.FormattingEnabled = true;
            this.comboFilter.Location = new System.Drawing.Point(0, 43);
            this.comboFilter.Name = "comboFilter";
            this.comboFilter.Size = new System.Drawing.Size(195, 24);
            this.comboFilter.TabIndex = 0;
            this.comboFilter.SelectedIndexChanged += new System.EventHandler(this.comboFilter_SelectedIndexChanged);
            // 
            // RoomsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 383);
            this.Controls.Add(this.comboFilter);
            this.Controls.Add(this.layoutRooms);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RoomsView";
            this.Text = "RoomsView";
            this.Load += new System.EventHandler(this.RoomsView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel layoutRooms;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton createRoom;
        private System.Windows.Forms.ToolStripButton updateRoom;
        private System.Windows.Forms.ToolStripButton sttRoom;
        private System.Windows.Forms.ComboBox comboFilter;
    }
}