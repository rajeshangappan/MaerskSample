using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample.Models
{
    public class Promotion
    {
        public int Count { get; set; }

        public bool IsComboOffer { get; set; }

        public IList<string> ProductNames { get; set; }

        public int DiscountPercentage { get; set; }

        public int OfferPrice { get; set; }

        public int MinCount { get; set; }

        public int Priority { get; set; }
    }
}
