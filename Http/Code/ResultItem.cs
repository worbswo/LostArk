using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.Code
{
    public class ResultItem
    {
        public Int32 PageNo;
        public Int32 PageSize;
        public Int64 TotalCount;
        public List<AuctionItem> Items=new List<AuctionItem>();

    }
    public class AuctionItem
    {
        public string Name;
        public string Grade;
        public Int32 Tier;
        public string Level; 
        public string Icon;
        public Int32 GradeQuality;
        public AuctionInfo AuctionInfo  = new AuctionInfo();
        public List<ItemOption> Options  = new List<ItemOption>();
    }
    public class AuctionInfo
    {
        public Int64 StartPrice;
        public Int64? BuyPrice;
        public Int64 BidPrice;
        public string EndDate;
        public Int32 BidCount;
        public Int64 BidStartPrice;
        public Boolean IsCompetitive;
        public Int32 TradeAllowCount;
    }
    public class ItemOption
    {
        public string Type;
        public string OptionName;
        public string OptionNameTripod;
        public Int32 Value;
        public Boolean IsPenalty;
        public string ClassName;
    }
}
