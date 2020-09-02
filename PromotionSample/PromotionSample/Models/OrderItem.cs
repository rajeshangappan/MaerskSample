namespace PromotionSample.Models
{
    /// <summary>
    /// Defines the <see cref="OrderItem" />.
    /// </summary>
    public class OrderItem
    {
        #region Public_Internal_Properties

        /// <summary>
        /// Gets or sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the ActualPrice.
        /// </summary>
        public int ActualPrice { get; set; }

        /// <summary>
        /// Gets or sets the Discountprice.
        /// </summary>
        public int Discountprice { get; set; }

        #endregion
    }
}
