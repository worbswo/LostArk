﻿using LostArkAction.Model;
using LostArkAction.View;
using LostArkAction.viewModel;
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
using Http.View;
using Http.viewModel;
using System.Threading;

namespace LostArkAction.viewModel
{
    public class MainWinodwVM : ViewModelBase
    {

        #region Field
        private ICommand _searchCommand;
        private float _progressValue;
        #endregion
        #region Property
        public List<FindAccVM> FindAccVMs { get; set; } = new List<FindAccVM>();
        public TargetAblityVM TargetAblityVM { get; set; } = new TargetAblityVM();
        public EquipAblityVM EquipAblityVM { get; set; } = new EquipAblityVM();
        public AccessoriesVM AccessoriesVM { get; set; } = new AccessoriesVM();
        public Ablity Ablity { get; set; }
        public Thread ThreadSearch { get; set; }
        HttpClient2 HttpClient { get; set; }
        public float ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                OnPropertyChanged("ProgressValue");
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

        }
        #endregion

        #region Method
        public void SearchMethod(object sender)
        {
            Ablity = new Ablity(this);

            Ablity.TargetItems = new Dictionary<string, int>();
            Ablity.EquipItems = new Dictionary<string, List<int>>();
            Ablity.PanaltyItems = new Dictionary<string, int>();
            bool ischeck = true;
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
                    ischeck = false;
                    return;
                }
                Ablity.TargetItems.Add(TargetAblityVM.SelectItems[i], value );
            }
            if (ischeck)
            {
                ischeck = true;
                for (int i = 0; i < TargetAblityVM.SelectItems.Count; i++)
                {
                    if (TargetAblityVM.SelectItems[i] != "")
                    {
                        if (TargetAblityVM.SelectFigureItems[i] == 0)
                        {
                            MessageBox.Show(TargetAblityVM.SelectItems[i] + "의 레벨을 선택하세요.");
                            ischeck = false;
                            return;
                        }
                    }
                }
                if (ischeck)
                {
                    if (AccessoriesVM.SelectCharacteriastics[0] == "")
                    {
                        MessageBox.Show("목걸이의 첫번째 특성을 선택하세요.");
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[1] == "")
                    {
                        MessageBox.Show("목걸이의 두번째 특성을 선택하세요.");
                        return;

                    }
                    else if (AccessoriesVM.SelectCharacteriastics[2] == "")
                    {
                        MessageBox.Show("첫번째 귀걸이의 특성을 선택하세요.");
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[3] == "")
                    {
                        MessageBox.Show("두번재 귀걸이의 특성을 선택하세요.");
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[4] == "")
                    {
                        MessageBox.Show("첫번째 반지의 특성을 선택하세요.");
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[5] == "")
                    {
                        MessageBox.Show("두번째 반지의 특성을 선택하세요.");
                        return;
                    }
                    else
                    {

                        for (int i = 0; i < EquipAblityVM.SelectItems.Count - 1; i++)
                        {

                            if (EquipAblityVM.SelectItems[i] == null || EquipAblityVM.SelectItems[i] == "")
                            {
                                break;
                            }
                            if (Ablity.EquipItems.ContainsKey(EquipAblityVM.SelectItems[i]))
                            {
                                Ablity.EquipItems[EquipAblityVM.SelectItems[i]].Add(EquipAblityVM.FigureItems[i]);
                            }
                            else
                            {
                                Ablity.EquipItems.Add(EquipAblityVM.SelectItems[i], new List<int> { EquipAblityVM.FigureItems[i] });
                            }

                        }
                        Ablity.PanaltyItems.Add(EquipAblityVM.SelectItems[4], EquipAblityVM.FigureItems[4]);

                        Ablity.Accesories = new Accesories();
                        Ablity.Accesories["목걸이"].Qulity = AccessoriesVM.Qulity[0];
                        Ablity.Accesories["귀걸이1"].Qulity = AccessoriesVM.Qulity[1];
                        Ablity.Accesories["귀걸이2"].Qulity = AccessoriesVM.Qulity[2];
                        Ablity.Accesories["반지1"].Qulity = AccessoriesVM.Qulity[3];
                        Ablity.Accesories["반지2"].Qulity = AccessoriesVM.Qulity[4];
                        Ablity.Accesories["목걸이"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[0]);
                        Ablity.Accesories["목걸이"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[1]);
                        Ablity.Accesories["귀걸이1"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[2]);
                        Ablity.Accesories["귀걸이2"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[3]);
                        Ablity.Accesories["반지1"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[4]);
                        Ablity.Accesories["반지2"].Characteristic.Add(AccessoriesVM.SelectCharacteriastics[5]);
                        Ablity.ComputeAblity();
                    }
                }
            }

        }
        public void OpenFindACC()
        {
            FindAccWindow findAccWindow= new FindAccWindow();
            
            findAccWindow.DataContext = new FIndAccWindowVM(FindAccVMs);
            (findAccWindow.DataContext as FIndAccWindowVM).RequestClose += (o, e) => { findAccWindow.Close(); };

            findAccWindow.Show();
        }
        internal void Close(bool isClosing = false)
        {
            if (!isClosing)
            {
                    Ablity.Thread.Abort();
                
            }
        }
        #endregion
    }
}
