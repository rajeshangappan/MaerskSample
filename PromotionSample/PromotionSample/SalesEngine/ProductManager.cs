using PromotionSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample.SalesEngine
{
    public class ProductManager
    {
        public IList<Product> Products { get; set; }
        private IndustryEngine _engine;
        public ProductManager(IndustryEngine engine)
        {
            _engine = engine;
            Init();
        }

        private void Init()
        {
            Products = new List<Product>();
            InitProducts();
        }

        private void InitProducts()
        {
            AddProduct(new Product { Name = "A", UnitPrice = 60 });
            AddProduct(new Product { Name = "B", UnitPrice = 40 });
            AddProduct(new Product { Name = "C", UnitPrice = 30 });
            AddProduct(new Product { Name = "D", UnitPrice = 40 });
        }

        public void AddProduct(Product prod)
        {
            Products.Add(prod);
        }
    }
}
