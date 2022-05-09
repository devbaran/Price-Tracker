using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.EmailHelper;
using HtmlAgilityPack;
using Prices;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {

        static async Task Main(string[] args)
        {
            EfUserProductTrackerDal data = new EfUserProductTrackerDal();

            TrendyolPrice trendyolPrice = new TrendyolPrice();
            AmazonPrice amazonPrice = new AmazonPrice();

            MailSender mail = new MailSender();

            var users = data.GetAll();
            int countSendedMails = 0;

            foreach (var user in users)
            {
                /* 
                 MarketplaceId 1 = Trendyol
                 MarketplaceId 3 = Amazon
                 */

                //If Marketplace is Trendyol
                if (user.MarketplaceId == 1)
                {


                   
                    if (user.ExpirationDate <= DateTime.Now)
                    {
                        data.Delete(user);
                        continue;
                    }
                    var currentPrice = trendyolPrice.GetPrice(user.Url);
                    if (currentPrice == 0)
                    {
                        //Linkten kontrol edilen fiyat sıfırsa linkte hata mevcut demek veya farklı bir problem var, bunların bilgisi verilebilir..
                        data.Delete(user);
                        continue;
                    }
                    if (currentPrice <= user.DesiredPrice)
                    {
                        var isTrue = mail.SendSaleEmail(user.Email, user.Url);

                        if (isTrue)
                        {
                            countSendedMails++;
                            data.Delete(user);
                        }
                        else
                        {
                            //Eposta gönderimi başarısız, bilgilendirme yapılabilir...
                            data.Delete(user);
                        }
                    }
                }


                //If Marketplace is Amazon
                if (user.MarketplaceId==3)
                {
                    if (user.ExpirationDate <= DateTime.Now)
                    {
                        data.Delete(user);
                        continue;
                    }
                    var currentPrice = amazonPrice.GetPrice(user.Url);
                    if (currentPrice == 0)
                    {
                        //Linkten kontrol edilen fiyat sıfırsa linkte hata mevcut demek veya farklı bir problem var, bunların bilgisi verilebilir..
                        data.Delete(user);
                        continue;
                    }
                    if (currentPrice <= user.DesiredPrice)
                    {
                        var isTrue = mail.SendSaleEmail(user.Email, user.Url);

                        if (isTrue)
                        {
                            countSendedMails++;
                            data.Delete(user);
                        }
                        else
                        {
                            //Eposta gönderimi başarısız, bilgilendirme yapılabilir...
                            data.Delete(user);
                        }
                    }
                }

                if (countSendedMails == 10)
                {
                    //Bir saniyede çok fazla mail atılması durumunda ufak bir bekleme düşündüm, ancak gerekli olmayabilir.
                    Console.WriteLine("Bir saniye beklemeye giriyoruz");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    countSendedMails = 0;
                    Console.WriteLine("Bir saniye bekledik...");
                }
            }

        }
    }























}
