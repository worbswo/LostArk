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
                    item.Sort = "ITEM_QUALITY";
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
                    item.ItemGradeQuality = (int)(qulity/ 10) * 10;
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

                        Cnt++;
                        if (Cnt >= 90)
                        {
                            apiKeyidx++;
                            if (apiKeyidx > APIkeys.Count - 1)
                            {
                                apiKeyidx = 0;
                            }
                            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[apiKeyidx]);

                            Cnt = 0;

                        }
                        item.PageNo = pageNo;
                        ResultItem tmp;
                        StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
                        using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", a))
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
                            if (jsonResponse.Contains("Rate Limit Exceeded") || jsonResponse.Contains("Unauthorized"))
                            {
                                apiKeyidx++;
                                if (apiKeyidx > APIkeys.Count - 1)
                                {
                                    apiKeyidx = 0;
                                }
                                SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[apiKeyidx]);

                                Cnt = 0;
                                continue;
                            }
                            tmp = JsonConvert.DeserializeObject<ResultItem>(jsonResponse);
                        }

                        if (tmp != null)
                        {
                            if (tmp.TotalCount == 0)
                            {
                                break;
                            }
                            if (tmp.Items != null)
                            {
                                bool isQuality = false;

                                for (int j = 0; j < tmp.Items.Count; j++)
                                {

                                    if (tmp.Items[j].GradeQuality < (qulity))
                                    {
                                        isQuality = true;
                                        continue;
                                    }
                                    if (tmp.Items[j].AuctionInfo.BuyPrice != 0 && tmp.Items[j].AuctionInfo.BuyPrice != null)
                                    {
                                        bool isSame = false;
                                        AccVM tmp2 = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.ConvertAuctionItemToAcc(tmp.Items[j], AcceccesoryType);

                                        if (AcceccesoryType == "목걸이")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc.Count; p++)
                                            {
                                                bool check = false;
                                                if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Contain(tmp2);
                                                }
                                                else
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Contain(tmp2, true);
                                                }
                                                if (check)
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Price >= tmp2.Price)
                                                    {
                                                        if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Price == tmp2.Price)
                                                        {
                                                            if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Quality < tmp2.Quality)
                                                            {
                                                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p] = tmp2;
                                                            }

                                                        }
                                                        else
                                                        {
                                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p] = tmp2;
                                                        }
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (AcceccesoryType == "반지1")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1.Count; p++)
                                            {
                                                bool check = false;
                                                if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Contain(tmp2);
                                                }
                                                else
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Contain(tmp2, true);
                                                }
                                                if (check)
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Price >= tmp2.Price)
                                                    {
                                                        if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Price == tmp2.Price)
                                                        {
                                                            if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Quality < tmp2.Quality)
                                                            {
                                                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p] = tmp2;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p] = tmp2;
                                                        }
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (AcceccesoryType == "반지2")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2.Count; p++)
                                            {
                                                bool check = false;
                                                if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p].Contain(tmp2);
                                                }
                                                else
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p].Contain(tmp2, true);
                                                }
                                                if (check)
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p].Price >= tmp2.Price)
                                                    {
                                                        if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p].Price == tmp2.Price)
                                                        {
                                                            if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p].Quality < tmp2.Quality)
                                                            {
                                                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p] = tmp2;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2[p] = tmp2;
                                                        }
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (AcceccesoryType == "귀걸이1")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1.Count; p++)
                                            {
                                                bool check = false;
                                                if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Contain(tmp2);
                                                }
                                                else
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Contain(tmp2, true);
                                                }
                                                if (check)
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Price >= tmp2.Price)
                                                    {
                                                        if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Price == tmp2.Price)
                                                        {
                                                            if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Quality < tmp2.Quality)
                                                            {
                                                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p] = tmp2;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p] = tmp2;
                                                        }
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (AcceccesoryType == "귀걸이2")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2.Count; p++)
                                            {
                                                bool check = false;
                                                if (searchAblitie[i].SecondAblity.Keys.ToList()[0] != "random")
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p].Contain(tmp2);
                                                }
                                                else
                                                {
                                                    check = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p].Contain(tmp2, true);
                                                }
                                                if (check)
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p].Price >= tmp2.Price)
                                                    {
                                                        if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p].Price == tmp2.Price)
                                                        {
                                                            if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p].Quality < tmp2.Quality)
                                                            {
                                                                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p] = tmp2;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2[p] = tmp2;
                                                        }
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        if (!isSame)
                                        {
                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc(tmp.Items[j], AcceccesoryType);
                                        }
                                    }
                                }
                                if (isQuality)
                                {
                                  //  break;
                                }
                                pageNo++;
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
                    if (auctionItem.Name != "")
                    {
                    }
                    searchCnt++;
                    (App.Current.MainWindow.DataContext as MainWinodwVM).SearchProgressValue = (float)searchCnt / searchTotal * 100;
                }
            }
            Console.WriteLine("검색완료");
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.Start();
        }

    }

}
