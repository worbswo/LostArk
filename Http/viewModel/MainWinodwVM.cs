using LostArkAction.Model;
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
using System.IO;
using System.Drawing;

namespace LostArkAction.viewModel
{
    public class MainWinodwVM : ViewModelBase
    {

        #region Field
        private ICommand _searchCommand;
        private ICommand _setupCommand;

        private float _progressValue;
        private float _searchProgressValue;
        private float _accProgressValue;
        private bool _isEnableSearchBtn = true;
        private bool isRelic  = true;
        private bool isAncient;
        private bool isAll;
        private string _setupAblityText;
        #endregion
        #region Property
        public List<FindAccVM> FindAccVMs  = new List<FindAccVM>();

        public TargetAblityVM TargetAblityVM { get; set; } = new TargetAblityVM();
        public EquipAblityVM EquipAblityVM { get; set; } = new EquipAblityVM();
        public AccessoriesVM AccessoriesVM { get; set; } = new AccessoriesVM();
        public Ablity Ablity { get; set; }
        public Thread ThreadSearch { get; set; }
        public string SetupAblityText
        {
            get { return _setupAblityText; }
            set
            {
                _setupAblityText = value;
                OnPropertyChanged("SetupAblityText");
            }
        }
        public bool IsEnableSearchBtn
        {
            get
            {
                return _isEnableSearchBtn;
            }
            set
            {
                _isEnableSearchBtn = value;
                OnPropertyChanged("IsEnableSearchBtn");

            }
        }
        public float ProgressValue
        {
            get { return _progressValue; }
            set
            {
                _progressValue = value;
                OnPropertyChanged("ProgressValue");
            }
        }
        public float AccProgressValue
        {
            get { return _accProgressValue; }
            set
            {
                _accProgressValue = value;
                OnPropertyChanged("AccProgressValue");
            }
        }
        public float SearchProgressValue
        {
            get { return _searchProgressValue; }
            set
            {
                _searchProgressValue = value;
                OnPropertyChanged("SearchProgressValue");
            }
        }
        public bool IsRelic
        {
            get
            {
                return isRelic;
            }
            set
            {
                isRelic = value;
                if (isRelic)
                {
                    Ablity.selectClass = 0;
                }
            }
        }
        public bool IsAncient
        {
            get
            {
                return isAncient;
            }
            set
            {
                isAncient = value;
                if (isAncient)
                {
                    Ablity.selectClass = 1;
                }
            }
        }
        public bool IsAll
        {
            get
            {
                return isAll;
            }
            set
            {
                isAll = value;
                if (isAll)
                {
                    Ablity.selectClass = 2;
                }
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
        public ICommand SetupCommand
        {
            get
            {
                if (_setupCommand == null)
                {
                    _setupCommand = new RelayCommand(SetupMethod);
                }
                return _setupCommand;
            }
        }
        #endregion

        #region Constroctor
        public MainWinodwVM()
        {
            if (!File.Exists("API.txt"))
            {
                MessageBox.Show("API 파일이 존재하지 않습니다.");
                App.Current.Shutdown();
            }
            else
            {
                StreamReader SR = new StreamReader("API.txt");
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    HttpClient2.APIkeys.Add(line);
                }
                SR.Close();
                if (HttpClient2.APIkeys.Count == 0)
                {
                    MessageBox.Show("API 키가 존재하지 않습니다.");
                    App.Current.Shutdown();

                }
            }
        }
        #endregion

        #region Method
        public void SetupMethod(object sender)
        {
            string tmp = SetupAblityText;
            string[] strList = new string[7]{"","","","","","","" };
            int[] ablityVal = new int[7];
            int idx = 0;
            for (int i = 0; i < tmp.Length; i++)
            {
                
                char tmp2 = tmp[i];
                if (tmp2 >= '0' && tmp2 <= '9')
                {
                    ablityVal[idx]= Convert.ToInt32(tmp[i])-48;
                    idx++;

                }else if(tmp2==' ')
                {

                }
                else
                {
                    strList[idx] += tmp[i];
                }
            }
            for(int i = 0; i < 7; i++)
            {
                if (strList[i] != "")
                {
                    if (!Ablity.AblityShort.ContainsKey(strList[i]))
                    {
                        MessageBox.Show("["+ strList[i] + "] 에 해당 하는 각인이 없습니다. 다시 입력해 주세요!");
                        return;
                    }
                    if (ablityVal[i] > 3 || ablityVal[i] < 0)
                    {
                        MessageBox.Show("[" + strList[i] + "] 의 각인 수치를 벗어났습니다. 다시 입력해 주세요!");
                        return;
                    }
                }
                
            }
            for (int i = 0; i < 7; i++)
            {
                if ( strList[i] != "")
                {
                    TargetAblityVM.SelectItems[i] = Ablity.AblityShort[strList[i]];
                    TargetAblityVM.SelectFigureItems[i] =(4- ablityVal[i]);
                    Console.WriteLine(ablityVal[i]);
                }
            }
            TargetAblityVM.SelectItems = TargetAblityVM.SelectItems;
            TargetAblityVM.SelectFigureItems = TargetAblityVM.SelectFigureItems;
        }
        public void SearchMethod(object sender)
        {
            IsEnableSearchBtn = false;
            Ablity = new Ablity(this);
            FindAccVMs = new List<FindAccVM>();
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
                if (!Ablity.AblityCode.ContainsKey(TargetAblityVM.SelectItems[i]))
                {
                    MessageBox.Show("해당 각인이 없습니다.");
                    IsEnableSearchBtn = true;
                    return;
                }
                if (Ablity.TargetItems.ContainsKey(TargetAblityVM.SelectItems[i]))
                {
                    MessageBox.Show("같은 각인이 있습니다.");
                    IsEnableSearchBtn = true;
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
                    if (TargetAblityVM.SelectItems[i] != ""&& TargetAblityVM.SelectItems[i]!=null)
                    {
                        if (TargetAblityVM.SelectFigureItems[i] == 0)
                        {
                            MessageBox.Show(TargetAblityVM.SelectItems[i] + "의 레벨을 선택하세요.");
                            IsEnableSearchBtn = true;
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
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[1] == "")
                    {
                        MessageBox.Show("목걸이의 두번째 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;

                    }
                    else if (AccessoriesVM.SelectCharacteriastics[2] == "")
                    {
                        MessageBox.Show("첫번째 귀걸이의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[3] == "")
                    {
                        MessageBox.Show("두번재 귀걸이의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[4] == "")
                    {
                        MessageBox.Show("첫번째 반지의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[5] == "")
                    {
                        MessageBox.Show("두번째 반지의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
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
                        if(EquipAblityVM.SelectItems[4]==null|| EquipAblityVM.SelectItems[4] == "")
                        {
                            MessageBox.Show("페널티 감소 각인을 입력 하세요.");
                            IsEnableSearchBtn = true;
                            return;
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
                        Ablity.SelectedAblity();
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
                if (Ablity != null)
                {
                    if(Ablity.Thread!=null)
                    Ablity.Thread.Abort();
                    if(Ablity.Thread2 != null)
                    {
                        Ablity.Thread2.Abort();
                    }
                }
                
            }
        }
        #endregion
    }
}
