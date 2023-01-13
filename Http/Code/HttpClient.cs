using LostArkAction.Code;
using LostArkAction.Model;
using LostArkAction.View;
using LostArkAction.viewModel;
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

namespace LostArkAction.Code
{


    public class HttpClient2
    {
        public static List<string> APIkeys { get; set; } = new List<string>();
        public static int Cnt = 0;

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
        public static async void GetAsync(List<SearchAblity> searchAblitie, Accesories accesory)
        {
            int apiKeyidx = 0;
            int searchTotal = 0;
            int searchCnt = 0;

            searchTotal = 3 * searchAblitie.Count;

            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1 = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1 = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2 = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2 = new List<AccVM>();
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
                        for (int i = 0;i< (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1.Count; i++) {
                            if (accesory[AcceccesoryType].Qulity <= (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[i].Quality)
                            {
                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2.Add(new AccVM((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[i]));
                            }
                        }
                        continue;
                    }
                }
                else if (AcceccesoryType.Contains("귀걸이2"))
                {
                    if (accesory[AcceccesoryType].Characteristic[0] == accesory["귀걸이1"].Characteristic[0])
                    {
                        for (int i = 0; i < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1.Count; i++)
                        {
                            if (accesory[AcceccesoryType].Qulity <= (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[i].Quality)
                            {
                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2.Add(new AccVM((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[i]));
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
                    AuctionItem auctionItem = new AuctionItem();
                    auctionItem.Name = "";

                    while (true)
                    {
                        item.PageNo = pageNo;
                        ResultItem tmp = new ResultItem() ;
                        using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json")))
                        {
                            if(response.StatusCode== HttpStatusCode.OK)
                            {
                                string jsonString = await response.Content.ReadAsStringAsync();
                                tmp = JsonConvert.DeserializeObject<ResultItem>(jsonString);
                            }
                            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                            {
                                MessageBox.Show("API key is failed");
                                continue;
                            }
                            else if(response.StatusCode.ToString() =="429")
                            {
                                apiKeyidx++;
                                if (apiKeyidx > APIkeys.Count - 1)
                                {
                                    apiKeyidx = 0;
                                }
                                SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[apiKeyidx]);
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
                                    if (tmp.Items[j].AuctionInfo.BuyPrice != 0 && tmp.Items[j].AuctionInfo.BuyPrice != null)
                                    {
                                        bool isSame = false;
                                        bool isRandom = searchAblitie[i].SecondAblity.Keys.ToList()[0] == "random";
                                        AccVM tmp2 = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.ConvertAuctionItemToAcc(tmp.Items[j], AcceccesoryType);

                                        if (AcceccesoryType == "목걸이")
                                        {
                                            isSame=MatchingAcc((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "반지1")
                                        {
                                            isSame = MatchingAcc((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "반지2")
                                        {
                                            isSame = MatchingAcc((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "귀걸이1")
                                        {
                                            isSame = MatchingAcc((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1, tmp2, isRandom);
                                        }
                                        else if (AcceccesoryType == "귀걸이2")
                                        {
                                            isSame = MatchingAcc((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2, tmp2, isRandom);
                                        }
                                        if (!isSame)
                                        {
                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc(tmp.Items[j], AcceccesoryType);
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
                    (App.Current.MainWindow.DataContext as MainWinodwVM).SearchProgressValue = (float)searchCnt / searchTotal * 100;
                }
            }
            Console.WriteLine("검색완료");
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.Start();
        }
        public static bool MatchingAcc(List<AccVM> Accs, AccVM inputAccVM, bool isRandom)
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
    }
    
}
