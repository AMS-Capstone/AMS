using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class Auction
    {
        private int auctionID;

        public int AuctionID
        {
            get { return auctionID; }
            set { auctionID = value; }
        }
        private DateTime auctionDate;

        public DateTime AuctionDate
        {
            get { return auctionDate; }
            set { auctionDate = value; }
        }
        private double auctionTotal;

        public double AuctionTotal
        {
            get { return auctionTotal; }
            set { auctionTotal = value; }
        }
        private double surCharges;

        public double Surcharges
        {
            get { return surCharges; }
            set { surCharges = value; }
        }
        private double cashCharges;

        public double CashCharges
        {
            get { return cashCharges; }
            set { cashCharges = value; }
        }
        private double chequeCharges;

        public double ChequeCharges
        {
            get { return chequeCharges; }
            set { chequeCharges = value; }
        }

        private double creditCardCharges;

        public double CreditCardCharges
        {
            get { return creditCardCharges; }
            set { creditCardCharges = value; }
        }

        public Auction()
        {

        }
    }
}