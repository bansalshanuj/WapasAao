using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WapasAao
{
    public partial class wapasAaoMainForm : Form
    {
        private string applicationPath = Path.Combine(Environment.SpecialFolder.ApplicationData.ToString(), @"WaapasAao\Common");

        public wapasAaoMainForm()
        {            
            InitializeComponent();
            this.RegisterEvents();
            this.Load += wapasAaoMainForm_Load;
            this.Closed += wapasAaoMainForm_Closed;
            this.Init();
        }

        void wapasAaoMainForm_Closed(object sender, EventArgs e)
        {
            // save the data into Xml file.
            this.CreateXmlFile();
        }

        void wapasAaoMainForm_Load(object sender, EventArgs e)
        {
            // On the application startup we have to check the current status of vendor.
            // i.e. which usercontrol has to be shown to the user.

            // check if the folder does not exist, create one.
           
            if (Directory.Exists(applicationPath) == false)
            {
                Directory.CreateDirectory(applicationPath);
                this.CreateXmlFile();

            }
            else
            {
                string filePath = Path.Combine(applicationPath, "SharedPreferences.xml");
                if (File.Exists(filePath))
                {
                    XDocument xdoc = XDocument.Load(filePath);
                    SharedPreferences.Instance.PhoneNumber = xdoc.Root.Element("PhoneNumber").Value;
                    SharedPreferences.Instance.VendorId = xdoc.Root.Element("VendorId").Value;
                    SharedPreferences.Instance.VendorCode = xdoc.Root.Element("VendorCode").Value;
                    SharedPreferences.Instance.SalesPersonId = xdoc.Root.Element("SalesPersonId").Value;
                    SharedPreferences.Instance.SalespersonName = xdoc.Root.Element("SalespersonName").Value;
                    SharedPreferences.Instance.VerificationCode = xdoc.Root.Element("VerificationCode").Value;
                    SharedPreferences.Instance.VendorProgressStep = Int32.Parse(xdoc.Root.Element("VendorProgressStep").Value);
                }
            }

            this.SetUpControl();
        }

        private void CreateXmlFile()
        {
            XElement phoneNumberXElement = new XElement("PhoneNumber", SharedPreferences.Instance.PhoneNumber);
            XElement vendorIdXElement = new XElement("VendorId", SharedPreferences.Instance.VendorId);
            XElement vendorCodeXElement = new XElement("VendorCode", SharedPreferences.Instance.VendorCode);
            XElement salesPersonIdXElement = new XElement("SalesPersonId", SharedPreferences.Instance.SalesPersonId);
            XElement salespersonNameXElement = new XElement("SalespersonName",
                SharedPreferences.Instance.SalespersonName);
            XElement verificationCodeXElement = new XElement("VerificationCode",
                SharedPreferences.Instance.VerificationCode);
            XElement vendorProgressStepXElement = new XElement("VendorProgressStep",
                SharedPreferences.Instance.VendorProgressStep);

           XElement rootElement=new XElement("Information");
           rootElement.Add(phoneNumberXElement, vendorIdXElement, vendorCodeXElement, salesPersonIdXElement, salespersonNameXElement, verificationCodeXElement, vendorProgressStepXElement);

            XDocument xdoc = new XDocument(rootElement);
            xdoc.Save(Path.Combine(applicationPath, "SharedPreferences.xml"));
        }

        public void RegisterEvents()
        {
            passwordVerificationControl.PasswordVerifiedEvent += passwordVerificationControl_PasswordVerifiedEvent;
            vendorBusinessInformationEntryModule.VendorBusineesInformationEnteredEvent += vendorBusinessInformationEntryModule_VendorBusineesInformationEnteredEvent;
            vendorInformationEntryControl.CustomerInfoEneteredEvent += vendorInformationEntryControl_CustomerInfoEneteredEvent;
            vendorInformationEntryControl.VendorAlreadyRegisteredEvent += vendorInformationEntryControl_VendorAlreadyRegisteredEvent;
        }

        void vendorInformationEntryControl_VendorAlreadyRegisteredEvent(object sender, EventArgs e)
        {
            this.CreateXmlFile();
            vendorInformationEntryControl.Visible = false;
            redeemCustomerPointsControl.Visible = true;
        }

        private void Init()
        {
            passwordVerificationControl.Visible = false;
            redeemCustomerPointsControl.Visible = false;
            susquentLoginUserNameEntryControl.Visible = false;
            vendorBusinessInformationEntryModule.Visible = false;
            vendorInformationEntryControl.Visible = true;
        }

        void vendorInformationEntryControl_CustomerInfoEneteredEvent(object sender, EventArgs e)
        {
            this.CreateXmlFile();
            // User i.e. the vendor has entered his/her personal details.
            vendorInformationEntryControl.Visible = false;
            passwordVerificationControl.Visible = true;
        }

        void vendorBusinessInformationEntryModule_VendorBusineesInformationEnteredEvent(object sender, EventArgs e)
        {
            this.CreateXmlFile();
            // Now the user has entered the business and organization details.
            vendorBusinessInformationEntryModule.Visible = false;
            redeemCustomerPointsControl.Visible = true;
        }

        void passwordVerificationControl_PasswordVerifiedEvent(object sender, EventArgs e)
        {
            this.CreateXmlFile();
            // Now the password has been verified.
            passwordVerificationControl.Visible = false;
            vendorBusinessInformationEntryModule.Visible = true;
        }

        public void SetUpControl()
        {
            passwordVerificationControl.Visible = false;
            redeemCustomerPointsControl.Visible = false;
            vendorBusinessInformationEntryModule.Visible = false;
            vendorInformationEntryControl.Visible = false;

            int applicationPreferenceStep = 1;
            if (string.IsNullOrEmpty(SharedPreferences.Instance.VendorProgressStep.ToString())==false)
            {
                applicationPreferenceStep = SharedPreferences.Instance.VendorProgressStep;
                if (applicationPreferenceStep < 1 || applicationPreferenceStep > 4)
                {
                    applicationPreferenceStep = 1;
                }
            }
            // read the preference stored somewhere.
            switch (applicationPreferenceStep)
            {
                case 1:
                    vendorInformationEntryControl.Visible = true;
                    break;
                case 2:
                    passwordVerificationControl.Visible = true;
                    break;
                case 3:
                    vendorBusinessInformationEntryModule.Visible = true;
                    break;
                case 4:
                    redeemCustomerPointsControl.Visible = true;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // test server call
            // http://wapasaao.com/WindowsApp/test.php

            /*
            var url = @"http://wapasaao.com/WindowsApp/test.php";
            var req = (HttpWebRequest)WebRequest.Create(url);
            var res = (HttpWebResponse)req.GetResponse();

            string testResult = res.ToString();
             */

            string url = "http://wapasaao.com/WindowsApp/test.php";
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            string urlText = reader.ReadToEnd();
        }

        private void susquentLoginUserNameEntryControl_Load(object sender, EventArgs e)
        {
            // We have to see if the vendor is already registered and the user name is valid or not.
        }
    }
}
