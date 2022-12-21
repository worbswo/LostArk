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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LostArkAction.Code
{
   

    public class HttpClient2
    {
        public static HttpClient SharedClient { get; set; } = new HttpClient();
        public HttpClient2() {
            SharedClient = new HttpClient();
            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDE1NTkifQ.TMCB8axbC1HD889255PH5c7_WsQz_HIAay5-tX9wbSktNRo2Hkx1qEwi_GRE5-zW4cM8IUfMBroiUb9XJfLc8RV1mY5EZWUqMK0eEc2lanhtgm7oGDKYVdKIYNEZk2AVOq4FYktPvRXSZNYbiLYvdv_KaJ4DDbVN7GP7Ny8Kjs1GoLQvNxmSmZ7uyngSucsyCSiGQmLy0db1iMdIOWZAffF70u5kTdNXwhh5qHJurpueGNSAJNf6b_Tp7b3DIoAHrEnZTjUcyv48geNuCqiEq03ei9MVx-X9MaRIBOL2Y-0dai3Zx7p6tyi7TyCw_DXCo2ZDujQQM_7J-CrEliHp8Q");
            SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            SharedClient.DefaultRequestHeaders.Add("ContentType","application/json");
        }
        public static async void GetAsync(List<List<SearchAblity>> searchAblitie, Accesories accesory)
        {
            
            for (int k = 0; k < searchAblitie.Count; k++)
            {
                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.NeckAcc = new List<AccVM>();
                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc2 = new List<AccVM>();
                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.RingAcc1 = new List<AccVM>();
                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc1 = new List<AccVM>();
                (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.EarAcc2 = new List<AccVM>();
                for (int i = 0; i < searchAblitie[k].Count; i++)
                {
                    int pageNo = 1;
                    string AcceccesoryType = Ablity.AccessoryCode.Keys.ToList()[i];
                    SearchItem item = new SearchItem();
                    item.Sort = "GRADE";
                    item.CategoryCode = Ablity.AccessoryCode[AcceccesoryType];
                    item.ItemGradeQuality = accesory[AcceccesoryType].Qulity;
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 3,
                        SecondOption = Ablity.AblityCode[searchAblitie[k][i].FirstAblity.Keys.ToList()[0]],
                        MinValue = searchAblitie[k][i].FirstAblity[searchAblitie[k][i].FirstAblity.Keys.ToList()[0]]
                    });
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 3,
                        SecondOption = Ablity.AblityCode[searchAblitie[k][i].SecondAblity.Keys.ToList()[0]],
                        MinValue = searchAblitie[k][i].SecondAblity[searchAblitie[k][i].SecondAblity.Keys.ToList()[0]]
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
                    while (true)
                    {

                        item.PageNo = pageNo;

                        StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
                        string jsonResponse = "";
                        using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", a))
                        {
                            jsonResponse = await response.Content.ReadAsStringAsync();
                            ResultItem tmp = JsonConvert.DeserializeObject<ResultItem>(jsonResponse);
                            if (tmp != null)
                            {
                                
                                pageSize = tmp.PageSize;
                                if (tmp.Items != null)
                                {
                                    
                                    for (int j = 0; j < tmp.Items.Count; j++)
                                    {
                                        /*Console.WriteLine("Name  : " + tmp.Items[j].Name);
                                        Console.WriteLine("Grade : " + tmp.Items[j].Grade);
                                        Console.WriteLine("Price : " + tmp.Items[j].AuctionInfo.BuyPrice);

                                        for (int o = 0; o < tmp.Items[j].Options.Count; o++)
                                        {
                                            Console.WriteLine("OptionName : " + tmp.Items[j].Options[o].OptionName);
                                            Console.WriteLine("Value : " + tmp.Items[j].Options[o].Value);
                                            Console.WriteLine("-------------------------------------");

                                        }
                                        Console.WriteLine("=======================================");*/
                                        if (tmp.Items[j].AuctionInfo.BuyPrice != 0)
                                        {
                                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc(tmp.Items[j], AcceccesoryType);

                                        }
                                    }
                                    
                                    
                                    
                                    
                                    
                                }
                                else
                                {
                                    break;
                                }
                                pageNo++;
                                Console.WriteLine(pageNo + " /" + pageSize);
                                if (pageNo > pageSize)
                                {
                                    break;
                                }
                            }else
                            {
                                break;
                            }
                        }
                    }
                }
                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc();

            }
                    (App.Current.MainWindow.DataContext as MainWinodwVM).OpenFindACC();

        }

    }

}
