using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.Code.Items
{
    public class ChallengeAbyssDungeonItem
    {
        public string Name;
        public string Description;
        public int MinCharaterLevel;
        public int MinItemLevel;
        public string AreaName;
        public string StartTime;
        public string EndTime;
        public string Image;
        public List<RewardItem> RewardItems;
    }
}
