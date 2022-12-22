using LostArkAction.Code;
using LostArkAction.viewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Animation;

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
            {"오의난무",292 },{"회귀",305 },{"만개",306} ,{"질풍노도",307 },{"이슬비",308 } };
        public static Dictionary<string, int> AccessoryCode { get; set; } = new Dictionary<string, int> { { "목걸이", 200010 }, { "반지1", 200030 }, { "반지2", 200030 }, { "귀걸이1", 200020 }, { "귀걸이2", 200020 } };
        #endregion

        public Dictionary<string, int> TargetItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> EquipItems { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, int> PanaltyItems { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, List<int>> FirstAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
        public Dictionary<string, List<int>> SecondAblityCandidate { get; set; } = new Dictionary<string, List<int>>();
        public List<List<SearchAblity>> SearchAblities { get; set; } = new List<List<SearchAblity>>();
        public List<List<SearchAblity>> SearchAblities2 { get; set; } = new List<List<SearchAblity>>();
        public int selectClass { get; set; } = 1;

        #region Accesory
        public Accesories Accesories { get; set; } = new Accesories();
        public List<AccVM> NeckAcc { get; set; } = new List<AccVM>();
        public List<AccVM> RingAcc2 { get; set; } = new List<AccVM>();
        public List<AccVM> RingAcc1 { get; set; } = new List<AccVM>();
        public List<AccVM> EarAcc1 { get; set; } = new List<AccVM>();
        public List<AccVM> EarAcc2 { get; set; } = new List<AccVM>();
        #endregion

        public HttpClient2 HttpClient { get; set; }

        public bool IsCheck { get; set; }= false;
        #endregion
        public Ablity()
        {
            HttpClient = new HttpClient2();

        }
        #region Method
        public void ComputeAblity()
        {
            FirstAblityCandidate = new Dictionary<string, List<int>>();
            SecondAblityCandidate = new Dictionary<string, List<int>>();
            SearchAblities = new List<List<SearchAblity>>();
            SearchAblities2 = new List<List<SearchAblity>>();
            for (int i = 0; i < EquipItems.Count; i++)
            {
                for (int j = 0; j < EquipItems[EquipItems.Keys.ToList()[i]].Count; j++)
                {
                    TargetItems[EquipItems.Keys.ToList()[i]] -= EquipItems[EquipItems.Keys.ToList()[i]][j];
                }
            }
            int cnt = 0;
            Dictionary<string, int> tmpItem = new Dictionary<string, int>();
            foreach (var tmp in TargetItems)
            {
                tmpItem.Add(tmp.Key, tmp.Value);
            }

            #region Seperate Ablity
            if (selectClass == 0)
            {

                for (int i = 0; i < tmpItem.Count; i++)
                {
                    while (true)
                    {
                        if (tmpItem[tmpItem.Keys.ToList()[i]] / 5 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 5 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 5 == 0))
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[tmpItem.Keys.ToList()[i]].Add(5);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 5 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 5;
                        }
                        else if (tmpItem[tmpItem.Keys.ToList()[i]] / 4 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 4 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 4 == 0))
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[tmpItem.Keys.ToList()[i]].Add(4);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 4 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 4;


                        }
                        else if (tmpItem[tmpItem.Keys.ToList()[i]] > 0)
                        {

                            if (SecondAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[tmpItem.Keys.ToList()[i]].Add(3);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 3 });
                            }
                            break;
                        } else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < tmpItem.Count; i++)
                {

                    while (true)
                    {
                        if (tmpItem[tmpItem.Keys.ToList()[i]] / 6 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 6 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 6 == 0))
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[tmpItem.Keys.ToList()[i]].Add(6);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 6 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 6;
                        }
                        else if (tmpItem[tmpItem.Keys.ToList()[i]] / 5 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 5 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 5 == 0))
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[tmpItem.Keys.ToList()[i]].Add(5);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 5 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 5;


                        }
                        else if (tmpItem[tmpItem.Keys.ToList()[i]] / 4 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 4 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 4 == 0))
                        {
                            cnt++;
                            if (FirstAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                FirstAblityCandidate[tmpItem.Keys.ToList()[i]].Add(4);
                            }
                            else
                            {
                                FirstAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 4 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 4;
                        }
                        else if (tmpItem[tmpItem.Keys.ToList()[i]] > 0)
                        {

                            if (SecondAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[tmpItem.Keys.ToList()[i]].Add(3);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 3 });
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            #endregion

            if (cnt > 5)
            {
                MessageBox.Show("구성할 수 없는 각인 입니다.");
                return;
            }
            else {
                List<SearchAblity> searchAblities = new List<SearchAblity>();
                foreach (var tmp in FirstAblityCandidate)
                {
                    for (int i = 0; i < tmp.Value.Count; i++)
                    {
                        foreach (var tmp2 in SecondAblityCandidate)
                        {
                            if (tmp.Key != tmp2.Key)
                            {
                                for (int j = 0; j < tmp2.Value.Count; j++)
                                {
                                    SearchAblity searchAblity = new SearchAblity();
                                    searchAblity.FirstAblity.Add(tmp.Key, tmp.Value[i]);
                                    searchAblity.SecondAblity.Add(tmp2.Key, tmp2.Value[j]);
                                    searchAblities.Add(searchAblity);
                                }
                            }
                        }
                    }
                }
                if (FirstAblityCandidate.Count < 5)
                {
                    for (int i = 0; i < SecondAblityCandidate.Count; i++)
                    {
                        for (int j = 0; j < SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]].Count; j++)
                        {
                            for (int k = 0; k < SecondAblityCandidate.Count; k++)
                            {
                                if (SecondAblityCandidate.Keys.ToList()[i] != SecondAblityCandidate.Keys.ToList()[k])
                                {
                                    for (int p = 0; p < SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[k]].Count; p++)
                                    {
                                        SearchAblity searchAblity = new SearchAblity();
                                        searchAblity.FirstAblity.Add(SecondAblityCandidate.Keys.ToList()[i], SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]][j]);
                                        searchAblity.SecondAblity.Add(SecondAblityCandidate.Keys.ToList()[k], SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[k]][p]);
                                        searchAblities.Add(searchAblity);
                                    }
                                }
                            }
                        }
                    }
                }
                /*  #region Debug
                  for (int i = 0; i < FirstAblityCandidate.Count; i++)
                  {
                      Console.Write(FirstAblityCandidate.Keys.ToList()[i] + " : ");
                      for (int j = 0; j < FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]].Count; j++)
                      {
                          Console.Write(FirstAblityCandidate[FirstAblityCandidate.Keys.ToList()[i]][j] + " , ");
                      }
                      Console.WriteLine("");

                  }
                  Console.WriteLine("----------------------------");
                  for (int i = 0; i < SecondAblityCandidate.Count; i++)
                  {
                      Console.Write(SecondAblityCandidate.Keys.ToList()[i] + " : ");
                      for (int j = 0; j < SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]].Count; j++)
                      {
                          Console.Write(SecondAblityCandidate[SecondAblityCandidate.Keys.ToList()[i]][j] + " , ");
                      }
                      Console.WriteLine("");

                  }
                  for (int i = 0; i < searchAblities.Count; i++)
                  {
                      foreach (var tmp in searchAblities[i].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                      foreach (var tmp in searchAblities[i].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                      Console.WriteLine();
                  }
                  #endregion*/
                HttpClient2.GetAsync(searchAblities, Accesories);            
            }

        }
        void combination(List<SearchAblity> arr, Boolean[] visitied, int start, int n, int r)
        {
            if (r == 0)
            {
                print(arr, visitied, n);
                return;
            }
            for (int i = start; i < n; i++)
            {
                visitied[i] = true;
                combination(arr, visitied, i + 1, n, r - 1);
                visitied[i] = false;
            }
        }
        void print(List<SearchAblity> arr, Boolean[] visited, int n)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            List<SearchAblity> searchAblitie = new List<SearchAblity>();

            bool check = true;

            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    foreach (var tmp in arr[i].FirstAblity)
                    {
                        if (result.ContainsKey(tmp.Key))
                        {
                            result[tmp.Key] += tmp.Value;
                        }
                        else
                        {
                            result.Add(tmp.Key, tmp.Value);
                        }
                    }
                    foreach (var tmp in arr[i].SecondAblity)
                    {
                        if (result.ContainsKey(tmp.Key))
                        {
                            result[tmp.Key] += tmp.Value;
                        }
                        else
                        {
                            result.Add(tmp.Key, tmp.Value);
                        }
                    }
                }
            }
            foreach (var tmp in TargetItems)
            {
                if (tmp.Value < 0) continue;
                if (result.ContainsKey(tmp.Key))
                {
                    if (result[tmp.Key] < tmp.Value)
                    {
                        check = false;
                        break;
                    }
                }
                else
                {
                    check = false;
                    break;

                }
            }
            for (int i = 0; i < n; i++)
            {
                if (visited[i])
                {
                    if (check)
                    {
                        //foreach (var tmp in arr[i].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                        //foreach (var tmp in arr[i].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                        searchAblitie.Add(arr[i]);
                    }
                }
            }
            if (check)
            {
                SearchAblities.Add(searchAblitie);
               // Console.WriteLine();
            }
        }
        List<SearchAblity>tmpAblity=new List<SearchAblity>();
        void Permutation(List<SearchAblity> searchAblities, int n, int r)
        {
            if (r == 0)
            {
                List<SearchAblity> searchAblitie = new List<SearchAblity>();
                for (int i = 0; i < tmpAblity.Count; i++)
                {
                    searchAblitie.Add(tmpAblity[i]);
                }
                SearchAblities2.Add(searchAblitie);
            }
            for(int i = n - 1; i >= 0; i--)
            {
                swap(searchAblities[i], searchAblities[n - 1]);
                tmpAblity.Add(searchAblities[n-1]);
                Permutation(searchAblities, n - 1, r - 1);
                tmpAblity.RemoveAt(tmpAblity.Count - 1);
                swap(searchAblities[i], searchAblities[n - 1]);
            }
        }
        internal void swap(SearchAblity a, SearchAblity b)
        {  //값을 이동하기 위한 함수
            SearchAblity tmp = new SearchAblity(a);
            a = new SearchAblity(b);
            b = tmp;
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
                    if (auctionItem.Options[i].Type=="STAT")
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
