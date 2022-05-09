using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserProductTracker
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int DesiredPrice { get; set; }
        public DateTime ExpirationDate { get; set; }

        /*Veritabanında MarketPlace adı altında bir tablo olsa da, proje içerisinde Entity olarak eklenmedi! (önemli eksiklik), CRUD işlemleri SSMS üzerinden yapılıyor.
         MarketPlace içerisinde mağazalar tutuluyor (Amazon, Trendyol vs...)
         
         MarketPlace'ler de buradan yönetilebilmeli, bu önemli eksiklik giderilmeli.
         O sebeple uygulamada fiyat takibi eklerken MarketplaceId değeri controller üzerinden atanıyor 
         ve bu sayede veritabanında bulunan Marketplace Id'si ile eşleşiyor.
         */
        public int MarketplaceId { get; set; }

    }
}
