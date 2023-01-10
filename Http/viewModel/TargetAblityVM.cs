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

namespace LostArkAction.viewModel
{
    public class TargetAblityVM : ViewModelBase
    {

        #region Field
        private string[] _options;
        private string[] _figure;
        private RelayCommand _mouseDownCommand;
        private List<string> _optionsList = new List<string>();
        private List<string> _selectItems = new List<string>() { "", "", "", "", "", "", "", };

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
                NotifyPropertyChanged(nameof(SelectItems));
            }
        }



        public Dictionary<int,int> optionIndex { get; set; } = new Dictionary<int,int>();
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
        public string[] Options
        {
            get
            {
                if (_options == null)
                {
                    _options = new string[]
                    {
                        "각성","갈증","강령술","강화 무기","강화 방패","결투의 대가", "고독한 기사","광기","광전사의 비기","구슬동자","굳은 의지","극의:체술","급소 타격","기습의 대가","긴급구조",
                        "넘치는 교감","달의 소리","달인의 저력","돌격대장","두 번째 동료","마나 효율 증가","마나의 흐름","멈출 수 없는 충동","바리케이드","버스트","번개의 분노","분노의 망치","분쇄의 주먹",
                        "불굴","사냥의 시간","상급 소환사","선수 필승","세맥타통","속전속결","슈퍼 차지","승부사","시선 집중","실드 관통","심판자","아드레날린","아르데타인의 기술","안정된 상태","약자 무시",
                        "에테르 포식자","여신의 가호","역전지체","예리한 둔기","오의 강화","오의난무","완변한 억제","원한","위기 모면","이슬비","일격  필살","잔재된 기운","저주받은 인형","전문의","전투 태세",
                        "절실한 구원","절정","절제","점화","정기 흡수","정밀 단도","죽음의 습격","중갑 착용","중력 수련","진실된 용맹","진화의 유산","질량 증가","질풍노도","초심","최대 마나 증가","추진력",
                        "축복의 오라","충격 단련","타격의 대가","탈출의 명수","포격 강화","폭발물 전문가","피스메이커","핸드거너","화력 강화","환류","황제의 칙령","황후의 은총","회귀","만개"
                    };

                }
                return _options;
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

        #region Method
        public void ClickMethod(object sender, object e)
        {
            ComboBox comboBox = (ComboBox)sender;

            string name = comboBox.Name;

            for (int i = 0; i < 7; i++)
            {
                string nameTmp = "Combo" + (i + 1);
                if (name == nameTmp)
                {
                    if (optionIndex.ContainsKey(i))
                    {
                        _optionsList[optionIndex[i]] = comboBox.SelectedItem as string;
                    }
                    else
                    {
                        _optionsList.Add(comboBox.SelectedItem as string);
                        optionIndex.Add(i, _optionsList.Count - 1);
                    }
                    (App.Current.MainWindow.DataContext as MainWinodwVM).EquipAblityVM.SelectOptions = new List<string>();
                    (App.Current.MainWindow.DataContext as MainWinodwVM).EquipAblityVM.SelectOptions = _optionsList;
                    for (int j = 0; j < _optionsList.Count; j++)
                    {
                        //(App.Current.MainWindow.DataContext as MainWinodwVM).EquipAblityVM.SelectOptions.Add(_optionsList[j]);
                    }
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
