using LostArkAction.Code.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel.Callange
{
    public class AbyssDungeonVM:ViewModelBase
    {
        #region Field
        public string _name;
        public string _description;
        public int _minCharaterLevel;
        public int _minItemLevel;
        public string _areaName;
        public string _startTime;
        public string _endTime;
        public string _image;
        public List<RewardVM> _rewards = new List<RewardVM>();
        #endregion

        #region Propoerty
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public int MinCharaterLevel
        {
            get { return _minCharaterLevel; }
            set
            {
                _minCharaterLevel = value;
                OnPropertyChanged("MinCharaterLevel");
            }
        }
        public int MinItemLevel
        {
            get { return _minItemLevel; }
            set
            {
                _minItemLevel = value;
                OnPropertyChanged("MinItemLevel");
            }
        }
        public string AreaName
        {
            get { return _areaName; }
            set
            {
                _areaName = value;
                OnPropertyChanged("AreaName");
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
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged("Image");
            }
        }
        public List<RewardVM> Rewards
        {
            get { return _rewards; }
            set
            {
                _rewards = value;
                OnPropertyChanged("ReWards");
            }
        }
        #endregion
    }
}
