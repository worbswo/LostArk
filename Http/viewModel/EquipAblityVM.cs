using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class EquipAblityVM : ViewModelBase
    {
        #region Field
        private ObservableCollection<string> _selectOption;

        private List<string> _selectOption2;
        
        private List<string> _selectItems=new List<string> { "", "", "", "", ""};
        private List<int> _figureItems  = new List<int> {0,0,0,0,0 };
        private List<string> _selectPossessionItems = new List<string> { "", "", "", "" };
        private List<int> _figurePossessionItems = new List<int> { 0, 0, 0, 0 };

        private int _selectedTabIdx = 0;
        #endregion
        #region Property
        public int SelectedTabIdx
        {
            get
            {
                return _selectedTabIdx;
            }
            set
            {
                _selectedTabIdx = value;
                OnPropertyChanged("SelectedTabIdx");
            }

        } 
        public List<string> SelectPossessionItems
        {
            get
            {
                return _selectPossessionItems;
            }
            set
            {
                _selectPossessionItems = value;
                NotifyPropertyChanged("SelectPossessionItems");
            }
        }
        public List<int> FigurePossessionItems
        {
            get
            {
                return _figurePossessionItems;
            }
            set
            {
                _figurePossessionItems = value;
                NotifyPropertyChanged("FigurePossessionItems");
            }
        }
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



        public ObservableCollection<string> SelectOptions
        {
            get
            {
                if (_selectOption == null)
                {
                    _selectOption = new ObservableCollection<string>();

                }
                return _selectOption;
            }
            set
            {
                _selectOption = value;
                NotifyPropertyChanged("SelectOptions");
            }
        }
        public List<string> SelectOptions2
        {
            get
            {
                if (_selectOption2 == null)
                {
                    _selectOption2 = new List<string>()
                    {
                        "공격력 감소",
                        "방어력 감소",
                        "이동속도 감소",
                        "공격속도 감소"
                    };

                }
                return _selectOption2;
            }
            set
            {
                _selectOption2 = value;
                OnPropertyChanged("SelectOptions2");
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
