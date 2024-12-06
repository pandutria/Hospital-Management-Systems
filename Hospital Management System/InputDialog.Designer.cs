namespace Hospital_Management_System
{
    partial class InputDialog
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
            this.tbInput = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblMeetingId = new System.Windows.Forms.Label();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.lblMeetingDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbInput
            // 
            this.tbInput.Location = new System.Drawing.Point(38, 36);
            this.tbInput.Multiline = true;
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(317, 88);
            this.tbInput.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(218, 143);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(137, 53);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblMeetingId
            // 
            this.lblMeetingId.AutoSize = true;
            this.lblMeetingId.Location = new System.Drawing.Point(67, 161);
            this.lblMeetingId.Name = "lblMeetingId";
            this.lblMeetingId.Size = new System.Drawing.Size(44, 16);
            this.lblMeetingId.TabIndex = 3;
            this.lblMeetingId.Text = "label1";
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Location = new System.Drawing.Point(147, 143);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(44, 16);
            this.lblPatientId.TabIndex = 4;
            this.lblPatientId.Text = "label1";
            // 
            // lblMeetingDate
            // 
            this.lblMeetingDate.AutoSize = true;
            this.lblMeetingDate.Location = new System.Drawing.Point(181, 96);
            this.lblMeetingDate.Name = "lblMeetingDate";
            this.lblMeetingDate.Size = new System.Drawing.Size(44, 16);
            this.lblMeetingDate.TabIndex = 5;
            this.lblMeetingDate.Text = "label1";
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 208);
            this.Controls.Add(this.lblMeetingDate);
            this.Controls.Add(this.lblPatientId);
            this.Controls.Add(this.lblMeetingId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tbInput);
            this.Name = "InputDialog";
            this.Text = "InputDialog";
            this.Load += new System.EventHandler(this.InputDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblMeetingId;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.Label lblMeetingDate;
    }
}