using LostArkAction.Code;
using LostArkAction.Model;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class AccessoriesVM : ViewModelBase
    {
        #region Field
        private List<string> _characteristics;
        private List<int> _qulity = new List<int> { 0, 0, 0, 0, 0 };
        private int _qulity1;
        private int _qulity2;
        private int _qulity3;
        private int _qulity4;
        private int _qulity5;
        private List<string> _selectCharacteriastics =new List<string>{"","","","","",""};
        #endregion
        #region Property
        public int Qulity1
        {
            get { return _qulity1; }
            set
            {
                _qulity1 = value;
                if (_qulity1 > 100)
                {
                    _qulity1 = 100;
                }
                Qulity[0] = _qulity1;

                NotifyPropertyChanged("Qulity1");
            }
        }
        public int Qulity2
        {
            get { return _qulity2; }
            set
            {
                _qulity2 = value;
                if (_qulity2 > 100)
                {
                    _qulity2 = 100;
                }
                Qulity[1] = _qulity2;

                NotifyPropertyChanged("Qulity2");
            }
        }
        public int Qulity3
        {
            get { return _qulity1; }
            set
            {
                _qulity3 = value;
                if (_qulity3 > 100)
                {
                    _qulity3 = 100;
                }
                Qulity[2] = _qulity3;

                NotifyPropertyChanged("Qulity3");
            }
        }
        public int Qulity4
        {
            get { return _qulity1; }
            set
            {
                _qulity4 = value;
                if (_qulity4 > 100)
                {
                    _qulity4 = 100;
                }
                Qulity[3] = _qulity4;

                NotifyPropertyChanged("Qulity4");
            }
        }
        public int Qulity5
        {
            get { return _qulity1; }
            set
            {
                _qulity5= value;
                if (_qulity5 > 100)
                {
                    _qulity5 = 100;
                }
                Qulity[4] = _qulity5;
                NotifyPropertyChanged("Qulity5");
            }
        }
        public List<int> Qulity
        {
            get { return _qulity; }
            set { 
                _qulity = value;
               
                NotifyPropertyChanged("Qulity"); 
            }
        }
        public List<string> SelectCharacteriastics
        {
            get { return _selectCharacteriastics; }
            set
            {
                _selectCharacteriastics = value; ;
                NotifyPropertyChanged("SelectCharacteriastics");
            }
        }
        public List<string> Characteristics
        {
            get
            {
                if (_characteristics == null)
                {
                    _characteristics = new List<string>
                    {
                        "치명","특화","제압","신속","인내","숙련"
                    };

                }
                return _characteristics;
            }
        }



        #endregion

        #region Constroctor
        public AccessoriesVM()
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
