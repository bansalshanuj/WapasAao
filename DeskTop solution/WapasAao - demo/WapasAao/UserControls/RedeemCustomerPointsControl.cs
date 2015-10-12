using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace WapasAao.UserControls
{
    public partial class RedeemCustomerPointsControl : UserControl
    {
        private Dictionary<string, string> responseDictionary = null;
        private BackgroundWorker backgroundWorker;

        public RedeemCustomerPointsControl()
        {
            InitializeComponent();
            SetUpControl();
            this.EnableDisableOtherControls(true);

            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string jsonString = e.Result as string;
            this.sendCreditsUserControl.loadingPictureBox.Visible = false;

            if (jsonString.Equals("success", StringComparison.OrdinalIgnoreCase) == false)
            {
                MessageBox.Show(this, "Could not register the credits. Please check ypur internet connection",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(this, "Credits successfully sent", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.None);

                this.sendCreditsUserControl.userNameTextBox.Clear();
                this.sendCreditsUserControl.Visible = false;
                
                this.EnableDisableOtherControls(true);

                this.responseDictionary.Clear();
                this.amountTextBox.Text = string.Empty;
                this.custMobileNumberTextBox.Text = string.Empty;
                this.redeemPointsCheckBox.Checked = true;
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            responseDictionary = e.Argument as Dictionary<string, string>;

            if (responseDictionary != null && responseDictionary.Count > 0)
            {
                /*
                // Get code start.
                string jsonTestURL = "http://wapasaao.com/GET1/PhpCode/transaction.php";
                StringBuilder postData = new StringBuilder();

                string userPhoneNumber = string.Empty;
                string creditAmount = string.Empty;
                string billingAmount = string.Empty;
                string isDebit = string.Empty;
                string debitAmount = string.Empty;

                responseDictionary.TryGetValue("userPhoneNumber",out userPhoneNumber);
                responseDictionary.TryGetValue("creditAmount", out creditAmount);
                responseDictionary.TryGetValue("billingAmount", out billingAmount);
                responseDictionary.TryGetValue("isDebit", out isDebit);
                responseDictionary.TryGetValue("debitAmount", out debitAmount);

                postData.Append((String.Format("userPhoneNumber={0}&", userPhoneNumber)));
                postData.Append((String.Format("salespersonId={0}&", SharedPreferences.Instance.SalesPersonId)));
                postData.Append((String.Format("vendorId={0}&", SharedPreferences.Instance.VendorId)));
                postData.Append((String.Format("creditAmount={0}&", creditAmount)));
                postData.Append((String.Format("billingAmount={0}&", billingAmount)));
                postData.Append((String.Format("isDebit={0}&", isDebit)));
                postData.Append((String.Format("debitAmount={0}", debitAmount)));

                ASCIIEncoding ascii = new ASCIIEncoding();
                byte[] postBytes = ascii.GetBytes(postData.ToString());

                jsonTestURL = jsonTestURL + "?" + postData;

                HttpWebRequest request = WebRequest.Create(jsonTestURL) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postBytes.Length;
      

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string jsonString = reader.ReadToEnd();
                jsonString = jsonString.Trim();
                // Get code ends.
                */

                // Post code starts.

                string jsonTestURL = URLConstants.PHP_DEMO_ENV + "/transaction.php";
                StringBuilder postData = new StringBuilder();

                string userPhoneNumber = string.Empty;
                string creditAmount = string.Empty;
                string billingAmount = string.Empty;
                string isDebit = string.Empty;
                string debitAmount = string.Empty;
                string userName = string.Empty;

                responseDictionary.TryGetValue("userPhoneNumber", out userPhoneNumber);
                responseDictionary.TryGetValue("creditAmount", out creditAmount);
                responseDictionary.TryGetValue("billingAmount", out billingAmount);
                responseDictionary.TryGetValue("isDebit", out isDebit);
                responseDictionary.TryGetValue("debitAmount", out debitAmount);
                responseDictionary.TryGetValue("username", out userName);

                postData.Append((String.Format("userPhoneNumber={0}&", userPhoneNumber)));
                postData.Append((String.Format("username={0}&", userName)));
                postData.Append((String.Format("salespersonId={0}&", SharedPreferences.Instance.SalesPersonId)));
                postData.Append((String.Format("vendorId={0}&", SharedPreferences.Instance.VendorId)));
                postData.Append((String.Format("creditAmount={0}&", creditAmount)));
                postData.Append((String.Format("billingAmount={0}&", billingAmount)));
                postData.Append((String.Format("isDebit={0}&", isDebit)));
                postData.Append((String.Format("debitAmount={0}", debitAmount)));

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

                // Post code ends.
                string jsonString = reader.ReadToEnd();
                jsonString = jsonString.Trim();

                e.Result = jsonString;
            }
        }

        private void SetUpControl()
        {
            this.sendCreditsUserControl.Visible = false;
            this.sendCreditsUserControl.sendCreditsButton.Click += sendCreditsButton_Click;
            this.mandatoryDetailsLabel.Visible = false;
            this.mandatoryDetailsLabel.Text = "Please enter the mandatory details";
        }

        private void sendCreditsButton_Click(object sender, EventArgs e)
        {
            if (this.sendCreditsUserControl.userNameTextBox.Visible)
            {
                if (responseDictionary.ContainsKey("username"))
                {
                    responseDictionary.Remove("username");
                    responseDictionary.Add("username", this.sendCreditsUserControl.userNameTextBox.Text);
                }
            }

            this.sendCreditsUserControl.loadingPictureBox.Visible = true;
            // this is to give the same background
            Bitmap behind = new Bitmap(this.sendCreditsUserControl.loadingPictureBox.Width, this.sendCreditsUserControl.loadingPictureBox.Height);
            this.sendCreditsUserControl.loadingPictureBox.DrawToBitmap(behind, this.sendCreditsUserControl.loadingPictureBox.Bounds);
            this.CreateGraphics().DrawImage(behind, -Left, -Top);

            backgroundWorker.RunWorkerAsync(responseDictionary);
        }

        private void EnableDisableOtherControls(bool enable)
        {
            this.amountLabel.Visible = enable;
            this.amountTextBox.Visible = enable;
            this.customerMobileNumberlabel.Visible = enable;
            this.custMobileNumberTextBox.Visible = enable;
            this.getTransactionsLabel.Visible = enable;
            this.getDetailsButton.Visible = enable;
        }

        private void getDetailsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(custMobileNumberTextBox.Text) || string.IsNullOrEmpty(this.amountTextBox.Text))
            {
                this.mandatoryDetailsLabel.Visible = true;
                return;
            }
            else
            {
                double amtResult;
                if (Double.TryParse(this.amountTextBox.Text, out amtResult) == false)
                {
                    this.mandatoryDetailsLabel.Text = "Please enter a valid billing amount.";
                    this.mandatoryDetailsLabel.Visible = true;
                    return;
                }

                this.mandatoryDetailsLabel.Visible = false;
            }
            string userPhoneNumber = this.custMobileNumberTextBox.Text;
            double transactionAmount = Double.Parse(this.amountTextBox.Text);
            bool isDebit = this.redeemPointsCheckBox.Checked;

            /*
            // Get code starts.
            string jsonTestURL = "http://wapasaao.com/GET1/PhpCode/getCustomerDetails.php";
            StringBuilder postData = new StringBuilder();
            postData.Append((String.Format("userPhoneNumber={0}&", userPhoneNumber)));
            postData.Append((String.Format("salespersonId={0}&", SharedPreferences.Instance.SalesPersonId)));
            postData.Append((String.Format("vendorId={0}", SharedPreferences.Instance.VendorId)));

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = ascii.GetBytes(postData.ToString());

            jsonTestURL = jsonTestURL + "?" + postData;

            HttpWebRequest request = WebRequest.Create(jsonTestURL) as HttpWebRequest;
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            request.Timeout = 10000;
  
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonString = reader.ReadToEnd();
            // Get code ends.
            */

            //Post code starts.

            string jsonTestURL = URLConstants.PHP_DEMO_ENV + "/getCustomerDetails.php";
            StringBuilder postData = new StringBuilder();
            postData.Append((String.Format("userPhoneNumber={0}&", userPhoneNumber)));
            postData.Append((String.Format("salespersonId={0}&", SharedPreferences.Instance.SalesPersonId)));
            postData.Append((String.Format("vendorId={0}", SharedPreferences.Instance.VendorId)));

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = Encoding.UTF8.GetBytes(postData.ToString());

            HttpWebRequest request = WebRequest.Create(jsonTestURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;
            request.Timeout = 10000;

            // done only for POST method.
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string jsonString = reader.ReadToEnd();

            // Post code ends.

            responseDictionary = JsonUtilities.JsonToDictionary(jsonString);
            if (responseDictionary != null && responseDictionary.Count > 0)
            {
                if (responseDictionary.ContainsKey("error".ToString()))
                {
                    this.sendCreditsUserControl.Visible = true;
                    this.EnableDisableOtherControls(false);
                    this.sendCreditsUserControl.loadingPictureBox.Visible = false;

                    string errorValue = string.Empty;
                    responseDictionary.TryGetValue("error", out errorValue);
                    if (string.IsNullOrEmpty(errorValue) == true || errorValue.Equals("USER_DOES_NOT_EXIST",StringComparison.OrdinalIgnoreCase))
                    {
                        string transactionCount = string.Empty;
                        string username = string.Empty;
                        string conversionFactorValue = string.Empty;
                        string discountValue = string.Empty;

                        responseDictionary.TryGetValue("transactionCount", out transactionCount);
                        responseDictionary.TryGetValue("username", out username);
                        responseDictionary.TryGetValue("conversionFactor", out conversionFactorValue);
                        responseDictionary.TryGetValue("points", out discountValue);

                        if (string.IsNullOrEmpty(conversionFactorValue) || conversionFactorValue.Equals("NULL",StringComparison.OrdinalIgnoreCase))
                        {
                            conversionFactorValue = "10";
                        }

                        double discount = Double.Parse(discountValue);
                        double conversionFactor = Double.Parse(conversionFactorValue);


                        if (string.IsNullOrEmpty(username) ||
                            username.Equals("null", StringComparison.OrdinalIgnoreCase))
                        {
                            username = "N.A.";
                            this.sendCreditsUserControl.userNameTextBox.Visible = true;
                            this.sendCreditsUserControl.nameLabel.Visible = false;
                        }
                        else
                        {
                            this.sendCreditsUserControl.userNameTextBox.Visible = false;
                            this.sendCreditsUserControl.nameLabel.Visible = true;
                        }

                        if (isDebit)
                        {
                            if (transactionAmount < discount)
                            {
                                discount = transactionAmount;
                            }
                        }
                        else
                        {
                            discount = 0.0;
                        }

                        double discountPercentage = discount/transactionAmount * 100;
                        string discountDisplayLabel = "(" + Math.Round(discountPercentage, 2) + "%)";
                        double creditsOffered = ((transactionAmount*conversionFactor)/100);
                        this.sendCreditsUserControl.nameLabel.Text = username;
                        this.sendCreditsUserControl.billingAmountLabel.Text = transactionAmount.ToString();
                        this.sendCreditsUserControl.creditsOfferedLabel.Text = creditsOffered.ToString();
                        this.sendCreditsUserControl.discountLabel.Text = discount.ToString() + " " +
                                                                         discountDisplayLabel;
                        this.sendCreditsUserControl.transactionCountLabel.Text = transactionCount;
                        this.sendCreditsUserControl.finalBillLabel.Text = (transactionAmount - discount).ToString();

                        responseDictionary.Add("billingAmount", transactionAmount.ToString());
                        responseDictionary.Add("creditAmount", creditsOffered.ToString());
                        responseDictionary.Add("userPhoneNumber", userPhoneNumber);
                        responseDictionary.Add("isDebit", isDebit.ToString().ToLowerInvariant());
                        responseDictionary.Add("debitAmount",discount.ToString());
                    }
                }
            }
        }

    }
}
