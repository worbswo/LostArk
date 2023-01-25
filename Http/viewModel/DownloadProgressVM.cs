using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class DownloadProgressVM :ViewModelBase
    {
        #region Field
        private float _progressBar = 0;
        private string _data = "";
        #endregion

        #region Property
        public float ProgressBar
        {
            get
            {
                return _progressBar;
            }
            set
            {
                _progressBar = value;
                OnPropertyChanged("ProgressBar");
            }
        }
        public string Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged("Data");
            }
        }
        #endregion
    }
}
