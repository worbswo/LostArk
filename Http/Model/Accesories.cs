using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.Model
{
    public class Accesories
    {
        #region Property
        public List<Accesory> Accesory { get; set; } = new List<Accesory>();
        public Accesory this[string index]
        {
            get
            {
                int idx = 0;
                for(int i = 0; i < Accesory.Count; i++)
                {
                    if (Accesory[i].Name == index)
                    {
                        idx = i;
                        break;
                    }
                }
                return Accesory[idx];
            }
            set
            {
                int idx = 0;
                for (int i = 0; i < Accesory.Count; i++)
                {
                    if (Accesory[i].Name == index)
                    {
                        idx = i;
                        break;
                    }
                }
                Accesory[idx] = value;
            }
        }
        public Accesories()
        {
            Accesory.Add(new Accesory() { Name="목걸이"});
            Accesory.Add(new Accesory() { Name = "귀걸이1" });
            Accesory.Add(new Accesory() { Name = "귀걸이2" });
            Accesory.Add(new Accesory() { Name = "반지1" });
            Accesory.Add(new Accesory() { Name = "반지2" });
        }
        #endregion
    }
}
