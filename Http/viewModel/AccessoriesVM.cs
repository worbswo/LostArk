using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LostArkAction.viewModel
{
    public class AccessoriesVM : ViewModelBase
    {
        #region Field
        private ICommand _selecteChangeCommand;
        private List<string> _characteristics;
        private List<int> _qulity = new List<int> { 0, 0, 0, 0, 0 };
        private int _qulity1;
        private int _qulity2;
        private int _qulity3;
        private int _qulity4;
        private int _qulity5;
        private List<string> _selectCharacteriastics =new List<string>{"","","","","",""};
        private List<int> previusSelected = new List<int> { -1, -1, -1, -1  , -1, -1 };
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
            get { return _qulity3; }
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
            get { return _qulity4; }
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
            get { return _qulity5; }
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
                _selectCharacteriastics = value;
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
                        "치명","신속","특화","제압","인내","숙련"
                    };

                }
                return _characteristics;
            }
        }



        #endregion
        #region Command
        public ICommand SlecteChangeCommand
        {
            get
            {
                if (_selecteChangeCommand == null)
                {
                    _selecteChangeCommand = new RelayCommand(SelectedChangeMethod, null);
                }
                return _selecteChangeCommand;
            }
        }
        #endregion
        #region Constroctor
        public AccessoriesVM()
        {


        }
        #endregion

        #region Method
        public void SelectedChangeMethod(object sender, object e,object param)
        {
            int index = Convert.ToInt32(param as string);
            ComboBox comboBox = sender as ComboBox;
           

            if (previusSelected[index] != -1)
            {
                (App.Current.MainWindow.DataContext as MainWinodwVM).CharacteristicRangeVM.isChecked[previusSelected[index]]--;
                if((App.Current.MainWindow.DataContext as MainWinodwVM).CharacteristicRangeVM.isChecked[previusSelected[index]] == 0)
                {
                    (App.Current.MainWindow.DataContext as MainWinodwVM).CharacteristicRangeVM.ColorTxt[previusSelected[index]] = "Gray";

                }
            }
            if (comboBox.SelectedIndex != -1)
            {
                (App.Current.MainWindow.DataContext as MainWinodwVM).CharacteristicRangeVM.isChecked[comboBox.SelectedIndex]++;
                (App.Current.MainWindow.DataContext as MainWinodwVM).CharacteristicRangeVM.ColorTxt[comboBox.SelectedIndex] = "White";
            }
            
            previusSelected[index] = comboBox.SelectedIndex;
        }
        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
            }
        }
        #endregion
    }
}
