using AdventureOrderApp.Data;
using System;
using System.Linq;

namespace AdventureOrderApp
{
  class Program
  {
    private static AdventureWorksContext context = new AdventureWorksContext();

    static void Main(string[] args)
    {

      var someOrders = context.SalesOrderHeader.Where(ord => ord.SubTotal > 100000m).ToList();
      Console.WriteLine(someOrders.Count);
      foreach (var order in someOrders)
      {
        Console.WriteLine(order.SalesOrderId);
      }
      Console.ReadLine();
    }
  }
}
