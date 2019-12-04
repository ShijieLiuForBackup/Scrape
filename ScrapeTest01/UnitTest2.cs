using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xunit;
using System.Net.Http;
using HtmlAgilityPack;
using System.Linq;

namespace ScrapeTest01
{
    public class  UnitTest2
    {
        [Fact(DisplayName ="Hotel")]
        public async void Test2()
        {
            var client = new HttpClient();
            var result = await client.GetAsync(@"");
            var html = await result.Content.ReadAsStringAsync();

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var priceNodes = doc.DocumentNode.DescendantsAndSelf().Where(n => n.Name.ToLower() ==
           "div" && n.HasClass("Price")).ToList();

            string priceRaw = priceNodes.First().InnerText;
            priceRaw = priceRaw.Replace(" ", "").Replace("\t", "");

            Debugger.Break();

            //想要测试失败：
            //throw new Exception();

        }


        //有参数的测试方法
        [Theory]
        [InlineData("John")]
        public void Test3(string name)
        {

        }

    }
}
