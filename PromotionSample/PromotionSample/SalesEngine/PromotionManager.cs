using PromotionSample.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionSample.SalesEngine
{
    /// <summary>
    /// Defines the <see cref="PromotionManager" />.
    /// </summary>
    public class PromotionManager
    {
        #region Private_Properties

        /// <summary>
        /// Defines the _engine.
        /// </summary>
        private IndustryEngine _engine;

        #endregion

        #region Public_Internal_Properties

        /// <summary>
        /// Gets or sets the Promotions.
        /// </summary>
        public IList<Promotion> Promotions { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PromotionManager"/> class.
        /// </summary>
        /// <param name="engine">The engine<see cref="IndustryEngine"/>.</param>
        public PromotionManager(IndustryEngine engine)
        {
            _engine = engine;
            Promotions = new List<Promotion>();
            Init();
        }

        #endregion

        #region Private_Methods

        /// <summary>
        /// The Init.
        /// </summary>
        private void Init()
        {
            IList<string> nn = new List<string> {"A"};
            var promo = new Promotion { ProductNames =  new List<string>  { "A" }, Count = 3, OfferPrice = 150 };
            AddPromotion(promo);
            AddPromotion(new Promotion { ProductNames = new List<string> { "B" }, Count = 2, OfferPrice = 60 });
            AddPromotion(new Promotion { ProductNames = new List<string> { "C", "D" }, IsComboOffer = true, OfferPrice = 50 });
        }

        /// <summary>
        /// The ApplyRemainProductValue.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        /// <param name="promodict">The promodict<see cref="Dictionary{string, int}"/>.</param>
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

        /// <summary>
        /// The ApplyComboPromotion.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        /// <param name="promotion">The promotion<see cref="Promotion"/>.</param>
        /// <param name="promodict">The promodict<see cref="Dictionary{string, int}"/>.</param>
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

        /// <summary>
        /// The ApplyUniquePromotion.
        /// </summary>
        /// <param name="order">The order<see cref="OrderItem"/>.</param>
        /// <param name="promotion">The promotion<see cref="Promotion"/>.</param>
        /// <param name="promodict">The promodict<see cref="Dictionary{string, int}"/>.</param>
        private void ApplyUniquePromotion(OrderItem order, Promotion promotion, Dictionary<string, int> promodict)
        {
            var promoCount = promotion.Count;
            order.Discountprice = (order.Quantity / promoCount) * promotion.OfferPrice;
            promodict[order.ProductName] = (order.Quantity % promoCount);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The AddPromotion.
        /// </summary>
        /// <param name="promotion">The promotion<see cref="Promotion"/>.</param>
        public void AddPromotion(Promotion promotion)
        {
            Promotions.Add(promotion);
        }

        /// <summary>
        /// The ApplyPromotions.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        public void ApplyPromotions(IList<OrderItem> orders)
        {
            Dictionary<string, int> promodict= new Dictionary<string, int>();
            foreach (var order in orders)
                promodict.Add(order.ProductName, order.Quantity);
            ApplyUniqueOffer(orders, promodict);
            ApplyComboOffer(orders, promodict);
            ApplyRemainProductValue(orders, promodict);
        }

        /// <summary>
        /// The ApplyUniqueOffer.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        /// <param name="promodict">The promodict<see cref="Dictionary{string, int}"/>.</param>
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

        /// <summary>
        /// The ApplyComboOffer.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        /// <param name="promodict">The promodict<see cref="Dictionary{string, int}"/>.</param>
        public void ApplyComboOffer(IList<OrderItem> orders, Dictionary<string, int> promodict)
        {
            var combopromotions = Promotions.Where(x=>x.IsComboOffer);
            foreach (var promotion in combopromotions)
            {
                ApplyComboPromotion(orders, promotion, promodict);
            }
        }

        #endregion
    }
}
