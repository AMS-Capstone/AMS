using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code.SuppportClasses
{
    public class VehicleFee
    {
        public VehicleFee()
        {

        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int vehicleConditionRequirementID;

        public int VehicleConditionRequirementID
        {
            get { return vehicleConditionRequirementID; }
            set { vehicleConditionRequirementID = value; }
        }
        private int feeID;

        public int FeeID
        {
            get { return feeID; }
            set { feeID = value; }
        }
        private double vehicleFeeCost;

        public double VehicleFeeCost
        {
            get { return vehicleFeeCost; }
            set { vehicleFeeCost = value; }
        }
    }
}