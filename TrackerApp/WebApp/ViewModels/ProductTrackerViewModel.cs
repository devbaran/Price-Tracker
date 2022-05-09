using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ProductTrackerViewModel
    {


        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int MarketPlace { get; set; }


        [Required(ErrorMessage ="Bu alan zorunludur.")]
        [EmailAddress(ErrorMessage ="Geçerli bir email adresi girin.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Url(ErrorMessage ="Geçerli bir url girin.")]
        public string Url { get; set; }
        
        
        
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int DesiredPrice { get; set; }

        //MarketplaceId veritabanına kayıt işlemi için Controller kısmında gerekli 
        //Hatalı bir işlem olsa da hızlıca Bind etmek üzere bu şekilde kullanıldı.
        public int MarketplaceId { get; set; }
    }
}
