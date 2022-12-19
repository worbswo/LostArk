using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Model
{
    public class SearchAblity
    {
        public Dictionary<string, int> FirstAblity { get; set; } = new Dictionary<string, int>();
        public Dictionary<string,int > SecondAblity { get; set; }=new Dictionary<string,int>();
        public Dictionary<string,int> PanaltyAblity { get; set; }=new Dictionary<string,int>();
        public int Price { get; set; }
    }
}
