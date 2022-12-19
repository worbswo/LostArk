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
        private ICommand _searchCommand;
        #endregion
        #region Property
        public TargetAblityVM TargetAblityVM { get; set; } = new TargetAblityVM();
        public EquipAblityVM EquipAblityVM { get; set; } = new EquipAblityVM();
        public AccessoriesVM AccessoriesVM { get; set; } = new AccessoriesVM();
        public Ablity Ablity { get; set; } = new Ablity();
        public Accesories Accesories { get; set; } = new Accesories();

        HttpClient2 HttpClient { get; set; }
        
        
        



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
            Ablity.TargetItems = new Dictionary<string, int>();
            Ablity.EquipItems = new Dictionary<string, List<int>>();
            Ablity.PanaltyItems = new Dictionary<string, int>();
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
                if (Ablity.TargetItems.ContainsKey(TargetAblityVM.SelectItems[i]))
                {
                    MessageBox.Show("같은 각인이 있습니다.");
                    break;
                }
                Ablity.TargetItems.Add(TargetAblityVM.SelectItems[i], value );
            }
            for(int i = 0; i < EquipAblityVM.SelectItems.Count-1; i++)
            {
                if (EquipAblityVM.SelectItems[i] == null|| EquipAblityVM.SelectItems[i] == "")
                {
                    break;
                }
                if (Ablity.EquipItems.ContainsKey(EquipAblityVM.SelectItems[i])){
                    Ablity.EquipItems[EquipAblityVM.SelectItems[i]].Add (EquipAblityVM.FigureItems[i]);
                }
                else
                {
                    Ablity.EquipItems.Add(EquipAblityVM.SelectItems[i], new List<int> { EquipAblityVM.FigureItems[i] });
                }
            }
            Ablity.PanaltyItems.Add(EquipAblityVM.SelectItems[4],  EquipAblityVM.FigureItems[4]);

            Accesory accesory = new Accesory();
            Accesories["목걸이"].Qulity = AccessoriesVM.Qulity[0];
            Accesories["귀걸이1"].Qulity = AccessoriesVM.Qulity[1];
            Accesories["귀걸이2"].Qulity = AccessoriesVM.Qulity[2];
            Accesories["반지1"].Qulity = AccessoriesVM.Qulity[3];
            Accesories["반지2"].Qulity = AccessoriesVM.Qulity[4];
            Accesories["목걸이"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[0]);
            Accesories["목걸이"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[1]);
            Accesories["귀걸이1"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[2]);
            Accesories["귀걸이2"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[3]);
            Accesories["반지1"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[4]);
            Accesories["반지2"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[5]);
            Ablity.ComputeAblity();

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
