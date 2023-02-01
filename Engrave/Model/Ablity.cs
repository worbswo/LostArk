using LostArkAction.Code;
using LostArkAction.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace LostArkAction.Model
{
    public class Ablity
    {
        #region Field
        #endregion

        #region Property
        #region Static
        public static Dictionary<string, int> CharactericsCode = new Dictionary<string, int> { { "치명", 15 }, { "특화", 16 }, { "제압", 17 }, { "신속", 18 }, { "인내", 19 }, { "숙련", 20 } };
        public static Dictionary<string, int> AblityCode = new Dictionary<string, int>
        { { "원한", 118 }, { "굳은 의지",123  }, { "실드 관통", 237 },{"강령술",243 },{ "저주받은 인형", 247 },{"각성",255},{"안정된 상태",111 },{"위기 모면",140 },{"달인의 저력",238 },
         { "중갑 착용", 240 }, { "강화 방패",242  }, { "부러진 뼈", 245 },{"승부사",248 },{ "기습의 대가", 249 },{"마나의 흐름",251},{"돌격대장",254 },{"약자 무시",107 },{"정기 흡수",109 },{"에테르 포식자",110 },
            {"슈퍼 차지",121 },{"구슬동자",134 },{"예리한 둔기",141 },{"불굴",235 },{"여신의 가호",239 },{"선수필승",244 },{"급소 타격",142 },{"분쇄의 주먹",236 },{"폭발물 전문가",241 },{"번개의 분노",246 },{"바리케이드",253 },
            {"마나 효율 증가",168 },{"최대 마나 증가",167 },{"탈출의 명수",202},{"결투의 대가",288 },{"질량 증가",295 },{"추진력",296 },{"타격의 대가",297 },{"시선 집중",298 },{"아드레날린",299 },{"속전속결",300 },{"전문의",301 },
            {"긴급구조",302 },{"정밀 단도",303 },{"공격력 감소",800 },{"방어력 감소",801 },{"공격속도 감소",802 },{"이동속도 감소",803 },{"광기",125 },{"오의 강화",127 },{"강화 무기",129},{"화력 강화",130 },{"광전사의 비기",188 },
            {"초심",189 },{"극의: 체술",190 },{"충격 단련",191 },{"핸드거너",192 },{"포격 강화",193 },{"진실된 용맹",194},{"절실한 구원",195 },{"점화",293 },{"환류",194 },{"중력 수련",197 },{ "상급 소환사",198},{"넘치는 교감",199 },
            {"황후의 은총",200 },{"황제의 칙령",201 },{"전투 태세",224},{"고독한 기사",225 },{"세맥타통",256 },{ "역천지체",257},{"두 번째 동료",258 },{"죽음의 습격",259 },{"절정",276 },{"절제",277 },{"잔재된 기운",278 },{"버스트",279 },
            {"완벽한 억제",280 },{"멈출 수 없는 충동",281 },{"심판자",282 },{"축복의 오라",283 },{"아르데타인의 기술" ,284},{"진화의 유산",285 },{"갈증",286 },{"달의 소리",287},{"피스메이커",289 },{"사냥의 시간",290 },{"일격필살",291 },
            {"오의난무",292 },{"회귀",305 },{"만개",306} ,{"질풍노도",307 },{"이슬비",308 },{"분노의 망치",196 },{"처단자",310 },{"포식자",309 } };
        public static Dictionary<string, string> AblityShort = new Dictionary<string, string>
        { { "원한","원한" }, { "굳지","굳은 의지"  }, {"실관", "실드 관통" },{"강령술","강령술" },{ "저받","저주받은 인형" },{"각성","각성"},{"안상","안정된 상태" },{"위모","위기 모면" },{"달저","달인의 저력" },
         { "중갑","중갑 착용" }, { "강화","강화 방패" }, {"부뼈", "부러진 뼈" },{"승부사","승부사" },{ "기대","기습의 대가" },{"마흠","마나의 흐름"},{"돌대","돌격대장" },{"약무","약자 무시" },{"정흡","정기 흡수" },{"에포","에테르 포식자" },
            {"슈차","슈퍼 차지" },{"구동","구슬동자" },{"예둔","예리한 둔기" },{"불굴","불굴" },{"여가","여신의 가호" },{"선필","선수필승" },{"급타","급소 타격" },{"분주","분쇄의 주먹" },{"폭전","폭발물 전문가" },{"번분","번개의 분노" },{"바리","바리케이드" },
            {"마효증","마나 효율 증가" },{"최마증","최대 마나 증가" },{"탈명","탈출의 명수"},{"결대","결투의 대가" },{"질증","질량 증가" },{"추진력","추진력" },{"타대","타격의 대가" },{"시집","시선 집중" },{"아드","아드레날린" },{"속속","속전속결"},{"전문의","전문의" },
            {"긴급","긴급구조" },{"정단","정밀 단도" },{"광기","광기" },{"오의","오의 강화" },{"강무","강화 무기"},{"화강","화력 강화" },{"비기","광전사의 비기" },
            {"초심","초심" },{"체술","극의: 체술" },{"충단","충격 단련" },{"핸드","핸드거너" },{"포강","포격 강화" },{"용맹","진실된 용맹"},{"구원","절실한 구원" },{"점화","점화" },{"환류","환류" },{"중수","중력 수련" },{"상소", "상급 소환사"},{"교감","넘치는 교감" },
            {"황후","황후의 은총" },{"황제","황제의 칙령"},{"전태","전투 태세"},{"고기","고독한 기사" },{"세맥","세맥타통" },{ "역천","역천지체"},{"두동","두 번째 동료" },{"죽습","죽음의 습격" },{"절정","절정" },{"절제","절제" },{"잔재","잔재된 기운" },{"버스트","버스트" },
            {"억제","완벽한 억제" },{"충동","멈출 수 없는 충동" },{"심판자","심판자" },{"축오","축복의 오라" },{"기술","아르데타인의 기술"},{"유산","진화의 유산" },{"갈증","갈증"},{"달소","달의 소리"},{"피메","피스메이커" },{"사시","사냥의 시간" },{"일격","일격필살" },
            {"난무","오의난무" },{"회귀","회귀" },{"만개","만개"} ,{"질풍","질풍노도" },{"이슬비","이슬비" },{"분망","분노의 망치" },{ "처단자","처단자"},{"포식자","포식자" } };
        public static Dictionary<string, int> AccessoryCode = new Dictionary<string, int> { { "목걸이", 200010 }, { "반지1", 200030 }, { "반지2", 200030 }, { "귀걸이1", 200020 }, { "귀걸이2", 200020 } };
        public static int selectClass { get; set; } = 0;
        #endregion

        List<List<SearchAblity>> AblitiesCombi = new List<List<SearchAblity>>();
        List<SearchAblity> SearchAblities = new List<SearchAblity>();
        List<Dictionary<string, List<int>>> SearchAblityCandidate = new List<Dictionary<string, List<int>>>();
        List<Dictionary<string, List<int>>> SearchSecondAblityCandidate = new List<Dictionary<string, List<int>>>();
        public Dictionary<int, List<List<int>>> AccRelicCases = new Dictionary<int, List<List<int>>>();
        public Dictionary<int, List<List<int>>> AccAncientCases = new Dictionary<int, List<List<int>>>();
        public Dictionary<string, int> TargetItems = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems = new Dictionary<string, int>();
        Dictionary<string, List<SearchAblity>> AblityCombinationCases = new Dictionary<string, List<SearchAblity>>();
        public Dictionary<string,int> MinimumValue= new Dictionary<string, int>();
        public Dictionary<string ,int> MaximumValue= new Dictionary<string ,int>();
        #region Accesory
        public Accesories Accesories = new Accesories();
        public List<AccInfo> NeckAcc = new List<AccInfo>();

        public List<AccInfo> RingAcc1 = new List<AccInfo>();
        public List<AccInfo> EarAcc1 = new List<AccInfo>();
        public List<AccInfo> RingAcc2 = new List<AccInfo>();
        public List<AccInfo> EarAcc2 = new List<AccInfo>();
        public List<List<AccInfo>> Accs = new List<List<AccInfo>>();
        public List<List<int>> perAccs = new List<List<int>>();

        #endregion

        public Thread Thread;
        public HttpClient2 HttpClient;

        uint TotalValue;
        uint Cnt;

        int[] _arr = { 0, 1, 2, 3, 4 };
        bool[] _check = { false, false, false, false, false };
        List<int> _v = new List<int>();
        #endregion
        public Ablity()
        {
            Permutation(0, 5);
            HttpClient = new HttpClient2();
            List<List<int>> tmp = new List<List<int>>() { new List<int> { 5, 5, 5 }, new List<int> { 5, 5, 4, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccRelicCases.Add(15, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 4 }, new List<int> { 5, 5, 3, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccRelicCases.Add(14, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 5, 4, 4 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccRelicCases.Add(13, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4 }, new List<int> { 4, 4, 3, 3 } };
            AccRelicCases.Add(12, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3, 3 }, new List<int> { 5, 4, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccRelicCases.Add(11, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5 }, new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 4, 4, 3 } };
            AccRelicCases.Add(10, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 4, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(9, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4, 4 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(8, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4, 3 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(7, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3, 3 }, new List<int> { 4, 3 }, new List<int> { 5, 3 } };
            AccRelicCases.Add(6, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5 } };
            AccRelicCases.Add(5, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4 }, new List<int> { 5 } };
            AccRelicCases.Add(4, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 }};
            AccRelicCases.Add(2, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 }};
            AccRelicCases.Add(1, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccRelicCases.Add(3, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 0 } };

            AccRelicCases.Add(0, new List<List<int>>(tmp));

            tmp = new List<List<int>>() { new List<int> { 5, 5, 5 }, new List<int> { 5, 5, 4, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccAncientCases.Add(15, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 4 }, new List<int> { 5, 5, 3, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccAncientCases.Add(14, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 5, 4, 4 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccAncientCases.Add(13, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4 }, new List<int> { 4, 4, 3, 3 } };
            AccAncientCases.Add(12, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3, 3 }, new List<int> { 5, 4, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccAncientCases.Add(11, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5 }, new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 4, 4, 3 } };
            AccAncientCases.Add(10, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 4, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(9, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4, 4 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(8, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4, 3 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(7, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3, 3 }, new List<int> { 4, 3 }, new List<int> { 5, 3 } };
            AccAncientCases.Add(6, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5 } };
            AccAncientCases.Add(5, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4 }, new List<int> { 5 } };
            AccAncientCases.Add(4, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 }};
            AccAncientCases.Add(2, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccAncientCases.Add(1, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccAncientCases.Add(3, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 0 } };
            AccAncientCases.Add(0, new List<List<int>>(tmp));

            AccAncientCases[15].Add(new List<int> { 6, 6, 3 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 4 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 5 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 4,3 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 3, 3 });
            AccAncientCases[15].Add(new List<int> { 6, 4, 4, 3 });
            AccAncientCases[15].Add(new List<int> { 6, 4, 3, 3 });
            AccAncientCases[15].Add(new List<int> { 6, 3, 3, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 6, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 5, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 5, 5 });
            AccAncientCases[14].Add(new List<int> { 6, 5, 4 });
            AccAncientCases[14].Add(new List<int> { 6, 4, 4, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 4, 3, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 3, 3, 3 });
            AccAncientCases[13].Add(new List<int> { 6, 4, 3 });
            AccAncientCases[13].Add(new List<int> { 6, 4, 4 });
            AccAncientCases[13].Add(new List<int> { 6, 3, 3, 3 });
            AccAncientCases[12].Add(new List<int> { 6, 6 });
            AccAncientCases[12].Add(new List<int> { 6, 5, 5 });
            AccAncientCases[12].Add(new List<int> { 6, 5, 4 });
            AccAncientCases[12].Add(new List<int> { 6, 5, 3, 3 });
            AccAncientCases[12].Add(new List<int> { 6, 4, 4 });
            AccAncientCases[12].Add(new List<int> { 6, 4, 3 });
            AccAncientCases[12].Add(new List<int> { 6, 3, 3 });
            AccAncientCases[11].Add(new List<int> { 6, 6 });
            AccAncientCases[11].Add(new List<int> { 6, 5 });
            AccAncientCases[11].Add(new List<int> { 6, 4, 3 });
            AccAncientCases[11].Add(new List<int> { 6, 3, 3 });
            AccAncientCases[10].Add(new List<int> { 6, 5 });
            AccAncientCases[10].Add(new List<int> { 6, 6 });
            AccAncientCases[10].Add(new List<int> { 6, 4 });
            AccAncientCases[10].Add(new List<int> { 6, 3, 3 });
            AccAncientCases[9].Add(new List<int> { 6, 3 });
            AccAncientCases[8].Add(new List<int> { 6, 3 });
            AccAncientCases[7].Add(new List<int> { 6, 3 });
            AccAncientCases[6].Add(new List<int> { 6 });
            AccAncientCases[5].Add(new List<int> { 6 });
            AccAncientCases[4].Add(new List<int> { 6 });

        }
        #region Method
        void Permutation(int n, int r)
        {
            if (n == r)
            {
                perAccs.Add(new List<int>
                {
                    _v[0],
                    _v[1],
                    _v[2],
                    _v[3],
                    _v[4],
                });
                return;
            }

            for (int i = 0; i < 5; i++)
            {
                if (_check[i] == true) continue;
                _check[i] = true;
                _v.Add(_arr[i]);
                Permutation(n + 1, r);
                _v.RemoveAt(_v.Count - 1);
                _check[i] = false;
            }
        }

        public void Start()
        {
            Accs.Add(NeckAcc);
            Accs.Add(EarAcc1);
            Accs.Add(EarAcc2);
            Accs.Add(RingAcc1);
            Accs.Add(RingAcc2);
            Thread = new Thread(ResultAcc);
            Thread.Start();
        }
        public void SelectedAblity()
        {

            int TargetSum = 0;
            int EquipSum = 0;
            int auctionIItemSum = 0;
            MainWinodwVM.ProgressValue = 0;
            MainWinodwVM.AccProgressValue = 0;
            MainWinodwVM.SearchProgressValue = 0;

            Dictionary<string, int> targetItems = new Dictionary<string, int>();
            Dictionary<string, List<int>> equipItems = new Dictionary<string, List<int>>();
            foreach (var tmp in EquipItems)
            {
                equipItems.Add(tmp.Key, tmp.Value);
            }
            foreach (var tmp in TargetItems)
            {
                targetItems.Add(tmp.Key, tmp.Value);
            }
            for (int i = 0; i < EquipItems.Count; i++)
            {
                for (int j = 0; j < EquipItems[EquipItems.Keys.ToList()[i]].Count; j++)
                {
                    EquipSum += EquipItems[EquipItems.Keys.ToList()[i]][j];

                    TargetItems[EquipItems.Keys.ToList()[i]] -= EquipItems[EquipItems.Keys.ToList()[i]][j];
                }
            }
            for (int i = 0; i < TargetItems.Count; i++)
            {
                TargetSum += TargetItems[TargetItems.Keys.ToList()[i]];
            }
            int Minus = TargetSum;
            Dictionary<string, int> tmpItem = new Dictionary<string, int>();
            foreach (var tmp in TargetItems)
            {
                tmpItem.Add(tmp.Key, tmp.Value);
            }

            Dictionary<int, List<List<int>>> tmpCases = new Dictionary<int, List<List<int>>>();
            if (selectClass == 0)
            {
                auctionIItemSum = 40;
                tmpCases = AccRelicCases;
            }
            else
            {
                auctionIItemSum = 45;
                tmpCases = AccAncientCases;
            }
            if (Minus > auctionIItemSum)
            {

                if (!MainWinodwVM.isRunnigSearch)
                {
                    MessageBox.Show("구성할 수 없는 각인 입니다.");
                }
                else
                {
                    MainWinodwVM.NextPossessionSetting();
                }
                DispatcherService.Invoke(() => { (App.Current.MainWindow.DataContext as MainWinodwVM).IsEnableSearchBtn = true; });


                return;
            }
            List<int> index = new List<int>();
            List<int> indexMax = new List<int>();
            List<string> abliName = new List<string>();
            for (int i = 0; i < tmpItem.Count; i++)
            {
                int idx = tmpItem.Values.ToList()[i];
                if (idx < 0)
                {
                    continue;
                }
                index.Add(0);
                indexMax.Add(tmpCases[idx].Count);
                abliName.Add(tmpItem.Keys.ToList()[i]);
            }

            bool check = false;
            while (true)
            {
                int ablitySum = 0;
                for (int i = 0; i < index.Count; i++)
                {
                    ablitySum += tmpCases[tmpItem[abliName[i]]][index[i]].Sum();
                }
                if (ablitySum <= auctionIItemSum)
                {
                    ComputeAblity(index, abliName, tmpCases, tmpItem, AblitiesCombi);
                }
                index[index.Count - 1]++;
                for (int i = 1; i <= index.Count; i++)
                {
                    if (index[index.Count - i] == indexMax[index.Count - i])
                    {
                        if ((index.Count - i) == 0)
                        {
                            check = true;
                            break;
                        }
                        index[index.Count - i] = 0;
                        index[index.Count - (i + 1)]++;
                    }
                }
                if (check)
                {
                    break;
                }
            }

            
            if (AblitiesCombi.Count == 0)
            {
                if (!MainWinodwVM.isRunnigSearch)
                {
                    MessageBox.Show("구성할 수 없는 각인 입니다.");
                }
                else
                {
                    MainWinodwVM.NextPossessionSetting();
                }
                DispatcherService.Invoke(() => { (App.Current.MainWindow.DataContext as MainWinodwVM).IsEnableSearchBtn = true; });

                return;
            }
            for (int i = 0; i < AblitiesCombi.Count; i++)
            {
                for (int j = 0; j < AblitiesCombi[i].Count; j++)
                {
                    bool exist = false;
                    for (int k = 0; k < SearchAblities.Count; k++)
                    {
                        if (SearchAblities[k].FirstAblity.ContainsKey(AblitiesCombi[i][j].FirstAblity.Keys.ToList()[0]))
                        {
                            if (SearchAblities[k].FirstAblity.Values.ToList()[0] == AblitiesCombi[i][j].FirstAblity.Values.ToList()[0])
                            {
                                if (SearchAblities[k].SecondAblity.ContainsKey(AblitiesCombi[i][j].SecondAblity.Keys.ToList()[0]))
                                {
                                    if (SearchAblities[k].SecondAblity.Values.ToList()[0] == AblitiesCombi[i][j].SecondAblity.Values.ToList()[0])
                                    {
                                        exist = true;
                                    }
                                }
                            }
                        }
                    }
                    if (!exist)
                    {
                        SearchAblities.Add(AblitiesCombi[i][j]);
                    }
                }
            }
#if DEBUG
            Console.WriteLine("----------------------result------------------------");
            for (int i = 0; i < AblitiesCombi.Count; i++)
            {
                for (int j = 0; j < AblitiesCombi[i].Count; j++)
                {
                    foreach (var tmp in AblitiesCombi[i][j].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                    foreach (var tmp in AblitiesCombi[i][j].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                    Console.WriteLine();

                }
                Console.WriteLine("----------------------------");
            }
           
            foreach (var tmp2 in AblityCombinationCases)
            {
                for (int j = 0; j < tmp2.Value.Count; j++)
                {
                    foreach (var tmp in tmp2.Value[j].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                    foreach (var tmp in tmp2.Value[j].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine("검색 개수 {0}", SearchAblities.Count);
#endif
           HttpClient2.GetAsync(SearchAblities, Accesories);
        }
        public void ComputeAblity(List<int> index, List<string> abliName, Dictionary<int, List<List<int>>> accCases, Dictionary<string, int> targetItems, List<List<SearchAblity>> searchAblities)
        {
            Dictionary<string, List<int>> firstAblityCandidate = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> secondAblityCandidate = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> candidate = new Dictionary<string, List<int>>();
            List<SearchAblity> tmpSearchAblities = new List<SearchAblity>();
            int firstCnt = 0;
            int secondCnt = 0;
            for (int i = 0; i < index.Count; i++)
            {
                List<int> tmp = accCases[targetItems[abliName[i]]][index[i]];
                
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (tmp[j] == 0) continue;
                    if (tmp[j] > 3) {
                        firstCnt++;
                        if (firstAblityCandidate.ContainsKey(abliName[i])) {
                            if (!firstAblityCandidate[abliName[i]].Contains(tmp[j]))
                            {
                                firstAblityCandidate[abliName[i]].Add(tmp[j]);
                            }
                        } else {
                            firstAblityCandidate.Add(abliName[i], new List<int> { tmp[j] });
                        }
                    }else {
                        secondCnt++;
                        if (secondAblityCandidate.ContainsKey(abliName[i]))  {
                            if (!secondAblityCandidate[abliName[i]].Contains(tmp[j])) {
                                secondAblityCandidate[abliName[i]].Add(tmp[j]);
                            }
                        } else {
                            secondAblityCandidate.Add(abliName[i], new List<int> { tmp[j] });
                        }

                    }
                    if (candidate.ContainsKey(abliName[i]))
                    {
                        if (candidate[abliName[i]][tmp[j] - 1] == 1000)
                        {
                            candidate[abliName[i]][tmp[j] - 1] = 1;
                        }
                        else
                        {
                            candidate[abliName[i]][tmp[j] - 1]++;
                        }
                    }
                    else
                    {
                        candidate.Add(abliName[i], new List<int> { 1000, 1000, 1000, 1000, 1000, 1000 });
                        candidate[abliName[i]][tmp[j] - 1] = 1;
                    }
                }
            }

            if (firstCnt > 5)
            {
                return;
            }
            if (firstCnt + secondCnt > 10)
            {
                return;
            }
            if (firstCnt < 5)
            {
                if (secondCnt < 6)
                {
                    secondAblityCandidate.Add("random", new List<int> { 3 });
                    candidate.Add("random", new List<int> { 1000, 1000, 1, 1000, 1000, 1000 });

                }
            }
            else
            {
                if (secondCnt < 5)
                {
                    secondAblityCandidate.Add("random", new List<int> { 3 });
                    candidate.Add("random", new List<int> { 1000, 1000, 1, 1000, 1000, 1000 });
                }
            }
            foreach (var tmp in firstAblityCandidate)
            {
                for (int i = 0; i < tmp.Value.Count; i++)
                {
                    foreach (var tmp2 in secondAblityCandidate)
                    {
                        if (tmp.Key != tmp2.Key)
                        {
                            for (int j = 0; j < tmp2.Value.Count; j++)
                            {
                                SearchAblity searchAblity = new SearchAblity();
                                searchAblity.FirstAblity.Add(tmp.Key, tmp.Value[i]);
                                searchAblity.SecondAblity.Add(tmp2.Key, tmp2.Value[j]);
                                tmpSearchAblities.Add(searchAblity);
                            }
                        }
                    }
                }
            }
            if (firstCnt < 5)
            {
                foreach (var tmp in secondAblityCandidate)
                {
                    if (tmp.Key == "random")
                    {
                        continue;
                    }
                    for (int i = 0; i < tmp.Value.Count; i++)
                    {
                        foreach (var tmp2 in secondAblityCandidate)
                        {
                            if (tmp2.Key == "random")
                            {
                                continue;
                            }
                            if (tmp.Key != tmp2.Key)
                            {
                                for (int j = 0; j < tmp2.Value.Count; j++)
                                {
                                    SearchAblity searchAblity = new SearchAblity();
                                    searchAblity.FirstAblity.Add(tmp.Key, tmp.Value[i]);
                                    searchAblity.SecondAblity.Add(tmp2.Key, tmp2.Value[j]);
                                    tmpSearchAblities.Add(searchAblity);
                                }

                            }
                        }
                    }
                }
            }
            #region Debug
            foreach (var tmp in firstAblityCandidate)
            {
                Console.Write(tmp.Key + " : ");
                for (int i = 0; i < tmp.Value.Count; i++)
                {
                    Console.Write(tmp.Value[i] + " , ");
                }
                Console.WriteLine("");

            }
            Console.WriteLine("----------------------------");
            foreach (var tmp in secondAblityCandidate)
            {
                Console.Write(tmp.Key + " : ");
                for (int i = 0; i < tmp.Value.Count; i++)
                {
                    Console.Write(tmp.Value[i] + " , ");
                }
                Console.WriteLine("");

            }
            for (int i = 0; i < tmpSearchAblities.Count; i++)
            {
                foreach (var tmp in tmpSearchAblities[i].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                foreach (var tmp in tmpSearchAblities[i].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            Console.WriteLine("----------------------------");
            #endregion
            SearchAblityCandidate.Add(candidate);
            Dictionary<string,List<SearchAblity>> tmep2 = new Dictionary<string,List<SearchAblity>>();

            for (int i = 0; i < tmpSearchAblities.Count; i++)
            {
                if (!candidateCheck(tmpSearchAblities[i], candidate))
                {
                    continue;
                }
                for (int j = 0; j < tmpSearchAblities.Count; j++)
                {
                    if (!candidateCheck(tmpSearchAblities[j], candidate))
                    {
                        continue;
                    }
                    for (int k = 0; k < tmpSearchAblities.Count; k++)
                    {
                        if (!candidateCheck(tmpSearchAblities[k], candidate))
                        {
                            continue;
                        }
                        for (int o = 0; o < tmpSearchAblities.Count; o++)
                        {
                            if (!candidateCheck(tmpSearchAblities[o], candidate))
                            {
                                continue;
                            }
                            for (int c = 0; c < tmpSearchAblities.Count; c++)
                            {
                                if (!candidateCheck(tmpSearchAblities[c], candidate))
                                {
                                    continue;
                                }
                                List<SearchAblity> tmep = new List<SearchAblity>();

                                tmep.Add(tmpSearchAblities[i]);
                                tmep.Add(tmpSearchAblities[j]);
                                tmep.Add(tmpSearchAblities[k]);
                                tmep.Add(tmpSearchAblities[o]);
                                tmep.Add(tmpSearchAblities[c]);
                                tmep= tmep.OrderBy(x => x.FirstAblity.Keys.ToList()[0]).ThenBy(x => x.SecondAblity.Keys.ToList()[0]).ToList(); ;
                                List<string> str = new List<string>();
                                for (int n = 0; n < tmep.Count; n++)
                                {
                                    string strtmp = tmep[n].FirstAblity.Keys.ToList()[0] + tmep[n].FirstAblity.Values.ToList()[0] + tmep[n].SecondAblity.Keys.ToList()[0] + tmep[n].SecondAblity.Values.ToList()[0];
                                    str.Add(strtmp);
                                }
                                if (!AblityCombinationCases.ContainsKey(String.Join("_", str.ToArray())))
                                {
                                    AblityCombinationCases.Add(String.Join("_", str.ToArray()), tmep);
                                }
                                candidateReturn(tmpSearchAblities[c], candidate);
                            }
                            candidateReturn(tmpSearchAblities[o], candidate);
                        }
                        candidateReturn(tmpSearchAblities[k], candidate);
                    }
                    candidateReturn(tmpSearchAblities[j], candidate);
                }
                candidateReturn(tmpSearchAblities[i], candidate);
            }
   
            searchAblities.Add(tmpSearchAblities);
        }
        public bool candidateCheck(SearchAblity searchAblity,Dictionary<string,List<int>> candidate)
        {
            string name1 = searchAblity.FirstAblity.Keys.ToList()[0];
            string name2 = searchAblity.SecondAblity.Keys.ToList()[0];
            int value1 = searchAblity.FirstAblity.Values.ToList()[0];
            int value2 = searchAblity.SecondAblity.Values.ToList()[0];

            candidate[name1][value1 - 1]--;
            candidate[name2][value2-1]--;
            if(candidate[name1][value1 - 1]<0|| candidate[name2][value2 - 1] < 0)
            {
                candidate[name1][value1 - 1]++;
                candidate[name2][value2 - 1]++;
                return false;
            }
            return true;
        }
        public void candidateReturn(SearchAblity searchAblity, Dictionary<string, List<int>> candidate)
        {
            string name1 = searchAblity.FirstAblity.Keys.ToList()[0];
            string name2 = searchAblity.SecondAblity.Keys.ToList()[0];
            int value1 = searchAblity.FirstAblity.Values.ToList()[0];
            int value2 = searchAblity.SecondAblity.Values.ToList()[0];
            candidate[name1][value1 - 1]++;
            candidate[name2][value2 - 1]++;
        }


        public void ResultAcc()
        {
            Cnt = 0;
            bool ringSameChar = false;
            bool earSameChar = false;
            if (Accesories["반지2"].Characteristic[0] == Accesories["반지1"].Characteristic[0])
            {
                ringSameChar = true;
            }
            if (Accesories["귀걸이1"].Characteristic[0] == Accesories["귀걸이2"].Characteristic[0])
            {
                earSameChar = true;
            }
            List<FindAccVM> findAccVMsTmp = new List<FindAccVM>();
            List<List<AccInfo>> tmpAccs = new List<List<AccInfo>>();
            Dictionary<string, int> sameIndex = new Dictionary<string, int>();
            for (int i = 0; i < perAccs.Count; i++)
            {
                string strTmp = "";
                for (int k = 0; k < 5; k++)
                {
                    if (earSameChar&& perAccs[i][k] == 2)
                    {
                         strTmp += "1";
                        continue;
                    }
                    if (ringSameChar&& perAccs[i][k] == 4)
                    {
                        strTmp += "3";
                        continue;
                    }
                    
                    
                        strTmp += perAccs[i][k];
                    
                }
                if (sameIndex.ContainsKey(strTmp))
                {
                    continue;
                }
                else
                {
                    sameIndex.Add(strTmp, i);
                }
            }
            for (int i = 0; i < Accs.Count; i++)
            {
                tmpAccs.Add(Accs[i]);
            }
            TotalValue = (uint)(AblityCombinationCases.Count * sameIndex.Count) ;
            
            foreach (var cases in AblityCombinationCases)
            {
                for(int i = 0; i < sameIndex.Count; i++)
                {
                    int index = sameIndex.Values.ToList()[i];
                    for (int k = 0; k < 5; k++)
                    {
                        tmpAccs[perAccs[index][k]] = Accs[perAccs[index][k]].Where((x => {
                            string name = x.Name2;
                            if (!TargetItems.ContainsKey(x.Name2))
                            {
                                name = "random";
                            }
                            return (x.Name1 == cases.Value[k].FirstAblity.Keys.ToList()[0] &&
                                                                                    x.Value1 == cases.Value[k].FirstAblity.Values.ToList()[0] &&
                                                                                     name == cases.Value[k].SecondAblity.Keys.ToList()[0] &&
                                                                                    x.Value2 == cases.Value[k].SecondAblity.Values.ToList()[0]); }
                        )).ToList();
                        tmpAccs[perAccs[index][k]] = tmpAccs[perAccs[index][k]].OrderBy(x=>x.Price).ToList();
                    }
                    int[] idx = { 0, 0, 0, 0, 0 };

                    for (idx[0]=0;idx[0] < tmpAccs[0].Count;idx[0]++)
                    {
                        Dictionary<string, int> panaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
                        panaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
                        panaltyCheck[tmpAccs[0][idx[0]].PenaltyName] += tmpAccs[0][idx[0]].PenaltyValue;
                        if (panaltyCheck[tmpAccs[0][idx[0]].PenaltyName] >= 5)
                        {
                            continue;
                        }
                        for (idx[1] = 0; idx[1] < tmpAccs[1].Count; idx[1]++)
                        {
                            panaltyCheck[tmpAccs[1][idx[1]].PenaltyName] += tmpAccs[1][idx[1]].PenaltyValue;
                            if (panaltyCheck[tmpAccs[1][idx[1]].PenaltyName] >= 5)
                            {
                                panaltyCheck[tmpAccs[1][idx[1]].PenaltyName] -= tmpAccs[1][idx[1]].PenaltyValue;
                                continue;
                            }
                            for (idx[2] = 0; idx[2] < tmpAccs[2].Count; idx[2]++)
                            {
                                if (earSameChar)
                                {
                                    if (tmpAccs[2][idx[2]].Contain(tmpAccs[1][idx[1]]))
                                    {
                                        continue;
                                    }
                                }
                                panaltyCheck[tmpAccs[2][idx[2]].PenaltyName] += tmpAccs[2][idx[2]].PenaltyValue;
                                if (panaltyCheck[tmpAccs[2][idx[2]].PenaltyName] >= 5)
                                {
                                    panaltyCheck[tmpAccs[2][idx[2]].PenaltyName] -= tmpAccs[2][idx[2]].PenaltyValue;
                                    continue;
                                }
                                for (idx[3] = 0; idx[3] < tmpAccs[3].Count; idx[3]++)
                                {
                                    panaltyCheck[tmpAccs[3][idx[3]].PenaltyName] += tmpAccs[3][idx[3]].PenaltyValue;
                                    if (panaltyCheck[tmpAccs[3][idx[3]].PenaltyName] >= 5)
                                    {
                                        panaltyCheck[tmpAccs[3][idx[3]].PenaltyName] -= tmpAccs[3][idx[3]].PenaltyValue;
                                        continue;
                                    }
                                    for (idx[4] = 0; idx[4] < tmpAccs[4].Count; idx[4]++)
                                    {
                                        if (ringSameChar)
                                        {
                                            if (tmpAccs[4][idx[4]].Contain(tmpAccs[3][idx[3]]))
                                            {
                                                continue;
                                            }
                                        }
                                        panaltyCheck[tmpAccs[4][idx[4]].PenaltyName] += tmpAccs[4][idx[4]].PenaltyValue;
                                        if (panaltyCheck[tmpAccs[4][idx[4]].PenaltyName] >= 5)
                                        {
                                            panaltyCheck[tmpAccs[4][idx[4]].PenaltyName] -= tmpAccs[4][idx[4]].PenaltyValue;
                                            continue;
                                        }
                                        Dictionary<string, int> totalChar = new Dictionary<string, int>();
                                        totalChar.Add(tmpAccs[0][idx[0]].Secondcharaterics ,tmpAccs[0][idx[0]].SecondCharValue);
                                        totalChar.Add(tmpAccs[0][idx[0]].FirstCharaterics ,tmpAccs[0][idx[0]].FirstCharValue);
                                        for (int c = 1; c < 5; c++)
                                        {
                                            if (totalChar.ContainsKey(tmpAccs[c][idx[c]].FirstCharaterics))
                                            {
                                                totalChar[tmpAccs[c][idx[c]].FirstCharaterics] += tmpAccs[c][idx[c]].FirstCharValue;
                                            }
                                            else
                                            {
                                                totalChar.Add(tmpAccs[c][idx[c]].FirstCharaterics, tmpAccs[c][idx[c]].FirstCharValue);
                                            }
                                        }
                                        string result = "";
                                        var sortChar = from entry in totalChar orderby entry.Value ascending select entry;
                                        bool charCheck = true;
                                        foreach (var tmp in sortChar)
                                        {
                                            if (tmp.Value < MinimumValue[tmp.Key] || tmp.Value > MaximumValue[tmp.Key])
                                            {
                                                charCheck = false;
                                                break;
                                            }
                                            result += tmp.Key + " : " + tmp.Value.ToString() + '\n';
                                        }
                                     
                                        if (charCheck)
                                        {
                                            FindAccVM findAcc = new FindAccVM
                                            {
                                                NeckAblity = tmpAccs[0][idx[0]],
                                                FirstRingAblity = tmpAccs[3][idx[3]],
                                                SecondRingAblity = tmpAccs[4][idx[4]],
                                                FirstEarAblity = tmpAccs[1][idx[1]],
                                                SecondEarAblity = tmpAccs[2][idx[2]],
                                                TotalChar = result,
                                                EquipChar = MainWinodwVM.EquipStr,
                                                EquipChar2 = MainWinodwVM.EquipStr2,

                                                TotalPrice = tmpAccs[0][idx[0]].Price + tmpAccs[1][idx[1]].Price + tmpAccs[2][idx[2]].Price + tmpAccs[3][idx[3]].Price + tmpAccs[4][idx[4]].Price
                                            };

                                            MainWinodwVM.FindAccVMs.Add(findAcc);
                                        }
                                        
                                        panaltyCheck[tmpAccs[4][idx[4]].PenaltyName] -= tmpAccs[4][idx[4]].PenaltyValue;
                                    }
                                    panaltyCheck[tmpAccs[3][idx[3]].PenaltyName] -= tmpAccs[3][idx[3]].PenaltyValue;
                                }
                                panaltyCheck[tmpAccs[2][idx[2]].PenaltyName] -= tmpAccs[2][idx[2]].PenaltyValue;
                            }
                            panaltyCheck[tmpAccs[1][idx[1]].PenaltyName] -= tmpAccs[1][idx[1]].PenaltyValue;
                        }
                    }
                    Cnt++;
                    MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                }
                

            }
            MainWinodwVM.ProgressValue = 100;
            if (MainWinodwVM.FindAccVMs.Count == 0)
            {
                if (!MainWinodwVM.isRunnigSearch)  MessageBox.Show("각인을 구성할 수 있는 매물이 없습니다.");
                DispatcherService.Invoke(() => { (App.Current.MainWindow.DataContext as MainWinodwVM).IsEnableSearchBtn = true; });
                DispatcherService.Invoke(() => { MainWinodwVM.NextPossessionSetting(); });
                return;
            }
            DispatcherService.Invoke(() => { (App.Current.MainWindow.DataContext as MainWinodwVM).IsEnableSearchBtn = true; });
            DispatcherService.Invoke(() => { MainWinodwVM.OpenFindACC(); });
            DispatcherService.Invoke(() => { MainWinodwVM.NextPossessionSetting(); });

        }
        public AccInfo ConvertAuctionItemToAcc(AuctionItem auctionItem, string accName)
        {
            bool isCheck = false;
            int value1 = -1;
            int value2 = -1;
            int[] idx = { 0, 0 };
            AccInfo searchAblity = new AccInfo();
            if (accName == "목걸이")
            {
                searchAblity.ImagePath = auctionItem.Icon;

                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        if (!isCheck)
                        {
                            searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;
                            searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                            isCheck = true;
                        }
                        else
                        {
                            searchAblity.Secondcharaterics = auctionItem.Options[i].OptionName;
                            searchAblity.SecondCharValue = auctionItem.Options[i].Value;
                            isCheck = true;

                        }
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
            }
            else if (accName == "반지1" || accName == "반지2")
            {
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;

                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
            }
            else if (accName == "귀걸이1" || accName == "귀걸이2")
            {
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;

                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
            }
            else
            {

            }
            return searchAblity;
        }
        public void SetAcc(AuctionItem auctionItem, string accName)
        {
            bool isCheck = false;
            int value1 = -1;
            int value2 = -1;
            int[] idx = { 0, 0 };

            if (accName == "목걸이")
            {
                AccInfo searchAblity = new AccInfo();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;
                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        if (!isCheck)
                        {
                            searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;
                            searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                            isCheck = true;
                        }
                        else
                        {
                            searchAblity.Secondcharaterics = auctionItem.Options[i].OptionName;
                            searchAblity.SecondCharValue = auctionItem.Options[i].Value;
                            isCheck = true;

                        }
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
                NeckAcc.Add(searchAblity);
            }
            else if (accName == "반지1")
            {
                AccInfo searchAblity = new AccInfo();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;
                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
                RingAcc1.Add(searchAblity);
            }
            else if (accName == "반지2")
            {
                AccInfo searchAblity = new AccInfo();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;
                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
                RingAcc2.Add(searchAblity);
            }
            else if (accName == "귀걸이1")
            {
                AccInfo searchAblity = new AccInfo();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;

                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
                EarAcc1.Add(searchAblity);
            }
            else if (accName == "귀걸이2")
            {
                AccInfo searchAblity = new AccInfo();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
                searchAblity.ImagePath = auctionItem.Icon;
                searchAblity.TradeAllow = auctionItem.AuctionInfo.TradeAllowCount;

                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type == "STAT")
                    {
                        searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;

                        searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                    }
                    else if (auctionItem.Options[i].Type == "ABILITY_ENGRAVE")
                    {
                        if (auctionItem.Options[i].IsPenalty)
                        {
                            searchAblity.PenaltyName = auctionItem.Options[i].OptionName;
                            searchAblity.PenaltyValue = auctionItem.Options[i].Value;
                            continue;
                        }
                        else
                        {
                            if (value1 == -1)
                            {
                                value1 = auctionItem.Options[i].Value;
                                idx[0] = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx[1] = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx[0]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[1]].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx[1]].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx[0]].OptionName;
                }
                EarAcc2.Add(searchAblity);
            }
            else
            {

            }
        }
        #endregion
    }
}
