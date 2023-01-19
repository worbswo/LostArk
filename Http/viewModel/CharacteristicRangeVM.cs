using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class CharacteristicRangeVM:ViewModelBase
    {
        
        public ObservableCollection<int> MinimumValue { get; set; } = new ObservableCollection<int>() { 0, 0, 0, 0, 0, 0 };
        public ObservableCollection<int> MaximumValue { get; set; } = new ObservableCollection<int>() { 1500, 1500, 1500, 1500, 1500,1500 };
        public ObservableCollection<int> isChecked { get; set; } = new ObservableCollection<int> { 0, 0, 0, 0, 0, 0 };
        public ObservableCollection<string> ColorTxt { get; set; } = new ObservableCollection<string> { "Gray", "Gray", "Gray", "Gray", "Gray", "Gray" };

    }
}
