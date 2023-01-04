using Http.Code;
using LostArkAction.Code;
using LostArkAction.viewModel;
using Newtonsoft.Json.Linq;
using System;
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
        public static Dictionary<string, int> CharactericsCode { get; set; } = new Dictionary<string, int> { { "치명", 15 }, { "특화", 16 }, { "제압", 17 }, { "신속", 18 }, { "인내", 19 }, { "숙련", 20 } };
        public static Dictionary<string, int> AblityCode { get; set; } = new Dictionary<string, int>
        { { "원한", 118 }, { "굳은 의지",123  }, { "실드 관통", 237 },{"강령술",243 },{ "저주받은 인형", 247 },{"각성",255},{"안정된 상태",111 },{"위기 모면",140 },{"달인의 저력",238 },
         { "중갑 착용", 240 }, { "강화 방패",242  }, { "부러진 뼈", 245 },{"승부사",248 },{ "기습의 대가", 249 },{"마나의 흐름",251},{"돌격대장",254 },{"약자 무시",107 },{"정기 흡수",109 },{"에테르 포식자",110 },
            {"슈퍼 차지",121 },{"구슬동자",134 },{"예리한 둔기",141 },{"불굴",235 },{"여신의 가호",239 },{"선수필승",244 },{"급소 타격",142 },{"분쇄의 주먹",236 },{"폭발물 전문가",241 },{"번개의 분노",246 },{"바리케이드",253 },
            {"마나 효율 증가",168 },{"최대 마나 증가",167 },{"탈출의 명수",202},{"결투의 대가",288 },{"질량 증가",295 },{"추진력",296 },{"타격의 대가",297 },{"시선 집중",298 },{"아드레날린",299 },{"속전속결",300 },{"전문의",301 },
            {"긴급구조",302 },{"정밀 단도",303 },{"공격력 감소",800 },{"방어력 감소",801 },{"공격속도 감소",802 },{"이동속도 감소",803 },{"광기",125 },{"오의 강화",127 },{"강화 무기",129},{"화력 강화",130 },{"광전사의 비기",188 },
            {"초심",189 },{"극의: 체술",190 },{"충격 단련",191 },{"핸드거나",192 },{"포격 강화",193 },{"진실된 용맹",194},{"절실한 구원",195 },{"점화",293 },{"환류",194 },{"중력 수련",197 },{ "상급 소환사",198},{"넘치는 교감",199 },
            {"황후의 은총",200 },{"황제의 칙령",201 },{"전투 태세",224},{"고독한 기사",225 },{"세맥타통",256 },{ "역전지체",257},{"두 번째 동료",258 },{"죽음의 습격",259 },{"절정",276 },{"절제",277 },{"잔재된 기운",278 },{"버스트",279 },
            {"완벽한 억제",280 },{"멈출 수 없는 충동",281 },{"심판자",282 },{"축복의 오라",283 },{"아르데타인의 기술" ,284},{"진화의 유산",285 },{"갈증",286 },{"달의 소리",287},{"피스메이커",289 },{"사냥의 시간",290 },{"일격필살",291 },
            {"오의난무",292 },{"회귀",305 },{"만개",306} ,{"질풍노도",307 },{"이슬비",308 },{"분노의 망치",196 } };
        public static Dictionary<string, int> AccessoryCode { get; set; } = new Dictionary<string, int> { { "목걸이", 200010 }, { "반지1", 200030 }, { "반지2", 200030 }, { "귀걸이1", 200020 }, { "귀걸이2", 200020 } };
        public static int selectClass { get; set; } = 0;
        public Dictionary<int, List<List<int>>> AccRelicCases { get; set; } = new Dictionary<int, List<List<int>>>();
        public Dictionary<int, List<List<int>>> AccAncientCases { get; set; } = new Dictionary<int, List<List<int>>>();

        #endregion

        public Dictionary<string, int> TargetItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> FirstAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> SecondAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
        public List<List<SearchAblity>> SearchAblities { get; set; } = new List<List<SearchAblity>>();
        public List<List<SearchAblity>> SearchAblities2 { get; set; } = new List<List<SearchAblity>>();
        #region Accesory
        public Accesories Accesories { get; set; } = new Accesories();
        public List<AccVM> NeckAcc { get; set; } = new List<AccVM>();
        public List<List<AccVM>> FinalNeckAcc { get; set; } = new List<List<AccVM>>();

        public List<AccVM> RingAcc1 { get; set; } = new List<AccVM>();
        public List<List<List<AccVM>>> RingCombi { get; set; } = new List<List<List<AccVM>>>();
        public List<List<List<AccVM>>> EarCombi { get; set; } = new List<List<List<AccVM>>>();
        public List<List<List<AccVM>>> Accs { get; set; } = new List<List<List<AccVM>>>();
        

        public List<AccVM> EarAcc1 { get; set; } = new List<AccVM>();
        public Thread Thread { get; set; }
        public Thread Thread2 { get; set; }
        MainWinodwVM MainWinodwVM { get; set; }
        #endregion

        public HttpClient2 HttpClient { get; set; }

        public bool IsCheck { get; set; }= false;

        Dictionary<string, int> EquipCheck { get; set; }
        Dictionary<string, int> PanaltyCheck { get; set; }

        uint TotalValue {get; set; }
        uint Cnt { get; set; }
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


        }
        #region Method
        public void Start()
        {
            Thread = new Thread(SetAcc);
            Thread.Start();
        }
        public void SelectedAblity()
        {
           
            List<List<SearchAblity>>  searchAblities = new List<List<SearchAblity>>();
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
                    ComputeAblity(index, abliName,tmpCases, tmpItem, searchAblities);
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
            RingCombi = new List<List<List<AccVM>>>();
            EarCombi = new List<List<List<AccVM>>>();
            HttpClient2.GetAsync(searchAblities, Accesories);
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
        
        public void combination(List<AccVM> arr, int type)
        {
            List<AccVM> list = new List<AccVM>();
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (PanaltyItems.Keys.ToList()[0] == arr[i].PenaltyName)
                {
                    if (arr[i].PenaltyValue + PanaltyItems[PanaltyItems.Keys.ToList()[0]] >= 5)
                    {
                        continue;
                    }
                }
                list.Add(arr[i]);
            }
            int checkValue = selectClass == 0 ? 16 : 18;
            int checkValue2 = selectClass == 0 ? 5 : 6;

            PanaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
            PanaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
            list = list.OrderBy(x => (x.Price)).ToList();
            List<List<AccVM>> tmp = new List<List<AccVM>>();
            int size = 100000;
            size = size > list.Count ? list.Count : size;
            bool check = true;
            for (int i = 0; i < size - 1; i++)
            {
                EquipCheck = new Dictionary<string, int>();
                foreach (var tmp3 in TargetItems)
                {
                    EquipCheck.Add(tmp3.Key, tmp3.Value);
                }
                PanaltyCheck[list[i].PenaltyName] += list[i].PenaltyValue;
                if (PanaltyCheck[list[i].PenaltyName] >= 5)
                {
                    PanaltyCheck[list[i].PenaltyName] -= list[i].PenaltyValue;
                    continue;
                }
                EquipCheck[list[i].Name1] -= list[i].Value1;
                if (EquipCheck.ContainsKey(list[i].Name2))
                {
                    EquipCheck[list[i].Name2] -= list[i].Value2;
                }
                for (int j = i + 1; j < size; j++)
                {
                    check = true;

                    PanaltyCheck[list[j].PenaltyName] += list[j].PenaltyValue;
                    if (PanaltyCheck[list[j].PenaltyName] >= 5)
                    {
                        PanaltyCheck[list[j].PenaltyName] -= list[j].PenaltyValue;
                        continue;
                    }
                    EquipCheck[list[j].Name1] -= list[j].Value1;
                    if (EquipCheck.ContainsKey(list[j].Name2))
                    {
                        EquipCheck[list[j].Name2] -= list[j].Value2;
                    }
                    List<int> ints= new List<int>();
                    for (int k = 0; k < NeckAcc.Count; k++)
                    {
                        PanaltyCheck[NeckAcc[k].PenaltyName] += NeckAcc[k].PenaltyValue;
                        if (PanaltyCheck[NeckAcc[k].PenaltyName] >= 5)
                        {
                            PanaltyCheck[NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;
                            
                                check = false;

                            continue;
                        }
                        EquipCheck[NeckAcc[k].Name1] -= NeckAcc[k].Value1;
                        if (EquipCheck.ContainsKey(NeckAcc[k].Name2))
                        {
                            EquipCheck[NeckAcc[k].Name2] -= NeckAcc[k].Value2;
                        }
                    

                        int cnt = 0;
                        int sumValue = 0;
                        bool check2 = true;
                        foreach (var tmp3 in EquipCheck)
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
                            
                            if(sumValue> checkValue)
                            {
                                 check2 = false;
                                break;
                            } 
                        }
                        if (!check2)
                        {
                            check = false;
                            PanaltyCheck[NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;
                            EquipCheck[NeckAcc[k].Name1] += NeckAcc[k].Value1;
                            if (EquipCheck.ContainsKey(NeckAcc[k].Name2))
                            {
                                EquipCheck[NeckAcc[k].Name2] += NeckAcc[k].Value2;
                            }
                          
                                continue;
                        }
                        check = true;
                        PanaltyCheck[NeckAcc[k].PenaltyName] -= NeckAcc[k].PenaltyValue;
                        EquipCheck[NeckAcc[k].Name1] += NeckAcc[k].Value1;
                        if (EquipCheck.ContainsKey(NeckAcc[k].Name2))
                        {
                            EquipCheck[NeckAcc[k].Name2] += NeckAcc[k].Value2;
                        }
                        break;
                      
                        
                    }
                    if (check)
                    {
                       
                        tmp.Add(new List<AccVM> { list[i], list[j] });
                        check = true;
                    }
                    PanaltyCheck[list[j].PenaltyName] -= list[j].PenaltyValue;
                    EquipCheck[list[j].Name1] += list[j].Value1;
                    if (EquipCheck.ContainsKey(list[j].Name2))
                    {
                        EquipCheck[list[j].Name2] += list[j].Value2;
                    }    

                }

                PanaltyCheck[list[i].PenaltyName] -= list[i].PenaltyValue;

            }
          
            tmp = tmp.OrderBy(x => (x[0].Price + x[1].Price)).ToList();
            if (type == 0)
            {
                RingCombi.Add(tmp);
            }
            else
            {
                EarCombi.Add(tmp);
            }
            
        }
        
        public void SetNeck()
        {
            List<AccVM> tmp = new List<AccVM>();
            int sizeNeck = 100000;
            sizeNeck = sizeNeck > NeckAcc.Count ? NeckAcc.Count : sizeNeck;
            NeckAcc = NeckAcc.OrderBy(x => (x.Price)).ToList();

            for (int i = 0; i < sizeNeck; i++)
            {
                if (PanaltyItems.Keys.ToList()[0] == NeckAcc[i].PenaltyName)
                {
                    if (PanaltyItems[PanaltyItems.Keys.ToList()[0]] + NeckAcc[i].PenaltyValue >= 5)
                    {
                        continue;
                    }
                }
                tmp.Add(NeckAcc[i]);
            }
            NeckAcc = tmp;
            FinalNeckAcc.Add(tmp);
        }
        public void SetAcc()
        {
            PanaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
            PanaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
            int checkValue = selectClass == 0 ? 8 : 9;
            uint total =0;
            for(int i = 0; i < RingCombi.Count; i++)
            {
                total+= (uint)(RingCombi[i].Count * EarCombi[i].Count);
            }
            uint cnt = 0;
            for (int o = 0; o < FinalNeckAcc.Count; o++)
            {
                List<List<AccVM>> tmpAccVMs = new List<List<AccVM>>();
                for (int i = 0; i < RingCombi[o].Count; i++)
                {
                    EquipCheck = new Dictionary<string, int>();

                    foreach (var tmp in TargetItems)
                    {
                        EquipCheck.Add(tmp.Key, tmp.Value);
                    }
                    PanaltyCheck[RingCombi[o][i][0].PenaltyName] += RingCombi[o][i][0].PenaltyValue;
                    PanaltyCheck[RingCombi[o][i][1].PenaltyName] += RingCombi[o][i][1].PenaltyValue;
                    EquipCheck[RingCombi[o][i][1].Name1] -= RingCombi[o][i][1].Value1;
                    if (EquipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                        EquipCheck[RingCombi[o][i][1].Name2] -= RingCombi[o][i][1].Value2;
                    EquipCheck[RingCombi[o][i][0].Name1] -= RingCombi[o][i][0].Value1;
                    if (EquipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                        EquipCheck[RingCombi[o][i][0].Name2] -= RingCombi[o][i][0].Value2;
                    if (PanaltyCheck[RingCombi[o][i][0].PenaltyName] >= 5 || PanaltyCheck[RingCombi[o][i][1].PenaltyName] >= 5)
                    {
                        EquipCheck[RingCombi[o][i][1].Name1] += RingCombi[o][i][1].Value1;
                        if (EquipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                            EquipCheck[RingCombi[o][i][1].Name2] += RingCombi[o][i][1].Value2;
                        EquipCheck[RingCombi[o][i][0].Name1] += RingCombi[o][i][0].Value1;
                        if (EquipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                            EquipCheck[RingCombi[o][i][0].Name2] += RingCombi[o][i][0].Value2;
                        PanaltyCheck[RingCombi[o][i][0].PenaltyName] -= RingCombi[o][i][0].PenaltyValue;
                        PanaltyCheck[RingCombi[o][i][1].PenaltyName] -= RingCombi[o][i][1].PenaltyValue;
                        cnt += (uint)EarCombi[o].Count;
                        MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                        continue;
                    }
                    for (int j = 0; j < EarCombi[o].Count; j++)
                    {
                        PanaltyCheck[EarCombi[o][j][0].PenaltyName] += EarCombi[o][j][0].PenaltyValue;
                        PanaltyCheck[EarCombi[o][j][1].PenaltyName] += EarCombi[o][j][1].PenaltyValue;
                        EquipCheck[EarCombi[o][j][1].Name1] -= EarCombi[o][j][1].Value1;
                        if (EquipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                            EquipCheck[EarCombi[o][j][1].Name2] -= EarCombi[o][j][1].Value2;
                        EquipCheck[EarCombi[o][j][0].Name1] -= EarCombi[o][j][0].Value1;
                        if (EquipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                            EquipCheck[EarCombi[o][j][0].Name2] -= EarCombi[o][j][0].Value2;
                        if (PanaltyCheck[EarCombi[o][j][0].PenaltyName] >= 5 || PanaltyCheck[EarCombi[o][j][1].PenaltyName] >= 5)
                        {
                            EquipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                            if (EquipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                                EquipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                            EquipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                            if (EquipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                                EquipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                            PanaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                            PanaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
                            cnt++;
                            MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                            continue;
                        }
                        int sumValue = 0;
                        foreach (var equip in EquipCheck)
                        {
                            if (equip.Value > 0)
                                sumValue += equip.Value;
                        }
                        if (sumValue > checkValue)
                        {
                            EquipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                            if (EquipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                                EquipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                            EquipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                            if (EquipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                                EquipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                            PanaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                            PanaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
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
                        tmpAccVMs.Add(tmp);


                        EquipCheck[EarCombi[o][j][1].Name1] += EarCombi[o][j][1].Value1;
                        if (EquipCheck.ContainsKey(EarCombi[o][j][1].Name2))
                            EquipCheck[EarCombi[o][j][1].Name2] += EarCombi[o][j][1].Value2;
                        EquipCheck[EarCombi[o][j][0].Name1] += EarCombi[o][j][0].Value1;
                        if (EquipCheck.ContainsKey(EarCombi[o][j][0].Name2))
                            EquipCheck[EarCombi[o][j][0].Name2] += EarCombi[o][j][0].Value2;
                        PanaltyCheck[EarCombi[o][j][0].PenaltyName] -= EarCombi[o][j][0].PenaltyValue;
                        PanaltyCheck[EarCombi[o][j][1].PenaltyName] -= EarCombi[o][j][1].PenaltyValue;
                        cnt++;
                        MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                    }


                    EquipCheck[RingCombi[o][i][1].Name1] += RingCombi[o][i][1].Value1;
                    if (EquipCheck.ContainsKey(RingCombi[o][i][1].Name2))
                        EquipCheck[RingCombi[o][i][1].Name2] += RingCombi[o][i][1].Value2;
                    EquipCheck[RingCombi[o][i][0].Name1] += RingCombi[o][i][0].Value1;
                    if (EquipCheck.ContainsKey(RingCombi[o][i][0].Name2))
                        EquipCheck[RingCombi[o][i][0].Name2] += RingCombi[o][i][0].Value2;
                    PanaltyCheck[RingCombi[o][i][0].PenaltyName] -= RingCombi[o][i][0].PenaltyValue;
                    PanaltyCheck[RingCombi[o][i][1].PenaltyName] -= RingCombi[o][i][1].PenaltyValue;
                }
                tmpAccVMs = tmpAccVMs.OrderBy(x => (x[0].Price + x[1].Price + x[2].Price + x[3].Price)).ToList();
                Accs.Add(tmpAccVMs);
            }
            Thread2 = new Thread(ResultAcc2);
            Thread2.Start();
        }
        public void ResultAcc2()
        {
            Cnt = 0;
            PanaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
            PanaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
            TotalValue = 0;
            for (int i = 0; i < FinalNeckAcc.Count; i++)
            {
                TotalValue += (uint)(FinalNeckAcc[i].Count);
            }
            for (int o = 0; o < FinalNeckAcc.Count; o++)
            {
                for (int i = 0; i < FinalNeckAcc[o].Count; i++)
                {
                    EquipCheck.Clear();

                    foreach (var tmp in TargetItems)
                    {
                        EquipCheck.Add(tmp.Key, tmp.Value);
                    }
                    PanaltyCheck[FinalNeckAcc[o][i].PenaltyName] += FinalNeckAcc[o][i].PenaltyValue;
                    EquipCheck[FinalNeckAcc[o][i].Name1] -= FinalNeckAcc[o][i].Value1;
                    if (EquipCheck.ContainsKey(FinalNeckAcc[o][i].Name2))
                        EquipCheck[FinalNeckAcc[o][i].Name2] -= FinalNeckAcc[o][i].Value2;
                    if (PanaltyCheck[FinalNeckAcc[o][i].PenaltyName] >= 5)
                    {
                        PanaltyCheck[FinalNeckAcc[o][i].PenaltyName] -= FinalNeckAcc[o][i].PenaltyValue;
                        Cnt ++;
                        MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                        continue;
                    }
                    for (int j = 0; j < Accs[o].Count; j++)
                    {
                        bool check2 = false;
                        for (int k = 0; k < Accs[o][j].Count; k++)
                        {
                            PanaltyCheck[Accs[o][j][k].PenaltyName] += Accs[o][j][k].PenaltyValue;

                            EquipCheck[Accs[o][j][k].Name1] -= Accs[o][j][k].Value1;
                            if (EquipCheck.ContainsKey(Accs[o][j][k].Name2))
                                EquipCheck[Accs[o][j][k].Name2] -= Accs[o][j][k].Value2;

                            if (PanaltyCheck[Accs[o][j][k].PenaltyName] >= 5)
                            {
                                check2 = true;
                            }
                        }
                        if (check2)
                        {
                            for (int k = 0; k < Accs[o][j].Count; k++)
                            {
                                PanaltyCheck[Accs[o][j][k].PenaltyName] -= Accs[o][j][k].PenaltyValue;

                                EquipCheck[Accs[o][j][k].Name1] += Accs[o][j][k].Value1;
                                if (EquipCheck.ContainsKey(Accs[o][j][k].Name2))
                                    EquipCheck[Accs[o][j][k].Name2] += Accs[o][j][k].Value2;
                            }
                            
                            continue;
                        }
                        var check = EquipCheck.Where(x => x.Value > 0).ToList();
                        if (check.Count == 0)
                        {
                            int value1 = FinalNeckAcc[o][i].FirstCharValue;
                            int value2 = FinalNeckAcc[o][i].SecondCharValue;

                            if (FinalNeckAcc[o][i].FirstCharaterics == Accs[o][j][0].FirstCharaterics) value1 += Accs[o][j][0].FirstCharValue;
                            if (FinalNeckAcc[o][i].FirstCharaterics == Accs[o][j][1].FirstCharaterics) value1 += Accs[o][j][1].FirstCharValue;
                            if (FinalNeckAcc[o][i].FirstCharaterics == Accs[o][j][2].FirstCharaterics) value1 += Accs[o][j][2].FirstCharValue;
                            if (FinalNeckAcc[o][i].FirstCharaterics == Accs[o][j][3].FirstCharaterics) value1 += Accs[o][j][3].FirstCharValue;
                            if (FinalNeckAcc[o][i].Secondcharaterics == Accs[o][j][0].FirstCharaterics) value2 += Accs[o][j][0].FirstCharValue;
                            if (FinalNeckAcc[o][i].Secondcharaterics == Accs[o][j][1].FirstCharaterics) value2 += Accs[o][j][1].FirstCharValue;
                            if (FinalNeckAcc[o][i].Secondcharaterics == Accs[o][j][2].FirstCharaterics) value2 += Accs[o][j][2].FirstCharValue;
                            if (FinalNeckAcc[o][i].Secondcharaterics == Accs[o][j][3].FirstCharaterics) value2 += Accs[o][j][3].FirstCharValue;
                            FindAccVM findAccVM = new FindAccVM
                            {
                                NeckAblity = FinalNeckAcc[o][i],
                                FirstRingAblity = Accs[o][j][0],
                                SecondRingAblity = Accs[o][j][1],
                                FirstEarAblity = Accs[o][j][2],
                                SecondEarAblity = Accs[o][j][3],
                                TotalPrice = FinalNeckAcc[o][i].Price + Accs[o][j][0].Price + Accs[o][j][1].Price + Accs[o][j][2].Price + Accs[o][j][3].Price
                            };
                            if (value1 > value2)
                            {
                                findAccVM.TotalFirstChar = value1;
                                findAccVM.TotalSecondChar = value2;
                                findAccVM.FirstChar = FinalNeckAcc[o][i].FirstCharaterics;
                                findAccVM.SecondChar = FinalNeckAcc[o][i].Secondcharaterics;
                            }
                            else
                            {
                                findAccVM.TotalFirstChar = value2;
                                findAccVM.TotalSecondChar = value1;
                                findAccVM.FirstChar = FinalNeckAcc[o][i].Secondcharaterics;
                                findAccVM.SecondChar = FinalNeckAcc[o][i].FirstCharaterics;
                            }
                            MainWinodwVM.FindAccVMs.Add(findAccVM);
                        }
                        for (int k = 0; k < Accs[o][j].Count; k++)
                        {
                            PanaltyCheck[Accs[o][j][k].PenaltyName] -= Accs[o][j][k].PenaltyValue;

                            EquipCheck[Accs[o][j][k].Name1] += Accs[o][j][k].Value1;
                            if (EquipCheck.ContainsKey(Accs[o][j][k].Name2))
                                EquipCheck[Accs[o][j][k].Name2] += Accs[o][j][k].Value2;
                        }
                      
                    }
                    Cnt++;
                    MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                    PanaltyCheck[FinalNeckAcc[o][i].PenaltyName] -= FinalNeckAcc[o][i].PenaltyValue;
                }
            }
            DispatcherService.Invoke(() => { MainWinodwVM.OpenFindACC(); });

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
                RingAcc1.Add(searchAblity);
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
                EarAcc1.Add(searchAblity);
            }
            else
            {

            }
        }
        #endregion
    }
}
