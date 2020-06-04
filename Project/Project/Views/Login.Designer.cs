namespace Project
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
            this.gradientPanel1 = new Project.GradientPanel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.errorPass = new System.Windows.Forms.Label();
            this.errorEmail = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.gradientPanel3 = new Project.GradientPanel();
            this.inputPass = new System.Windows.Forms.TextBox();
            this.gradientPanel2 = new Project.GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gradientPanel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.angular = 90F;
            this.gradientPanel1.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(190)))), ((int)(((byte)(111)))));
            this.gradientPanel1.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(245)))), ((int)(((byte)(122)))));
            this.gradientPanel1.Controls.Add(this.label4);
            this.gradientPanel1.Controls.Add(this.bunifuGradientPanel1);
            this.gradientPanel1.Location = new System.Drawing.Point(-1, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(420, 506);
            this.gradientPanel1.TabIndex = 0;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.Controls.Add(this.errorPass);
            this.bunifuGradientPanel1.Controls.Add(this.errorEmail);
            this.bunifuGradientPanel1.Controls.Add(this.button1);
            this.bunifuGradientPanel1.Controls.Add(this.gradientPanel3);
            this.bunifuGradientPanel1.Controls.Add(this.inputPass);
            this.bunifuGradientPanel1.Controls.Add(this.gradientPanel2);
            this.bunifuGradientPanel1.Controls.Add(this.label3);
            this.bunifuGradientPanel1.Controls.Add(this.inputEmail);
            this.bunifuGradientPanel1.Controls.Add(this.label2);
            this.bunifuGradientPanel1.Controls.Add(this.label1);
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(69, 54);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(281, 363);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // errorPass
            // 
            this.errorPass.AutoSize = true;
            this.errorPass.BackColor = System.Drawing.Color.Transparent;
            this.errorPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorPass.Location = new System.Drawing.Point(33, 258);
            this.errorPass.Name = "errorPass";
            this.errorPass.Size = new System.Drawing.Size(35, 13);
            this.errorPass.TabIndex = 9;
            this.errorPass.Text = "label5";
            // 
            // errorEmail
            // 
            this.errorEmail.AutoSize = true;
            this.errorEmail.BackColor = System.Drawing.Color.Transparent;
            this.errorEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorEmail.Location = new System.Drawing.Point(33, 160);
            this.errorEmail.Name = "errorEmail";
            this.errorEmail.Size = new System.Drawing.Size(35, 13);
            this.errorEmail.TabIndex = 8;
            this.errorEmail.Text = "label4";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(190)))), ((int)(((byte)(111)))));
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(97, 314);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.angular = 90F;
            this.gradientPanel3.ColorBottom = System.Drawing.Color.Empty;
            this.gradientPanel3.ColorTop = System.Drawing.Color.PaleGreen;
            this.gradientPanel3.Location = new System.Drawing.Point(35, 245);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(220, 10);
            this.gradientPanel3.TabIndex = 6;
            // 
            // inputPass
            // 
            this.inputPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPass.Location = new System.Drawing.Point(35, 217);
            this.inputPass.Name = "inputPass";
            this.inputPass.Size = new System.Drawing.Size(235, 22);
            this.inputPass.TabIndex = 5;
            this.inputPass.Text = "1";
            this.inputPass.UseSystemPasswordChar = true;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.angular = 90F;
            this.gradientPanel2.ColorBottom = System.Drawing.Color.Empty;
            this.gradientPanel2.ColorTop = System.Drawing.Color.PaleGreen;
            this.gradientPanel2.Location = new System.Drawing.Point(35, 147);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(220, 10);
            this.gradientPanel2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("iCielBC DDCHardwareRough Compre", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pass";
            // 
            // inputEmail
            // 
            this.inputEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputEmail.Location = new System.Drawing.Point(35, 119);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(235, 22);
            this.inputEmail.TabIndex = 2;
            this.inputEmail.Text = "manager@gmail.com";
            this.inputEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.inputEmail_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("iCielBC DDCHardwareRough Compre", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comfortaa", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 474);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(417, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "XIXAO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 502);
            this.Controls.Add(this.gradientPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Phần mềm quản lý khách sạn";
            this.Load += new System.EventHandler(this.Login_Load);
            this.gradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GradientPanel gradientPanel1;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
        private GradientPanel gradientPanel3;
        private System.Windows.Forms.TextBox inputPass;
        private GradientPanel gradientPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label errorPass;
        private System.Windows.Forms.Label errorEmail;
        private System.Windows.Forms.Label label4;
    }
}