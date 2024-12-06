namespace Hospital_Management_System
{
    partial class FormMain
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
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnICD = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.btnParent = new System.Windows.Forms.Button();
            this.btnNewMeeting = new System.Windows.Forms.Button();
            this.btnManageMeeting = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(25, 24);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(98, 32);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "label1";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(652, 26);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(107, 36);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnICD
            // 
            this.btnICD.Location = new System.Drawing.Point(281, 139);
            this.btnICD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnICD.Name = "btnICD";
            this.btnICD.Size = new System.Drawing.Size(196, 38);
            this.btnICD.TabIndex = 3;
            this.btnICD.Text = "Master ICD-11";
            this.btnICD.UseVisualStyleBackColor = true;
            this.btnICD.Click += new System.EventHandler(this.btnICD_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Location = new System.Drawing.Point(281, 182);
            this.btnDoctor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(196, 38);
            this.btnDoctor.TabIndex = 4;
            this.btnDoctor.Text = "Master Doctor";
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // btnParent
            // 
            this.btnParent.Location = new System.Drawing.Point(281, 225);
            this.btnParent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnParent.Name = "btnParent";
            this.btnParent.Size = new System.Drawing.Size(196, 38);
            this.btnParent.TabIndex = 5;
            this.btnParent.Text = "Master Patient";
            this.btnParent.UseVisualStyleBackColor = true;
            this.btnParent.Click += new System.EventHandler(this.btnParent_Click);
            // 
            // btnNewMeeting
            // 
            this.btnNewMeeting.Location = new System.Drawing.Point(281, 268);
            this.btnNewMeeting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNewMeeting.Name = "btnNewMeeting";
            this.btnNewMeeting.Size = new System.Drawing.Size(196, 38);
            this.btnNewMeeting.TabIndex = 6;
            this.btnNewMeeting.Text = "New Meeting";
            this.btnNewMeeting.UseVisualStyleBackColor = true;
            this.btnNewMeeting.Click += new System.EventHandler(this.btnNewMeeting_Click);
            // 
            // btnManageMeeting
            // 
            this.btnManageMeeting.Location = new System.Drawing.Point(281, 311);
            this.btnManageMeeting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageMeeting.Name = "btnManageMeeting";
            this.btnManageMeeting.Size = new System.Drawing.Size(196, 38);
            this.btnManageMeeting.TabIndex = 7;
            this.btnManageMeeting.Text = "Manage Meeting";
            this.btnManageMeeting.UseVisualStyleBackColor = true;
            this.btnManageMeeting.Click += new System.EventHandler(this.btnManageMeeting_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageMeeting);
            this.Controls.Add(this.btnNewMeeting);
            this.Controls.Add(this.btnParent);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnICD);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUsername);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnICD;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnParent;
        private System.Windows.Forms.Button btnNewMeeting;
        private System.Windows.Forms.Button btnManageMeeting;
    }
}