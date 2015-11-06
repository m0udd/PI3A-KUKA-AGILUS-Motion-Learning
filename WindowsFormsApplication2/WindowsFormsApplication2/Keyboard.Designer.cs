namespace WindowsFormsApplication2
{
    partial class Keyboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Keyboard));
            this.m_gripper = new System.Windows.Forms.Button();
            this.m_back = new System.Windows.Forms.Button();
            this.gripperClosed = new System.Windows.Forms.PictureBox();
            this.gripperOpened = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.gripperClosed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripperOpened)).BeginInit();
            this.SuspendLayout();
            // 
            // m_gripper
            // 
            this.m_gripper.Location = new System.Drawing.Point(1064, 12);
            this.m_gripper.Name = "m_gripper";
            this.m_gripper.Size = new System.Drawing.Size(100, 100);
            this.m_gripper.TabIndex = 0;
            this.m_gripper.Text = "Gripper";
            this.m_gripper.UseVisualStyleBackColor = true;
            this.m_gripper.Click += new System.EventHandler(this.m_gripper_Click);
            // 
            // m_back
            // 
            this.m_back.BackColor = System.Drawing.SystemColors.Window;
            this.m_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.m_back.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.m_back.FlatAppearance.BorderSize = 0;
            this.m_back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_back.Location = new System.Drawing.Point(12, 12);
            this.m_back.Name = "m_back";
            this.m_back.Size = new System.Drawing.Size(75, 41);
            this.m_back.TabIndex = 2;
            this.m_back.Text = "Back";
            this.m_back.UseVisualStyleBackColor = false;
            this.m_back.Click += new System.EventHandler(this.m_back_Click);
            // 
            // gripperClosed
            // 
            this.gripperClosed.Image = ((System.Drawing.Image)(resources.GetObject("gripperClosed.Image")));
            this.gripperClosed.Location = new System.Drawing.Point(470, 12);
            this.gripperClosed.Name = "gripperClosed";
            this.gripperClosed.Size = new System.Drawing.Size(200, 200);
            this.gripperClosed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.gripperClosed.TabIndex = 3;
            this.gripperClosed.TabStop = false;
            // 
            // gripperOpened
            // 
            this.gripperOpened.Image = ((System.Drawing.Image)(resources.GetObject("gripperOpened.Image")));
            this.gripperOpened.Location = new System.Drawing.Point(470, 12);
            this.gripperOpened.Name = "gripperOpened";
            this.gripperOpened.Size = new System.Drawing.Size(200, 200);
            this.gripperOpened.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.gripperOpened.TabIndex = 4;
            this.gripperOpened.TabStop = false;
            this.gripperOpened.Visible = false;
            this.gripperOpened.Click += new System.EventHandler(this.gripperOpened_Click);
            // 
            // Keyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 586);
            this.Controls.Add(this.gripperOpened);
            this.Controls.Add(this.gripperClosed);
            this.Controls.Add(this.m_back);
            this.Controls.Add(this.m_gripper);
            this.Name = "Keyboard";
            this.Text = "Keyboard";
            ((System.ComponentModel.ISupportInitialize)(this.gripperClosed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gripperOpened)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_gripper;
        private System.Windows.Forms.Button m_back;
        private System.Windows.Forms.PictureBox gripperClosed;
        private System.Windows.Forms.PictureBox gripperOpened;
    }
}