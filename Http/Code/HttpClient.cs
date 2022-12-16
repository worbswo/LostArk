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

namespace Http.Code
{
    public class Item
    {
        public int ItemLevelMin = 0;
        public int ItemLevelMax = 1700;
        public int ItemGradeQuality=10;
        public List<SkillOption> SkillOptions = new List<SkillOption>();
        public List<EtcOptions> EtcOptions = new List<EtcOptions>(); 
        public string Sort= "ITEM_GRADE";
        public int CategoryCode;
        public string CharacterClass;
        public int ItemTier=3;
        public string ItemGrade="유물";
        public int PageNo=1;
        public string SortCondition= "ASC";

    }
    public class SkillOption
    {
        public int FirstOption;
        public int SecondOption;
        public int MinValue;
        public int MaxValue;
    }
    public class EtcOptions
    {
        public int FirstOption;
        public int SecondOption;
        public int MinValue;
        public int MaxValue;
    }

    public class HttpClient2
    {
        static HttpClient sharedClient = new HttpClient()
        {
            BaseAddress = new Uri("https://developer-lostark.game.onstove.com/guilds/rankings?serverName=%EB%A3%A8%ED%8E%98%EC%98%A8"),
        };
        public HttpClient2() {
            sharedClient = new HttpClient();
            sharedClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyIsImtpZCI6IktYMk40TkRDSTJ5NTA5NWpjTWk5TllqY2lyZyJ9.eyJpc3MiOiJodHRwczovL2x1ZHkuZ2FtZS5vbnN0b3ZlLmNvbSIsImF1ZCI6Imh0dHBzOi8vbHVkeS5nYW1lLm9uc3RvdmUuY29tL3Jlc291cmNlcyIsImNsaWVudF9pZCI6IjEwMDAwMDAwMDAwMDE1NTkifQ.TMCB8axbC1HD889255PH5c7_WsQz_HIAay5-tX9wbSktNRo2Hkx1qEwi_GRE5-zW4cM8IUfMBroiUb9XJfLc8RV1mY5EZWUqMK0eEc2lanhtgm7oGDKYVdKIYNEZk2AVOq4FYktPvRXSZNYbiLYvdv_KaJ4DDbVN7GP7Ny8Kjs1GoLQvNxmSmZ7uyngSucsyCSiGQmLy0db1iMdIOWZAffF70u5kTdNXwhh5qHJurpueGNSAJNf6b_Tp7b3DIoAHrEnZTjUcyv48geNuCqiEq03ei9MVx-X9MaRIBOL2Y-0dai3Zx7p6tyi7TyCw_DXCo2ZDujQQM_7J-CrEliHp8Q");
            sharedClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            sharedClient.DefaultRequestHeaders.Add("ContentType","application/json");


            GetAsync();
        }
        static async Task GetAsync()
        {
            Item item = new Item();
            item.Sort = "GRADE";
            item.CategoryCode = 200010;
            item.PageNo = 0;
        StringContent a = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8,"application/json");
            Console.WriteLine(JsonConvert.SerializeObject(item));
            var content = new FormUrlEncodedContent(new[]
           {
                new KeyValuePair<string, string>("CategoryCode", "1000")
            });
            using (HttpResponseMessage response = await sharedClient.PostAsync("https://developer-lostark.game.onstove.com/auctions/items",a))
            {

                response.EnsureSuccessStatusCode();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(jsonResponse);
                
            }
        }
        
    }
}
