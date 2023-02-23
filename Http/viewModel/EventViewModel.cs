using LostArkAction.Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
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
        public NoticeInfoVM SelectedItem2 { get; set; } = new NoticeInfoVM();

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
        public ObservableCollection<NoticeInfoVM> NoticesList = new ObservableCollection<NoticeInfoVM>();

        private CollectionViewSource NoticesListCollectionViewSource { get; set; }
        public ICollectionView NoticesListCollectionView
        {
            get { return NoticesListCollectionViewSource.View; }
            set
            {
                OnPropertyChanged("NoticesListCollectionView");
            }
        }
        #endregion

        #region Constructor
        public EventViewModel()
        {

            EventsListCollectionViewSource = new CollectionViewSource();
            EventsListCollectionViewSource.Source = this.EventsList;
            NoticesListCollectionViewSource = new CollectionViewSource();
            NoticesListCollectionViewSource.Source = this.NoticesList;
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
            ListView listView = sender as ListView;
            if (listView.Name=="events")
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {

                    FileName = (listView.SelectedItem as EventInfoVM).EventLink,
                    UseShellExecute = true

                });
            }
            else
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {

                    FileName = (listView.SelectedItem as NoticeInfoVM).Link,
                    UseShellExecute = true

                });
            }
        }
        #endregion

    }
}
