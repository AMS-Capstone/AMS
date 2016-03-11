using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code.SuppportClasses
{
    public class Vehicle
    {
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private int lotNumber;
        public int LotNumber
        {
            get
            {
                return lotNumber;
            }

            set
            {
                lotNumber = value;
            }
        }

        private string year;
          public string Year { 
            get
            {
                return Year;
            }

    set
            {
                Year = value;
            }
        }
        private string make;
        public string Make
        {
            get
            {
                return Make;
            }

            set
            {
                Make = value;
            }
        }
        private string model;
        public string Model
        {
            get
            {
                return Model;
            }

            set
            {
                Model = value;
            }
        }

        private string vin;
        public string Vin
        {
            get
            {
                return Vin;
            }

            set
            {
                Vin = value;
            }
        }

        private string color;
        public string Color
        {
            get
            {
                return Color;
            }

            set
            {
                Color = value;
            }
        }

        private int mileage;
        public string Mileage
        {
            get
            {
                return Mileage;
            }

            set
            {
                Mileage = value;
            }
        }

        private string units;
        public string Units
        {
            get
            {
                return Units;
            }

            set
            {
                Units = value;
            }
        }

        private string province;
        public string Province
        {
            get
            {
                return Province;
            }

            set
            {
                Province = value;
            }
        }

        private string transmission;
        public string Transmission
        {
            get
            {
                return Transmission;
            }

            set
            {
                Transmission = value;
            }
        }

        private string vehicleOptions;
        public string VehicleOptions
        {
            get
            {
                return VehicleOptions;
            }

            set
            {
                VehicleOptions = value;
            }
        }
    }
}