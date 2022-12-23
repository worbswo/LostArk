using LostArkAction.Model;
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
        private int _totalPrice;
        private int _totalFirstChar;
        private int _totalSecondChar;
        private string _firstChar;
        private string _secondChar;
        #endregion

        #region Property
        public AccVM NeckAblity { get; set; } = new AccVM();
        public AccVM FirstRingAblity { get; set; } = new AccVM();
        public AccVM SecondRingAblity { get; set; } = new AccVM();
        public AccVM FirstEarAblity { get; set; } = new AccVM();
        public AccVM SecondEarAblity { get; set; } = new AccVM();
        public int TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                _totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        public int TotalFirstChar
        {
            get
            {
                return _totalFirstChar;
            }
            set
            {
                _totalFirstChar = value;
                OnPropertyChanged("TotalFirstChar");
            }
        }
        public int TotalSecondChar
        {
            get
            {
                return _totalSecondChar;
            }
            set
            {
                _totalSecondChar = value;
                OnPropertyChanged("TotalSecondChar");
            }
        }
        public string FirstChar
        {
            get
            {
                return _firstChar;
            }
            set
            {
                _firstChar = value;
                OnPropertyChanged("FirstChar");
            }
        }
        public string SecondChar
        {
            get
            {
                return _secondChar;
            }
            set
            {
                _secondChar = value;
                OnPropertyChanged("SecondChar");
            }
        }

        #endregion

        #region Constructor
        public FindAccVM()
        {

        }
        public FindAccVM(List<SearchAblity> searchAblities)
        {

        }
        #endregion
    }
}
