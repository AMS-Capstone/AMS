using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class GST
    {
        private int gstID;
        private int gstPercent;
        private bool gstStatus;

        public int GSTID
        {
            get { return gstID; }
            set { gstID = value; }
        }

        public int GSTPercent
        {
            get { return gstPercent; }
            set { gstPercent = value; }
        }

        public bool GSTStatus
        {
            get { return gstStatus; }
            set { gstStatus = value; }
        }

        public GST() 
        {

        }
    }
}