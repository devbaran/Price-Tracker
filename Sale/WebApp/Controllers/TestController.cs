using Business.Abstract;
using Calculate;
using Entities;
using HtmlAgilityPack;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class TestController : Controller
    {
        ITrackerService _trackerService;

        public TestController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        //https://www.trendyol.com/atolyemy/chester-koltuk-takimi-p-205005917
        //calismayan link

        [HttpPost]
        public IActionResult Index(ProductTrackerViewModel trackerModel)
        {
            if (ModelState.IsValid)
            {
                if (trackerModel.MarketPlace == 1)
                {
                    Uri uri = new Uri(trackerModel.Url);
                    string host = uri.Host;
                    if (host != "www.trendyol.com")
                    {
                        return View(trackerModel);
                    }

                    UserProductTracker product = new UserProductTracker();
                    product.Url = trackerModel.Url;
                    product.DesiredPrice = trackerModel.DesiredPrice;
                    product.Email = trackerModel.Email;
                    product.ExpirationDate = DateTime.Now.AddDays(30);
                    product.MarketplaceId = 1;

                    _trackerService.Add(product);

                    TrendyolPrice price = new TrendyolPrice();
                    ViewBag.test = price.GetPrice(trackerModel.Url);

                    return View(trackerModel);
                }

                if (trackerModel.MarketPlace == 3)
                {
                    Uri uri = new Uri(trackerModel.Url);
                    string host = uri.Host;
                    if (host != "www.amazon.com.tr")
                    {
                        ViewBag.IncorrectLink="Girdiğiniz link ile seçtiğiniz e-ticaret sitesi farklı!";
                        return View(trackerModel);
                    }

                    UserProductTracker product = new UserProductTracker();
                    product.Url = trackerModel.Url;
                    product.DesiredPrice= trackerModel.DesiredPrice;
                    product.Email = trackerModel.Email;
                    product.ExpirationDate= DateTime.Now.AddDays(30);
                    product.MarketplaceId = 3;
       
                    _trackerService.Add(product);

                    AmazonPrice price = new AmazonPrice();
                    ViewBag.test = price.GetPrice(trackerModel.Url);

                    return View(trackerModel);
                }

                return View(trackerModel);
            }
            else
            {
                return View(trackerModel);
            }

        }
    }
}
