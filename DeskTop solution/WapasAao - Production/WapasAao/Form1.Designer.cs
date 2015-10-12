using System.Drawing;
using System.Windows.Forms;

namespace WapasAao
{
    partial class wapasAaoMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wapasAaoMainForm));
            this.vendorBusinessInformationEntryModule = new WapasAao.UserControls.VendorBusinessInformationEntryModule();
            this.redeemCustomerPointsControl = new WapasAao.UserControls.RedeemCustomerPointsControl();
            this.passwordVerificationControl = new WapasAao.UserControls.PasswordVerificationControl();
            this.susquentLoginUserNameEntryControl = new WapasAao.UserControls.SusquentLoginUserNameEntryControl();
            this.vendorInformationEntryControl = new WapasAao.UserControls.VendorInformationEntryControl();
            this.SuspendLayout();
            // 
            // vendorBusinessInformationEntryModule
            // 
            this.vendorBusinessInformationEntryModule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendorBusinessInformationEntryModule.Location = new System.Drawing.Point(0, 0);
            this.vendorBusinessInformationEntryModule.Name = "vendorBusinessInformationEntryModule";
            this.vendorBusinessInformationEntryModule.Size = new System.Drawing.Size(413, 349);
            this.vendorBusinessInformationEntryModule.TabIndex = 2;
            // 
            // redeemCustomerPointsControl
            // 
            this.redeemCustomerPointsControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redeemCustomerPointsControl.Location = new System.Drawing.Point(0, 0);
            this.redeemCustomerPointsControl.Name = "redeemCustomerPointsControl";
            this.redeemCustomerPointsControl.Size = new System.Drawing.Size(413, 349);
            this.redeemCustomerPointsControl.TabIndex = 1;
            // 
            // passwordVerificationControl
            // 
            this.passwordVerificationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.passwordVerificationControl.Location = new System.Drawing.Point(0, 0);
            this.passwordVerificationControl.Name = "passwordVerificationControl";
            this.passwordVerificationControl.Size = new System.Drawing.Size(413, 349);
            this.passwordVerificationControl.TabIndex = 0;
            // 
            // susquentLoginUserNameEntryControl
            // 
            this.susquentLoginUserNameEntryControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.susquentLoginUserNameEntryControl.Location = new System.Drawing.Point(0, 0);
            this.susquentLoginUserNameEntryControl.Name = "susquentLoginUserNameEntryControl";
            this.susquentLoginUserNameEntryControl.Size = new System.Drawing.Size(413, 349);
            this.susquentLoginUserNameEntryControl.TabIndex = 4;
            this.susquentLoginUserNameEntryControl.Load += new System.EventHandler(this.susquentLoginUserNameEntryControl_Load);
            // 
            // vendorInformationEntryControl
            // 
            this.vendorInformationEntryControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vendorInformationEntryControl.Location = new System.Drawing.Point(0, 0);
            this.vendorInformationEntryControl.Name = "vendorInformationEntryControl";
            this.vendorInformationEntryControl.Size = new System.Drawing.Size(413, 349);
            this.vendorInformationEntryControl.TabIndex = 3;
            // 
            // wapasAaoMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(413, 349);
            this.Controls.Add(this.vendorBusinessInformationEntryModule);
            this.Controls.Add(this.redeemCustomerPointsControl);
            this.Controls.Add(this.passwordVerificationControl);
            this.Controls.Add(this.susquentLoginUserNameEntryControl);
            this.Controls.Add(this.vendorInformationEntryControl);
            this.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "wapasAaoMainForm";
            this.Text = "Wapas Aao";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.PasswordVerificationControl passwordVerificationControl;
        private UserControls.RedeemCustomerPointsControl redeemCustomerPointsControl;
        private UserControls.VendorBusinessInformationEntryModule vendorBusinessInformationEntryModule;
        private UserControls.VendorInformationEntryControl vendorInformationEntryControl;
        private UserControls.SusquentLoginUserNameEntryControl susquentLoginUserNameEntryControl;



    }
}

