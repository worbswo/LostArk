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
        public ObservableCollection<RaidVM> Raids = new ObservableCollection<RaidVM>();

        private CollectionViewSource RaidsCollectionViewSource { get; set; }
        public ICollectionView RaidsCollectionView
        {
            get { return RaidsCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("RaidsCollectionView");
            }
        }
        public ObservableCollection<RewaidRaidVM> RewaidRaids = new ObservableCollection<RewaidRaidVM>();

        private CollectionViewSource RewaidRaidsCollectionViewSource { get; set; }
        public ICollectionView RewaidRaidsCollectionView
        {
            get { return RewaidRaidsCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("RewaidRaidsCollectionView");
            }
        }
        public ChallangeVM()
        {
            AbyssDungeonsCollectionViewSource = new CollectionViewSource();
            AbyssDungeonsCollectionViewSource.Source = this.AbyssDungeons;
            RaidsCollectionViewSource = new CollectionViewSource();
            RaidsCollectionViewSource.Source = this.Raids;
            RewaidRaidsCollectionViewSource = new CollectionViewSource();
            RewaidRaidsCollectionViewSource.Source = this.RewaidRaids;
        }
    }
}
