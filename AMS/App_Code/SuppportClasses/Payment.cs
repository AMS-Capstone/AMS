using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class Payment
    {
        private int paymentID;

        public int PaymentID
        {
            get { return paymentID; }
            set { paymentID = value; }
        }
        private double paymentAmount;

        public double PaymentAmount
        {
            get { return paymentAmount; }
            set { paymentAmount = value; }
        }
        private int auctionSaleID;

        public int AuctionSaleID
        {
            get { return auctionSaleID; }
            set { auctionSaleID = value; }
        }
        private int paymentTypeID;

        public int PaymentTypeID
        {
            get { return paymentTypeID; }
            set { paymentTypeID = value; }
        }
        private double surcharges;

        public double Surcharges
        {
            get { return surcharges; }
            set { surcharges = value; }
        }
        private DateTime paymentDate;

        public DateTime PaymentDate
        {
            get { return paymentDate; }
            set { paymentDate = value; }
        }
    }
}