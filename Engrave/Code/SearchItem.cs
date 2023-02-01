using Engrave.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engrave.Code
{
    public class SearchItem
    {
        public int ItemLevelMin = 0;
        public int ItemLevelMax = 1700;
        public int ItemGradeQuality = 10;
        public List<SkillOption> SkillOptions = new List<SkillOption>();
        public List<EtcOption> EtcOptions = new List<EtcOption>();
        public string Sort = "BUY_PRICE";
        public int CategoryCode;
        public string CharacterClass;
        public int ItemTier = 3;
        public string ItemGrade = "유물";
        public int PageNo = 1;
        public string SortCondition = "ASC";

    }
}
