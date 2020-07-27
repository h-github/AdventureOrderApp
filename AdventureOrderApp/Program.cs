using AdventureOrderApp.Data;
using System;
using System.Linq;

namespace AdventureOrderApp
{
    class Program
    {
        private static AdventureWorksContext _context = new AdventureWorksContext();

        static void Main(string[] args)
        {

            var max = 100000m;
            var someOrders = _context.SalesOrderHeader.Where(ord => ord.SubTotal > max).Select(o => new { o.SalesOrderId, FirstOrder = o.SalesOrderDetail.FirstOrDefault() }).ToList();
            someOrders[0].FirstOrder.OrderQty = 10;
            //Console.WriteLine(someOrders.Count);
            foreach (var order in someOrders)
            {
                Console.WriteLine($"{order.SalesOrderId}      {order.FirstOrder.ProductId}");
                
            }
            Console.ReadLine();
        }
    }
}
