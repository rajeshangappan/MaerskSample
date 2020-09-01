using System;

namespace PromotionSample
{
    public class Program
    {
        static void Main(string[] args)
        {

            SampleClass sample = new SampleClass();
            sample.InitializeEngine();

            // Add Input value by programatically.
            // InputOrders = new List<OrderItem>
            //{
            //    new OrderItem{ ProductName = "A", Quantity = 3},
            //    new OrderItem{ ProductName = "B", Quantity = 5},
            //    new OrderItem {ProductName = "C", Quantity=1},
            //    new OrderItem{ProductName ="D", Quantity = 1}
            //};

            //Read Input By Console, Also, you can assign the above commentted list.
            var orders = sample.ReadInput();

            //Calculate the Orders
            sample.CalculateOrders(orders);

            //Write Output in console
            sample.WriteOutput(orders);

            Console.ReadLine();
           
        }
    }
}
