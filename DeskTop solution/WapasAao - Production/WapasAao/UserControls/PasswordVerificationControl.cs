using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace WapasAao.UserControls
{
    public partial class PasswordVerificationControl : UserControl
    {
        public delegate void PasswordVerifiedDelegate(object sender, EventArgs e);

        public event PasswordVerifiedDelegate PasswordVerifiedEvent;

        public PasswordVerificationControl()
        {
            InitializeComponent();
        }

        private void verifyPwdButton_Click(object sender, EventArgs e)
        {
            SharedPreferences.Instance.VendorProgressStep = 3;

            if (PasswordVerifiedEvent != null)
            {
                PasswordVerifiedEvent(sender,e);
            }
        }
    }
}
