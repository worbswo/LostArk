using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.viewModel
{
    public class EquipAblityVM : ViewModelBase
    {
        #region Field
        private List<string> _selectOption;

        #endregion
        #region Property



       

        public List<string> SelectOptions
        {
            get
            {
                if (_selectOption == null)
                {
                    _selectOption = new List<string>();

                }
                return _selectOption;
            }
            set
            {
                _selectOption = value;
                OnPropertyChanged("SelectOptions");
            }
        }

        #endregion

        #region Constroctor
        public EquipAblityVM()
        {


        }
        #endregion

        #region Method

        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
            }
        }
        #endregion
    }
}
