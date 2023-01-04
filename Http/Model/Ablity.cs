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
        public List<AccVM> RingAcc1 { get; set; } = new List<AccVM>();
        public List<List<AccVM>> RingAcc2 { get; set; } = new List<List<AccVM>>();
        public List<List<AccVM>> EarAcc2 { get; set; } = new List<List<AccVM>>();
        public List<List<AccVM>> Accs { get; set; } = new List<List<AccVM>>();
        

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

        }
        #region Method
        public void Start()
        {
            Thread = new Thread(SetAcc);
            Thread.Start();
        }
        public void ComputeAblity()
        {
            FirstAblityCandidate = new Dictionary<string, List<int>>();
            SecondAblityCandidate = new Dictionary<string, List<int>>();
            SearchAblities = new List<List<SearchAblity>>();
            SearchAblities2 = new List<List<SearchAblity>>();
            int TargetSum = 0;
            int EquipSum = 0;
            for (int i = 0; i < EquipItems.Count; i++)
            {
                for (int j = 0; j < EquipItems[EquipItems.Keys.ToList()[i]].Count; j++)
                {
                    EquipSum += EquipItems[EquipItems.Keys.ToList()[i]][j];

                    TargetItems[EquipItems.Keys.ToList()[i]] -= EquipItems[EquipItems.Keys.ToList()[i]][j];
                }
            }
            for(int i = 0; i < TargetItems.Count; i++)
            {
                TargetSum += TargetItems[TargetItems.Keys.ToList()[i]];
            }
            int Minus = TargetSum - EquipSum;
            int cnt = 0;
            Dictionary<string, int> tmpItem = new Dictionary<string, int>();
            foreach (var tmp in TargetItems)
            {
                tmpItem.Add(tmp.Key, tmp.Value);
            }

            #region Seperate Ablity
            int firstCnt = 0;
            int secondCnt = 0;

            if (selectClass == 0)
            {
                Minus = 40 - Minus;
                for (int i = 0; i < tmpItem.Count; i++)
                {
                    while (true)
                    {
                        if (tmpItem[tmpItem.Keys.ToList()[i]] / 5 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 5 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 5 == 0))
                        {
                            firstCnt++;
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
                            firstCnt++;
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
                            secondCnt++;
                            if (SecondAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[tmpItem.Keys.ToList()[i]].Add(3);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 3 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 3;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
               
            }
            else
            {
                Minus = 45 - Minus;
                for (int i = 0; i < tmpItem.Count; i++)
                {
                    while (true)
                    {
                        if (tmpItem[tmpItem.Keys.ToList()[i]] / 6 > 0 && (tmpItem[tmpItem.Keys.ToList()[i]] % 6 >= 3 || tmpItem[tmpItem.Keys.ToList()[i]] % 6 == 0))
                        {
                            firstCnt++;
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
                            firstCnt++;
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
                            firstCnt++;
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
                            secondCnt++;
                            if (SecondAblityCandidate.ContainsKey(tmpItem.Keys.ToList()[i]))
                            {
                                SecondAblityCandidate[tmpItem.Keys.ToList()[i]].Add(3);
                            }
                            else
                            {
                                SecondAblityCandidate.Add(tmpItem.Keys.ToList()[i], new List<int> { 3 });
                            }
                            tmpItem[tmpItem.Keys.ToList()[i]] -= 3;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
               
            }
            #endregion

            if (Minus < 0)
            {
                MessageBox.Show("구성할 수 없는 각인 입니다.");
                return;
            }
            else {
                List<SearchAblity> searchAblities = new List<SearchAblity>();
                Dictionary<string, int> firstAblityCandidate = new Dictionary<string, int>();
                Dictionary<string, int> secondAblityCandidate = new Dictionary<string, int>();
        
               
                foreach (var tmp in FirstAblityCandidate)
                {
                    for (int i = 0; i < tmp.Value.Count; i++)
                    {
                        if (firstAblityCandidate.ContainsKey(tmp.Key))
                        { 
                            if (firstAblityCandidate[tmp.Key] > tmp.Value[i])
                            {
                                firstAblityCandidate[tmp.Key]=(tmp.Value[i]);
                            }
                        }
                        else
                        {
                            firstAblityCandidate.Add(tmp.Key, tmp.Value[i]);
                        }
                    }
                }
                foreach (var tmp in SecondAblityCandidate)
                {
                    for (int i = 0; i < tmp.Value.Count; i++)
                    {
                        if (secondAblityCandidate.ContainsKey(tmp.Key))
                        {
                            if (secondAblityCandidate[tmp.Key] > tmp.Value[i])
                            {
                                secondAblityCandidate[tmp.Key] = (tmp.Value[i]);
                            }
                        }
                        else
                        {
                            secondAblityCandidate.Add(tmp.Key, tmp.Value[i]);
                        }
                    }
                }
                if (firstCnt < 5)
                {
                    if (secondCnt < 6)
                    {
                        secondAblityCandidate.Add("random", 3);
                    }
                }
                else
                {
                    if (secondCnt < 5)
                    {
                        secondAblityCandidate.Add("random", 3);

                    }
                }
                foreach (var tmp in firstAblityCandidate)
                {
                    foreach (var tmp2 in secondAblityCandidate)
                    {
                        if (tmp.Key != tmp2.Key)
                        {
                            SearchAblity searchAblity = new SearchAblity();
                            searchAblity.FirstAblity.Add(tmp.Key, tmp.Value);
                            searchAblity.SecondAblity.Add(tmp2.Key, tmp2.Value);
                            searchAblities.Add(searchAblity);
                        }
                    }
                }
                if (firstCnt < 5)
                {
                    for (int i = 0; i < secondAblityCandidate.Count; i++)
                    {
                        if(secondAblityCandidate.Keys.ToList()[i]== "random")
                        {
                            continue;
                        }
                        for (int k = 0; k < secondAblityCandidate.Count; k++)
                        {
                            if (secondAblityCandidate.Keys.ToList()[k] == "random")
                            {
                                continue;
                            }
                            if (secondAblityCandidate.Keys.ToList()[i] != secondAblityCandidate.Keys.ToList()[k])
                            {
                                SearchAblity searchAblity = new SearchAblity();
                                searchAblity.FirstAblity.Add(secondAblityCandidate.Keys.ToList()[i], secondAblityCandidate[secondAblityCandidate.Keys.ToList()[i]]);
                                searchAblity.SecondAblity.Add(secondAblityCandidate.Keys.ToList()[k], secondAblityCandidate[secondAblityCandidate.Keys.ToList()[k]]);
                                searchAblities.Add(searchAblity);
                            }
                        }
                    }
                }
                #region Debug
                  for (int i = 0; i < firstAblityCandidate.Count; i++)
                  {
                      Console.Write(firstAblityCandidate.Keys.ToList()[i] + " : ");
                      
                      Console.Write(firstAblityCandidate[firstAblityCandidate.Keys.ToList()[i]] + " , ");
                      
                      Console.WriteLine("");

                  }
                  Console.WriteLine("----------------------------");
                  for (int i = 0; i < secondAblityCandidate.Count; i++)
                  {
                      Console.Write(secondAblityCandidate.Keys.ToList()[i] + " : ");
                      {
                          Console.Write(secondAblityCandidate[secondAblityCandidate.Keys.ToList()[i]] + " , ");
                      }
                      Console.WriteLine("");

                  }
                  for (int i = 0; i < searchAblities.Count; i++)
                  {
                      foreach (var tmp in searchAblities[i].FirstAblity) { Console.Write("{ " + tmp.Key + " : " + tmp.Value + " , "); }
                      foreach (var tmp in searchAblities[i].SecondAblity) { Console.Write(tmp.Key + " : " + tmp.Value + " }"); }
                      Console.WriteLine();
                  }
                  #endregion

                RingAcc2  = new List<List<AccVM>>();
                EarAcc2 = new List<List<AccVM>>();
                HttpClient2.GetAsync(searchAblities, Accesories);
            }

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
            size = 100000;
            size = size > tmp.Count?tmp.Count:size;
            tmp = tmp.OrderBy(x => (x[0].Price + x[1].Price)).ToList();
            
            for(int i = 0; i < size; i++)
            {
                
                if (type == 0)
                {
                    RingAcc2.Add(tmp[i]);
                }
                else
                {
                    EarAcc2.Add(tmp[i]);
                }
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
            NeckAcc = NeckAcc.OrderBy(x => (x.Price)).ToList();

            NeckAcc = tmp;
        }
        public void SetAcc()
        {
            PanaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
            PanaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
            int checkValue = selectClass == 0 ? 8 : 9;
            uint total = (uint)(RingAcc2.Count * EarAcc2.Count);
            uint cnt = 0;
            for (int i = 0; i < RingAcc2.Count; i++)
            {
                EquipCheck = new Dictionary<string, int>();

                foreach (var tmp in TargetItems)
                {
                    EquipCheck.Add(tmp.Key, tmp.Value);
                }
                PanaltyCheck[RingAcc2[i][0].PenaltyName] += RingAcc2[i][0].PenaltyValue;
                PanaltyCheck[RingAcc2[i][1].PenaltyName] += RingAcc2[i][1].PenaltyValue;
                EquipCheck[RingAcc2[i][1].Name1] -= RingAcc2[i][1].Value1;
                if (EquipCheck.ContainsKey(RingAcc2[i][1].Name2))
                    EquipCheck[RingAcc2[i][1].Name2] -= RingAcc2[i][1].Value2;
                EquipCheck[RingAcc2[i][0].Name1] -= RingAcc2[i][0].Value1;
                if (EquipCheck.ContainsKey(RingAcc2[i][0].Name2))
                    EquipCheck[RingAcc2[i][0].Name2] -= RingAcc2[i][0].Value2;
                if (PanaltyCheck[RingAcc2[i][0].PenaltyName] >= 5 || PanaltyCheck[RingAcc2[i][1].PenaltyName] >= 5)
                {
                    EquipCheck[RingAcc2[i][1].Name1] += RingAcc2[i][1].Value1;
                    if (EquipCheck.ContainsKey(RingAcc2[i][1].Name2))
                        EquipCheck[RingAcc2[i][1].Name2] += RingAcc2[i][1].Value2;
                    EquipCheck[RingAcc2[i][0].Name1] += RingAcc2[i][0].Value1;
                    if (EquipCheck.ContainsKey(RingAcc2[i][0].Name2))
                        EquipCheck[RingAcc2[i][0].Name2] += RingAcc2[i][0].Value2;
                    PanaltyCheck[RingAcc2[i][0].PenaltyName] -= RingAcc2[i][0].PenaltyValue;
                    PanaltyCheck[RingAcc2[i][1].PenaltyName] -= RingAcc2[i][1].PenaltyValue;
                    cnt += (uint)EarAcc2.Count;
                    MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                    continue;
                }
                for(int j = 0; j < EarAcc2.Count; j++)
                {
                    PanaltyCheck[EarAcc2[j][0].PenaltyName] += EarAcc2[j][0].PenaltyValue;
                    PanaltyCheck[EarAcc2[j][1].PenaltyName] += EarAcc2[j][1].PenaltyValue;
                    EquipCheck[EarAcc2[j][1].Name1] -= EarAcc2[j][1].Value1;
                    if (EquipCheck.ContainsKey(EarAcc2[j][1].Name2))
                        EquipCheck[EarAcc2[j][1].Name2] -= EarAcc2[j][1].Value2;
                    EquipCheck[EarAcc2[j][0].Name1] -= EarAcc2[j][0].Value1;
                    if (EquipCheck.ContainsKey(EarAcc2[j][0].Name2))
                        EquipCheck[EarAcc2[j][0].Name2] -= EarAcc2[j][0].Value2;
                    if (PanaltyCheck[EarAcc2[j][0].PenaltyName] >= 5 || PanaltyCheck[EarAcc2[j][1].PenaltyName] >= 5)
                    {
                        EquipCheck[EarAcc2[j][1].Name1] += EarAcc2[j][1].Value1;
                        if (EquipCheck.ContainsKey(EarAcc2[j][1].Name2))
                            EquipCheck[EarAcc2[j][1].Name2] += EarAcc2[j][1].Value2;
                        EquipCheck[EarAcc2[j][0].Name1] += EarAcc2[j][0].Value1;
                        if (EquipCheck.ContainsKey(EarAcc2[j][0].Name2))
                            EquipCheck[EarAcc2[j][0].Name2] += EarAcc2[j][0].Value2;
                        PanaltyCheck[EarAcc2[j][0].PenaltyName] -= EarAcc2[j][0].PenaltyValue;
                        PanaltyCheck[EarAcc2[j][1].PenaltyName] -= EarAcc2[j][1].PenaltyValue;
                        cnt ++;
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
                        EquipCheck[EarAcc2[j][1].Name1] += EarAcc2[j][1].Value1;
                        if (EquipCheck.ContainsKey(EarAcc2[j][1].Name2))
                            EquipCheck[EarAcc2[j][1].Name2] += EarAcc2[j][1].Value2;
                        EquipCheck[EarAcc2[j][0].Name1] += EarAcc2[j][0].Value1;
                        if (EquipCheck.ContainsKey(EarAcc2[j][0].Name2))
                            EquipCheck[EarAcc2[j][0].Name2] += EarAcc2[j][0].Value2;
                        PanaltyCheck[EarAcc2[j][0].PenaltyName] -= EarAcc2[j][0].PenaltyValue;
                        PanaltyCheck[EarAcc2[j][1].PenaltyName] -= EarAcc2[j][1].PenaltyValue;
                        cnt ++;
                        MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                        continue;
                    }
                    List<AccVM> tmp = new List<AccVM>
                    {
                        RingAcc2[i][0],
                        RingAcc2[i][1],
                        EarAcc2[j][0],
                        EarAcc2[j][1]
                    };
                    Accs.Add(tmp);
                   

                    EquipCheck[EarAcc2[j][1].Name1] += EarAcc2[j][1].Value1;
                    if (EquipCheck.ContainsKey(EarAcc2[j][1].Name2))
                        EquipCheck[EarAcc2[j][1].Name2] += EarAcc2[j][1].Value2;
                    EquipCheck[EarAcc2[j][0].Name1] += EarAcc2[j][0].Value1;
                    if (EquipCheck.ContainsKey(EarAcc2[j][0].Name2))
                        EquipCheck[EarAcc2[j][0].Name2] += EarAcc2[j][0].Value2;
                    PanaltyCheck[EarAcc2[j][0].PenaltyName] -= EarAcc2[j][0].PenaltyValue;
                    PanaltyCheck[EarAcc2[j][1].PenaltyName] -= EarAcc2[j][1].PenaltyValue;
                    cnt ++;
                    MainWinodwVM.AccProgressValue = (float)(((double)cnt / total) * 100.0);
                }


                EquipCheck[RingAcc2[i][1].Name1] += RingAcc2[i][1].Value1;
                if (EquipCheck.ContainsKey(RingAcc2[i][1].Name2))
                    EquipCheck[RingAcc2[i][1].Name2] += RingAcc2[i][1].Value2;
                EquipCheck[RingAcc2[i][0].Name1] += RingAcc2[i][0].Value1;
                if (EquipCheck.ContainsKey(RingAcc2[i][0].Name2))
                    EquipCheck[RingAcc2[i][0].Name2] += RingAcc2[i][0].Value2;
                PanaltyCheck[RingAcc2[i][0].PenaltyName] -= RingAcc2[i][0].PenaltyValue;
                PanaltyCheck[RingAcc2[i][1].PenaltyName] -= RingAcc2[i][1].PenaltyValue;
            }
            Accs= Accs.OrderBy(x => (x[0].Price+ x[1].Price+ x[2].Price+ x[3].Price)).ToList();
            Thread2 = new Thread(ResultAcc2);
            Thread2.Start();
        }
        public void ResultAcc2()
        {
            Cnt = 0;
            PanaltyCheck = new Dictionary<string, int> { { "공격력 감소", 0 }, { "공격속도 감소", 0 }, { "방어력 감소", 0 }, { "이동속도 감소", 0 } };
            PanaltyCheck[PanaltyItems.Keys.ToList()[0]] += PanaltyItems[PanaltyItems.Keys.ToList()[0]];
            int size = int.MaxValue;
            size = size > Accs.Count ? Accs.Count : size;
            TotalValue = (uint)(NeckAcc.Count * size);

            for (int i=0;i<NeckAcc.Count;i++)
            {
                EquipCheck.Clear();

                foreach (var tmp in TargetItems)
                {
                    EquipCheck.Add(tmp.Key, tmp.Value);
                }
                PanaltyCheck[NeckAcc[i].PenaltyName] += NeckAcc[i].PenaltyValue;
                EquipCheck[NeckAcc[i].Name1] -= NeckAcc[i].Value1;
                if (EquipCheck.ContainsKey(NeckAcc[i].Name2))
                    EquipCheck[NeckAcc[i].Name2] -= NeckAcc[i].Value2;
                if (PanaltyCheck[NeckAcc[i].PenaltyName] >= 5 )
                {
                    PanaltyCheck[NeckAcc[i].PenaltyName] -= NeckAcc[i].PenaltyValue;
                    Cnt+=(uint)Accs.Count;
                    MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                    continue;
                }
                for (int j = 0; j < size; j++)
                { 
                    bool check2 = false;
                    for(int k = 0; k < Accs[j].Count; k++)
                    {
                        PanaltyCheck[Accs[j][k].PenaltyName] += Accs[j][k].PenaltyValue;

                        EquipCheck[Accs[j][k].Name1] -= Accs[j][k].Value1;
                        if (EquipCheck.ContainsKey(Accs[j][k].Name2))
                            EquipCheck[Accs[j][k].Name2] -= Accs[j][k].Value2;

                        if(PanaltyCheck[Accs[j][k].PenaltyName] >= 5)
                        {
                            check2= true;
                        }
                    }
                    if (check2)
                    {
                        for (int k = 0; k < Accs[j].Count; k++)
                        {
                            PanaltyCheck[Accs[j][k].PenaltyName] -= Accs[j][k].PenaltyValue;

                            EquipCheck[Accs[j][k].Name1] += Accs[j][k].Value1;
                            if (EquipCheck.ContainsKey(Accs[j][k].Name2))
                                EquipCheck[Accs[j][k].Name2] += Accs[j][k].Value2;
                        }
                        Cnt ++;
                        MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                        continue;
                    }
                    var check = EquipCheck.Where(x => x.Value > 0).ToList();
                    if (check.Count == 0)
                    {
                        int value1 = NeckAcc[i].FirstCharValue;
                        int value2 = NeckAcc[i].SecondCharValue;

                        if (NeckAcc[i].FirstCharaterics == Accs[j][0].FirstCharaterics) value1 += Accs[j][0].FirstCharValue;
                        if (NeckAcc[i].FirstCharaterics == Accs[j][1].FirstCharaterics) value1 += Accs[j][1].FirstCharValue;
                        if (NeckAcc[i].FirstCharaterics == Accs[j][2].FirstCharaterics) value1 += Accs[j][2].FirstCharValue;
                        if (NeckAcc[i].FirstCharaterics == Accs[j][3].FirstCharaterics) value1 += Accs[j][3].FirstCharValue;
                        if (NeckAcc[i].Secondcharaterics == Accs[j][0].FirstCharaterics) value2 += Accs[j][0].FirstCharValue;
                        if (NeckAcc[i].Secondcharaterics == Accs[j][1].FirstCharaterics) value2 += Accs[j][1].FirstCharValue;
                        if (NeckAcc[i].Secondcharaterics == Accs[j][2].FirstCharaterics) value2 += Accs[j][2].FirstCharValue;
                        if (NeckAcc[i].Secondcharaterics == Accs[j][3].FirstCharaterics) value2 += Accs[j][3].FirstCharValue;
                        FindAccVM findAccVM = new FindAccVM
                        {
                            NeckAblity = NeckAcc[i],
                            FirstRingAblity = Accs[j][0],
                            SecondRingAblity = Accs[j][1],
                            FirstEarAblity = Accs[j][2],
                            SecondEarAblity = Accs[j][3],
                            TotalPrice = NeckAcc[i].Price + Accs[j][0].Price + Accs[j][1].Price + Accs[j][2].Price + Accs[j][3].Price
                        };
                        if (value1 > value2)
                        {
                            findAccVM.TotalFirstChar = value1;
                            findAccVM.TotalSecondChar = value2;
                            findAccVM.FirstChar = NeckAcc[i].FirstCharaterics;
                            findAccVM.SecondChar = NeckAcc[i].Secondcharaterics;
                        }
                        else
                        {
                            findAccVM.TotalFirstChar = value2;
                            findAccVM.TotalSecondChar = value1;
                            findAccVM.FirstChar = NeckAcc[i].Secondcharaterics;
                            findAccVM.SecondChar = NeckAcc[i].FirstCharaterics;
                        }
                        MainWinodwVM.FindAccVMs.Add(findAccVM);
                    }
                    for (int k = 0; k < Accs[j].Count; k++)
                    {
                        PanaltyCheck[Accs[j][k].PenaltyName] -= Accs[j][k].PenaltyValue;

                        EquipCheck[Accs[j][k].Name1] += Accs[j][k].Value1;
                        if (EquipCheck.ContainsKey(Accs[j][k].Name2))
                            EquipCheck[Accs[j][k].Name2] += Accs[j][k].Value2;
                    }
                    Cnt++;
                    MainWinodwVM.ProgressValue = (float)(((double)Cnt / TotalValue) * 100.0);
                }
                PanaltyCheck[NeckAcc[i].PenaltyName] -= NeckAcc[i].PenaltyValue;
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
