using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class Seller
    {
        private int sellerID;

        public int SellerID
        {
            get { return sellerID; }
            set { sellerID = value; }
        }
        private String sellerCode;

        public String SellerCode
        {
            get { return sellerCode; }
            set { sellerCode = value; }
        }
        private String sellerName;

        public String SellerName
        {
            get { return sellerName; }
            set { sellerName = value; }
        }
        private String sellerStreet;

        public String SellerStreet
        {
            get { return sellerStreet; }
            set { sellerStreet = value; }
        }
        private String sellerCity;

        public String SellerCity
        {
            get { return sellerCity; }
            set { sellerCity = value; }
        }
        private String sellerProvince;

        public String SellerProvince
        {
            get { return sellerProvince; }
            set { sellerProvince = value; }
        }
        private String sellerPostalCode;

        public String SellerPostalCode
        {
            get { return sellerPostalCode; }
            set { sellerPostalCode = value; }
        }
        private String sellerCountry;

        public String SellerCountry
        {
            get { return sellerCountry; }
            set { sellerCountry = value; }
        }
        private String sellerPhone;

        public String SellerPhone
        {
            get { return sellerPhone; }
            set { sellerPhone = value; }
        }
        private String sellerOtherPhone;

        public String SellerOtherPhone
        {
            get { return sellerOtherPhone; }
            set { sellerOtherPhone = value; }
        }
        private String sellerFax;

        public String SellerFax
        {
            get { return sellerFax; }
            set { sellerFax = value; }
        }
        private String contactFirstName;

        public String ContactFirstName
        {
            get { return contactFirstName; }
            set { contactFirstName = value; }
        }
        private String contactLastName;

        public String ContactLastName
        {
            get { return contactLastName; }
            set { contactLastName = value; }
        }
        private String conFile;

        public String ConFile
        {
            get { return conFile; }
            set { conFile = value; }
        }
        private String debtorFirstName;

        public String DebtorFirstName
        {
            get { return debtorFirstName; }
            set { debtorFirstName = value; }
        }
        private String debtorLastName;

        public String DebtorLastName
        {
            get { return debtorLastName; }
            set { debtorLastName = value; }
        }
        private bool sellerIsPrivate;

        public bool SellerIsPrivate
        {
            get { return sellerIsPrivate; }
            set { sellerIsPrivate = value; }
        }
        private String sellerGSTNumber;

        public String SellerGSTNumber
        {
            get { return sellerGSTNumber; }
            set { sellerGSTNumber = value; }
        }

        public Seller()
        {

        }
    }
}