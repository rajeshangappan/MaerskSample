using System.Collections.Generic;

namespace PromotionSample.Models
{
    /// <summary>
    /// Defines the <see cref="Promotion" />.
    /// </summary>
    public class Promotion
    {
        #region Public_Internal_Properties

        /// <summary>
        /// Gets or sets the Count.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsComboOffer.
        /// </summary>
        public bool IsComboOffer { get; set; }

        /// <summary>
        /// Gets or sets the ProductNames.
        /// </summary>
        public IList<string> ProductNames { get; set; }

        /// <summary>
        /// Gets or sets the DiscountPercentage.
        /// </summary>
        public int DiscountPercentage { get; set; }

        /// <summary>
        /// Gets or sets the OfferPrice.
        /// </summary>
        public int OfferPrice { get; set; }

        /// <summary>
        /// Gets or sets the MinCount.
        /// </summary>
        public int MinCount { get; set; }

        /// <summary>
        /// Gets or sets the Priority.
        /// </summary>
        public int Priority { get; set; }

        #endregion
    }
}
