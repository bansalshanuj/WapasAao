using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WapasAao.UserControls
{
    public partial class SusquentLoginUserNameEntryControl : UserControl
    {
        public SusquentLoginUserNameEntryControl()
        {
            InitializeComponent();
        }      

        private void submitButton_Click(object sender, EventArgs e)
        {
            // Send the GET request and check if that number is registered or not.
            if (this.IsVendorAlreadyRegistered())
            {
                this.invalidcredentialsLabel.Visible = false;
                // move to the main redeemCustomerPointsControl.
            }
            else
            {
                this.invalidcredentialsLabel.Visible = true;
            }
        }

        private bool IsVendorAlreadyRegistered()
        {
            return true;
        }
    }
}
