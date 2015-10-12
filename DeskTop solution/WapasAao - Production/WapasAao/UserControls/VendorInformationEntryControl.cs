using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WapasAao.UserControls
{   
    public partial class VendorInformationEntryControl : UserControl
    {
        public delegate void CustomerInfoEneteredDelegate(object sender, EventArgs e);

        public event CustomerInfoEneteredDelegate CustomerInfoEneteredEvent;

        public delegate void VendorAlreadyRegisteredDelegate(object sender, EventArgs e);

        public event VendorAlreadyRegisteredDelegate VendorAlreadyRegisteredEvent;

        public VendorInformationEntryControl()
        {
            InitializeComponent();
            this.mandatoryDetailsLabel.Visible = false;
        }

        private bool CheckIftheVendorIsAlreadyRegistered()
        {
            string jsonTestURL = URLConstants.PHP_PROD_ENV + "/checkSalesPerson.php";
            StringBuilder postData = new StringBuilder();

            postData.Append((String.Format("phoneNumber={0}", vendorMobileNumberTextBox.Text)));

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

            // Here if the salesperson id exist, then the custoomer is already registered.
             Dictionary<string,string> responseDictionary = JsonUtilities.JsonToDictionary(jsonString);
             if (responseDictionary != null && responseDictionary.Count > 0)
             {
                 if (responseDictionary.ContainsKey("error".ToString()))
                 {
                     string error = string.Empty;
                     responseDictionary.TryGetValue("error",out error);
                     if(error.Equals("SALES_PERSON_DOES_NOT_EXISTS",StringComparison.OrdinalIgnoreCase))
                     {
                         // then we need to enter the details of the salesperson.
                         return false;
                     }
                     else
                     {
                         string salesPersonId = "";
                         string vendorId = "";
                         string vendorCode = "";

                         responseDictionary.TryGetValue("vendorId", out vendorId);
                         responseDictionary.TryGetValue("salespersonId", out salesPersonId);
                         responseDictionary.TryGetValue("vendorCode", out vendorCode);

                         SharedPreferences.Instance.SalesPersonId = salesPersonId;
                         SharedPreferences.Instance.VendorId = vendorId;
                         SharedPreferences.Instance.VendorCode = vendorCode;

                         return true;
                     }
                 }
             }

            return false;
        }
       
        private void signUpButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(vendorMobileNumberTextBox.Text) || string.IsNullOrEmpty(vendorNametextBox.Text))
            {
                this.mandatoryDetailsLabel.Visible = true;
            }
            else
            {
                this.mandatoryDetailsLabel.Visible = false;
                if (this.CheckIftheVendorIsAlreadyRegistered() == false)
                {
                    SharedPreferences.Instance.PhoneNumber = this.vendorMobileNumberTextBox.Text;
                    SharedPreferences.Instance.SalespersonName = vendorNametextBox.Text;

                    SharedPreferences.Instance.VendorProgressStep = 2;

                    if (CustomerInfoEneteredEvent != null)
                    {
                        CustomerInfoEneteredEvent(sender, e);
                    }
                }
                else
                {
                    SharedPreferences.Instance.VendorProgressStep = 4;

                    if (VendorAlreadyRegisteredEvent != null)
                    {
                        VendorAlreadyRegisteredEvent(sender, e);
                    }
                }
            }
        }
    }

    public class TestObject
    {
        public string vendorCode { get; set; }
        public string salespersonId { get; set; }
        public string vendorId { get; set; }
        public string error { get; set; }
        public string role { get; set; }
        // public string vendorName { get; set; }

    }
}
