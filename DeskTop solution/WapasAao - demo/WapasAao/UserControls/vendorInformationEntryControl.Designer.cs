namespace WapasAao.UserControls
{
    partial class VendorInformationEntryControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.mobileNumberLabel = new System.Windows.Forms.Label();
            this.vendorNametextBox = new System.Windows.Forms.TextBox();
            this.vendorMobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.signUpButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.inProgressPictureBox = new System.Windows.Forms.PictureBox();
            this.mandatoryDetailsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inProgressPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(34, 66);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(37, 15);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Name";
            // 
            // mobileNumberLabel
            // 
            this.mobileNumberLabel.AutoSize = true;
            this.mobileNumberLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mobileNumberLabel.Location = new System.Drawing.Point(34, 105);
            this.mobileNumberLabel.Name = "mobileNumberLabel";
            this.mobileNumberLabel.Size = new System.Drawing.Size(90, 15);
            this.mobileNumberLabel.TabIndex = 1;
            this.mobileNumberLabel.Text = "Mobile Number";
            // 
            // vendorNametextBox
            // 
            this.vendorNametextBox.Location = new System.Drawing.Point(157, 66);
            this.vendorNametextBox.Name = "vendorNametextBox";
            this.vendorNametextBox.Size = new System.Drawing.Size(100, 20);
            this.vendorNametextBox.TabIndex = 2;
            // 
            // vendorMobileNumberTextBox
            // 
            this.vendorMobileNumberTextBox.Location = new System.Drawing.Point(157, 100);
            this.vendorMobileNumberTextBox.Name = "vendorMobileNumberTextBox";
            this.vendorMobileNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.vendorMobileNumberTextBox.TabIndex = 3;
            // 
            // signUpButton
            // 
            this.signUpButton.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUpButton.Location = new System.Drawing.Point(179, 167);
            this.signUpButton.Name = "signUpButton";
            this.signUpButton.Size = new System.Drawing.Size(75, 23);
            this.signUpButton.TabIndex = 4;
            this.signUpButton.Text = "SignUp";
            this.signUpButton.UseVisualStyleBackColor = true;
            this.signUpButton.Click += new System.EventHandler(this.signUpButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(67, 19);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(190, 17);
            this.headerLabel.TabIndex = 5;
            this.headerLabel.Text = "VENDOR INFORMATION";
            // 
            // inProgressPictureBox
            // 
            this.inProgressPictureBox.Image = global::WapasAao.Properties.Resources.wait;
            this.inProgressPictureBox.Location = new System.Drawing.Point(107, 158);
            this.inProgressPictureBox.Name = "inProgressPictureBox";
            this.inProgressPictureBox.Size = new System.Drawing.Size(66, 70);
            this.inProgressPictureBox.TabIndex = 6;
            this.inProgressPictureBox.TabStop = false;
            this.inProgressPictureBox.Visible = false;
            // 
            // mandatoryDetailsLabel
            // 
            this.mandatoryDetailsLabel.AutoSize = true;
            this.mandatoryDetailsLabel.Location = new System.Drawing.Point(69, 137);
            this.mandatoryDetailsLabel.Name = "mandatoryDetailsLabel";
            this.mandatoryDetailsLabel.Size = new System.Drawing.Size(169, 13);
            this.mandatoryDetailsLabel.TabIndex = 7;
            this.mandatoryDetailsLabel.Text = "Please enter the mandatory details";
            // 
            // VendorInformationEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mandatoryDetailsLabel);
            this.Controls.Add(this.inProgressPictureBox);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.signUpButton);
            this.Controls.Add(this.vendorMobileNumberTextBox);
            this.Controls.Add(this.vendorNametextBox);
            this.Controls.Add(this.mobileNumberLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "VendorInformationEntryControl";
            this.Size = new System.Drawing.Size(317, 242);
            ((System.ComponentModel.ISupportInitialize)(this.inProgressPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label mobileNumberLabel;
        private System.Windows.Forms.TextBox vendorNametextBox;
        private System.Windows.Forms.TextBox vendorMobileNumberTextBox;
        private System.Windows.Forms.Button signUpButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.PictureBox inProgressPictureBox;
        private System.Windows.Forms.Label mandatoryDetailsLabel;
    }
}
