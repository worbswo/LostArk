using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel.Callange
{
    public class RewardVM :ViewModelBase
    {
        private string _name ="";
        private string _icon ="";
        private string _grade ="";
        private string _startTimes = "";


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                OnPropertyChanged("Icon");
            }
        }
        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
                OnPropertyChanged("Grade");
            }
        }
        public string StartTimes
        {
            get { return _startTimes; }
            set
            {
                _startTimes = value;
                OnPropertyChanged("StartTimes");
            }
        }
    }
}
