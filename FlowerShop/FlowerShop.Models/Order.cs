using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerShop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FlowerType { get; set; }

        public int Quantity { get; set; }
        public int OrderTypeId { get; set; }

        public int UserId { get; set; }

    }
}
