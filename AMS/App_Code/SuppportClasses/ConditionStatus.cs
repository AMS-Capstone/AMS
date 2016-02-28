using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class ConditionStatus
    {
        private int conditionID;
        private String conditionCode;
        private String conditionDescription;

        public int ConditionID
        {
            get { return conditionID; }
            set { conditionID = value; }
        }

        public String ConditionCode
        {
            get { return conditionCode; }
            set { conditionCode = value; }
        }

        public String ConditionDescription
        {
            get { return conditionDescription; }
            set { conditionDescription = value; }
        }

        public ConditionStatus()
        {

        }
    }
}