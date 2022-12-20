using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class EquipAblityVM : ViewModelBase
    {
        #region Field
        private List<string> _selectOption;
        private List<string> _selectItems=new List<string> { "", "", "", "", ""};
        private List<int> _figureItems  = new List<int> {0,0,0,0,0 };
        #endregion
        #region Property

        public List<string> SelectItems
        {
            get
            {
                return _selectItems;
            }
            set
            {
                _selectItems = value;
                NotifyPropertyChanged("SelectItems");
            }
        }
        public List<int> FigureItems
        {
            get
            {
                return _figureItems;
            }
            set
            {
                _figureItems = value;
                NotifyPropertyChanged("FigureItems");
            }
        }



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
