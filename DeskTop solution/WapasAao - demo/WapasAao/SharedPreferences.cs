using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json.Schema;

namespace WapasAao
{
    public class SharedPreferences
    {
        private static SharedPreferences _sharedPreference;
        private static string vendorId = string.Empty;
        private static string vendorCode = string.Empty;
        private static string phoneNumber = string.Empty;
        private static string salesPersonName = string.Empty;
        private static string salesPersonId = string.Empty;
        private static string verificationCode = string.Empty;
        private static int vendorProgressStep = 1;

        private SharedPreferences()
        {
            
        }

        public int VendorProgressStep
        {
            get { return vendorProgressStep; }
            set { vendorProgressStep = value; }
        }

        public string VerificationCode
        {
            get { return verificationCode; }
            set { verificationCode = value; }
        }

        public string SalespersonName
        {
            get { return salesPersonName; }
            set { salesPersonName = value; }
        }

        public string SalesPersonId
        {
            get { return salesPersonId; }
            set { salesPersonId = value; }
        }

        public string VendorId
        {
            get { return vendorId; }
            set { vendorId = value; }
        }

        public string VendorCode
        {
            get { return vendorCode; }
            set { vendorCode = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public static SharedPreferences Instance
        {
            get { return (_sharedPreference == null) ? new SharedPreferences() : _sharedPreference; }
        }
    }
}
