﻿using System;
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

        public CcAvenueViewModel(string encryptionRequest, string accessCode, string checkoutUrl)
        {
            this.AccessCode = accessCode;
            this.EncryptionRequest = encryptionRequest;
            this.CheckoutUrl = checkoutUrl;
        }

      
    }
}
