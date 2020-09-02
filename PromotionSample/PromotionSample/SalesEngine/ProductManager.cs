using PromotionSample.Models;
using System.Collections.Generic;

namespace PromotionSample.SalesEngine
{
    /// <summary>
    /// Defines the <see cref="ProductManager" />.
    /// </summary>
    public class ProductManager
    {
        #region Private_Properties

        /// <summary>
        /// Defines the _engine.
        /// </summary>
        private IndustryEngine _engine;

        #endregion

        #region Public_Internal_Properties

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public IList<Product> Products { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductManager"/> class.
        /// </summary>
        /// <param name="engine">The engine<see cref="IndustryEngine"/>.</param>
        public ProductManager(IndustryEngine engine)
        {
            _engine = engine;
            Init();
        }

        #endregion

        #region Private_Methods

        /// <summary>
        /// The Init.
        /// </summary>
        private void Init()
        {
            Products = new List<Product>();
            InitProducts();
        }

        /// <summary>
        /// The InitProducts.
        /// </summary>
        private void InitProducts()
        {
            AddProduct(new Product { Name = "A", UnitPrice = 60 });
            AddProduct(new Product { Name = "B", UnitPrice = 40 });
            AddProduct(new Product { Name = "C", UnitPrice = 30 });
            AddProduct(new Product { Name = "D", UnitPrice = 40 });
        }

        #endregion

        #region Methods

        /// <summary>
        /// The AddProduct.
        /// </summary>
        /// <param name="prod">The prod<see cref="Product"/>.</param>
        public void AddProduct(Product prod)
        {
            Products.Add(prod);
        }

        #endregion
    }
}
