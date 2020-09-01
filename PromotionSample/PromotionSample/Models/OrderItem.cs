using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample.Models
{
    public class OrderItem
    {
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public int ActualPrice { get; set; }

        public int Discountprice { get; set; }
    }
}
