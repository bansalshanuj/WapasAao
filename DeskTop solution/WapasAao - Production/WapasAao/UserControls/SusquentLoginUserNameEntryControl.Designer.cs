namespace WapasAao.UserControls
{
    partial class SusquentLoginUserNameEntryControl
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.mobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.invalidcredentialsLabel = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.Location = new System.Drawing.Point(63, 14);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(157, 17);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to WapasAao";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Times New Roman", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.Location = new System.Drawing.Point(15, 64);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(252, 16);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Please enter your registered mobile number";
            // 
            // mobileNumberTextBox
            // 
            this.mobileNumberTextBox.Location = new System.Drawing.Point(73, 93);
            this.mobileNumberTextBox.Name = "mobileNumberTextBox";
            this.mobileNumberTextBox.Size = new System.Drawing.Size(136, 20);
            this.mobileNumberTextBox.TabIndex = 2;
            // 
            // invalidcredentialsLabel
            // 
            this.invalidcredentialsLabel.AutoSize = true;
            this.invalidcredentialsLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invalidcredentialsLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidcredentialsLabel.Location = new System.Drawing.Point(90, 125);
            this.invalidcredentialsLabel.Name = "invalidcredentialsLabel";
            this.invalidcredentialsLabel.Size = new System.Drawing.Size(118, 15);
            this.invalidcredentialsLabel.TabIndex = 3;
            this.invalidcredentialsLabel.Text = "Invalid Credentials !!";
            this.invalidcredentialsLabel.Visible = false;
            // 
            // submitButton
            // 
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.Font = new System.Drawing.Font("Times New Roman", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitButton.Location = new System.Drawing.Point(146, 163);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // SusquentLoginUserNameEntryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.invalidcredentialsLabel);
            this.Controls.Add(this.mobileNumberTextBox);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "SusquentLoginUserNameEntryControl";
            this.Size = new System.Drawing.Size(307, 248);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox mobileNumberTextBox;
        private System.Windows.Forms.Label invalidcredentialsLabel;
        private System.Windows.Forms.Button submitButton;
    }
}
