using System;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using Xunit;
using HtmlAgilityPack;

namespace ScrapeTest01
{
    public class UnitTest1
    {
        [Fact(DisplayName ="Scrape Hotel Price")]
        public async void Test1()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(@"https://www.chemistwarehouse.com.au/buy/69966/A2-Infant-Formula-Stage-1-900g");
            var html = await result.Content.ReadAsStringAsync();

            //using HtmlAgilityPack
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            //using system.Linq Where 里面是一个lambda函数
            var priceNodes = doc.DocumentNode.DescendantsAndSelf().Where(n => n.Name.ToLower() 
            == "div" && n.HasClass("Price")).ToList();
            //using system.diagnostics
            //Debugger.Break();c

            string priceRaw = priceNodes.First().InnerText;
            priceRaw = priceRaw.Replace(" ", "").Replace("\n", "").Replace("\t", "");

            Debugger.Break();

        }
    }
}
