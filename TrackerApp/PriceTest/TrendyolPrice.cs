using HtmlAgilityPack;
using System.Collections.Generic;

namespace PriceTest
{
    //PriceTest katmanı kullanılarak verilen linkler üzerinden sağlıklı bir şekilde fiyat gelip gelmediği CONTOLLER veya BUSINESS kısmında kontrol edilebilir.
    //Projeye ben eklemedim ancak ekleyecek kişiler için faydalı olabilir.
    //Bu kısım asıl olarak ConsoleApp tarafında işimize yarayacak.

    public class TrendyolPrice
    {
        //Bu XPath'ler veritabanından alınabilir, ancak burada local çalıştım.
        //Eksik pathler olabilir, fiyat getirmesi açısından bütün path olasılıkları eklenmelidir.
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
        //Burada fiyat kırpma durumlarının tamamı ele alınmadı, virgül bulunmayan fiyat durumları ortaya çıkacaktır. Ele alınması gerekir.
        //https://www.trendyol.com/atolyemy/chester-koltuk-takimi-p-205005917 bu linkteki fiyat farklı gözüküyor, doğru fiyat alınamıyor. Çözülebilir.
        private int GetIntValue(string result)
        {
            var resultNew = result.Replace(".", "").Replace(" ", "").Split(",");
            int price = int.Parse(resultNew[0]);
            return price;
        }


    }
}
