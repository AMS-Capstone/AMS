using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code.SuppportClasses
{
    public class Vehicle
    {
        public Vehicle() 
        { 

        }

        public Vehicle(string pLotNumber, string pYear, string pMake, string pModel, string pVin, string pColor, int pMileage, string pUnits, string pTransmission, int pSellerID, string pOptions, string pProvince, bool pMileageNA, string pMileageNAReason)
        {
            lotNumber = pLotNumber;
            year = pYear;
            make = pMake;
            model = pModel;
            vin = pVin;
            color = pColor;
            mileage = pMileage;
            units = pUnits;
            transmission = pTransmission;
            sellerID = pSellerID;
            options = pOptions;

            province = pProvince;
            mileageNA = pMileageNA;
            mileageNAReason = pMileageNAReason;
        }

        private int sellerID;

        public int SellerID
        {
            get { return sellerID; }
            set { sellerID = value; }
        }
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private string lotNumber;

        public string LotNumber
        {
            get { return lotNumber; }
            set { lotNumber = value; }
        }
        private string year;

        public string Year
        {
            get { return year; }
            set { year = value; }
        }
        private string make;

        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        private string model;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        private string vin;

        public string Vin
        {
            get { return vin; }
            set { vin = value; }
        }
        private string color;

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        private int mileage;

        public int Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }
        private string units;

        public string Units
        {
            get { return units; }
            set { units = value; }
        }
        private string province;

        public string Province
        {
            get { return province; }
            set { province = value; }
        }
        private string transmission;

        public string Transmission
        {
            get { return transmission; }
            set { transmission = value; }
        }
        private string options;

        public string Options
        {
            get { return options; }
            set { options = value; }
        }

        private bool mileageNA;

        public bool MileageNA
        {
            get { return mileageNA; }
            set { mileageNA = value; }
        }
        private string mileageNAReason;

        public string MileageNAReason
        {
            get { return mileageNAReason; }
            set { mileageNAReason = value; }
        }

    }
}