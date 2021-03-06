using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entity
{
    public class UserProductTracker
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int DesiredPrice { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int MarketplaceId { get; set; }
    }
}
