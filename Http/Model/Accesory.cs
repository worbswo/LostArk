using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.Model
{
    public class Accesory
    {
        #region Property
        public string Name { get; set; }
        public List<string> Characteristic { get; set; } = new List<string>();
        public int Qulity { get; set; } 
        #endregion
    }
}
