using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prices
{
    public class AmazonPrice
    {
        List<string> list = new List<string>()
            {

            "//*[@id='corePrice_feature_div']/div/span/span[2]",
            "//*[@id='corePrice_feature_div']/div/span/span[1]"

            };

        public int GetPrice(string url)
        {
            try
            {
                var html = $@"{url}";
                HtmlWeb web = new HtmlWeb();
                var htmlDoc = web.Load(html);

                string result = "";
                foreach (var xpath in list)
                {
                    var node = htmlDoc.DocumentNode.SelectSingleNode(xpath);
                    if (node == null)
                    {
                        continue;
                    }
                    else
                    {
                        result = node.InnerText;
                    }
                }

                int intResult = GetIntValue(result);
                return intResult;
            }
            catch
            {

                return 0;
            }






        }
        private int GetIntValue(string result)
        {
            var resultNew = result.Replace(".", "").Split(",");
            int price = int.Parse(resultNew[0]);
            return price;
        }
    }
}
