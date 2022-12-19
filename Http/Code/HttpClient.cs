using Http.Code;
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
        static HttpClient SharedClient { get; set; } = new HttpClient();
        public HttpClient2() {
            SharedClient = new HttpClient();
            SharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDE1NTkifQ.TMCB8axbC1HD889255PH5c7_WsQz_HIAay5-tX9wbSktNRo2Hkx1qEwi_GRE5-zW4cM8IUfMBroiUb9XJfLc8RV1mY5EZWUqMK0eEc2lanhtgm7oGDKYVdKIYNEZk2AVOq4FYktPvRXSZNYbiLYvdv_KaJ4DDbVN7GP7Ny8Kjs1GoLQvNxmSmZ7uyngSucsyCSiGQmLy0db1iMdIOWZAffF70u5kTdNXwhh5qHJurpueGNSAJNf6b_Tp7b3DIoAHrEnZTjUcyv48geNuCqiEq03ei9MVx-X9MaRIBOL2Y-0dai3Zx7p6tyi7TyCw_DXCo2ZDujQQM_7J-CrEliHp8Q");
            SharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            SharedClient.DefaultRequestHeaders.Add("ContentType","application/json");
            GetAsync();
        }
        static async Task GetAsync()
        {
            Item item = new Item();
            item.Sort = "GRADE";
            item.CategoryCode = 200020;
            EtcOption etcOption = new EtcOption();
            etcOption.FirstOption = 3;
            etcOption.SecondOption = 118;
            item.EtcOptions.Add(new EtcOption() {
                FirstOption = 3,
                SecondOption = 118,
            MinValue=6});
            item.EtcOptions.Add(new EtcOption()
            {
                FirstOption=3,
                SecondOption= 247,
            });
            item.EtcOptions.Add(new EtcOption()
            {
                FirstOption = 2,
                SecondOption = 16,
                MaxValue=500
            });
            StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8,"application/json");
            Console.WriteLine(JsonConvert.SerializeObject(item));

            using (HttpResponseMessage response = await SharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items",a))
            {

                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonResponse);
                Item tmp = JsonConvert.DeserializeObject<Item>(jsonResponse);
            }
        }
        
    }
}
