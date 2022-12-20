using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.Model
{
    public class SearchAblity
    {
        public Dictionary<string, int> FirstAblity { get; set; } = new Dictionary<string, int>();
        public Dictionary<string,int > SecondAblity { get; set; }=new Dictionary<string,int>();
        public Dictionary<string,int> PanaltyAblity { get; set; }=new Dictionary<string,int>();
        public int Price { get; set; }
        public SearchAblity()
        {
          
        }
        public SearchAblity(SearchAblity searchAblity)
        {
            foreach(var tmp in searchAblity.FirstAblity)
            {
                FirstAblity.Add(tmp.Key, tmp.Value);
            }
            foreach (var tmp in searchAblity.SecondAblity)
            {
                SecondAblity.Add(tmp.Key, tmp.Value);
            }
            foreach (var tmp in searchAblity.PanaltyAblity)
            {
                PanaltyAblity.Add(tmp.Key, tmp.Value);
            }
        }
    }
}
