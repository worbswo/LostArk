using Http.Code.DataBase;
using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows;
using System.Security.Cryptography;
using LostArkAction;

namespace Http.viewModel
{
    public class APISetupVM :ViewModelBase
    {
        #region Field
        private RelayCommand _addApiKeyCommand;
        private RelayCommand _deleteApiKeyCommand;

        private string _apiKeystr;
        #endregion

        #region Property
        public int SelectedIndex { get; set; }
        private DataBase DataBase;
        public string ApiKeyStr
        {
            get
            {
                return _apiKeystr;
            }
            set
            {
                _apiKeystr = value;
                OnPropertyChanged("ApiKeyStr");
            }
        }
        private ObservableCollection<string> ApiKeys { get; set; }
        private CollectionViewSource ApiKeyViewSource { get; set; }
        public ICollectionView ApiKeyCollectionView
        {
            get { return ApiKeyViewSource.View; }
            set
            {
                OnPropertyChanged("ApiKeyCollectionView");
            }
        }
        #endregion

        #region Constructor
        public APISetupVM() { }
        public APISetupVM(DataBase dataBase)
        {
            DataBase=dataBase;
            ApiKeys = new ObservableCollection<string>(DataBase.getAPIKey());
            ApiKeyViewSource = new CollectionViewSource();
            ApiKeyViewSource.Source = this.ApiKeys;

        }
        #endregion

        #region Command
        public ICommand AddApiKeyCommand
        {
            get
            {
                if (_addApiKeyCommand == null)
                {
                    _addApiKeyCommand = new RelayCommand(AddAPIKey);
                }
                return _addApiKeyCommand;
            }
        }
        public ICommand DeleteApiKeyCommand
        {
            get
            {
                if (_deleteApiKeyCommand == null)
                {
                    _deleteApiKeyCommand = new RelayCommand(DeleteAPIKey);
                }
                return _deleteApiKeyCommand;
            }
        }

        #endregion

        #region Method
        public void AddAPIKey(object sender)
        {
            InputApiKey();        
        }
        public void DeleteAPIKey(object sender)
        {
            ApiKeys.RemoveAt(SelectedIndex);
        }
        public async void InputApiKey()
        {
            HttpClient SharedClient = new HttpClient();

            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", ApiKeyStr);
            SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using (HttpResponseMessage response = await SharedClient.GetAsync("https://developer-lostark.game.onstove.com/auctions/options"))
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("API KEY가 올바르지 않습니다.");
                    ApiKeyStr = "";
                    return;
                }
            }
            for(int i=0;i<ApiKeys.Count;i++)
            {
                if (ApiKeys[i].Equals(ApiKeyStr))
                {
                    MessageBox.Show("같은 API KEY가 있습니다.");
                    ApiKeyStr = "";
                    return;
                }
            }
            DataBase.AddAPIKey(ApiKeyStr);  
            ApiKeys.Add(ApiKeyStr);
            HttpClient2.APIkeys.Add(ApiKeyStr);
            ApiKeyStr = "";
        }
        public List<string> GetAPIKey()
        {
            return ApiKeys.ToList();
        }
        #endregion
        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
                base.Close();
            }
        }
    }
}
