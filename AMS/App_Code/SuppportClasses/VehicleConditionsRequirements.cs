using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code.SuppportClasses
{
    public class VehicleConditionsRequirements
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int vehicleID;

        public int VehicleID
        {
            get { return vehicleID; }
            set { vehicleID = value; }
        }
        private bool reserve;

        public bool Reserve
        {
            get { return reserve; }
            set { reserve = value; }
        }
        private bool record;

        public bool Record
        {
            get { return record; }
            set { record = value; }
        }
        private bool callOnHigh;

        public bool CallOnHigh
        {
            get { return callOnHigh; }
            set { callOnHigh = value; }
        }
        private String comments;

        public String Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        private Double estValue;

        public Double EstValue
        {
            get { return estValue; }
            set { estValue = value; }
        }
        private DateTime dateIn;

        public DateTime DateIn
        {
            get { return dateIn; }
            set { dateIn = value; }
        }
        private bool forSale;

        public bool ForSale
        {
            get { return forSale; }
            set { forSale = value; }
        }
    }
}