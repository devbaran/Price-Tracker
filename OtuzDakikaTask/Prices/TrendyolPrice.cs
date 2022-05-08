using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prices
{
    public class TrendyolPrice
    {
        List<string> list = new List<string>()
            {
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[2]/div/div/div[4]/div/div/div/div[2]/span",
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[1]/div/div/div[4]/div[2]/div/span[2]",
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[2]/div/div/div[4]/div/div/span",
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[1]/div/div/div[4]/div/div/span",
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[1]/div/div/div[4]/div/div/div/div[2]/span",
                "/html/body/div[1]/div[5]/main/div/div[2]/div[1]/div[2]/div[2]/div/div/div[5]/div/div/span",

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
                        break;
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
            var resultNew = result.Replace(".", "").Replace(" ", "").Split(",");
            int price = int.Parse(resultNew[0]);
            return price;
        }


    }
}
