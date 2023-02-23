using LostArkAction.viewModel;
using LostArkAction.viewModel.Callange;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LostArkAction.ViewModel
{
    public class ChallangeVM :ViewModelBase
    {
        public ObservableCollection<AbyssDungeonVM> AbyssDungeons = new ObservableCollection<AbyssDungeonVM>();

        private CollectionViewSource AbyssDungeonsCollectionViewSource { get; set; }
        public ICollectionView AbyssDungeonsCollectionView
        {
            get { return AbyssDungeonsCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("AbyssDungeonsCollectionView");
            }
        }
        public ChallangeVM()
        {
            AbyssDungeonsCollectionViewSource = new CollectionViewSource();
            AbyssDungeonsCollectionViewSource.Source = this.AbyssDungeons;
        }
    }
}
