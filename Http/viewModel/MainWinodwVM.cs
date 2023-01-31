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

using System.Threading;
using System.IO;
using System.Drawing;
using LostArkAction.Code.DataBase;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Net;
using System.Diagnostics;

namespace LostArkAction.viewModel
{
    public class MainWinodwVM : ViewModelBase
    {
        #region Field
        private ICommand _searchCommand;
        private ICommand _setupCommand;
        private ICommand _keyDownCommand;
        private ICommand _apiSetupOpenCommand;
        private ICommand _AddEngraveCommand;
        private ICommand _RemoveEngraveCommand;
        private ICommand _listClickCommand;
        private ICommand _updateEngraveCommand;
        private float _progressValue;
        private float _searchProgressValue;
        private float _accProgressValue;
        private float _waitAPIprogressValue;
        private string _searchProgressText;
        private string _waitAPIProgressText;

        private bool _isEnableSearchBtn = true;
        private bool isRelic  = true;
        private bool isAncient;
        private bool isAll;
        private string _setupAblityText="";
        private string _setEngraveNameText = "";
        private int _setEngraveIndex = -1;

        #endregion
        #region Property
        public string EquipStr = "";
        public string EquipStr2 = "";

        private APISetup APISetup = new APISetup();
        public DataBase DataBase = new DataBase(System.AppDomain.CurrentDomain.BaseDirectory + "EngaveDatabase.sqlite");
        private APISetupVM APISetupVM;
        public Dictionary<string, SetEngrave> SetEngraves = new Dictionary<string, SetEngrave>();
        public List<FindAccVM> FindAccVMs  = new List<FindAccVM>();
        public CharacteristicRangeVM CharacteristicRangeVM { get; set; } = new CharacteristicRangeVM();
        public TargetAblityVM TargetAblityVM { get; set; } = new TargetAblityVM();
        public EquipAblityVM EquipAblityVM { get; set; } = new EquipAblityVM();
        public AccessoriesVM AccessoriesVM { get; set; } = new AccessoriesVM();
        public Ablity Ablity { get; set; }
        public Thread ThreadSearch { get; set; }
        public bool LimitedCheck { get; set; } = false;

        public string SearchProgressText
        {
            get
            {
                return _searchProgressText;
            }
            set
            {
                _searchProgressText = value;
                OnPropertyChanged("SearchProgressText");
            }
        }
        public string WaitAPIProgressText
        {
            get
            {
                return _waitAPIProgressText;
            }
            set
            {
                _waitAPIProgressText = value;
                OnPropertyChanged("WaitAPIProgressText");
            }
        }
        
        public string SetEngraveNameText
        {
            get
            {
                return _setEngraveNameText;
            }
            set
            {
                _setEngraveNameText = value;
                OnPropertyChanged("SetEngraveNameText");
            }
        }
        public int SetEngraveIndex
        {
            get
            {
                return _setEngraveIndex;
            }
            set
            {
                _setEngraveIndex = value;
                OnPropertyChanged("SetEngraveIndex");
            }
        }
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
        public float WaitAPIprogressValue
        {
            get { return _waitAPIprogressValue; }
            set
            {
                _waitAPIprogressValue = value;
                OnPropertyChanged("WaitAPIprogressValue");
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

        private ObservableCollection<string> SetEngraveName { get; set; }
        private CollectionViewSource SetEngraveNameViewSource { get; set; }
        public ICollectionView SetEngraveNameCollectionView
        {
            get { return SetEngraveNameViewSource.View; }
            set
            {
                OnPropertyChanged("SetEngraveNameCollectionView");
            }
        }
        #endregion

        #region Command
        public ICommand KeyDownCommand
        {
            get
            {
                if (_keyDownCommand == null)
                {
                    _keyDownCommand = new RelayCommand(KeyDownMethod,null);
                }
                return _keyDownCommand;
            }
        }
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
        public ICommand APISetupOpenCommand
        {
            get
            {
                if (_apiSetupOpenCommand == null)
                {
                    _apiSetupOpenCommand = new RelayCommand(OpenAPISetup);
                }
                return _apiSetupOpenCommand;
            }
        }
        public ICommand RemoveEngraveCommand
        {
            get
            {
                if (_RemoveEngraveCommand == null)
                {
                    _RemoveEngraveCommand = new RelayCommand(RemoveEngraveMethod);
                }
                return _RemoveEngraveCommand;
            }
        }
        public ICommand AddEngraveCommand
        {
            get
            {
                if (_AddEngraveCommand == null)
                {
                    _AddEngraveCommand = new RelayCommand(AddEngraveMethod);
                }
                return _AddEngraveCommand;
            }
        }
        public ICommand ListClickCommand
        {
            get
            {
                if (_listClickCommand == null)
                {
                    _listClickCommand = new RelayCommand(ListClickMethod,null);
                }
                return _listClickCommand;
            }
        }
        public ICommand UpdateEngraveCommand
        {
            get
            {
                if (_updateEngraveCommand == null)
                {
                    _updateEngraveCommand = new RelayCommand(UpdateEngraveMethod);
                }
                return _updateEngraveCommand;
            }
        }
        #endregion

        #region Constroctor
        public MainWinodwVM()
        {
            TargetAblityVM = new TargetAblityVM();
            EquipAblityVM = new EquipAblityVM();
            AccessoriesVM = new AccessoriesVM();
            APISetupVM = new APISetupVM(DataBase);
            APISetup.DataContext = APISetupVM;
            APISetupVM.RequestClose += (o, e) => { APISetup.Close(); };
            APISetup.Closing += (o, e) =>
            {
                (e as CancelEventArgs).Cancel = true;
                APISetup.Hide();
            };
            APISetup.Hide();
            HttpClient2.APIkeys = APISetupVM.GetAPIKey();
            List<SetEngrave> setEngraves = DataBase.GetEngrave();
            SetEngraveName = new ObservableCollection<string>();
            for (int i = 0; i < setEngraves.Count; i++)
            {
                if (setEngraves[i].Name == DataBase.FinalStateStr)
                {
                    SetEngraves.Add(setEngraves[i].Name, setEngraves[i]);
                    continue;
                }
                SetEngraves.Add(setEngraves[i].Name, setEngraves[i]);
                SetEngraveName.Add(setEngraves[i].Name);
            }

            SetEngraveNameViewSource = new CollectionViewSource();
            SetEngraveNameViewSource.Source = this.SetEngraveName;
        }

  
        #endregion

        #region Method
        public void OpenAPISetup(object obj)
        {
            if (APISetup.Visibility == Visibility.Hidden)
            {
                APISetup.Show();
            }
        }
        public void KeyDownMethod(object obj, object args)
        {
            KeyEventArgs e = args as KeyEventArgs;
            if (e != null)
            {
                if (e.Key == Key.Enter)
                {
                    SetupMethod(obj);
                }
               
            }
        }
        public void SetupMethod(object sender)
        {
            if (SetupAblityText == "" || string.IsNullOrEmpty(SetupAblityText))
            {
                return;
            }
            string tmp = SetupAblityText;
            string[] strList = new string[7]{"","","","","","","" };
            int[] ablityVal = new int[7] {4,4,4,4,4,4,4 };
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
                }
                else
                {
                    TargetAblityVM.SelectItems[i] = null;
                    TargetAblityVM.SelectFigureItems[i] = (4 - ablityVal[i]);
                }
            }
            TargetAblityVM.SelectItems = TargetAblityVM.SelectItems;
            TargetAblityVM.SelectFigureItems = TargetAblityVM.SelectFigureItems;
            TargetAblityVM.SelectItem1 = TargetAblityVM.SelectItems[0];
            TargetAblityVM.SelectItem2 = TargetAblityVM.SelectItems[1];
            TargetAblityVM.SelectItem3 = TargetAblityVM.SelectItems[2];
            TargetAblityVM.SelectItem4 = TargetAblityVM.SelectItems[3];
            TargetAblityVM.SelectItem5 = TargetAblityVM.SelectItems[4];
            TargetAblityVM.SelectItem6 = TargetAblityVM.SelectItems[5];
            TargetAblityVM.SelectItem7 = TargetAblityVM.SelectItems[6];
        }
        public void SearchAcc()
        {
            if (HttpClient2.APIkeys == null || HttpClient2.APIkeys.Count == 0)
            {
                MessageBox.Show("API Key를 입력하세요!");
                return;
            }
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
                if (TargetAblityVM.SelectItems[i] == null)
                {
                    MessageBox.Show("올바른 각인을 입력하세요");
                    IsEnableSearchBtn = true;
                    return;
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
                Ablity.TargetItems.Add(TargetAblityVM.SelectItems[i], value);
            }
            if (ischeck)
            {
                ischeck = true;
                for (int i = 0; i < TargetAblityVM.SelectItems.Count; i++)
                {
                    if (TargetAblityVM.SelectItems[i] != "" && TargetAblityVM.SelectItems[i] != null)
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
                    if (AccessoriesVM.SelectCharacteriastics[0] == ""|| AccessoriesVM.SelectCharacteriastics[0]==null)
                    {
                        MessageBox.Show("목걸이의 첫번째 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[1] == "" || AccessoriesVM.SelectCharacteriastics[1] == null)
                    {
                        MessageBox.Show("목걸이의 두번째 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;

                    }
                    else if (AccessoriesVM.SelectCharacteriastics[2] == "" || AccessoriesVM.SelectCharacteriastics[2] == null)
                    {
                        MessageBox.Show("첫번째 귀걸이의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[3] == "" || AccessoriesVM.SelectCharacteriastics[3] == null)
                    {
                        MessageBox.Show("두번재 귀걸이의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[4] == "" || AccessoriesVM.SelectCharacteriastics[4] == null)
                    {
                        MessageBox.Show("첫번째 반지의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else if (AccessoriesVM.SelectCharacteriastics[5] == "" || AccessoriesVM.SelectCharacteriastics[5] == null)
                    {
                        MessageBox.Show("두번째 반지의 특성을 선택하세요.");
                        IsEnableSearchBtn = true;
                        return;
                    }
                    else
                    {
                        if (EquipAblityVM.SelectItems[0]== EquipAblityVM.SelectItems[1])
                        {
                            EquipStr = EquipAblityVM.SelectItems[0] + " : " + (EquipAblityVM.FigureItems[0] + EquipAblityVM.FigureItems[1]) + "\n";
                        }
                        else
                        {
                            EquipStr =  EquipAblityVM.SelectItems[0] + " : " + (EquipAblityVM.FigureItems[0]) + "\n";
                            EquipStr += EquipAblityVM.SelectItems[1] + " : " + (EquipAblityVM.FigureItems[1]) + "\n";
                        }
                        EquipStr2 =  EquipAblityVM.SelectItems[2] + " : " + (EquipAblityVM.FigureItems[2]) + "\n";
                        EquipStr2 +=  EquipAblityVM.SelectItems[3] + " : " + (EquipAblityVM.FigureItems[3]) + "\n";
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
                        if (EquipAblityVM.SelectItems[4] == null || EquipAblityVM.SelectItems[4] == "")
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
                        Ablity.MinimumValue.Add("치명", CharacteristicRangeVM.MinimumValue[0]);
                        Ablity.MinimumValue.Add("신속", CharacteristicRangeVM.MinimumValue[1]);
                        Ablity.MinimumValue.Add("특화", CharacteristicRangeVM.MinimumValue[2]);
                        Ablity.MinimumValue.Add("제압", CharacteristicRangeVM.MinimumValue[3]);
                        Ablity.MinimumValue.Add("인내", CharacteristicRangeVM.MinimumValue[4]);
                        Ablity.MinimumValue.Add("숙련", CharacteristicRangeVM.MinimumValue[5]);
                        Ablity.MaximumValue.Add("치명", CharacteristicRangeVM.MaximumValue[0]);
                        Ablity.MaximumValue.Add("신속", CharacteristicRangeVM.MaximumValue[1]);
                        Ablity.MaximumValue.Add("특화", CharacteristicRangeVM.MaximumValue[2]);
                        Ablity.MaximumValue.Add("제압", CharacteristicRangeVM.MaximumValue[3]);
                        Ablity.MaximumValue.Add("인내", CharacteristicRangeVM.MaximumValue[4]);
                        Ablity.MaximumValue.Add("숙련", CharacteristicRangeVM.MaximumValue[5]);
                        Ablity.SelectedAblity();
                    }
                }
            }
        }
        public void SearchMethod(object sender)
        {
            if (EquipAblityVM.SelectedTabIdx == 0)
            {
                SearchAcc();
            }
            else
            {

            }
        }
        public void AddEngraveMethod(object sender)
        {
            if (SetEngraveNameText == "")
            {
                MessageBox.Show("세팅 이름을 입력하세요");
                return;
            }
            for(int i = 0; i < SetEngraveName.Count; i++)
            {
                if (SetEngraveName[i]== SetEngraveNameText)
                {
                    SetEngraveNameText = "";
                    MessageBox.Show("같은 이름의 세팅이 있습니다.");
                    return;
                }
            }
           
            AddEngrave(SetEngraveNameText);
            SetEngraveNameText = "";
        }
        public void UpdateEngraveMethod(object sender)
        {
            if(SetEngraveIndex<0||SetEngraveName.Count==0) return;  

            AddEngrave(SetEngraveName[SetEngraveIndex],true);

        }
        public void RemoveEngraveMethod(object sender)
        {
            if (SetEngraveIndex == -1)
            {
                return;
            }
            DataBase.DeleteEngrave(SetEngraveName[SetEngraveIndex].GetHashCode());
            int idx = SetEngraveIndex;
            if (SetEngraveIndex == 0)
            {
                SetEngraveIndex = 0;

            }
            else
            {
                SetEngraveIndex = SetEngraveIndex - 1 < 0 ? 0 : SetEngraveIndex - 1;


            }
            try
            {
                SetEngraveName.RemoveAt(idx);
            }
            catch { }
        }
        public void AddEngrave(string Name,bool isUpdate=false)
        {
            
            SetEngrave setEngrave = new SetEngrave();
            string Target="";
            for (int i = 0; i < TargetAblityVM.SelectItems.Count; i++)
            {
                if (TargetAblityVM.SelectItems[i] == null|| TargetAblityVM.SelectItems[i] == "")
                {
                    Target+=("미사용-" + TargetAblityVM.SelectFigureItems[i].ToString());
                }
                else
                {
                    Target += (TargetAblityVM.SelectItems[i] + "-" + TargetAblityVM.SelectFigureItems[i].ToString());
                }
                if(i< TargetAblityVM.SelectItems.Count-1)
                {
                    Target += "_";
                }
            }
            string Equip = "";
            for (int i = 0; i < EquipAblityVM.SelectItems.Count; i++)
            {

                if (EquipAblityVM.SelectItems[i] == null || EquipAblityVM.SelectItems[i] == "")
                {
                    Equip += ("미사용-" + EquipAblityVM.FigureItems[i].ToString());
                }
                else 
                {
                    Equip += (EquipAblityVM.SelectItems[i] + "-" + EquipAblityVM.FigureItems[i].ToString());
                }
                if (i < EquipAblityVM.SelectItems.Count-1)
                {
                    Equip += "_";
                }
            }
            string Possesion = "";
            for (int i = 0; i < EquipAblityVM.SelectPossessionItems.Count; i++)
            {

                if (EquipAblityVM.SelectPossessionItems[i] == null || EquipAblityVM.SelectPossessionItems[i] == "")
                {
                    Possesion += ("미사용-" + EquipAblityVM.FigurePossessionItems[i].ToString());
                }
                else
                {
                    Possesion += (EquipAblityVM.SelectPossessionItems[i] + "-" + EquipAblityVM.FigurePossessionItems[i].ToString());
                }
                if (i < EquipAblityVM.SelectPossessionItems.Count - 1)
                {
                    Possesion += "_";
                }
            }
            string Acc = "";
            for(int i=0;i< AccessoriesVM.Qulity.Count; i++)
            {
                Acc += AccessoriesVM.Qulity[i];
                Acc += "_";
                
            }
            for (int i = 0; i < AccessoriesVM.SelectCharacteriastics.Count; i++)
            {
                if (AccessoriesVM.SelectCharacteriastics[i] == "")
                {
                    Acc += "없음";
                }
                else
                {
                    Acc += AccessoriesVM.SelectCharacteriastics[i];
                }
                if (i < AccessoriesVM.SelectCharacteriastics.Count - 1)
                {
                    Acc += "_";
                }
            }
            setEngrave.Name = Name; 
            setEngrave.Target = Target;
            setEngrave.Equip= Equip;
            setEngrave.Acc= Acc;
            setEngrave.Possession = Possesion;

            setEngrave.Key = Name.GetHashCode();
            if (isUpdate)
            {
                SetEngraves[Name] = setEngrave;
                DataBase.UpdateEngrave(setEngrave);
            }
            else
            {
                SetEngraveName.Add(Name);
                SetEngraves.Add(Name, setEngrave);
                DataBase.AddEngrave(setEngrave);
            }
        }
        public void SetEngraveText(bool isInit=false)
        {

            string Name = DataBase.FinalStateStr;
            if (!isInit)
            {
                Name = SetEngraveName[SetEngraveIndex];
            }

            List<string> Target = SetEngraves[Name].Target.Split('_').ToList();
            for (int i = 0; i < Target.Count; i++)
            {
                string[] sub = Target[i].Split('-');
                if (sub[0] != "미사용")
                {
                    TargetAblityVM.SelectItems[i] = sub[0];
                    TargetAblityVM.SelectFigureItems[i] = Convert.ToInt32(sub[1]);
                }
                else
                {
                    TargetAblityVM.SelectItems[i] = null;
                    TargetAblityVM.SelectFigureItems[i] = 0;
                }
            }
            TargetAblityVM.SelectItems = TargetAblityVM.SelectItems;
            TargetAblityVM.SelectFigureItems = TargetAblityVM.SelectFigureItems;
            TargetAblityVM.SelectItem1 = TargetAblityVM.SelectItems[0];
            TargetAblityVM.SelectItem2 = TargetAblityVM.SelectItems[1];
            TargetAblityVM.SelectItem3 = TargetAblityVM.SelectItems[2];
            TargetAblityVM.SelectItem4 = TargetAblityVM.SelectItems[3];
            TargetAblityVM.SelectItem5 = TargetAblityVM.SelectItems[4];
            TargetAblityVM.SelectItem6 = TargetAblityVM.SelectItems[5];
            TargetAblityVM.SelectItem7 = TargetAblityVM.SelectItems[6];
            List<string> Equip = SetEngraves[Name].Equip.Split('_').ToList();
            for (int i = 0; i < Equip.Count; i++)
            {
                string[] sub = Equip[i].Split('-');
                if (sub[0] != "미사용")
                {
                    EquipAblityVM.SelectItems[i] = sub[0];
                    EquipAblityVM.FigureItems[i] = Convert.ToInt32(sub[1]);
                }
                else
                {
                    EquipAblityVM.SelectItems[i] = null;
                    EquipAblityVM.FigureItems[i] = 0;
                }
            }
            EquipAblityVM.SelectItems = EquipAblityVM.SelectItems;
            EquipAblityVM.FigureItems = EquipAblityVM.FigureItems;
            List<string> Possesion = SetEngraves[Name].Possession.Split('_').ToList();
            for (int i = 0; i < Possesion.Count; i++)
            {
                string[] sub = Possesion[i].Split('-');
                if (sub[0] != "미사용")
                {
                    EquipAblityVM.SelectPossessionItems[i] = sub[0];
                    EquipAblityVM.FigurePossessionItems[i] = Convert.ToInt32(sub[1]);
                }
                else
                {
                    EquipAblityVM.SelectPossessionItems[i] = null;
                    EquipAblityVM.FigurePossessionItems[i] = 0;
                }
            }
            EquipAblityVM.SelectPossessionItems = EquipAblityVM.SelectPossessionItems;
            EquipAblityVM.FigurePossessionItems = EquipAblityVM.FigurePossessionItems;

            List<string> Acc = SetEngraves[Name].Acc.Split('_').ToList();

            for (int i = 0; i < Acc.Count; i++)
            {
                if (i < 5)
                {
                    AccessoriesVM.Qulity[i] = Convert.ToInt32(Acc[i]);
                }
                else
                {
                   AccessoriesVM.SelectCharacteriastics[i - 5] = Acc[i];  
                }
            }
            AccessoriesVM.Qulity1 = AccessoriesVM.Qulity[0];
            AccessoriesVM.Qulity2 = AccessoriesVM.Qulity[1];
            AccessoriesVM.Qulity3 = AccessoriesVM.Qulity[2];
            AccessoriesVM.Qulity4 = AccessoriesVM.Qulity[3];
            AccessoriesVM.Qulity5 = AccessoriesVM.Qulity[4];
            AccessoriesVM.SelectCharacteriastics = AccessoriesVM.SelectCharacteriastics;
        }
    
        public void ListClickMethod(object sender, object e)
        {
            SetEngraveText();
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
                    if (Ablity.Thread != null)
                    {
                        Ablity.Thread.Abort();
                        if (Ablity.Thread2 != null)
                        {
                            Ablity.Thread2.Abort();
                        }
                    }
                }
                if (APISetup != null)
                {
                    APISetup.Owner = App.Current.MainWindow;
                    AddEngrave(DataBase.FinalStateStr, true);
                }
            }
        }
        #endregion
    }
}
