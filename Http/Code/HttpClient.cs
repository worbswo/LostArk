using Http.Code;
using Http.Model;
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
        public static async Task GetAsync(SearchAblity searchAblitie, Accesories accesory, string AcceccesoryName)
        {
            int pageNo = 1;
            while (true)
            {

                SearchItem item = new SearchItem();
                item.Sort = "GRADE";
                item.CategoryCode = Ablity.AccessoryCode[AcceccesoryName];
                item.PageNo = pageNo;
                item.ItemGradeQuality = accesory[AcceccesoryName].Qulity;
                item.EtcOptions.Add(new EtcOption()
                {
                    FirstOption = 3,
                    SecondOption = Ablity.AblityCode[searchAblitie.FirstAblity.Keys.ToList()[0]],
                    MinValue = searchAblitie.FirstAblity[searchAblitie.FirstAblity.Keys.ToList()[0]]
                });
                item.EtcOptions.Add(new EtcOption()
                {
                    FirstOption = 3,
                    SecondOption = Ablity.AblityCode[searchAblitie.SecondAblity.Keys.ToList()[0]],
                    MinValue = searchAblitie.SecondAblity[searchAblitie.SecondAblity.Keys.ToList()[0]]
                });
                int code = Ablity.CharactericsCode[accesory[AcceccesoryName].Characteristic[0]];
                item.EtcOptions.Add(new EtcOption()
                {
                    FirstOption = 2,
                    SecondOption = code,
                    MaxValue = 500
                });
                if(AcceccesoryName == "목걸이")
                {
                    code = Ablity.CharactericsCode[accesory[AcceccesoryName].Characteristic[1]];
                    item.EtcOptions.Add(new EtcOption()
                    {
                        FirstOption = 2,
                        SecondOption = code,
                        MaxValue = 500
                    });
                }
                StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");
                string jsonResponse = "";
                using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items", a))
                {

                    response.EnsureSuccessStatusCode();
                    jsonResponse = await response.Content.ReadAsStringAsync();

                }

                ResultItem tmp = JsonConvert.DeserializeObject<ResultItem>(jsonResponse);
                if (tmp != null)
                {
                    if (tmp.Items != null)
                    {
                        for (int i = 0; i < tmp.Items.Count; i++)
                        {
                            Console.WriteLine("Name  : " + tmp.Items[i].Name);
                            Console.WriteLine("Grade : " + tmp.Items[i].Grade);
                            Console.WriteLine("Price : " + tmp.Items[i].AuctionInfo.BuyPrice);

                            for (int j = 0; j < tmp.Items[i].Options.Count; j++)
                            {
                                Console.WriteLine("OptionName : " + tmp.Items[i].Options[j].OptionName);
                                Console.WriteLine("Value : " + tmp.Items[i].Options[j].Value);
                                Console.WriteLine("-------------------------------------");

                            }
                            Console.WriteLine("=======================================");
                            if(tmp.Items[i].AuctionInfo.BuyPrice!=0)
                            (App.Current.MainWindow.DataContext as MainWinodwVM).Ablity.SetAcc(tmp.Items[i].Options, (int)tmp.Items[i].AuctionInfo.BuyPrice, AcceccesoryName);

                        }
                    }
                }
                
                pageNo++;
                if(pageNo>tmp.PageSize)
                {
                    break;
                }
            }
        }

    }
}
