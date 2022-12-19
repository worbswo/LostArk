using Http.Model;
using Http.View;
using Http.viewModel;
using LostArkAction.Code;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace LostArkAction.viewModel
{
    public class MainWinodwVM : ViewModelBase
    {

        #region Field
        private List<string> _characteristics;
        private ICommand _searchCommand;
        #endregion
        #region Property
        public TargetAblityVM TargetAblityVM { get; set; } = new TargetAblityVM();
        public EquipAblityVM EquipAblityVM { get; set; } = new EquipAblityVM();
        public AccessoriesVM AccessoriesVM { get; set; } = new AccessoriesVM();
        public Ablity TargetAblity { get; set; } = new Ablity();
        public Ablity EquipAblity { get; set; }=new Ablity();
        public Ablity PanaltyAblity { get; set; } = new Ablity();

        HttpClient2 HttpClient { get; set; }
        
        
        public List<string> Characteristics
        {
            get
            {
                if (_characteristics == null)
                {
                    _characteristics = new List<string>
                    {
                        "치명","특화","제압","신속","인내","숙련"
                    };

                }
                return _characteristics;
            }
        }



        #endregion

        #region Command
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(SearchMethod);
                }
                return _searchCommand;
            }
        }
        #endregion

        #region Constroctor
        public MainWinodwVM()
        {
            HttpClient = new HttpClient2();
           

        }
        #endregion

        #region Method
        public void SearchMethod(object sender)
        {
            TargetAblity.Items = new Dictionary<string, List<int>>();
            EquipAblity.Items = new Dictionary<string, List<int>>();
            for (int i = 0; i < TargetAblityVM.SelectItems.Count; i++)
            {
                int value = 0;
                if (TargetAblityVM.SelectFigureItems[i] == 1)
                {
                    value = 15;
                }
                else if (TargetAblityVM.SelectFigureItems[i] == 2)
                {
                    value = 10;
                }
                else if (TargetAblityVM.SelectFigureItems[i] == 3)
                {
                    value = 5;
                }
                else if (TargetAblityVM.SelectFigureItems[i] == 4)
                {
                    value = 3;
                }
                else if (TargetAblityVM.SelectFigureItems[i] == 0)
                {
                    continue;
                }
                if (TargetAblity.Items.ContainsKey(TargetAblityVM.SelectItems[i]))
                {
                    MessageBox.Show("같은 각인이 있습니다.");
                    break;
                }
                TargetAblity.Items.Add(TargetAblityVM.SelectItems[i], new List<int> { value });
            }
            for(int i = 0; i < EquipAblityVM.SelectItems.Count-1; i++)
            {
                if (EquipAblityVM.SelectItems[i] == null|| EquipAblityVM.SelectItems[i] == "")
                {
                    break;
                }
                if (EquipAblity.Items.ContainsKey(EquipAblityVM.SelectItems[i])){
                    EquipAblity.Items[EquipAblityVM.SelectItems[i]].Add (EquipAblityVM.FigureItems[i]);
                }
                else
                {
                    EquipAblity.Items.Add(EquipAblityVM.SelectItems[i], new List<int> { EquipAblityVM.FigureItems[i] });
                }
            }
            PanaltyAblity.Items.Add(EquipAblityVM.SelectItems[4], new List<int> { EquipAblityVM.FigureItems[4] });
        }
        
        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
            }
        }
        #endregion
    }
}
