using PromotionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample.SalesEngine
{
    public class PromotionManager
    {
        public IList<Promotion> Promotions { get; set; }
        private IndustryEngine _engine;
        public PromotionManager(IndustryEngine engine)
        {
            _engine = engine;
            Promotions = new List<Promotion>();
            Init();
        }

        private void Init()
        {
            IList<string> nn = new List<string> {"A"};
            var promo = new Promotion { ProductNames =  new List<string>  { "A" }, Count = 3, OfferPrice = 150 };
            AddPromotion(promo);
            AddPromotion(new Promotion { ProductNames = new List<string> { "B" }, Count = 2, OfferPrice = 60 });
            AddPromotion(new Promotion { ProductNames = new List<string> { "C", "D" }, IsComboOffer = true, OfferPrice = 50 });
        }

        public void AddPromotion(Promotion promotion)
        {
            Promotions.Add(promotion);
        }

        public void ApplyPromotions(IList<OrderItem> orders)
        {
            Dictionary<string, int> promodict= new Dictionary<string, int>();
            foreach (var order in orders)
                promodict.Add(order.ProductName, order.Quantity);
            ApplyUniqueOffer(orders, promodict);
            ApplyComboOffer(orders, promodict);
            ApplyRemainProductValue(orders, promodict);
        }

        private void ApplyRemainProductValue(IList<OrderItem> orders, Dictionary<string, int> promodict)
        {
            foreach (var order in orders)
            {
                var prod = _engine._productManager.Products.FirstOrDefault(x=>x.Name == order.ProductName);
                if (prod != null)
                {
                    int unitPrice = promodict[order.ProductName] * prod.UnitPrice;
                    order.Discountprice += unitPrice;
                }
            }
        }

        public void ApplyUniqueOffer(IList<OrderItem> orders, Dictionary<string, int> promodict)
        {
            var uniquepromotions = Promotions.Where(x=>!x.IsComboOffer);
            foreach (var promotion in uniquepromotions)
            {
                var order = orders.FirstOrDefault(x=>x.ProductName == promotion.ProductNames[0]);
                if (order != null)
                    ApplyUniquePromotion(order, promotion, promodict);
            }
        }

        public void ApplyComboOffer(IList<OrderItem> orders, Dictionary<string, int> promodict)
        {
            var combopromotions = Promotions.Where(x=>x.IsComboOffer);
            foreach (var promotion in combopromotions)
            {
                ApplyComboPromotion(orders, promotion, promodict);
            }
        }

        private void ApplyComboPromotion(IList<OrderItem> orders, Promotion promotion, Dictionary<string, int> promodict)
        {
            var prodnames = promotion.ProductNames;

            var dict = promodict.Where(x=>prodnames.Contains(x.Key));

            var maxcount = dict.Min(x=>x.Value);

            if (maxcount > 0)
            {
                foreach (var name in prodnames)
                {
                    promodict[name] = promodict[name] - maxcount;
                }
                var promoOrder = orders.First(x=>x.ProductName == prodnames[prodnames.Count-1]);
                promoOrder.Discountprice += (maxcount * promotion.OfferPrice);
            }
        }

        private void ApplyUniquePromotion(OrderItem order, Promotion promotion, Dictionary<string, int> promodict)
        {
            var promoCount = promotion.Count;
            order.Discountprice = (order.Quantity / promoCount) * promotion.OfferPrice;
            promodict[order.ProductName] = (order.Quantity % promoCount);
        }
    }
}
