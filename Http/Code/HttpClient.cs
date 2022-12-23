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
        public static List<string> APIkeys { get; set; } = new List<string>
        {
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMTA5MjEifQ.kH7FD3hDzAby9kaAFxgOSg3WMNY-5-6w5v9-D1CvEa_oS6aXWXC2GoiJktclrcq4cXCZtSp8ONhjbJe5tJUeN6_w58FZJ77og20DmnidDXaaB_Dvn3UAUjtWBSseXGHESd2yaYpXLrWdjWZxTdYQSxFl59Y-PWM5j2dY3oV8GrtNVYnOd5leyHiyq0cudlTCBiM0EnGlh0g2nuXzxgGIo17Q5riX_uu0O9zeqEXXs2m3fFiMrWgRfp7DK03R-Vd_vp8c7glUuNHzedWa99x8wO6ypDYI9vbYO95JZ3s4yTp8lzqvAOjK6gepKHCBT6F1YlNbvwnGlWoCjWDS6-YG2Q",
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDE1NTkifQ.TMCB8axbC1HD889255PH5c7_WsQz_HIAay5-tX9wbSktNRo2Hkx1qEwi_GRE5-zW4cM8IUfMBroiUb9XJfLc8RV1mY5EZWUqMK0eEc2lanhtgm7oGDKYVdKIYNEZk2AVOq4FYktPvRXSZNYbiLYvdv_KaJ4DDbVN7GP7Ny8Kjs1GoLQvNxmSmZ7uyngSucsyCSiGQmLy0db1iMdIOWZAffF70u5kTdNXwhh5qHJurpueGNSAJNf6b_Tp7b3DIoAHrEnZTjUcyv48geNuCqiEq03ei9MVx-X9MaRIBOL2Y-0dai3Zx7p6tyi7TyCw_DXCo2ZDujQQM_7J-CrEliHp8Q",
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMTA5MzUifQ.IHdHOnxjwLeTG2HnGzEw27l6IwZm7C4CazGEdFwiqBx0dceieJVy7Rhncb88rpjkZGo8cZiZw6_QGiz3aLDMgwW4XIQJ8jhv267tDPHt3ZC3NHDyMiRPv1ChEetFUhXTuK0R7_r_FnLfaFhA-jTsHBcZ0wsidzAxGWSlDEQErhbqo6vHLmSIacOkeS3UuwG_h_sc0sWaI93X_kGiWnjYUZrk58spxiuk_eR8q51Km7KniCg9ogwJHE4MXRRM9CaI9s-7_QzPbjwDO8_9KwDw8JZCv6Ypz7E2JqD3flcU1KwH2gkQ-5pMi3fxtMr_LQfvDkOInmeJRRZiM5wp7unnvg",
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMTA5MzgifQ.XCWgPel0okbF7hbtFXh-xvdyhjYazlgb43HuSScNnAAKhf8qA9zID4We5OYQdzb3U5Peuxa3986PHXIEXN7SedPr_Z3K1MOoufLsHsIGUYzYJ65A0ihByTn4fBgMYl2z_cqe7jeu9CGuALkdddAuHwjMO1AqAn175-6ytYrWCEdPgt8zFO3V8MvP4dgSlHL4JPgWwWM5ZCcsplJfIXBOgTI-3bbFBzEelhq_ffI-mejaVqUKLKje_xEm_iDoT_xvOOTZxDnwJYmuUZLIhJxBEiWbOEJXFRu4amvoPFsbPakQctzox5Uli4hZLvGl_WOh1NMstrYAMEjEmXn3Hv2pfA",
            "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMTA5NDEifQ.alXuifwaIvacx5sEnLLXqSYb6kmG68k0Jtu-guBIphucIXwrAT8u-sZtjci4JmacjPSNKrhpeAeM-bpxNsqzpAi7ZanpiYZlY-OuDSnKzwSKFDld9Kcoq1YgUnS0RdKYniE9bFCpv2p9fqg4inXjm3DTX-aBQ8Lo_T6AN2T8V-vWPvnv-wG9sXW5Ag4zzyet6AcF4Aj8nFKalzXv4RvaWRbtIWpQ8vl8Dg1-KEEZ_NMzi0faT0E6Q97WHtj_-JOBAckptsWBEPdfxWoEXIOAzM7EmKjtnDiyRHL1NsY8Tr_rvDtcqbH6iWRTUGaErzeWqDYIYacdmZvaxPSjv2G2Ow",
        };
        public static HttpClient SharedClient { get; set; } = new HttpClient();
        public HttpClient2() {
            SharedClient = new HttpClient();
            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[0]);
            SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            SharedClient.DefaultRequestHeaders.Add("ContentType","application/json");
        }
        public static async void GetAsync(List<SearchAblity> searchAblitie, Accesories accesory)
        {
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1 = new List<AccVM>();
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1 = new List<AccVM>();
            int cnt = 0;
            int apiKeyidx = 1;
            for (int k = 0; k < 5; k+=2)
            {
                string AcceccesoryType = Ablity.AccessoryCode.Keys.ToList()[k];

                for (int i = 0; i < searchAblitie.Count; i++)
                {
                    int pageNo = 1;
                    SearchItem item = new SearchItem();
                    item.Sort = "ITEM_QUALITY ";
                    item.CategoryCode = Ablity.AccessoryCode[AcceccesoryType];
                    item.ItemGradeQuality = (int)(accesory[AcceccesoryType].Qulity/10)*10;
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 3,
                        SecondOption = Ablity.AblityCode[searchAblitie[i].FirstAblity.Keys.ToList()[0]],
                        MinValue = searchAblitie[i].FirstAblity[searchAblitie[i].FirstAblity.Keys.ToList()[0]]
                    });
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 3,
                        SecondOption = Ablity.AblityCode[searchAblitie[i].SecondAblity.Keys.ToList()[0]],
                        MinValue = searchAblitie[i].SecondAblity[searchAblitie[i].SecondAblity.Keys.ToList()[0]]
                    });
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
                    int pageSize = 0;
                    AuctionItem auctionItem = new AuctionItem();
                    auctionItem.Name = "";
                    int minValue = int.MaxValue;

                    while (true)
                    {
                        Thread.Sleep(1);
                        cnt++;
                        if (cnt >= 100)
                        {
                            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", APIkeys[apiKeyidx]);
                            apiKeyidx++;
                            if (apiKeyidx > 4)
                            {
                                apiKeyidx = 0;
                            }
                            cnt = 0;

                        }
                        item.PageNo = pageNo;
                        ResultItem tmp;
                        StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
                        using (HttpResponseMessage response =  await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", a))
                        {
                            string jsonResponse = await response.Content.ReadAsStringAsync();
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

                                    if (tmp.Items[j].GradeQuality > (accesory[AcceccesoryType].Qulity+10)|| tmp.Items[j].GradeQuality< (accesory[AcceccesoryType].Qulity))
                                    {
                                        isQuality = true;
                                        break;
                                    }
                                    if (tmp.Items[j].AuctionInfo.BuyPrice != 0)
                                    {
                                        bool isSame = false;
                                        AccVM tmp2 = (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.ConvertAuctionItemToAcc(tmp.Items[j], AcceccesoryType);

                                        if (AcceccesoryType == "목걸이")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc.Count; p++) {
                                                if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Contain(tmp2))
                                                {
                                                    if((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p].Price> tmp2.Price)
                                                    {
                                                        (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc[p] = tmp2;
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }else if(AcceccesoryType == "반지2")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1.Count; p++)
                                            {
                                                if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Contain(tmp2))
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p].Price > tmp2.Price)
                                                    {
                                                        (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1[p] = tmp2;
                                                    }
                                                    isSame = true;
                                                    break;
                                                }
                                            }
                                        }
                                        else if (AcceccesoryType == "귀걸이2")
                                        {
                                            for (int p = 0; p < (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1.Count; p++)
                                            {
                                                if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Contain(tmp2))
                                                {
                                                    if ((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p].Price > tmp2.Price)
                                                    {
                                                        (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1[p] = tmp2;
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
                                    break;
                                }
                            }
                            pageNo++;
                            Console.WriteLine(pageNo + " /" + pageSize);  
                        }
                    }
                    if (auctionItem.Name!="")
                    {
                    }
                }
                           // (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc();
            }
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.combination((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1, 0);
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.combination((App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1, 1);
            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.Start();
        }

    }

}
