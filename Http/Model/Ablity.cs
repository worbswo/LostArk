using Http.Code;
using LostArkAction.Code;
using LostArkAction.viewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using System.Windows.Media.TextFormatting;

namespace LostArkAction.Model
{
    public class Ablity
    {
        #region Field
        #endregion

        #region Property
        #region Static
        public static Dictionary<string, int> CharactericsCode = new Dictionary<string, int> { { "치명", 15 }, { "특화", 16 }, { "제압", 17 }, { "신속", 18 }, { "인내", 19 }, { "숙련", 20 } };
        public static Dictionary<string, int> AblityCode  = new Dictionary<string, int>
        { { "원한", 118 }, { "굳은 의지",123  }, { "실드 관통", 237 },{"강령술",243 },{ "저주받은 인형", 247 },{"각성",255},{"안정된 상태",111 },{"위기 모면",140 },{"달인의 저력",238 },
         { "중갑 착용", 240 }, { "강화 방패",242  }, { "부러진 뼈", 245 },{"승부사",248 },{ "기습의 대가", 249 },{"마나의 흐름",251},{"돌격대장",254 },{"약자 무시",107 },{"정기 흡수",109 },{"에테르 포식자",110 },
            {"슈퍼 차지",121 },{"구슬동자",134 },{"예리한 둔기",141 },{"불굴",235 },{"여신의 가호",239 },{"선수필승",244 },{"급소 타격",142 },{"분쇄의 주먹",236 },{"폭발물 전문가",241 },{"번개의 분노",246 },{"바리케이드",253 },
            {"마나 효율 증가",168 },{"최대 마나 증가",167 },{"탈출의 명수",202},{"결투의 대가",288 },{"질량 증가",295 },{"추진력",296 },{"타격의 대가",297 },{"시선 집중",298 },{"아드레날린",299 },{"속전속결",300 },{"전문의",301 },
            {"긴급구조",302 },{"정밀 단도",303 },{"공격력 감소",800 },{"방어력 감소",801 },{"공격속도 감소",802 },{"이동속도 감소",803 },{"광기",125 },{"오의 강화",127 },{"강화 무기",129},{"화력 강화",130 },{"광전사의 비기",188 },
            {"초심",189 },{"극의: 체술",190 },{"충격 단련",191 },{"핸드거나",192 },{"포격 강화",193 },{"진실된 용맹",194},{"절실한 구원",195 },{"점화",293 },{"환류",194 },{"중력 수련",197 },{ "상급 소환사",198},{"넘치는 교감",199 },
            {"황후의 은총",200 },{"황제의 칙령",201 },{"전투 태세",224},{"고독한 기사",225 },{"세맥타통",256 },{ "역전지체",257},{"두 번째 동료",258 },{"죽음의 습격",259 },{"절정",276 },{"절제",277 },{"잔재된 기운",278 },{"버스트",279 },
            {"완벽한 억제",280 },{"멈출 수 없는 충동",281 },{"심판자",282 },{"축복의 오라",283 },{"아르데타인의 기술" ,284},{"진화의 유산",285 },{"갈증",286 },{"달의 소리",287},{"피스메이커",289 },{"사냥의 시간",290 },{"일격필살",291 },
            {"오의난무",292 },{"회귀",305 },{"만개",306} ,{"질풍노도",307 },{"이슬비",308 },{"분노의 망치",196 } };
        public static Dictionary<string, int> AccessoryCode  = new Dictionary<string, int> { { "목걸이", 200010 }, { "반지1", 200030 }, { "반지2", 200030 }, { "귀걸이1", 200020 }, { "귀걸이2", 200020 } };
        public static int selectClass { get; set; } = 0;
     #endregion
        List<List<SearchAblity>> AblitiesCombi = new List<List<SearchAblity>>();
        List<SearchAblity> SearchAblities = new List<SearchAblity>();
        Dictionary<string, List<int>> SearchFirstAblityCandidate = new Dictionary<string, List<int>>();
        Dictionary<string, List<int>> SearchSecondAblityCandidate = new Dictionary<string, List<int>>();
        public Dictionary<int, List<List<int>>> AccRelicCases  = new Dictionary<int, List<List<int>>>();
        public Dictionary<int, List<List<int>>> AccAncientCases  = new Dictionary<int, List<List<int>>>();
        public Dictionary<string, int> TargetItems  = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems  = new Dictionary<string, int>();
        #region Accesory
        public Accesories Accesories  = new Accesories();
        public List<AccVM> NeckAcc  = new List<AccVM>();
        public List<List<AccVM>> FinalNeckAcc  = new List<List<AccVM>>();

        public List<List<List<AccVM>>> RingCombi  = new List<List<List<AccVM>>>();
        public List<List<List<AccVM>>> EarCombi = new List<List<List<AccVM>>>();
        public List<List<List<AccVM>>> Accs = new List<List<List<AccVM>>>();

        public List<AccVM> RingAcc1 = new List<AccVM>();
        public List<AccVM> EarAcc1 = new List<AccVM>();
        public List<AccVM> RingAcc2 = new List<AccVM>();
        public List<AccVM> EarAcc2 = new List<AccVM>();
        public Thread Thread { get; set; }
        public Thread Thread2 { get; set; }
        MainWinodwVM MainWinodwVM { get; set; }
        #endregion

        public HttpClient2 HttpClient { get; set; }


        Dictionary<string, int> EquipCheck;
        Dictionary<string, int> panaltyCheck;

        uint TotalValue;
        uint Cnt;
        #endregion
        public Ablity(MainWinodwVM mainWinodw)
        {
            MainWinodwVM = mainWinodw;
            HttpClient = new HttpClient2();
            List<List<int>> tmp = new List<List<int>>() { new List<int>{5,5,5}, new List<int> {5,5,4,3 }, new List<int> {5,5,3,3 }, new List<int> {5,4,4,3 }, new List<int> {5,4,3,3 }, new List<int> {4,4,4,3 } };
            AccRelicCases.Add(15, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 4 }, new List<int> { 5, 5, 3, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 }, new List<int> { 4, 4, 3, 3 } };
            AccRelicCases.Add(14, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 5, 4, 4 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 3, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccRelicCases.Add(13, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4 }, new List<int> { 4, 4, 3, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccRelicCases.Add(12, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3, 3 }, new List<int> { 5, 4,3 }, new List<int> { 4, 3, 3, 3 } };
            AccRelicCases.Add(11, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5 }, new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 4, 4, 3 } };
            AccRelicCases.Add(10, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 4, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(9, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4,4 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(8, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4, 3 }, new List<int> { 3, 3, 3 } };
            AccRelicCases.Add(7, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3, 3 } };
            AccRelicCases.Add(6, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5 }, new List<int> { 4,3 }, new List<int> { 3,3 } };
            AccRelicCases.Add(5, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4 }, new List<int> { 3, 3 } };
            AccRelicCases.Add(4, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccRelicCases.Add(2, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccRelicCases.Add(1, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccRelicCases.Add(3, new List<List<int>>(tmp));
            AccRelicCases.Add(0, new List<List<int>>());

            tmp = new List<List<int>>() { new List<int> { 5, 5, 5 }, new List<int> { 5, 5, 4, 3 }, new List<int> { 5, 5, 3, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 } };
            AccAncientCases.Add(15, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 4 }, new List<int> { 5, 5, 3, 3 }, new List<int> { 5, 4, 4, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 4, 4, 4, 3 }, new List<int> { 4, 4, 3, 3 } };
            AccAncientCases.Add(14, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5, 3 }, new List<int> { 5, 4, 3, 3 }, new List<int> { 5, 4, 4 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 3, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccAncientCases.Add(13, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3, 3 }, new List<int> { 4, 4, 4 }, new List<int> { 4, 4, 3, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccAncientCases.Add(12, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3, 3 }, new List<int> { 5, 4, 3 }, new List<int> { 4, 3, 3, 3 } };
            AccAncientCases.Add(11, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 5 }, new List<int> { 5, 4, 3 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 4, 4, 3 } };
            AccAncientCases.Add(10, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 4 }, new List<int> { 5, 3, 3 }, new List<int> { 4, 4, 3 }, new List<int> { 4, 3, 3 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(9, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5, 3 }, new List<int> { 4, 4 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(8, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4, 3 }, new List<int> { 3, 3, 3 } };
            AccAncientCases.Add(7, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3, 3 } };
            AccAncientCases.Add(6, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 5 }, new List<int> { 4, 3 }, new List<int> { 3, 3 } };
            AccAncientCases.Add(5, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 4 }, new List<int> { 3, 3 } };
            AccAncientCases.Add(4, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccAncientCases.Add(2, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccAncientCases.Add(1, new List<List<int>>(tmp));
            tmp = new List<List<int>>() { new List<int> { 3 } };
            AccAncientCases.Add(3, new List<List<int>>(tmp));
            AccAncientCases.Add(0, new List<List<int>>());

            AccAncientCases[15].Add(new List<int> { 6, 6, 3 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 4 });
            AccAncientCases[15].Add(new List<int> { 6, 5, 3,3 });
            AccAncientCases[15].Add(new List<int> { 6, 4, 3,3 });
            AccAncientCases[15].Add(new List<int> { 6, 3, 3, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 5, 3 });
            AccAncientCases[14].Add(new List<int> { 6, 4, 3,3 });
            AccAncientCases[14].Add(new List<int> { 6, 3, 3,3 });
            AccAncientCases[13].Add(new List<int> { 6, 4, 3 });
            AccAncientCases[13].Add(new List<int> { 6, 3, 3,3 });
            AccAncientCases[12].Add(new List<int> { 6, 6});
            AccAncientCases[12].Add(new List<int> { 6, 5,4 });
            AccAncientCases[12].Add(new List<int> { 6, 5,3,3 });
            AccAncientCases[12].Add(new List<int> { 6, 4,3 });
            AccAncientCases[12].Add(new List<int> { 6, 3,3 });
            AccAncientCases[11].Add(new List<int> { 6, 5 });
            AccAncientCases[11].Add(new List<int> { 6, 4,3 });
            AccAncientCases[11].Add(new List<int> { 6, 3,3 });
            AccAncientCases[10].Add(new List<int> { 6, 4 });
            AccAncientCases[10].Add(new List<int> { 6, 3,3});
            AccAncientCases[9].Add(new List<int> { 6, 3 });
            AccAncientCases[6].Add(new List<int> { 6});
        }
        #region Method
        public void Start()
        {
            Thread = new Thread(SetAcc);
            Thread.Start();
        }
        public void SelectedAblity()
        {
           
            int TargetSum = 0;
            int EquipSum = 0;
            int auctionIItemSum = 0;
            Dictionary<string, int> targetItems = new Dictionary<string, int>();
            Dictionary<string, List<int>> equipItems  = new Dictionary<string, List<int>>();
            foreach(var tmp in EquipItems)
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
            int Minus = TargetSum - EquipSum;
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
                MessageBox.Show("구성할 수 없는 각인 입니다.");
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
                if(ablitySum<= auctionIItemSum)
                {
                    ComputeAblity(index, abliName,tmpCases, tmpItem, AblitiesCombi);
                }
                index[index.Count - 1]++;
                for(int i = 1; i <=index.Count; i++)
                {
                    if (index[index.Count - i] == indexMax[index.Count - i])
                    {
                        if ((index.Count - i) == 0)
                        {
                            check = true;
                            break;
                        }
                        index[index.Count - i] = 0;
                        index[index.Count - (i+1)]++;
                    }
                }
                if (check)
                {
                    break;
                }
            }
            if (AblitiesCombi.Count==0)
            {
                MessageBox.Show("구성할 수 없는 각인 입니다.");
                return;
            }
            for (int i = 0; i < AblitiesCombi.Count; i++)
            {
                for (int j = 0; j < AblitiesCombi[i].Count; j++)
                {
                    bool exist = false;
                    for(int k = 0; k < SearchAblities.Count; k++)
                    {
                        if (SearchAblities[k].FirstAblity.ContainsKey(AblitiesCombi[i][j].FirstAblity.Keys.ToList()[0])){
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
            RingCombi = new List<List<List<AccVM>>>();
            EarCombi = new List<List<List<AccVM>>>();
            FinalNeckAcc = new List<List<AccVM>>();
            for(int i = 0; i < AblitiesCombi.Count; i++)
            {
                RingCombi.Add(new List<List<AccVM>>());
                EarCombi.Add(new List<List<AccVM>>());
                FinalNeckAcc.Add(new List<AccVM>());
            }
            HttpClient2.GetAsync(SearchAblities, Accesories);
        }
        public void ComputeAblity(List<int> index, List<string> abliName,Dictionary<int, List<List<int>>> accCases, Dictionary<string, int> targetItems, List<List<SearchAblity>> searchAblities)
        {
            Dictionary<string, List<int>> firstAblityCandidate = new Dictionary<string, List<int>>();
            Dictionary<string, List<int>> secondAblityCandidate = new Dictionary<string, List<int>>();
            List<SearchAblity> tmpSearchAblities = new List<SearchAblity>();
            int firstCnt = 0;
            int secondCnt = 0;
            for(int i = 0; i < index.Count; i++)
            {
                List<int> tmp = accCases[targetItems[abliName[i]]][index[i]];
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (tmp[j] > 3)
                    {
                        firstCnt++;
                        if (firstAblityCandidate.ContainsKey(abliName[i]))
                        {
                            if (!firstAblityCandidate[abliName[i]].Contains(tmp[j])){
                                firstAblityCandidate[abliName[i]].Add(tmp[j]);
                            }
                        }
                        else
                        {
                            firstAblityCandidate.Add(abliName[i], new List<int> { tmp[j] });
                        }
                    }
                    else
                    {
                        secondCnt++;
                        if (secondAblityCandidate.ContainsKey(abliName[i]))
                        {
                            if (!secondAblityCandidate[abliName[i]].Contains(tmp[j])){
                                secondAblityCandidate[abliName[i]].Add(tmp[j]);
                            }
                        }
                        else
                        {
                            secondAblityCandidate.Add(abliName[i], new List<int> { tmp[j] });
                        }
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
                }
            }
            else
            {
                if (secondCnt < 5)
                {
                    secondAblityCandidate.Add("random", new List<int> { 3 });

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
            searchAblities.Add(tmpSearchAblities);
        }
        
        public void combination(int type)
        {
            List<List<AccVM>> arr = new List<List<AccVM>>();
            if (type == 0)
            {
                arr.Add(RingAcc1);
                arr.Add(RingAcc2);

            }
            else
            {
                arr.Add(EarAcc1);
                arr.Add(EarAcc2);
            }
            for (int o = 0; o < AblitiesCombi.Count; o++)
            {
                List<List<AccVM>> list = new List<List<AccVM>>();
                for (int j = 0; j < 2; j++)
                {
                    List<AccVM> listTmp = new List<AccVM>();
                    for (int i = 0; i < arr[j].Count - 1; i++)
                    {
                        if (PanaltyItems.Keys.ToList()[0] == arr[j][i].PenaltyName)
                        {
                            if (arr[j][i].PenaltyValue + PanaltyItems[PanaltyItems.Keys.ToList()[0]] >= 5)
                            {
                                continue;
                            }
                        }
                        for (int k = 0; k < AblitiesCombi[o].Count; k++)
                        {
                            if (arr[j][i].Name1.Equals(AblitiesCombi[o][k].FirstAblity.Keys.ToList()[0]))
                            {
                                if (arr[j][i].Value1 == AblitiesCombi[o][k].FirstAblity.Values.ToList()[0])
                                {
                                    if (arr[j][i].Name2.Equals(AblitiesCombi[o][k].SecondAblity.Keys.ToList()[0]))
                                    {
                                        if (arr[j][i].Value2 == AblitiesCombi[o][k].SecondAblity.Values.ToList()[0])
                                        {
                                            listTmp.Add(arr[j][i]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    list.Add(listTmp);
                }
                int checkValue = selectClass == 0 ? 16 : 18;
                int checkValue2 = selectClass == 0 ? 5 : 6;
                List < Dictionary < string ,int>> equipCheck = new List<Dictionary<string, int>>();
                List < Dictionary < string, int>> panaltyCheck = new List<Dictionary<string, int>>();
                List<List<List<AccVM>>> tmp = new List<List<List<AccVM>>>();

                for (int i = 0; i < list[0].Count; i++)
                {
                    panaltyCheck.Add(new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } });
                    panaltyCheck[i][PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
                    equipCheck.Add(new Dictionary<string, int>());
                    tmp.Add(new List<List<AccVM>>());
                }
                Parallel.For(0, list[0].Count - 1, i =>
                {
                    bool check = true;
                    foreach (var tmp3 in TargetItems)
                    {
                        equipCheck[i].Add(tmp3.Key, tmp3.Value);
                    }
                    panaltyCheck[i][list[0][i].PenaltyName] += list[0][i].PenaltyValue;
                    if (panaltyCheck[i][list[0][i].PenaltyName] >= 5)
                    {
                        panaltyCheck[i][list[0][i].PenaltyName] -= list[0][i].PenaltyValue;
                        return ;
                    }
                    equipCheck[i][list[0][i].Name1] -= list[0][i].Value1;
                    if (equipCheck[i].ContainsKey(list[0][i].Name2))
                    {
                        equipCheck[i][list[0][i].Name2] -= list[0][i].Value2;
                    }
                    for (int j = i + 1; j < list[1].Count; j++)
                    {
                        check = true;

                        panaltyCheck[i][list[1][j].PenaltyName] += list[1][j].PenaltyValue;
                        if (panaltyCheck[i][list[1][j].PenaltyName] >= 5)
                        {
                            panaltyCheck[i][list[1][j].PenaltyName] -= list[1][j].PenaltyValue;
                            continue;
                        }
                        equipCheck[i][list[1][j].Name1] -= list[1][j].Value1;
                        if (equipCheck[i].ContainsKey(list[1][j].Name2))
                        {
                            equipCheck[i][list[1][j].Name2] -= list[1][j].Value2;
                        }
                        for (int k = 0; k < NeckAcc.Count; k++)
                        {
                            panaltyCheck[i][NeckAcc[k].PenaltyName] += NeckAcc[k].PenaltyValue;
                            if (panaltyCheck[i][NeckAcc[k].PenaltyName] >= 5)
                            {
                                panaltyCheck[i][NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;

                                check = false;

                                continue;
                            }
                            equipCheck[i][NeckAcc[k].Name1] -= NeckAcc[k].Value1;
                            if (equipCheck[i].ContainsKey(NeckAcc[k].Name2))
                            {
                                equipCheck[i][NeckAcc[k].Name2] -= NeckAcc[k].Value2;
                            }


                            int cnt = 0;
                            int sumValue = 0;
                            bool check2 = true;
                            foreach (var tmp3 in equipCheck[i])
                            {
                                if (tmp3.Value >= 4) { cnt++; }
                                if (cnt > 2)
                                {
                                    check2 = false;
                                    break;
                                }

                                if (tmp3.Value > 0)
                                {
                                    sumValue += tmp3.Value;
                                }

                                if (sumValue > checkValue)
                                {
                                    check2 = false;
                                    break;
                                }
                            }
                            if (!check2)
                            {
                                check = false;
                                panaltyCheck[i][NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;
                                equipCheck[i][NeckAcc[k].Name1] += NeckAcc[k].Value1;
                                if (equipCheck[i].ContainsKey(NeckAcc[k].Name2))
                                {
                                    equipCheck[i][NeckAcc[k].Name2] += NeckAcc[k].Value2;
                                }

                                continue;
                            }
                            check = true;
                            panaltyCheck[i][NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;
                            equipCheck[i][NeckAcc[k].Name1] += NeckAcc[k].Value1;
                            if (equipCheck[i].ContainsKey(NeckAcc[k].Name2))
                            {
                                equipCheck[i][NeckAcc[k].Name2] += NeckAcc[k].Value2;
                            }
                            break;
                        }
                        if (check)
                        {

                            tmp[i].Add(new List<AccVM> { list[0][i], list[1][j] });
                            check = true;
                        }
                        panaltyCheck[i][list[1][j].PenaltyName] -= list[1][j].PenaltyValue;
                        equipCheck[i][list[1][j].Name1] += list[1][j].Value1;
                        if (equipCheck[i].ContainsKey(list[1][j].Name2))
                        {
                            equipCheck[i][list[1][j].Name2] += list[1][j].Value2;
                        }

                    }

                    panaltyCheck[i][list[0][i].PenaltyName] -= list[0][i].PenaltyValue;

                });
                for (int i = 0; i < tmp.Count; i++) {
                    tmp[i] = tmp[i].OrderBy(x => (x[0].Price + x[1].Price)).ToList();
                    for (int j = 0; j < tmp[i].Count; j++)
                    {
                        if (type == 0)
                        {
                            RingCombi[o].Add(new List<AccVM>(tmp[i][j]));

                        }
                        else
                        {
                            EarCombi[o].Add(new List<AccVM>(tmp[i][j]));
                        }
                    }
                }
            }
        }

        public void SetNeck()
        {
            NeckAcc = NeckAcc.OrderBy(x => (x.Price)).ToList();
            Parallel.For(0, AblitiesCombi.Count, j =>
             {
                 List<AccVM> tmp = new List<AccVM>();
                 for (int i = 0; i < NeckAcc.Count; i++)
                 {

                     if (PanaltyItems.Keys.ToList()[0] == NeckAcc[i].PenaltyName)
                     {
                         if (PanaltyItems[PanaltyItems.Keys.ToList()[0]] + NeckAcc[i].PenaltyValue >= 5)
                         {
                             continue;
                         }
                     }
                     for (int k = 0; k < AblitiesCombi[j].Count; k++)
                     {
                         if (NeckAcc[i].Name1.Equals(AblitiesCombi[j][k].FirstAblity.Keys.ToList()[0]))
                         {
                             if (NeckAcc[i].Value1 == AblitiesCombi[j][k].FirstAblity.Values.ToList()[0])
                             {
                                 if (NeckAcc[i].Name2.Equals(AblitiesCombi[j][k].SecondAblity.Keys.ToList()[0]))
                                 {
                                     if (NeckAcc[i].Value2 == AblitiesCombi[j][k].SecondAblity.Values.ToList()[0])
                                     {
                                         tmp.Add(NeckAcc[i]);
                                         break;
                                     }
                                 }
                             }
                         }
                     }
                 }
                 FinalNeckAcc[j] = new List<AccVM>(tmp);
             });
        }
        public void SetAcc()
        {
            
            int checkValue = selectClass == 0 ? 8 : 9;
            uint total =0;
            for(int i = 0; i < RingCombi.Count; i++)
            {
                total += (uint)(RingCombi[i].Count * EarCombi[i].Count);
            }
            uint cnt = 0;
            for(int i = 0; i < FinalNeckAcc.Count; i++)
            {
                Accs.Add(new List<List<AccVM>>());
            }
            for (int o = 0; o < FinalNeckAcc.Count; o++)
            {
                List<List<List<AccVM>>> tmpAccVMs = new List<List<List<AccVM>>>();
                for(int i = 0; i < RingCombi[o].Count; i++)
                {
                    tmpAccVMs.Add(new List<List<AccVM>>());
                }
                Parallel.For(0, RingCombi[o].Count, i =>
                {
                    Dictionary<string, int> equipCheck = new Dictionary<string, int>();
                    Dictionary<string, int> panaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
                    panaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
                    foreach (var tmp in TargetItems)
                    {
                        equipCheck.Add(tmp.Key, tmp.Value);
                    }
                    panaltyCheck[RingCombi[o][i][0].PenaltyName] += RingCombi[o][i][0].PenaltyValue;
                    panaltyCheck[RingCombi[o][i][1].PenaltyName] += RingCombi[o][i][1].PenaltyValue;
                    equipCheck[RingCombi[o][i][1].Name1] -= RingCombi[o][i][1].Value1;
                    if (equipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                        equipCheck[RingCombi[o][i][1].Name2] -= RingCombi[o][i][1].Value2;
                    equipCheck[RingCombi[o][i][0].Name1] -= RingCombi[o][i][0].Value1;
                    if (equipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                        equipCheck[RingCombi[o][i][0].Name2] -= RingCombi[o][i][0].Value2;
                    if (panaltyCheck[RingCombi[o][i][0].PenaltyName] >= 5 || panaltyCheck[RingCombi[o][i][1].PenaltyName] >= 5)
                    {
                        equipCheck[RingCombi[o][i][1].Name1] += RingCombi[o][i][1].Value1;
                        if (equipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                            equipCheck[RingCombi[o][i][1].Name2] += RingCombi[o][i][1].Value2;
                        equipCheck[RingCombi[o][i][0].Name1] += RingCombi[o][i][0].Value1;
                        if (equipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                            equipCheck[RingCombi[o][i][0].Name2] += RingCombi[o][i][0].Value2;
                        panaltyCheck[RingCombi[o][i][0].PenaltyName] -= RingCombi[o][i][0].PenaltyValue;
                        panaltyCheck[RingCombi[o][i][1].PenaltyName] -= RingCombi[o][i][1].PenaltyValue;
                        cnt += (uint)EarCombi[o].Count;
                        MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                        return;
                    }
                    for (int j = 0; j < EarCombi[o].Count; j++)
                    {
                        panaltyCheck[EarCombi[o][j][0].PenaltyName] += EarCombi[o][j][0].PenaltyValue;
                        panaltyCheck[EarCombi[o][j][1].PenaltyName] += EarCombi[o][j][1].PenaltyValue;
                        equipCheck[EarCombi[o][j][1].Name1] -= EarCombi[o][j][1].Value1;
                        if (equipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                            equipCheck[EarCombi[o][j][1].Name2] -= EarCombi[o][j][1].Value2;
                        equipCheck[EarCombi[o][j][0].Name1] -= EarCombi[o][j][0].Value1;
                        if (equipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                            equipCheck[EarCombi[o][j][0].Name2] -= EarCombi[o][j][0].Value2;
                        if (panaltyCheck[EarCombi[o][j][0].PenaltyName] >= 5 || panaltyCheck[EarCombi[o][j][1].PenaltyName] >= 5)
                        {
                            equipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                            if (equipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                                equipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                            equipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                            if (equipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                                equipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                            panaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                            panaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
                            cnt++;
                            MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                            continue;
                        }
                        int sumValue = 0;
                        foreach (var equip in equipCheck)
                        {
                            if (equip.Value > 0)
                                sumValue += equip.Value;
                        }
                        if (sumValue > checkValue)
                        {
                            equipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                            if (equipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                                equipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                            equipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                            if (equipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                                equipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                            panaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                            panaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
                            cnt++;
                            MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                            continue;
                        }
                        List<AccVM> tmp = new List<AccVM>
                        {
                            RingCombi[o][i][0],
                            RingCombi[o][i][1],
                            EarCombi[o][j][0],
                            EarCombi[o][j][1]
                        };
                        if (tmp != null)
                        {
                            tmpAccVMs[i].Add(tmp);
                        }

                        equipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                        if (equipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                            equipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                        equipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                        if (equipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                            equipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                        panaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                        panaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
                        cnt++;
                        MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                    }


                    equipCheck[RingCombi[o][i][1].Name1] += RingCombi[o][i][1].Value1;
                    if (equipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                        equipCheck[RingCombi[o][i][1].Name2] += RingCombi[o][i][1].Value2;
                    equipCheck[RingCombi[o][i][0].Name1] += RingCombi[o][i][0].Value1;
                    if (equipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                        equipCheck[RingCombi[o][i][0].Name2] += RingCombi[o][i][0].Value2;
                    panaltyCheck[RingCombi[o][i][0].PenaltyName] -= RingCombi[o][i][0].PenaltyValue;
                    panaltyCheck[RingCombi[o][i][1].PenaltyName] -= RingCombi[o][i][1].PenaltyValue;
                });
                for (int i = 0; i < tmpAccVMs.Count; i++) {
                    for (int j = 0; j < tmpAccVMs[i].Count; j++)
                    {
                        if (tmpAccVMs[i][j] != null)
                        {
                            Accs[o].Add(tmpAccVMs[i][j]);
                        }
                    }
                }
                MainWinodwVM.AccProgressValue = 100;
            }
            Thread2 = new Thread(ResultAcc2);
            Thread2.Start();
        }
        public void ResultAcc2()
        {
            Cnt = 0;
            List<FindAccVM> findAccVMsTmp  = new List<FindAccVM>();

            TotalValue = 0;
            for (int i = 0; i < FinalNeckAcc.Count; i++)
            {
                TotalValue += (uint)(FinalNeckAcc[i].Count);
            }
          
            for (int o = 0; o < FinalNeckAcc.Count; o++)
            {
                for (int i = 0; i < FinalNeckAcc[o].Count; i++)
                {
                    
                    Parallel.For(0, Accs[o].Count, j =>
                    {
                        Dictionary<string, int> equipCheck = new Dictionary<string, int>();
                        Dictionary<string, int> panaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
                        panaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
                        foreach (var tmp in TargetItems)
                        {
                            equipCheck.Add(tmp.Key, tmp.Value);
                        }
                        panaltyCheck[FinalNeckAcc[o][i].PenaltyName] += FinalNeckAcc[o][i].PenaltyValue;
                        equipCheck[FinalNeckAcc[o][i].Name1] -= FinalNeckAcc[o][i].Value1;
                        if (equipCheck.ContainsKey(FinalNeckAcc[o][i].Name2))
                            equipCheck[FinalNeckAcc[o][i].Name2] -= FinalNeckAcc[o][i].Value2;
                        bool check2 = false;
                        for (int k = 0; k < Accs[o][j].Count; k++)
                        {
                            panaltyCheck[Accs[o][j][k].PenaltyName] += Accs[o][j][k].PenaltyValue;

                            equipCheck[Accs[o][j][k].Name1] -= Accs[o][j][k].Value1;
                            if (equipCheck.ContainsKey(Accs[o][j][k].Name2))
                                equipCheck[Accs[o][j][k].Name2] -= Accs[o][j][k].Value2;

                            if (panaltyCheck[Accs[o][j][k].PenaltyName] >= 5)
                            {
                                check2 = true;
                            }
                        }
                        if (check2)
                        {
                            for (int k = 0; k < Accs[o][j].Count; k++)
                            {
                                panaltyCheck[Accs[o][j][k].PenaltyName] -= Accs[o][j][k].PenaltyValue;

                                equipCheck[Accs[o][j][k].Name1] += Accs[o][j][k].Value1;
                                if (equipCheck.ContainsKey(Accs[o][j][k].Name2))
                                    equipCheck[Accs[o][j][k].Name2] += Accs[o][j][k].Value2;
                            }

                            return ;
                        }
                        var check = equipCheck.Where(x => x.Value > 0).ToList();
                        if (check.Count == 0)
                        {
                            Dictionary<string, int> totalChar = new Dictionary<string, int>();
                            totalChar.Add(FinalNeckAcc[o][i].FirstCharaterics, FinalNeckAcc[o][i].FirstCharValue);
                            totalChar.Add(FinalNeckAcc[o][i].Secondcharaterics, FinalNeckAcc[o][i].SecondCharValue);
                            for (int c = 0; c < 4; c++)
                            {
                                if (totalChar.ContainsKey(Accs[o][j][c].FirstCharaterics))
                                {
                                    totalChar[Accs[o][j][c].FirstCharaterics] += Accs[o][j][c].FirstCharValue;
                                }
                                else
                                {
                                    totalChar.Add(Accs[o][j][c].FirstCharaterics, Accs[o][j][c].FirstCharValue);
                                }
                               

                            }
                            string result = "";
                            var sortChar = from entry in totalChar orderby entry.Value ascending select entry;
                            foreach (var tmp in sortChar)
                            {
                                result += tmp.Key +" : "+ tmp.Value.ToString() + '\n';
                            }
                            FindAccVM findAcc = new FindAccVM
                            {
                                NeckAblity = FinalNeckAcc[o][i],
                                FirstRingAblity = Accs[o][j][0],
                                SecondRingAblity = Accs[o][j][1],
                                FirstEarAblity = Accs[o][j][2],
                                SecondEarAblity = Accs[o][j][3],
                                TotalChar = result,
                                TotalPrice = FinalNeckAcc[o][i].Price + Accs[o][j][0].Price + Accs[o][j][1].Price + Accs[o][j][2].Price + Accs[o][j][3].Price
                            };
                           
                            if (findAcc != null)
                            {
                                findAccVMsTmp.Add(findAcc);
                            }
                        }
                        for (int k = 0; k < Accs[o][j].Count; k++)
                        {
                            panaltyCheck[Accs[o][j][k].PenaltyName] -= Accs[o][j][k].PenaltyValue;

                            equipCheck[Accs[o][j][k].Name1] += Accs[o][j][k].Value1;
                            if (equipCheck.ContainsKey(Accs[o][j][k].Name2))
                                equipCheck[Accs[o][j][k].Name2] += Accs[o][j][k].Value2;
                        }
                        panaltyCheck[FinalNeckAcc[o][i].PenaltyName] -= FinalNeckAcc[o][i].PenaltyValue;

                    });
                    Cnt++;
                    MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                }
            }
            if (findAccVMsTmp.Count == 0)
            {
                MessageBox.Show("각인을 구성할 수 있는 매물이 없습니다.");
                return;
            }
            for (int i = 0; i < findAccVMsTmp.Count; i++)
            {
                if (findAccVMsTmp[i] != null)
                {
                    MainWinodwVM.FindAccVMs.Add(findAccVMsTmp[i]);  
                }
            }
            DispatcherService.Invoke(() => { MainWinodwVM.OpenFindACC(); });

        }
        public string SetTotalChar(AccVM neck, List<AccVM> accs)
        {
            Dictionary<string, int> totalChar = new Dictionary<string, int>();
            totalChar.Add(neck.FirstCharaterics, neck.FirstCharValue);
            totalChar.Add(neck.Secondcharaterics, neck.SecondCharValue);
            for (int i = 0; i < 4; i++)
            {
                if (totalChar.ContainsKey(accs[i].FirstCharaterics))
                {
                    totalChar[accs[i].FirstCharaterics] += accs[i].FirstCharValue;
                }
                else
                {
                    totalChar.Add(accs[i].FirstCharaterics, accs[i].FirstCharValue);
                }
                if (totalChar.ContainsKey(accs[i].Secondcharaterics))
                {
                    totalChar[accs[i].Secondcharaterics] += accs[i].SecondCharValue;
                }
                else
                {
                    totalChar.Add(accs[i].Secondcharaterics, accs[i].SecondCharValue);
                }
                
            }
            string result = "";
            var sortChar = from entry in totalChar orderby entry.Value ascending select entry;
            foreach (var tmp in sortChar)
            {
                result += tmp.Key + tmp.Value.ToString() + '\n';
            }
            return result;
        }
        public AccVM ConvertAuctionItemToAcc(AuctionItem auctionItem, string accName)
        {
            bool isCheck = false;
            int value1 = -1;
            int value2 = -1;
            int idx1 = 0;
            int idx2 = 0;
            AccVM searchAblity = new AccVM();
            if (accName == "목걸이")
            {
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;

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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
            }
            else if (accName == "반지2")
            {
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
            }
            else if (accName == "귀걸이2")
            {
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
            }
            else
            {

            }
            return searchAblity;
        }
        public void SetAcc(AuctionItem auctionItem ,string accName)
        {
            bool isCheck = false;
            int value1 = -1;
            int value2 = -1;
            int idx1 = 0;
            int idx2 = 0;
            if (accName == "목걸이")
            {
                AccVM searchAblity = new AccVM();
                searchAblity.Name = auctionItem.Name;
                searchAblity.Price = (int)auctionItem.AuctionInfo.BuyPrice;
                searchAblity.Quality = auctionItem.GradeQuality;
             
                for (int i = 0; i < auctionItem.Options.Count; i++)
                {
                    if (auctionItem.Options[i].Type=="STAT")
                    {
                        if (!isCheck)
                        {
                            searchAblity.FirstCharaterics = auctionItem.Options[i].OptionName;
                            searchAblity.FirstCharValue = auctionItem.Options[i].Value;
                            isCheck=true;
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
                                value1= auctionItem.Options[i].Value;
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }  
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1= auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
                NeckAcc.Add(searchAblity);
            }
            else if (accName == "반지1")
            {
                AccVM searchAblity = new AccVM();
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
                RingAcc1.Add(searchAblity);
            }
            else if (accName == "반지2")
            {
                AccVM searchAblity = new AccVM();
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
                RingAcc2.Add(searchAblity);
            }
            else if (accName == "귀걸이1")
            {
                AccVM searchAblity = new AccVM();
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
                }
                EarAcc1.Add(searchAblity);
            }
            else if (accName == "귀걸이2")
            {
                AccVM searchAblity = new AccVM();
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
                                idx1 = i;
                            }
                            else
                            {
                                value2 = auctionItem.Options[i].Value;
                                idx2 = i;
                            }
                        }
                    }
                }
                if (value1 > value2)
                {
                    searchAblity.Value1 = value1;
                    searchAblity.Value2 = value2;
                    searchAblity.Name1 = auctionItem.Options[idx1].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx2].OptionName;

                }
                else
                {
                    searchAblity.Value1 = value2;
                    searchAblity.Value2 = value1;
                    searchAblity.Name1 = auctionItem.Options[idx2].OptionName;
                    searchAblity.Name2 = auctionItem.Options[idx1].OptionName;
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
