using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class Buyer
    {
        private int buyerID;

        public int BuyerID
        {
            get { return buyerID; }
            set { buyerID = value; }
        }
        private int bidderNum;

        public int BidderNum
        {
            get { return bidderNum; }
            set { bidderNum = value; }
        }
        private String buyerFirstName;

        public String BuyerFirstName
        {
            get { return buyerFirstName; }
            set { buyerFirstName = value; }
        }
        private String buyerLastName;

        public String BuyerLastName
        {
            get { return buyerLastName; }
            set { buyerLastName = value; }
        }
        private String buyerStreet;

        public String BuyerStreet
        {
            get { return buyerStreet; }
            set { buyerStreet = value; }
        }
        private String buyerCity;

        public String BuyerCity
        {
            get { return buyerCity; }
            set { buyerCity = value; }
        }
        private String buyerProvince;

        public String BuyerProvince
        {
            get { return buyerProvince; }
            set { buyerProvince = value; }
        }
        private String buyerPostalCode;

        public String BuyerPostalCode
        {
            get { return buyerPostalCode; }
            set { buyerPostalCode = value; }
        }
        private String buyerCountry; // Needs to default to Canada

        public String BuyerCountry
        {
            get { return buyerCountry; }
            set { buyerCountry = value; }
        }
        private String buyerPhone;

        public String BuyerPhone
        {
            get { return buyerPhone; }
            set { buyerPhone = value; }
        }
        private bool buyerIsPermanent;

        public bool BuyerIsPermanent
        {
            get { return buyerIsPermanent; }
            set { buyerIsPermanent = value; }
        }
        private bool buyerIsBanned;

        public bool BuyerIsBanned
        {
            get { return buyerIsBanned; }
            set { buyerIsBanned = value; }
        }

        public Buyer()
        {

        }
    }
}