using LostArkAction.Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace LostArkAction.viewModel
{
    
    public class EventViewModel:ViewModelBase
    {

        #region Field
        private ICommand _mouseClickCommand;

        #endregion

        #region Property
        public EventInfoVM SelectedItem { get; set; } = new EventInfoVM();
        public ObservableCollection<EventInfoVM> EventsList = new ObservableCollection<EventInfoVM>();

        private CollectionViewSource EventsListCollectionViewSource { get; set; }
        public ICollectionView EventsListCollectionView
        {
            get { return EventsListCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("EventsListCollectionView");
            }
        }
        #endregion

        #region Constructor
        public EventViewModel()
        {

            EventsListCollectionViewSource = new CollectionViewSource();
            EventsListCollectionViewSource.Source = this.EventsList;
        }
        #endregion

        #region Command
        public ICommand MouseClickCommand
        {
            get
            {
                if (_mouseClickCommand == null)
                {
                    _mouseClickCommand = new RelayCommand(MouseClickMethod, null);
                }
                return _mouseClickCommand;
            }
        }
        #endregion

        #region Method
        public void MouseClickMethod(object sender, object e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = SelectedItem.EventLink,
                UseShellExecute = true
            });
        }
        #endregion

    }
}
