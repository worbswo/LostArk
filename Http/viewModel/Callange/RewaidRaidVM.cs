using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel.Callange
{
    public class RewaidRaidVM :ViewModelBase
    {
        public int _expeditionItemLevel;
        public List<RewardVM> Rewards { get; set; }

        public int ExpeditionItemLevel
        {
            get { return _expeditionItemLevel;}
            set
            {
                _expeditionItemLevel= value;
                OnPropertyChanged("ExpeditionItemLevel");
            }
        }

    }
}
