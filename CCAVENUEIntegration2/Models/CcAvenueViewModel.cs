using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCAVENUEIntegration2.Models
{
    public class CcAvenueViewModel
    {
        public string AccessCode;
        public string EncryptionRequest;
        public string CheckoutUrl;

        public CcAvenueViewModel(string v1, string v2, string v3)
        {
            this.AccessCode = v2;
            this.EncryptionRequest = v1;
            this.CheckoutUrl = v3;
        }

      
    }
}
