using LostArkAction.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Code
{
    public class Item
    {
        public int ItemLevelMin = 0;
        public int ItemLevelMax = 1700;
        public int ItemGradeQuality = 10;
        public List<SkillOption> SkillOptions = new List<SkillOption>();
        public List<EtcOption> EtcOptions = new List<EtcOption>();
        public string Sort = "ITEM_GRADE";
        public int CategoryCode;
        public string CharacterClass;
        public int ItemTier = 3;
        public string ItemGrade = "고대";
        public int PageNo = 1;
        public string SortCondition = "ASC";

    }
}
