namespace WapasAao.UserControls
{
    partial class RedeemCustomerPointsControl
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
            this.getTransactionsLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.customerMobileNumberlabel = new System.Windows.Forms.Label();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.custMobileNumberTextBox = new System.Windows.Forms.TextBox();
            this.redeemPointsCheckBox = new System.Windows.Forms.CheckBox();
            this.getDetailsButton = new System.Windows.Forms.Button();
            this.mandatoryDetailsLabel = new System.Windows.Forms.Label();
            this.sendCreditsUserControl = new WapasAao.UserControls.SendCreditsUserControl();
            this.SuspendLayout();
            // 
            // getTransactionsLabel
            // 
            this.getTransactionsLabel.AutoSize = true;
            this.getTransactionsLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getTransactionsLabel.Location = new System.Drawing.Point(91, 20);
            this.getTransactionsLabel.Name = "getTransactionsLabel";
            this.getTransactionsLabel.Size = new System.Drawing.Size(163, 17);
            this.getTransactionsLabel.TabIndex = 0;
            this.getTransactionsLabel.Text = "GET TRANSACTIONS";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountLabel.Location = new System.Drawing.Point(27, 63);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(51, 15);
            this.amountLabel.TabIndex = 1;
            this.amountLabel.Text = "Amount";
            // 
            // customerMobileNumberlabel
            // 
            this.customerMobileNumberlabel.AutoSize = true;
            this.customerMobileNumberlabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerMobileNumberlabel.Location = new System.Drawing.Point(27, 102);
            this.customerMobileNumberlabel.Name = "customerMobileNumberlabel";
            this.customerMobileNumberlabel.Size = new System.Drawing.Size(144, 15);
            this.customerMobileNumberlabel.TabIndex = 2;
            this.customerMobileNumberlabel.Text = "Customer Mobile Number";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(196, 63);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 20);
            this.amountTextBox.TabIndex = 3;
            // 
            // custMobileNumberTextBox
            // 
            this.custMobileNumberTextBox.Location = new System.Drawing.Point(196, 99);
            this.custMobileNumberTextBox.Name = "custMobileNumberTextBox";
            this.custMobileNumberTextBox.Size = new System.Drawing.Size(100, 20);
            this.custMobileNumberTextBox.TabIndex = 4;
            // 
            // redeemPointsCheckBox
            // 
            this.redeemPointsCheckBox.AutoSize = true;
            this.redeemPointsCheckBox.Checked = true;
            this.redeemPointsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.redeemPointsCheckBox.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redeemPointsCheckBox.Location = new System.Drawing.Point(30, 146);
            this.redeemPointsCheckBox.Name = "redeemPointsCheckBox";
            this.redeemPointsCheckBox.Size = new System.Drawing.Size(105, 19);
            this.redeemPointsCheckBox.TabIndex = 6;
            this.redeemPointsCheckBox.Text = "Redeem Points";
            this.redeemPointsCheckBox.UseVisualStyleBackColor = true;
            // 
            // getDetailsButton
            // 
            this.getDetailsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.getDetailsButton.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getDetailsButton.Location = new System.Drawing.Point(196, 210);
            this.getDetailsButton.Name = "getDetailsButton";
            this.getDetailsButton.Size = new System.Drawing.Size(100, 31);
            this.getDetailsButton.TabIndex = 7;
            this.getDetailsButton.Text = "Get Details";
            this.getDetailsButton.UseVisualStyleBackColor = true;
            this.getDetailsButton.Click += new System.EventHandler(this.getDetailsButton_Click);
            // 
            // mandatoryDetailsLabel
            // 
            this.mandatoryDetailsLabel.AutoSize = true;
            this.mandatoryDetailsLabel.Location = new System.Drawing.Point(91, 178);
            this.mandatoryDetailsLabel.Name = "mandatoryDetailsLabel";
            this.mandatoryDetailsLabel.Size = new System.Drawing.Size(169, 13);
            this.mandatoryDetailsLabel.TabIndex = 9;
            this.mandatoryDetailsLabel.Text = "Please enter the mandatory details";
            // 
            // sendCreditsUserControl
            // 
            this.sendCreditsUserControl.Location = new System.Drawing.Point(18, 3);
            this.sendCreditsUserControl.Name = "sendCreditsUserControl";
            this.sendCreditsUserControl.Size = new System.Drawing.Size(344, 289);
            this.sendCreditsUserControl.TabIndex = 8;
            // 
            // RedeemCustomerPointsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sendCreditsUserControl);
            this.Controls.Add(this.mandatoryDetailsLabel);
            this.Controls.Add(this.getDetailsButton);
            this.Controls.Add(this.redeemPointsCheckBox);
            this.Controls.Add(this.custMobileNumberTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.customerMobileNumberlabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.getTransactionsLabel);
            this.Name = "RedeemCustomerPointsControl";
            this.Size = new System.Drawing.Size(394, 302);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label getTransactionsLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label customerMobileNumberlabel;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox custMobileNumberTextBox;
        private System.Windows.Forms.CheckBox redeemPointsCheckBox;
        private System.Windows.Forms.Button getDetailsButton;
        private SendCreditsUserControl sendCreditsUserControl;
        private System.Windows.Forms.Label mandatoryDetailsLabel;
    }
}
