using PromotionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample.SalesEngine
{
    public class IndustryEngine
    {
        internal ProductManager _productManager;
        internal PromotionManager _promotionManager;

        private IList<OrderItem> Orders { get; set; }
         
        public IndustryEngine()
        {
            _productManager = new ProductManager(this);
            _promotionManager = new PromotionManager(this);
        }

        public void CalculateOrders(IList<OrderItem> orders)
        {
            _promotionManager.ApplyPromotions(orders);
        }
    }
}
