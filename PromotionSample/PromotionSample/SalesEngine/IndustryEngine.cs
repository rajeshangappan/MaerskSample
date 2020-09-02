using PromotionSample.Models;
using System.Collections.Generic;

namespace PromotionSample.SalesEngine
{
    /// <summary>
    /// Defines the <see cref="IndustryEngine" />.
    /// </summary>
    public class IndustryEngine
    {
        #region Private_Properties

        /// <summary>
        /// Gets or sets the Orders.
        /// </summary>
        private IList<OrderItem> Orders { get; set; }

        #endregion

        #region Public_Internal_Properties

        /// <summary>
        /// Defines the _productManager.
        /// </summary>
        internal ProductManager _productManager;

        /// <summary>
        /// Defines the _promotionManager.
        /// </summary>
        internal PromotionManager _promotionManager;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="IndustryEngine"/> class.
        /// </summary>
        public IndustryEngine()
        {
            _productManager = new ProductManager(this);
            _promotionManager = new PromotionManager(this);
        }

        #endregion

        #region Methods

        /// <summary>
        /// The CalculateOrders.
        /// </summary>
        /// <param name="orders">The orders<see cref="IList{OrderItem}"/>.</param>
        public void CalculateOrders(IList<OrderItem> orders)
        {
            _promotionManager.ApplyPromotions(orders);
        }

        #endregion
    }
}
