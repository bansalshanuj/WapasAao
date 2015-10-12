namespace WapasAao.UserControls
{
    partial class PasswordVerificationControl
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.verifyPwdButton = new System.Windows.Forms.Button();
            this.inProgressPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.inProgressPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Location = new System.Drawing.Point(70, 13);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(147, 13);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "PASSWORD VERIFICATION";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please enter the password received non your registered mobile number.";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(93, 79);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordTextBox.TabIndex = 2;
            // 
            // verifyPwdButton
            // 
            this.verifyPwdButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verifyPwdButton.Location = new System.Drawing.Point(106, 120);
            this.verifyPwdButton.Name = "verifyPwdButton";
            this.verifyPwdButton.Size = new System.Drawing.Size(75, 23);
            this.verifyPwdButton.TabIndex = 3;
            this.verifyPwdButton.Text = "Verify";
            this.verifyPwdButton.UseVisualStyleBackColor = true;
            this.verifyPwdButton.Click += new System.EventHandler(this.verifyPwdButton_Click);
            // 
            // inProgressPictureBox
            // 
            this.inProgressPictureBox.ErrorImage = null;
            this.inProgressPictureBox.Image = global::WapasAao.Properties.Resources.wait;
            this.inProgressPictureBox.InitialImage = null;
            this.inProgressPictureBox.Location = new System.Drawing.Point(109, 149);
            this.inProgressPictureBox.Name = "inProgressPictureBox";
            this.inProgressPictureBox.Size = new System.Drawing.Size(68, 70);
            this.inProgressPictureBox.TabIndex = 4;
            this.inProgressPictureBox.TabStop = false;
            this.inProgressPictureBox.Visible = false;
            // 
            // PasswordVerificationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inProgressPictureBox);
            this.Controls.Add(this.verifyPwdButton);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.headerLabel);
            this.Name = "PasswordVerificationControl";
            this.Size = new System.Drawing.Size(355, 245);
            ((System.ComponentModel.ISupportInitialize)(this.inProgressPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button verifyPwdButton;
        private System.Windows.Forms.PictureBox inProgressPictureBox;
    }
}
