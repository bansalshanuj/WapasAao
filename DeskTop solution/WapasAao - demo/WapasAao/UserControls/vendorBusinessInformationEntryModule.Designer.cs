namespace WapasAao.UserControls
{
    partial class VendorBusinessInformationEntryModule
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
            this.workplaceInfoLabel = new System.Windows.Forms.Label();
            this.businessNameLabel = new System.Windows.Forms.Label();
            this.businessAddressLabel = new System.Windows.Forms.Label();
            this.paybackPercentageLabel = new System.Windows.Forms.Label();
            this.organizationNametextBox = new System.Windows.Forms.TextBox();
            this.organizationAddressTextBox = new System.Windows.Forms.RichTextBox();
            this.paybackPercentageTextBox = new System.Windows.Forms.TextBox();
            this.submitInfoButton = new System.Windows.Forms.Button();
            this.mandatoryDeatilsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workplaceInfoLabel
            // 
            this.workplaceInfoLabel.AutoSize = true;
            this.workplaceInfoLabel.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workplaceInfoLabel.Location = new System.Drawing.Point(61, 10);
            this.workplaceInfoLabel.Name = "workplaceInfoLabel";
            this.workplaceInfoLabel.Size = new System.Drawing.Size(225, 17);
            this.workplaceInfoLabel.TabIndex = 0;
            this.workplaceInfoLabel.Text = "WORKPLACE INFORMATION";
            this.workplaceInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // businessNameLabel
            // 
            this.businessNameLabel.AutoSize = true;
            this.businessNameLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessNameLabel.Location = new System.Drawing.Point(30, 54);
            this.businessNameLabel.Name = "businessNameLabel";
            this.businessNameLabel.Size = new System.Drawing.Size(105, 15);
            this.businessNameLabel.TabIndex = 1;
            this.businessNameLabel.Text = "OrganizationName";
            // 
            // businessAddressLabel
            // 
            this.businessAddressLabel.AutoSize = true;
            this.businessAddressLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.businessAddressLabel.Location = new System.Drawing.Point(30, 91);
            this.businessAddressLabel.Name = "businessAddressLabel";
            this.businessAddressLabel.Size = new System.Drawing.Size(123, 15);
            this.businessAddressLabel.TabIndex = 2;
            this.businessAddressLabel.Text = "Organization Address";
            // 
            // paybackPercentageLabel
            // 
            this.paybackPercentageLabel.AutoSize = true;
            this.paybackPercentageLabel.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paybackPercentageLabel.Location = new System.Drawing.Point(30, 167);
            this.paybackPercentageLabel.Name = "paybackPercentageLabel";
            this.paybackPercentageLabel.Size = new System.Drawing.Size(114, 15);
            this.paybackPercentageLabel.TabIndex = 3;
            this.paybackPercentageLabel.Text = "Payback Percentage";
            // 
            // organizationNametextBox
            // 
            this.organizationNametextBox.Location = new System.Drawing.Point(192, 54);
            this.organizationNametextBox.Name = "organizationNametextBox";
            this.organizationNametextBox.Size = new System.Drawing.Size(125, 20);
            this.organizationNametextBox.TabIndex = 4;
            // 
            // organizationAddressTextBox
            // 
            this.organizationAddressTextBox.Location = new System.Drawing.Point(192, 89);
            this.organizationAddressTextBox.Name = "organizationAddressTextBox";
            this.organizationAddressTextBox.Size = new System.Drawing.Size(125, 55);
            this.organizationAddressTextBox.TabIndex = 5;
            this.organizationAddressTextBox.Text = "";
            // 
            // paybackPercentageTextBox
            // 
            this.paybackPercentageTextBox.Location = new System.Drawing.Point(192, 167);
            this.paybackPercentageTextBox.Name = "paybackPercentageTextBox";
            this.paybackPercentageTextBox.Size = new System.Drawing.Size(125, 20);
            this.paybackPercentageTextBox.TabIndex = 6;
            // 
            // submitInfoButton
            // 
            this.submitInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitInfoButton.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitInfoButton.Location = new System.Drawing.Point(192, 228);
            this.submitInfoButton.Name = "submitInfoButton";
            this.submitInfoButton.Size = new System.Drawing.Size(75, 23);
            this.submitInfoButton.TabIndex = 7;
            this.submitInfoButton.Text = "Submit";
            this.submitInfoButton.UseVisualStyleBackColor = true;
            this.submitInfoButton.Click += new System.EventHandler(this.submitInfoButton_Click);
            // 
            // mandatoryDeatilsLabel
            // 
            this.mandatoryDeatilsLabel.AutoSize = true;
            this.mandatoryDeatilsLabel.Location = new System.Drawing.Point(95, 203);
            this.mandatoryDeatilsLabel.Name = "mandatoryDeatilsLabel";
            this.mandatoryDeatilsLabel.Size = new System.Drawing.Size(172, 13);
            this.mandatoryDeatilsLabel.TabIndex = 8;
            this.mandatoryDeatilsLabel.Text = "Please enter the mandatory details.";
            // 
            // VendorBusinessInformationEntryModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mandatoryDeatilsLabel);
            this.Controls.Add(this.submitInfoButton);
            this.Controls.Add(this.paybackPercentageTextBox);
            this.Controls.Add(this.organizationAddressTextBox);
            this.Controls.Add(this.organizationNametextBox);
            this.Controls.Add(this.paybackPercentageLabel);
            this.Controls.Add(this.businessAddressLabel);
            this.Controls.Add(this.businessNameLabel);
            this.Controls.Add(this.workplaceInfoLabel);
            this.Name = "VendorBusinessInformationEntryModule";
            this.Size = new System.Drawing.Size(392, 269);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label workplaceInfoLabel;
        private System.Windows.Forms.Label businessNameLabel;
        private System.Windows.Forms.Label businessAddressLabel;
        private System.Windows.Forms.Label paybackPercentageLabel;
        private System.Windows.Forms.TextBox organizationNametextBox;
        private System.Windows.Forms.RichTextBox organizationAddressTextBox;
        private System.Windows.Forms.TextBox paybackPercentageTextBox;
        private System.Windows.Forms.Button submitInfoButton;
        private System.Windows.Forms.Label mandatoryDeatilsLabel;
    }
}
