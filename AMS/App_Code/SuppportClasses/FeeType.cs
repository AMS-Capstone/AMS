using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class FeeType
    {
        private int feeID;
        private double feeDefault;
        private String feeTypeName;

        public int FeeID
        {
            get { return feeID; }
            set { feeID = value; }
        }

        public double FeeDefault
        {
            get { return feeDefault; }
            set { feeDefault = value; }
        }

        public String FeeTypeName
        {
            get { return feeTypeName; }
            set { feeTypeName = value; }
        }

        public FeeType()
        {

        }
    }
}