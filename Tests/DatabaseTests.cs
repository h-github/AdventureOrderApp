using AdventureOrderApp.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertPersonIntoDatabase()
        {
            using (var context = new AdventureWorksContext())
            {
                var person = new Person()
                {
                    PersonType = "SC",
                    NameStyle = false,
                    FirstName = "John",
                    LastName = "Smith",
                    EmailPromotion = 0,
                };

                context.Person.Add(person);
                
                Debug.WriteLine($"Before save: {person.BusinessEntityId}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {person.BusinessEntityId}");

                Assert.AreNotEqual(0, person.BusinessEntityId);
            }
        }
    }
}
