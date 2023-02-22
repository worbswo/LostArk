using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class EventInfoVM : ViewModelBase
    {
        private string _eventUrl;
        private string _eventLink;
        private string _startTime;
        private string _endTime;


        public string EventUrl
        {
            get { return _eventUrl; }
            set
            {
                _eventUrl = value;
                OnPropertyChanged("EventUrl");
            }
        }
        public string EventLink
        {
            get { return _eventLink; }
            set
            {
                _eventLink = value;
                OnPropertyChanged("EventLink");
            }
        }
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged("StartTime");
            }
        }
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged("EndTime");
            }
        }
    }
}
