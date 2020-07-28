using AdventureOrderApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertSalesOrderHeaderIntoDatabase()
        {
            using(var context = new AdventureWorksContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var salesOrderHeader = new SalesOrderHeader();
                context.SalesOrderHeader.Add(salesOrderHeader);
                Debug.WriteLine($"Before save: {salesOrderHeader.SalesOrderId}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {salesOrderHeader.SalesOrderId}");

                Assert.AreNotEqual(0, salesOrderHeader.SalesOrderId);
            }
        }
    }
}
