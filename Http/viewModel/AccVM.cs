using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class AccVM :ViewModelBase
    {
        #region Field
        private string _name;
        private int _quality;
        private string _name1;
        private int _value1;
        private string _name2;
        private int _value2;
        private string _penaltyName;
        private int _penaltyValue;
        private int _price;
        private string _firstcharaterics;
        private int _firstCharValue;
        private string _secondcharaterics;
        private int _secondCharValue;

        #endregion

        #region Property
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                OnPropertyChanged("Name");
            }
        }
        public int Quality
        {
            get { return _quality; }
            set
            {
                if (_quality != value)
                {
                    _quality = value;
                }
                OnPropertyChanged("Quality");
            }
        }
        public string Name1
        {
            get { return _name1; }
            set
            {
                if (_name1 != value)
                {
                    _name1 = value;
                }
                OnPropertyChanged("Name1");
            }
        }
        public int Value1
        {
            get { return _value1; }
            set
            {
                if (_value1 != value)
                {
                    _value1 = value;
                }
                OnPropertyChanged("Value1");
            }
        }
        public string Name2
        {
            get { return _name2; }
            set
            {
                if (_name2 != value)
                {
                    _name2 = value;
                }
                OnPropertyChanged("Name2");
            }
        }
        public int Value2
        {
            get { return _value2; }
            set
            {
                if (_value2 != value)
                {
                    _value2 = value;
                }
                OnPropertyChanged("Value2");
            }
        }
        public string PenaltyName
        {
            get { return _penaltyName; }
            set
            {
                if (_penaltyName != value)
                {
                    _penaltyName = value;
                }
                OnPropertyChanged("PenaltyName");
            }
        }
        public int PenaltyValue
        {
            get { return _penaltyValue; }
            set
            {
                if (_penaltyValue != value)
                {
                    _penaltyValue = value;
                }
                OnPropertyChanged("PenaltyValue");
            }
        }
        public int Price
        {
            get { return _price; }
            set
            {
                if(_price != value)
                {
                    _price = value;
                }
                OnPropertyChanged("Price");
            }
        }
        public string FirstCharaterics
        {
            get
            {
                return _firstcharaterics;
            }
            set
            {
                _firstcharaterics = value;
                OnPropertyChanged("FirstCharaterics");
            }
        }
        public string Secondcharaterics
        {
            get
            {
                return _secondcharaterics;
            }
            set
            {
                _secondcharaterics = value;
                OnPropertyChanged("Secondcharaterics");
            }
        }
        public int FirstCharValue
        {
            get
            {
                return _firstCharValue;
            }
            set
            {
                _firstCharValue= value;
                OnPropertyChanged("FirstCharValue");
            }
        }
        public int SecondCharValue
        {
            get
            {
                return _secondCharValue;
            }
            set
            {
                _secondCharValue = value;
                OnPropertyChanged("SecondCharValue");
            }
        }
        #endregion
    }
}
