using LostArkAction.Model;
using LostArkAction;
using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Windows.Media.Animation;

namespace LostArkAction.viewModel
{
    public class TargetAblityVM : ViewModelBase
    {

        #region Field
        private ObservableCollection<string> _options1;
        private ObservableCollection<string> _options2;
        private ObservableCollection<string> _options3;
        private ObservableCollection<string> _options4;
        private ObservableCollection<string> _options5;
        private ObservableCollection<string> _options6;
        private ObservableCollection<string> _options7;

        private string[] _figure;
        private RelayCommand _mouseDownCommand;
        private RelayCommand _keyBoardDownCommand;
        private ObservableCollection<string> _optionsList = new ObservableCollection<string>();
        private List<string> _selectItems = new List<string>() { "", "", "", "", "", "", "", };
        public Dictionary<int, string> optionIndex { get; set; } = new Dictionary<int, string>();

        private List<int> _selectFigureItems = new List<int>() { 0, 0 ,0, 0, 0, 0, 0 };

        #endregion
        #region Property
        public List<int> SelectFigureItems
        {
            get
            {
                return _selectFigureItems;
            }
            set {
                _selectFigureItems = value;
                NotifyPropertyChanged(nameof(SelectFigureItems));
            }
        }
        public List<string> SelectItems
        {
            get
            {
                return _selectItems;
            }
            set
            {
                _selectItems = value;
                for (int i = 0; i < 7; i++)
                {
                    if (optionIndex.ContainsKey(i))
                    {
                        if (_selectItems[i] == "")
                        {
                            optionIndex.Remove(i);
                        }
                        else
                        {
                            optionIndex[i] = _selectItems[i];
                        }
                    }
                    else
                    {
                        if (_selectItems[i] != "")
                        {
                            optionIndex.Add(i, _selectItems[i]);
                        }
                    }
                }
                _optionsList = new ObservableCollection<string>();
                foreach(var item in optionIndex)
                {

                        _optionsList.Add(item.Value);
                    
                }
                 (App.Current.MainWindow.DataContext as MainWinodwVM).EquipAblityVM.SelectOptions = _optionsList;

                NotifyPropertyChanged("SelectItems");
            }
        }

        public string SelectItem1
        {
            get
            {
                return SelectItems[0];
            }
            set
            {
                SelectItems[0] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem1");

            }
        }
        public string SelectItem2
        {
            get
            {
                return SelectItems[1];
            }
            set
            {
                SelectItems[1] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem2");

            }
        }
        public string SelectItem3
        {
            get
            {
                return SelectItems[2];
            }
            set
            {
                SelectItems[2] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem3");

            }
        }

        public string SelectItem4
        {
            get
            {
                return SelectItems[3];
            }
            set
            {
                SelectItems[3] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem4");

            }
        }
        public string SelectItem5
        {
            get
            {
                return SelectItems[4];
            }
            set
            {
                SelectItems[4] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem5");

            }
        }
        public string SelectItem6
        {
            get
            {
                return SelectItems[5];
            }
            set
            {
                SelectItems[5] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem6");

            }
        }
        public string SelectItem7
        {
            get
            {
                return SelectItems[6];
            }
            set
            {
                SelectItems[6] = value;
                SelectItems = SelectItems;
                NotifyPropertyChanged("SelectItem7");

            }
        }

        
        public ObservableCollection<string> Options1
        {
            get
            {
                if (_options1 == null)
                {
                    _options1= new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options1;
            }
        }
        public ObservableCollection<string> Options2
        {
            get
            {
                if (_options2 == null)
                {
                    _options2 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options2;
            }
        }
        public ObservableCollection<string> Options3
        {
            get
            {
                if (_options3 == null)
                {
                    _options3 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options3;
            }
        }
        public ObservableCollection<string> Options4
        {
            get
            {
                if (_options4 == null)
                {
                    _options4 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options4;
            }
        }
        public ObservableCollection<string> Options5
        {
            get
            {
                if (_options5 == null)
                {
                    _options5 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options5;
            }
        }
        public ObservableCollection<string> Options6
        {
            get
            {
                if (_options6 == null)
                {
                    _options6 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options6;
            }
        }
        public ObservableCollection<string> Options7
        {
            get
            {
                if (_options7 == null)
                {
                    _options7 = new ObservableCollection<string>
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options7;
            }
        }
        public string[] Figure
        {
            get
            {
                if (_figure == null)
                {
                    _figure = new string[]
                    {
                        "미사용","+15(3레벨)","+10(2레벨)","+5(1레벨)","+3"
                    };

                }
                return _figure;
            }
        }

        #endregion

        #region Constroctor
        public TargetAblityVM()
        {

        }
        #endregion

        #region Command
        public ICommand MouseDownCommand
        {
            get
            {
                if (_mouseDownCommand == null)
                {
                    _mouseDownCommand = new RelayCommand(ClickMethod, null);
                }
                return _mouseDownCommand;
            }
        }
        public ICommand KeyBoardDownCommand
        {
            get
            {
                if (_keyBoardDownCommand == null)
                {
                    _keyBoardDownCommand = new RelayCommand(KeyDownMethod, null);
                }
                return _keyBoardDownCommand;
            }
        }
        #endregion
        #region Method
        public void ClickMethod(object sender, object e,object param)
        {
            ComboBox comboBox = (ComboBox)param;

            
        }
        public void KeyDownMethod(object sender, object e)
        {
            ComboBox comboBox = (ComboBox)sender;
            KeyEventArgs arg = e as KeyEventArgs;
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(comboBox.ItemsSource);
            TextBox txt = comboBox.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
            string tmp = txt.Text;
            if ((arg.Key == Key.Enter) || (arg.Key == Key.Tab) || (arg.Key == Key.Return)||(arg.Key==Key.Up) || (arg.Key == Key.Down) || (arg.Key == Key.Left) || (arg.Key == Key.Right))

            {
                return;
            }
            else if (arg.Key == Key.Back)
            {
                comboBox.SelectedIndex = -1;
                comboBox.Items.Filter = null;
            }
            else
            {
                if (txt.Text != "")
                {
                    comboBox.IsDropDownOpen = true;

                    comboBox.Items.Filter = ((o) =>
                    {
                        string sValue = string.Empty;
                        if(o is string)
                        {
                            sValue = o.ToString();
                        }else if(o is ComboBoxItem)
                        {
                            System.Reflection.PropertyInfo info = o.GetType().GetProperty(comboBox.DisplayMemberPath);
                            if (info != null)
                            {
                                object oValue = info.GetValue(o, null);
                                if (oValue != null)
                                {
                                    sValue = oValue.ToString();
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(sValue) && sValue.Contains(txt.Text)) return true;
                        else return false;
                    });
                }
            }
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
