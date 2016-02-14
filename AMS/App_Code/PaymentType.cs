using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class PaymentType
    {
        private int paymentTypeID;
        private String paymentDescription;
        private bool paymentTypeStatus;

        public int PaymentTypeID
        {
            get { return paymentTypeID; }
            set { paymentTypeID = value; }
        }

        public String PaymentDescription
        {
            get { return paymentDescription; }
            set { paymentDescription = value; }
        }

        public bool PaymentTypeStatus
        {
            get { return paymentTypeStatus; }
            set { paymentTypeStatus = value; }
        }

        public PaymentType()
        {

        }
    }
}