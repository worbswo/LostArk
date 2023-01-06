﻿using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Http.viewModel
{
    public class FIndAccWindowVM:ViewModelBase
    {
        #region Field
        #endregion
        #region Property
        public ObservableCollection<FindAccVM> FindAccVMs { get; set; } =new ObservableCollection<FindAccVM>();
        private CollectionViewSource AccCollectionViewSource { get; set; }
        public ICollectionView AccCollectionView
        {
            get { return AccCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("AccCollectionView");
            }
        }
        #endregion

        #region Constructor
        public FIndAccWindowVM(List<FindAccVM> findAccVMs)
        {
            findAccVMs = findAccVMs.OrderBy(x => x.TotalPrice).ToList();
            int size = 1000 > findAccVMs.Count ? findAccVMs.Count : 1000;
            FindAccVMs = new ObservableCollection<FindAccVM>(findAccVMs.GetRange(0, size));
            AccCollectionViewSource = new CollectionViewSource();
            AccCollectionViewSource.Source = this.FindAccVMs;
            //AccCollectionViewSource.View.SortDescriptions.Add(new SortDescription("TotalPrice", ListSortDirection.Ascending));
        }
        #endregion



        #region Method

        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
                base.Close();

            }
        }
        #endregion
    }
}
