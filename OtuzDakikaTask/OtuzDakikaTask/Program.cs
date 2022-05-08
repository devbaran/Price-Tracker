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

namespace OtuzDakikaTask
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
                        //fiyat sıfır gelirse linkte hata mevcut demek veya farklı bir problem.
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
                            //eposta gönderim başarısız.
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
                        //fiyat sıfır gelirse linkte hata mevcut demek veya farklı bir problem.
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
                            //eposta gönderim başarısız.
                            data.Delete(user);
                        }
                    }
                }

                if (countSendedMails == 10)
                {
                    //burada sistemi dinlendirme gibi birşey düşündüm.
                    Console.WriteLine("Bir saniye beklemeye giriyoruz");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    countSendedMails = 0;
                    Console.WriteLine("Bir saniye bekledik...");
                }
            }

        }
    }























}
