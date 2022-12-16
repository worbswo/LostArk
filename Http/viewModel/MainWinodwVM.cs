using LostArkAction.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostArkAction.viewModel
{
    public class MainWinodwVM :ViewModelBase
    {

        HttpClient2 HttpClient { get; set; }
        public MainWinodwVM() {
            HttpClient = new HttpClient2();
        }
        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
            }
        }
    }
}
