using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Model
{
    public class Ablity
    {
        #region Field
        #endregion

        #region Property
        public Dictionary<string, int> TargetItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems { get; set; } = new Dictionary<string, int>();
        public List<SearchAblity> SearchAblities { get; set; }=new List<SearchAblity>();
        #endregion

        #region Method
        public void ComputeAblity()
        {

        }
        #endregion
    }
}
