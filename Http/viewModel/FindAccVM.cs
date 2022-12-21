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
