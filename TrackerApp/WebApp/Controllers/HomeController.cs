using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        ITrackerService _trackerService;

        public HomeController(ITrackerService trackerService)
        {
            _trackerService = trackerService;
        }
    

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ProductTrackerViewModel trackerModel)
        {
            if (ModelState.IsValid)
            {
                /*
                 Marketplace değeri veritabanında Id'lerle tutuluyor
                1 = Trendyol
                3 = Amazon
                Karşılık gelmektedir.
                 */
                if (trackerModel.MarketPlace == 1)
                {
                    Uri uri = new Uri(trackerModel.Url);
                    string host = uri.Host;
                    if (host != "www.trendyol.com")
                    {
                        /*
                            Örnek olarak seçtiği platform trendyol ise ancak verdiği link trendyol değil ise burada hata dönecektir.
                         */
                        return View(trackerModel);
                    }

                    UserProductTracker product = new UserProductTracker();
                    product.Url = trackerModel.Url;
                    product.DesiredPrice = trackerModel.DesiredPrice;
                    product.Email = trackerModel.Email;
                    product.ExpirationDate = DateTime.Now.AddDays(30);
                    product.MarketplaceId = 1;

                    _trackerService.Add(product);

                    return View(trackerModel);
                }

                if (trackerModel.MarketPlace == 3)
                {
                    Uri uri = new Uri(trackerModel.Url);
                    string host = uri.Host;
                    if (host != "www.amazon.com.tr")
                    {
                        ViewBag.IncorrectLink = "Girdiğiniz link ile seçtiğiniz e-ticaret sitesi farklı!";
                        return View(trackerModel);
                    }

                    UserProductTracker product = new UserProductTracker();
                    product.Url = trackerModel.Url;
                    product.DesiredPrice = trackerModel.DesiredPrice;
                    product.Email = trackerModel.Email;
                    product.ExpirationDate = DateTime.Now.AddDays(30);
                    product.MarketplaceId = 3;

                    _trackerService.Add(product);

                    return RedirectToAction("Done","Home"/*routeValues: product*/);
                }

                return View(trackerModel);
            }
            else
            {
                return View(trackerModel);
            }

        }

        [HttpGet]
        public IActionResult Done(UserProductTracker product)
        {
            //Burada amaç; bu sayfayı sadece işlemi başarıyla tamamlayanların görebilmesi.
            //Elbette farklı şekilde ele alınabilir bu kısım.
            var databaseId = _trackerService.GetById(product.Id);
            if (databaseId == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}