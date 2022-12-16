using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public event EventHandler RequestClose;

        public event PropertyChangedEventHandler PropertyChanged;
        public void Close()
        {
            this.RequestClose?.Invoke(this, EventArgs.Empty);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected virtual void NotifyPropertyChanged(params string[] propertyName)
        {
            foreach (var prop in propertyName)
            {
                OnPropertyChanged(prop);
            }
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
