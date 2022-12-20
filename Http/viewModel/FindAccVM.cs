using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class FindAccVM:ViewModelBase
    {
        #region Field
        private string neckStr;
        private int nectValue;
        private string _firstRingStr;
        private string _secondRingStr;
        private int _firstRingValue;
        private int _secondRingValue;
        private string _firstEarStr;
        private string _secondEarStr;
        private int _firstEarValue;
        private int _secondEarValue;
        #endregion

        #region Property
        public string NeckStr
        {
            get
            {
                return neckStr;
            }
            set
            {
                neckStr = value;
                OnPropertyChanged("NeckStr");
            }
        }
        public int NectValue
        {
            get
            {
                return nectValue;
            }
            set
            {
                nectValue = value;
                OnPropertyChanged("NectValue");
            }
        }
        public string FirstRingStr
        {
            get
            {
                return _firstRingStr;
            }
            set
            {
                _firstRingStr = value;
                OnPropertyChanged("FirstRingStr");
            }
        }
        public int FirstRingValue
        {
            get
            {
                return _firstRingValue;
            }
            set
            {
                _firstRingValue = value;
                OnPropertyChanged("FirstRingValue");
            }
        }
        public string SecondRingStr
        {
            get
            {
                return _secondRingStr;
            }
            set
            {
                _secondRingStr = value;
                OnPropertyChanged("SecondRingStr");
            }
        }
        public int SecondRingValue
        {
            get
            {
                return _secondRingValue;
            }
            set
            {
                _secondRingValue = value;
                OnPropertyChanged("SecondRingValue");
            }
        }
        public string FirstEarStr
        {
            get
            {
                return _firstEarStr;
            }
            set
            {
                _firstEarStr = value;
                OnPropertyChanged("FirstEarStr");
            }
        }
        public int FirstEarValue
        {
            get
            {
                return _firstEarValue;
            }
            set
            {
                _firstEarValue = value;
                OnPropertyChanged("FirstEarValue");
            }
        }
        public string SecondEarStr
        {
            get
            {
                return _secondEarStr;
            }
            set
            {
                _secondEarStr = value;
                OnPropertyChanged("SecondEarStr");
            }
        }
        public int SecondEarValue
        {
            get
            {
                return _secondEarValue;
            }
            set
            {
                _secondEarValue = value;
                OnPropertyChanged("SecondEarValue");
            }
        }
        #endregion
    }
}
