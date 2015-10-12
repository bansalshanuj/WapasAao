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
            invalidVerifyCodeLbl.Visible = false;
        }

        private void verifyPwdButton_Click(object sender, EventArgs e)
        {
            // check if the verification code is correct ot not.
            if (passwordTextBox.Text.Equals(SharedPreferences.Instance.VerificationCode) == false)
            {
                invalidVerifyCodeLbl.Visible = true;
                passwordTextBox.Text = string.Empty;
                passwordTextBox.Select();
                return;
            }

            invalidVerifyCodeLbl.Visible = false;
            SharedPreferences.Instance.VendorProgressStep = 3;

            if (PasswordVerifiedEvent != null)
            {
                PasswordVerifiedEvent(sender,e);
            }
        }

        private void resendVerifyCodeBtn_Click(object sender, EventArgs e)
        {
            // Resend the verification code to the user.

            string jsonTestURL = "http://api.wapasaao.com/Demo/PhpCode/verificationSMS.php";
            StringBuilder postData = new StringBuilder();

            postData.Append((String.Format("number={0}", SharedPreferences.Instance.PhoneNumber)));
            postData.Append((String.Format("code={0}", SharedPreferences.Instance.VerificationCode)));

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = Encoding.UTF8.GetBytes(postData.ToString());

            HttpWebRequest request = WebRequest.Create(jsonTestURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            // done only for POST method.
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonString = reader.ReadToEnd();
            jsonString = jsonString.Trim();
        }
    }
}
