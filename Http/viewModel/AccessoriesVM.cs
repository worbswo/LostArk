using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Http.viewModel
{
    public class AccessoriesVM : ViewModelBase
    {
        #region Field
        private List<string> _characteristics;
        private List<int> _qulity = new List<int> { 0, 0, 0, 0, 0 };
        private List<string> _selectCharacteriastics =new List<string>{"","","","","",""};
        #endregion
        #region Property

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
