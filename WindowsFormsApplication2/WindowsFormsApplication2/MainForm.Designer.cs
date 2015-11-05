namespace WindowsFormsApplication2
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_souris3d = new System.Windows.Forms.Button();
            this.m_back = new System.Windows.Forms.Button();
            this.m_keyboard = new System.Windows.Forms.Button();
            this.gripperOpened = new System.Windows.Forms.PictureBox();
            this.gripperClosed = new System.Windows.Forms.PictureBox();
            this.m_logs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gripperOpened)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripperClosed)).BeginInit();
            this.SuspendLayout();
            // 
            // m_souris3d
            // 
            this.m_souris3d.Font = new System.Drawing.Font("Segoe UI", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_souris3d.Location = new System.Drawing.Point(12, 98);
            this.m_souris3d.Name = "m_souris3d";
            this.m_souris3d.Size = new System.Drawing.Size(180, 80);
            this.m_souris3d.TabIndex = 0;
            this.m_souris3d.Text = "Teaching";
            this.m_souris3d.UseVisualStyleBackColor = true;
            this.m_souris3d.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_back
            // 
            this.m_back.BackColor = System.Drawing.SystemColors.Window;
            this.m_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_back.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.m_back.FlatAppearance.BorderSize = 0;
            this.m_back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_back.Font = new System.Drawing.Font("Segoe UI", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_back.Location = new System.Drawing.Point(12, 12);
            this.m_back.Name = "m_back";
            this.m_back.Size = new System.Drawing.Size(180, 41);
            this.m_back.TabIndex = 1;
            this.m_back.Text = "Back";
            this.m_back.UseVisualStyleBackColor = false;
            this.m_back.Visible = false;
            this.m_back.Click += new System.EventHandler(this.m_back_Click);
            // 
            // m_keyboard
            // 
            this.m_keyboard.Font = new System.Drawing.Font("Segoe UI", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_keyboard.Location = new System.Drawing.Point(12, 218);
            this.m_keyboard.Name = "m_keyboard";
            this.m_keyboard.Size = new System.Drawing.Size(180, 80);
            this.m_keyboard.TabIndex = 2;
            this.m_keyboard.Text = "Play";
            this.m_keyboard.UseVisualStyleBackColor = true;
            this.m_keyboard.Click += new System.EventHandler(this.m_keyboard_Click);
            // 
            // gripperOpened
            // 
            this.gripperOpened.Image = ((System.Drawing.Image)(resources.GetObject("gripperOpened.Image")));
            this.gripperOpened.Location = new System.Drawing.Point(504, 98);
            this.gripperOpened.Name = "gripperOpened";
            this.gripperOpened.Size = new System.Drawing.Size(200, 200);
            this.gripperOpened.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gripperOpened.TabIndex = 5;
            this.gripperOpened.TabStop = false;
            this.gripperOpened.Visible = false;
            this.gripperOpened.Click += new System.EventHandler(this.gripperOpened_Click);
            // 
            // gripperClosed
            // 
            this.gripperClosed.Image = ((System.Drawing.Image)(resources.GetObject("gripperClosed.Image")));
            this.gripperClosed.Location = new System.Drawing.Point(504, 98);
            this.gripperClosed.Name = "gripperClosed";
            this.gripperClosed.Size = new System.Drawing.Size(200, 200);
            this.gripperClosed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gripperClosed.TabIndex = 6;
            this.gripperClosed.TabStop = false;
            this.gripperClosed.Click += new System.EventHandler(this.gripperClosed_Click);
            // 
            // m_logs
            // 
            this.m_logs.Font = new System.Drawing.Font("Segoe UI", 8.142858F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_logs.Location = new System.Drawing.Point(12, 494);
            this.m_logs.Name = "m_logs";
            this.m_logs.Size = new System.Drawing.Size(180, 80);
            this.m_logs.TabIndex = 7;
            this.m_logs.Text = "Logs";
            this.m_logs.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1176, 586);
            this.Controls.Add(this.m_logs);
            this.Controls.Add(this.gripperClosed);
            this.Controls.Add(this.gripperOpened);
            this.Controls.Add(this.m_keyboard);
            this.Controls.Add(this.m_back);
            this.Controls.Add(this.m_souris3d);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agilus Program";
            ((System.ComponentModel.ISupportInitialize)(this.gripperOpened)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripperClosed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_souris3d;
        private System.Windows.Forms.Button m_back;
        private System.Windows.Forms.Button m_keyboard;
        private System.Windows.Forms.PictureBox gripperOpened;
        private System.Windows.Forms.PictureBox gripperClosed;
        private System.Windows.Forms.Button m_logs;
    }
}