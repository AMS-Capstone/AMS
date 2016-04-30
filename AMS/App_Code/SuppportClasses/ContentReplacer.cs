using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AMS.App_Code.SuppportClasses
{
    public class ContentReplacer
    {
        public ContentReplacer() 
        { 

        }

        public string Replace(String doc, DataRow dr, Boolean extra = false, String auctionDate = "", String epicString = "", String logsheetString = "",
            Double totalSelling = 0.0, Double totalFees = 0.0, Double totalGST = 0.0, Double grossTotal = 0.0, Double monies = 0.0, Double netTotal = 0.0)
        {
            doc = doc.Replace("«LOT»", dr["LOT"].ToString());
            doc = doc.Replace("«CON_NAME»", dr["CON_NAME"].ToString());
            doc = doc.Replace("«CON_CONTACT»", dr["CON_CONTACT"].ToString());
            doc = doc.Replace("«CON_FAX»", dr["CON_FAX"].ToString());
            doc = doc.Replace("«DEBTOR_NAME»", dr["DEBTOR_NAME"].ToString());
            doc = doc.Replace("«CON_FILE»", dr["CON_FILE#"].ToString());
            doc = doc.Replace("«YEAR»", dr["YEAR"].ToString());
            doc = doc.Replace("«MAKE»", dr["MAKE"].ToString());
            doc = doc.Replace("«MODEL»", dr["MODEL"].ToString());
            doc = doc.Replace("«VIN»", dr["VIN"].ToString());
            doc = doc.Replace("«RESERVE»", dr["RESERVE"].ToString());

            doc = doc.Replace("«AUCTION_DATE»", auctionDate.ToString());

            doc = doc.Replace("«SELLING_PRICE»", cur(dr["SELLING_PRICE"]));
            if (extra) {
                doc = doc.Replace("«SALE_DATE»", DateTime.Now.ToShortDateString());
            }else{
                DateTime sDate = Convert.ToDateTime(dr["SALE_DATE"].ToString());
                doc = doc.Replace("«SALE_DATE»", sDate.ToString("MMMM dd, yyyy"));
            }

            doc = doc.Replace("«OUT_OF_PROV»", dr["STATUS"].ToString());
            doc = doc.Replace("«STATUS»", dr["STATUS"].ToString());
            doc = doc.Replace("«COLOR»", dr["COLOR"].ToString());
            doc = doc.Replace("«OPTIONS»", dr["OPTIONS"].ToString());
            doc = doc.Replace("«MILEAGE»", dr["MILEAGE"].ToString());
            doc = doc.Replace("«HOURS»", dr["HOURS"].ToString());
            doc = doc.Replace("«CON_STREET_CITY_PROV»", dr["CON_ADDRESS"].ToString() + " " + dr["CON_CITY"].ToString() + " " + dr["CON_PROVINCE"].ToString());
            doc = doc.Replace("«POSTAL»", dr["CON_POSTAL"].ToString());
            doc = doc.Replace("«CON_PHONE»", dr["CON_PHONE"].ToString());
            doc = doc.Replace("«CON_CODE»", dr["CON_CODE"].ToString());
            doc = doc.Replace("«BUYER_NAME»", dr["BUYER_NAME"].ToString());
            doc = doc.Replace("«BUYER_ADDRESS»", dr["BUYER_ADDRESS"].ToString());
            doc = doc.Replace("«BUYER_CITY»", dr["BUYER_CITY"].ToString());
            doc = doc.Replace("«BUYER_PROVINCE»", dr["BUYER_PROVINCE"].ToString());
            doc = doc.Replace("«BUYER_POSTAL»", dr["BUYER_POSTAL"].ToString());
            doc = doc.Replace("«BID_»", dr["BID_#"].ToString());
            doc = doc.Replace("«BUYER_PHONE»", dr["BUYER_PHONE"].ToString());
            doc = doc.Replace("«BUYERS_FEE»", cur(dr["BUYERS_FEE"]));
            doc = doc.Replace("«GST»", cur(dr["GST"]));
            doc = doc.Replace("«TOTAL»", cur(dr["TOTAL"]));
            doc = doc.Replace("«DEPOSIT»", cur(dr["DEPOSIT"]));
            doc = doc.Replace("«PAYMENT»", cur(dr["PAYMENT"]));
            doc = doc.Replace("«BALANCE»", cur(dr["BALANCE"]));

            doc = doc.Replace("«TOTAL_SALES»", cur(totalSelling));
            doc = doc.Replace("«BFEE_TOTAL»", cur(totalFees));
            doc = doc.Replace("«FULL_GST»", cur(totalGST));
            doc = doc.Replace("«GROSS»", cur(grossTotal));
            doc = doc.Replace("«MONIES»", cur(monies));
            doc = doc.Replace("«NET»", cur(netTotal));

            doc = doc.Replace("«CAR_DETAILS»", epicString);
            doc = doc.Replace("«LOGSHEET_TABLE»", logsheetString);

            return doc;
        }

        private String cur(Object item)
        {
            String str = "";
            Decimal dec = 0.00M;
            if (item.Equals(""))
            {
                str = dec.ToString("C");
            }
            else if(item.Equals(null))
            {
                dec = Convert.ToDecimal(item);
            }
            str = dec.ToString("C");
            return str;
        }
    }
}