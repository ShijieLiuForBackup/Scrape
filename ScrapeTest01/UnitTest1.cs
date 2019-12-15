using System;
using System.Diagnostics;
using System.Net.Http;
using System.Linq;
using Xunit;
using HtmlAgilityPack;
using Scrape;

namespace Scrape.Test
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


        [Theory]
        [InlineData("John")]
        [InlineData("Jason")]
        public void WithParameter(string name)
        {

        }

        [Fact(DisplayName ="Scrape Baby Formula")]
        public async void ScrapeBabyFormula()
        {
            string searchURL = @"https://www.chemistwarehouse.com.au/shop-online/1592/the-a2-milk-company";
            var client = new HttpClient();
            var result = await client.GetAsync(searchURL);
            var html = await result.Content.ReadAsStringAsync();

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var priceNodes = doc.DocumentNode.DescendantsAndSelf().
                Where(n => n.Name.ToLower() == "a"
               && n.HasClass("product-container")).ToList();

            var urls = priceNodes.
                Select(node => node.GetAttributeValue("href", "")).
                Where(url => url != "").
                ToList();
            
            Debugger.Break();
        }

        [Fact(DisplayName ="Scrape A2 Baby Formula Prices")]
        public async void A2BabyFormulaPrice()
        {
            string searchURL = @"https://www.chemistwarehouse.com.au/shop-online/1592/the-a2-milk-company";
            var client = new HttpClient();
            var result = await client.GetAsync(searchURL);
            var html = await result.Content.ReadAsStringAsync();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var priceNodes = doc.DocumentNode.DescendantsAndSelf()
                .Where(n => n.Name.ToLower() == "a"
               && n.HasClass("product-container")).ToList();

            var urls = priceNodes.Select(node => node.GetAttributeValue("href", ""))
                .Where(url => url != "")
                .ToList();

            

            foreach (var url in urls)
            {
                
                var sortURL = await client.GetAsync(@"https://www.chemistwarehouse.com.au" + url);
                var finalURL = sortURL.RequestMessage.RequestUri.AbsoluteUri.ToString();

                var resultPrd = await client.GetAsync(finalURL);
                var htmlPrd = await resultPrd.Content.ReadAsStringAsync();
                var docPrd = new HtmlDocument();
                docPrd.LoadHtml(htmlPrd);

                var priceNodesPrd = docPrd.DocumentNode.DescendantsAndSelf().Where(n => n.Name.ToLower()
            == "div" && n.HasClass("Price")).ToList();
                //using system.diagnostics
                //Debugger.Break();c

                string priceRaw = priceNodesPrd.First().InnerText;
                priceRaw = priceRaw.Replace(" ", "").Replace("\n", "");
                Debug.WriteLine(priceRaw);
            }


            Debugger.Break();

        }

        [Fact(DisplayName ="Test Json")]
        public async void TestJson()
        {
            RealEstateScraper scraperTest = new RealEstateScraper();
            var result1 = await scraperTest.GetHouseInMapBoundary();
            Debugger.Break(); 
        }

    }
}
