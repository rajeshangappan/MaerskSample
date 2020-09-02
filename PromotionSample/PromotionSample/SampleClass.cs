using PromotionSample.Models;
using PromotionSample.SalesEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionSample
{
    public class SampleClass
    {
        //Init Engine
        IndustryEngine Engine = new IndustryEngine();

        public void InitializeEngine()
        {

            Console.WriteLine("ProductName - UnitPrice");

            foreach (var product in Engine._productManager.Products)
                Console.WriteLine($"{product.Name} - {product.UnitPrice}");

            Console.WriteLine("\n");



        }

        public void showPromotions()
        {
            Console.WriteLine("Promotions details");

            foreach (var promotion in Engine._promotionManager.Promotions)
            {
                if (promotion.IsComboOffer)
                {
                    var str = string.Join(",",promotion.ProductNames);
                    Console.WriteLine($"{str} for {promotion.OfferPrice}");
                }
                else
                {
                    Console.WriteLine($"{promotion.Count} of {promotion.ProductNames[0]}'s for {promotion.OfferPrice}");
                }
            }

            Console.WriteLine("\n");
        }

        internal IList<OrderItem> ReadInput()
        {
            Console.WriteLine("ProductName Quantity");
            var InputOrders = new List<OrderItem>();
            bool Exist;
            do
            {
                var inputstr =Console.ReadLine();
                var splitstr = inputstr.Split(new Char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                if (splitstr.Length == 2 && int.TryParse(splitstr[1], out int quantity))
                {
                    var OrderItem = new OrderItem
                    {
                        ProductName= splitstr[0],
                        Quantity = int.Parse(splitstr[1])
                    };
                    InputOrders.Add(OrderItem);
                }

                Exist = inputstr != string.Empty;


            } while (Exist);
            return InputOrders;
        }

        internal void CalculateOrders(IList<OrderItem> InputOrders)
        {
            Engine.CalculateOrders(InputOrders);
        }

        internal void WriteOutput(IList<OrderItem> InputOrders)
        {
            foreach (var order in InputOrders)
            {
                Console.WriteLine($"{order.ProductName} - {order.Discountprice}");
            }
            Console.WriteLine("\n");
            Console.WriteLine($"Total - {InputOrders.Sum(x => x.Discountprice)}");
        }
    }
}
