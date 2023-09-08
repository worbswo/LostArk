using LostArkAction.Code;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace LostArkAction.viewModel
{
    public class EquipAccVM :ViewModelBase
    {
        private ObservableCollection<string> _options1;
        private ObservableCollection<string> _options2;
        private ObservableCollection<string> _options3;
        private ObservableCollection<string> _options4;
        private ObservableCollection<string> _options5;
        private ObservableCollection<string> _options6;
        private ObservableCollection<string> _options7;
        private ObservableCollection<string> _options8;
        private ObservableCollection<string> _options9;
        private ObservableCollection<string> _options10;

        private ObservableCollection<string> _selectOption;
        public List<bool> isUsed = new List<bool>() { false, false, false, false, false, };

        private List<string> _selectOption2;

        private List<int> _figureItems = new List<int> { 0, 0, 0, 0, 0 };

        private RelayCommand _keyBoardDownCommand;
        private ObservableCollection<string> _optionsList = new ObservableCollection<string>();
        private ObservableCollection<string> _optionsPosList = new ObservableCollection<string>();
        public List<AccVM> AccVM { get; set;  } = new List<AccVM>() {new AccVM(), new AccVM(), new AccVM(), new AccVM(), new AccVM() };
        public Dictionary<int, string> optionIndex { get; set; } = new Dictionary<int, string>();


        public List<bool> IsUsed
        {
            get
            {
                return isUsed;
            }
            set
            {
                isUsed = value;
                OnPropertyChanged("IsUsed");
            }
        }
        public ObservableCollection<string> SelectOptions
        {
            get
            {
                if (_selectOption == null)
                {
                    _selectOption = new ObservableCollection<string>();

                }
                return _selectOption;
            }
            set
            {
                _selectOption = value;
                NotifyPropertyChanged("SelectOptions");
            }
        }

        public ObservableCollection<string> Options1
        {
            get
            {
                if (_options1 == null)
                {
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자" ,"만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options1 = new ObservableCollection<string>(tmp);


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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options2 = new ObservableCollection<string>(tmp);

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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options3 = new ObservableCollection<string>(tmp);

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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options4 = new ObservableCollection<string>(tmp);

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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options5 = new ObservableCollection<string>(tmp);

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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options6 = new ObservableCollection<string>(tmp);

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
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options7 = new ObservableCollection<string>(tmp);

                }
                return _options7;
            }
        }
        public ObservableCollection<string> Options8
        {
            get
            {
                if (_options8 == null)
                {
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options8 = new ObservableCollection<string>(tmp);

                }
                return _options8;
            }
        }
        public ObservableCollection<string> Options9
        {
            get
            {
                if (_options9 == null)
                {
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options9 = new ObservableCollection<string>(tmp);

                }
                return _options9;
            }
        }
        public ObservableCollection<string> Options10
        {
            get
            {
                if (_options5 == null)
                {
                    List<string> tmp = new List<string>()
                    {
                        "","각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","부러진 뼈","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역천지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개","처단자","포식자","만월의 집행자", "그믐의 경계"
                    };
                    tmp.Sort();
                    _options10 = new ObservableCollection<string>(tmp);

                }
                return _options10;
            }
        }
        public List<string> SelectOptions2
        {
            get
            {
                if (_selectOption2 == null)
                {
                    _selectOption2 = new List<string>()
                    {
                        "",
                        "공격력 감소",
                        "방어력 감소",
                        "이동속도 감소",
                        "공격속도 감소"
                    };

                }
                return _selectOption2;
            }
            set
            {
                _selectOption2 = value;
                OnPropertyChanged("SelectOptions2");
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
        public void KeyDownMethod(object sender, object e)
        {
            ComboBox comboBox = (ComboBox)sender;
            KeyEventArgs arg = e as KeyEventArgs;
            CollectionView itemsViewOriginal = (CollectionView)CollectionViewSource.GetDefaultView(comboBox.ItemsSource);
            TextBox txt = comboBox.Template.FindName("PART_EditableTextBox", comboBox) as TextBox;
            string tmp = txt.Text;
            comboBox.SelectedItem = txt.Text;
            if ((arg.Key == Key.Enter) || (arg.Key == Key.Tab) || (arg.Key == Key.Return) || (arg.Key == Key.Up) || (arg.Key == Key.Down) || (arg.Key == Key.Left) || (arg.Key == Key.Right))

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
                        if (o is string)
                        {
                            sValue = o.ToString();
                        }
                        else if (o is ComboBoxItem)
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
    }
}
