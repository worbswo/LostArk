using Engrave.Code;
using Engrave.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Engrave.Code
{


    public class HttpClient2
    {

        #region Field
        public delegate void SetProgressbarEventHandler(ProgressBarType type, float value);
        public delegate void SetProgressBarTextEventHandler(ProgressBarType type, string value);
        public delegate bool GetLimitedEventHandler();

        #endregion
        public static event SetProgressbarEventHandler SetProgressbar;
        public static event SetProgressBarTextEventHandler SetProgressBarText;
        public static event GetLimitedEventHandler GetLimitedEvent;

        #region Event
        #endregion
        public static List<string> APIkeys { get; set; } = new List<string>();
        public static List<bool> CheckAPILimit = new List<bool>();
        public static List<int> APILimitTime = new List<int>();
        public static int Cnt = 0;
        public static int minTime = int.MaxValue;
        private static int minmumAPiKey = 0;
        public static HttpClient SharedClient { get; set; } = new HttpClient();
        public HttpClient2()
        {
            SharedClient = new HttpClient();
            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[0]);
            SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            SharedClient.DefaultRequestHeaders.Add("ContentType", "application/json");
        }
        public static async void testAPIKey()
        {
            SharedClient = new HttpClient();
            for (int i = 0; i < APIkeys.Count; i++)
            {
                SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[i]);
                SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                using (HttpResponseMessage response = await SharedClient.GetAsync("https://developer-lostark.game.onstove.com/auctions/options"))
                {
                     if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show(i + 1 + "번째 API KEY가 올바르지 않습니다.");
                    }
                }
            }
        }
        public static async void GetAsync(List<SearchAblity> searchAblitie, Accesories accesory, Ablity ablity)
        {
            int apiKeyidx = 0;
            int searchTotal = 0;
            int searchCnt = 0;

            searchTotal = 3 * searchAblitie.Count;
            if (accesory["반지1"].Characteristic[0] != accesory["반지2"].Characteristic[0])
            {
                searchTotal += searchAblitie.Count;
            }
            if (accesory["귀걸이1"].Characteristic[0] != accesory["귀걸이2"].Characteristic[0])
            {
                searchTotal += searchAblitie.Count;
            }
            ablity.NeckAcc = new List<AccInfo>();
            ablity.RingAcc1 = new List<AccInfo>();
            ablity.EarAcc1 = new List<AccInfo>();
            ablity.RingAcc2 = new List<AccInfo>();
            ablity.EarAcc2 = new List<AccInfo>();
            for (int k = 0; k < 5; k++)
            {
                string AcceccesoryType = Ablity.AccessoryCode.Keys.ToList()[k];
                int qulity = (int)(accesory[AcceccesoryType].Qulity);
                if (AcceccesoryType.Contains("반지1"))
                {
                    if (accesory[AcceccesoryType].Characteristic[0] == accesory["반지2"].Characteristic[0])
                    {
                       if(accesory[AcceccesoryType].Qulity> accesory["반지2"].Qulity)
                        {
                            qulity = accesory["반지2"].Qulity;
                            accesory["반지2"].Qulity = accesory["반지1"].Qulity;
                        }
                    }
                }
                else if (AcceccesoryType.Contains("귀걸이1"))
                {
                    if (accesory[AcceccesoryType].Characteristic[0] == accesory["귀걸이2"].Characteristic[0])
                    {
                        if (accesory[AcceccesoryType].Qulity > accesory["귀걸이2"].Qulity)
                        {
                            qulity = accesory["귀걸이2"].Qulity;
                            accesory["귀걸이2"].Qulity = accesory["귀걸이1"].Qulity;

                        }
                    }
                }
                if (AcceccesoryType.Contains("반지2"))
                {
                    if (accesory[AcceccesoryType].Characteristic[0] == accesory["반지1"].Characteristic[0])
                    {
                        for (int i = 0;i< ablity.RingAcc1.Count; i++) {
                            if (accesory[AcceccesoryType].Qulity <= ablity.RingAcc1[i].Quality)
                            {
                                ablity.RingAcc2.Add(new AccInfo(ablity.RingAcc1[i]));
                            }
                        }
                        continue;
                    }
                }
                else if (AcceccesoryType.Contains("귀걸이2"))
                {
                    if (accesory[AcceccesoryType].Characteristic[0] == accesory["귀걸이1"].Characteristic[0])
                    {
                        for (int i = 0; i < ablity.EarAcc1.Count; i++)
                        {
                            if (accesory[AcceccesoryType].Qulity <= ablity.EarAcc1[i].Quality)
                            {
                                ablity.EarAcc2.Add(new AccInfo(ablity.EarAcc1[i]));
                            }
                        }

                        continue;
                    }
                }
                for (int i = 0; i < searchAblitie.Count; i++)
                {
                    int pageNo = 1;
                    SearchItem item = new SearchItem();
                    item.Sort = "BUY_PRICE";
                    if (Ablity.selectClass == 0)
                    {
                        item.ItemGrade = "유물";
                    }
                    else if (Ablity.selectClass == 1)
                    {
                        item.ItemGrade = "고대";
                    }
                    else
                    {
                        item.ItemGrade = "";
                    }
                    item.CategoryCode = Ablity.AccessoryCode[AcceccesoryType];
                    item.ItemGradeQuality = (int)(qulity);
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 3,
                        SecondOption = Ablity.AblityCode[searchAblitie[i].FirstAblity.Keys.ToList()[0]],
                        MinValue = searchAblitie[i].FirstAblity[searchAblitie[i].FirstAblity.Keys.ToList()[0]],
                        MaxValue = searchAblitie[i].FirstAblity[searchAblitie[i].FirstAblity.Keys.ToList()[0]],

                    });
                    if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                    {
                        item.EtcOptions.Add(new EtcOption()
                        {
                            FirstOption = 3,
                            SecondOption = Ablity.AblityCode[searchAblitie[i].SecondAblity.Keys.ToList()[0]],
                            MinValue = searchAblitie[i].SecondAblity[searchAblitie[i].SecondAblity.Keys.ToList()[0]],

                        });
                    }
                    int code = Ablity.CharactericsCode[accesory[AcceccesoryType].Characteristic[0]];
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 2,
                        SecondOption = code,
                        MaxValue = 500
                    });
                    if (AcceccesoryType == "목걸이")
                    {
                        code = Ablity.CharactericsCode[accesory[AcceccesoryType].Characteristic[1]];
                        item.EtcOptions.Add(new EtcOption()
                        {
                            FirstOption = 2,
                            SecondOption = code,
                            MaxValue = 500
                        });
                    }
                    while (true)
                    {
                        item.PageNo = pageNo;
                        ResultItem tmp = new ResultItem();
                        bool apiKeyLimitCheck = false;
                        for(int keyIndex =0;keyIndex < APIkeys.Count; keyIndex++)
                        {
                            if (CheckAPILimit[keyIndex])
                            {
                                apiKeyLimitCheck = true;
                                break;
                            }
                        }
                        if (!apiKeyLimitCheck)
                        {

                            await Task.Delay(1000);
                            int currentTime = (int)GetTime();
                            SetProgressbar(ProgressBarType.WaitAPI, (float)((minTime - currentTime)) / 60.0f * 100);
                            SetProgressBarText(ProgressBarType.WaitAPI, String.Format("API Key reset Time : {0}s...", (minTime - currentTime)));
                            if (minTime <= currentTime)
                            {
                            SetProgressbar(ProgressBarType.WaitAPI, (float)((minTime - currentTime)) / 60.0f * 100);
                            SetProgressBarText(ProgressBarType.WaitAPI, String.Format("API Key reset Time : {0}s...", (minTime - currentTime)));
                            for (int keyIndex = 0; keyIndex < APIkeys.Count; keyIndex++)
                                {
                                    CheckAPILimit[keyIndex] = true;
                                }
                                minTime = int.MaxValue;
                                apiKeyLimitCheck = true;
                                apiKeyidx = minmumAPiKey;
                            }
                            else
                            {
                                continue;
                            }
                            
                        }
                        using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")))
                        {
                            if(response.StatusCode== HttpStatusCode.OK)
                            {
                                string jsonString = await response.Content.ReadAsStringAsync();
                                tmp = JsonConvert.DeserializeObject<ResultItem>(jsonString);
                                CheckAPILimit[apiKeyidx] = true;
                                try
                                {
                                    foreach (var reset in response.Headers.ToList()[2].Value)
                                    {
                                        if (reset != null || reset != "")
                                            APILimitTime[apiKeyidx] = Convert.ToInt32(reset);
                                    }
                                }
                                catch
                                {
                                }
                                if (minTime > APILimitTime[apiKeyidx])
                                {
                                    minTime = APILimitTime[apiKeyidx];
                                    minmumAPiKey = apiKeyidx;
                                }
                            }
                            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                MessageBox.Show("API key is failed");
                                continue;
                            }
                            else if(response.StatusCode.ToString() =="429")
                            {
                                CheckAPILimit[apiKeyidx] = false;
                                try
                                {
                                    foreach (var reset in response.Headers.ToList()[2].Value)
                                    {
                                        if (reset != null || reset != "")
                                            APILimitTime[apiKeyidx] = Convert.ToInt32(reset);
                                    }
                                }
                                catch
                                {
                                }
                                if (minTime > APILimitTime[apiKeyidx])
                                {
                                    minTime = APILimitTime[apiKeyidx];
                                    minmumAPiKey = apiKeyidx;

                                }
                                apiKeyidx++;
                                if (apiKeyidx > APIkeys.Count - 1)
                                {
                                    apiKeyidx = 0;
                                }
                                SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[apiKeyidx]);
                                continue;
                            }else if(response.StatusCode == HttpStatusCode.BadRequest)
                            {
                                continue;
                            }
                        }
                        if (tmp != null)
                        {
                            if (tmp.TotalCount == 0)
                            {
                                break;
                            }
                            if (tmp.Items != null)
                            {
                                for (int j = 0; j < tmp.Items.Count; j++)
                                {
                                    if (GetLimitedEvent())
                                    {
                                        if (tmp.Items[j].AuctionInfo.TradeAllowCount < 2)
                                        {
                                            continue;
                                        }
                                    }
                                    if (tmp.Items[j].AuctionInfo.BuyPrice != 0 && tmp.Items[j].AuctionInfo.BuyPrice != null)
                                    {
                                        bool isSame = false;
                                        bool isRandom = searchAblitie[i].SecondAblity.Keys.ToList()[0] == "random";
                                        AccInfo tmp2 = ablity.ConvertAuctionItemToAcc(tmp.Items[j], AcceccesoryType);

                                        if (AcceccesoryType == "목걸이")
                                        {
                                            isSame=MatchingAcc(ablity.NeckAcc, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "반지1")
                                        {
                                            isSame = MatchingAcc(ablity.RingAcc1, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "반지2")
                                        {
                                            isSame = MatchingAcc(ablity.RingAcc2, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "귀걸이1")
                                        {
                                            isSame = MatchingAcc(ablity.EarAcc1, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "귀걸이2")
                                        {
                                            isSame = MatchingAcc(ablity.EarAcc2, tmp2, isRandom);
                                        }
                                        if (!isSame)
                                        {
                                            ablity.SetAcc(tmp.Items[j], AcceccesoryType);
                                        }
                                    }
                                }                               
                                pageNo++;
                                if(pageNo > tmp.TotalCount / 10 + 1)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                        }
                    }
                    searchCnt++;
                    SetProgressbar(ProgressBarType.Search, (float)searchCnt / searchTotal * 100);
                    SetProgressBarText(ProgressBarType.Search, String.Format("{0} / {1}", searchCnt, searchTotal));
                }
            }
            Console.WriteLine("검색완료");
            ablity.Start();
        }
        public static bool MatchingAcc(List<AccInfo> Accs, AccInfo inputAccVM, bool isRandom)
        {
            bool isSame = false;
            for (int p = 0; p < Accs.Count; p++)
            {
                bool check = false;

                check = isRandom ? Accs[p].Contain(inputAccVM, true):Accs[p].Contain(inputAccVM);

                if (check)
                {
                    if (Accs[p].Price >= inputAccVM.Price)
                    {
                        if (Accs[p].Price == inputAccVM.Price)
                        {
                            if (Accs[p].Quality < inputAccVM.Quality)
                            {
                                Accs[p] = inputAccVM;
                            }
                        }
                        else
                        {
                            Accs[p] = inputAccVM;
                        }
                    }
                    isSame = true;
                    break;
                }
            }
            return isSame;
        }
        public static long GetTime()
        {
            DateTime dtCurTime = DateTime.Now.ToUniversalTime();

            DateTime dtEpochStartTime = Convert.ToDateTime("1/1/1970 0:00:00 AM");

            TimeSpan ts = dtCurTime.Subtract(dtEpochStartTime);

            double epochtime;

            epochtime = ((((((ts.Days * 24) + ts.Hours) * 60) + ts.Minutes) * 60) + ts.Seconds);

            return Convert.ToInt64(epochtime);
        }
    }
   
}
