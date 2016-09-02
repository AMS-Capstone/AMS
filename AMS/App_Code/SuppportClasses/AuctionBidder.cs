using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMS.App_Code
{
    public class AuctionBidder
    {
        private int auctionID;

        public int AuctionID
        {
            get { return auctionID; }
            set { auctionID = value; }
        }
        private int bidderNumber;

        public int BidderNumber
        {
            get { return bidderNumber; }
            set { bidderNumber = value; }
        }

        private int buyerID;

        public int BuyerID
        {
            get { return buyerID; }
            set { buyerID = value; }
        }
    }
}