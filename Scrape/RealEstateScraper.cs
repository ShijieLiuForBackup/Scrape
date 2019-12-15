using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace Scrape
{
    public class RealEstateScraper
    {
        public async Task<RootObject> GetHouseInMapBoundary()
        {
            var url = @"https://beijing.anjuke.com/v3/ajax/map/sale/3669/facet/?room_num=-1&price_id=-1&area_id=-1&floor=-1&orientation=-1&is_two_years=0&is_school=0&is_metro=0&order_id=0&p=1&zoom=12&lat=39.865084_40.072116&lng=115.923559_116.942309&kw=&maxp=99&et=c9ad0f&ib=1&bst=pem227";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                //我们要测试这个json，现在去Test测试它
                //现在需要这个方法返回一个RootObject
                return JsonConvert.DeserializeObject<RootObject>(json);//把json转换成RootObject的类型

                
            }
        }
    }
}
