using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class AuctionSale
    {
        private int auctionSaleID;

        public int AuctionSaleID
        {
            get { return auctionSaleID; }
            set { auctionSaleID = value; }
        }
        private int auctionID;

        public int AuctionID
        {
            get { return auctionID; }
            set { auctionID = value; }
        }
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private int buyerID;

        public int BuyerID
        {
            get { return buyerID; }
            set { buyerID = value; }
        }
        private int bidderNumber;

        public int BidderNumber
        {
            get { return bidderNumber; }
            set { bidderNumber = value; }
        }
        private double sellingPrice;

        public double SellingPrice
        {
            get { return sellingPrice; }
            set { sellingPrice = value; }
        }
        private double buyersFee;

        public double BuyersFee
        {
            get { return buyersFee; }
            set { buyersFee = value; }
        }
        private double deposit;

        public double Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        private int conditionID;

        public int ConditionID
        {
            get { return conditionID; }
            set { conditionID = value; }
        }
        private int gstID;

        public int GstID
        {
            get { return gstID; }
            set { gstID = value; }
        }
        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }
        private DateTime saleDate;

        public DateTime SaleDate
        {
            get { return saleDate; }
            set { saleDate = value; }
        }
        private String notes;

        public String Notes
        {
            get { return notes; }
            set { notes = value; }
        }
    }
}