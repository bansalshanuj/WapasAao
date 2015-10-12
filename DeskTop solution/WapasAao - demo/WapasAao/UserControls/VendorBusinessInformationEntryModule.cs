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
    public partial class VendorBusinessInformationEntryModule : UserControl
    {
        public delegate void VendorBusineesInformationEnteredDelegate(object sender, EventArgs e);

        public event VendorBusineesInformationEnteredDelegate VendorBusineesInformationEnteredEvent;

        public VendorBusinessInformationEntryModule()
        {
            InitializeComponent();
            this.mandatoryDeatilsLabel.Visible = false;
            mandatoryDeatilsLabel.Text = "Please enter the mandatory details.";
        }

        private void submitInfoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.organizationAddressTextBox.Text) || string.IsNullOrEmpty(this.organizationNametextBox.Text) || string.IsNullOrEmpty(paybackPercentageTextBox.Text))
            {
             // the mandatory details have not been given.
                // show and error
                this.mandatoryDeatilsLabel.Visible = true;                
            }
            else
            {
                double result = 0;
                if (Double.TryParse(paybackPercentageTextBox.Text, out result) == false)
                {
                    mandatoryDeatilsLabel.Text = "Please enter a valid value for conversion factor.";
                    mandatoryDeatilsLabel.Visible = true;
                    return;
                }

               mandatoryDeatilsLabel.Visible = false;
            
            string address = this.organizationAddressTextBox.Text;
            string organizationName = this.organizationNametextBox.Text;
            string payBack = this.paybackPercentageTextBox.Text;
            string vendorPhoneNumber = SharedPreferences.Instance.PhoneNumber;
            string vendorName = SharedPreferences.Instance.SalespersonName;

            // string jsonMainURL = "http://api.wapasaao.com/Demo/PhpCode/addvendor.php";
            //string jsonTestURL = "http://192.168.1.5/wa/Server/PhpCode/addvendor.php";

            /*
             // GET Code start
             string jsonTestURL = "http://wapasaao.com/GET1/PhpCode/addvendor.php";
             StringBuilder postData = new StringBuilder();
            postData.Append((String.Format("vendorName={0}&", organizationName)));
            postData.Append((String.Format("address={0}&", address)));
            postData.Append((String.Format("salespersonName={0}&", vendorName)));
            postData.Append((String.Format("code={0}&", "-1")));
            postData.Append((String.Format("conversionFactor={0}&", payBack)));
            postData.Append((String.Format("phoneNumber={0}", vendorPhoneNumber)));

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
            // GET Code end
            */

            // POST code start
            string jsonTestURL = "http://api.wapasaao.com/Demo/PhpCode/addvendor.php";

            StringBuilder postData = new StringBuilder();
            postData.Append((String.Format("vendorName={0}&", organizationName)));
            postData.Append((String.Format("address={0}&", address)));
            postData.Append((String.Format("salespersonName={0}&", vendorName)));
            postData.Append((String.Format("code={0}&", "-1")));
            postData.Append((String.Format("conversionFactor={0}&", payBack)));
            postData.Append((String.Format("phoneNumber={0}", vendorPhoneNumber)));

            ASCIIEncoding ascii = new ASCIIEncoding();
            byte[] postBytes = Encoding.UTF8.GetBytes(postData.ToString());

            HttpWebRequest request = WebRequest.Create(jsonTestURL) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            // done only for POST method.
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                            "Server error (HTTP {0}: {1}).",
                            response.StatusCode,
                            response.StatusDescription));

                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string jsonString = reader.ReadToEnd();
                    List<string> valueList = new List<string>();

                    //Newtonsoft.Json.JsonSerializer sz = new JsonSerializer();
                    //TextReader txtReader = new StreamReader(response.GetResponseStream());
                    //JsonReader jreader = new JsonTextReader(txtReader);
                    //object obj = sz.Deserialize(jreader);
                    // Post code end

                    Dictionary<string, string> responseDictionary = JsonUtilities.JsonToDictionary(jsonString);
                    if (responseDictionary != null && responseDictionary.Count > 0)
                    {
                        if (responseDictionary.ContainsKey("error".ToString()))
                        {
                            string errorValue = string.Empty;
                            responseDictionary.TryGetValue("error", out errorValue);
                            if (string.IsNullOrEmpty(errorValue))
                            {
                                string salesPersonId = string.Empty;
                                string vendorId = string.Empty;
                                string vendorCode = string.Empty;

                                responseDictionary.TryGetValue("salespersonId", out salesPersonId);
                                responseDictionary.TryGetValue("vendorCode", out vendorCode);
                                responseDictionary.TryGetValue("vendorId", out vendorId);

                                SharedPreferences.Instance.SalesPersonId = salesPersonId;
                                SharedPreferences.Instance.VendorId = vendorId;
                                SharedPreferences.Instance.VendorCode = vendorCode;
                            }
                        }
                    }


                    SharedPreferences.Instance.VendorProgressStep = 4;

                    if (VendorBusineesInformationEnteredEvent != null)
                    {
                        VendorBusineesInformationEnteredEvent(sender, e);
                    }
                }
            }
        }
    }
}
