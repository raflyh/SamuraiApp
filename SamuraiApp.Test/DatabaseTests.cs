using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Diagnostics;

namespace SamuraiApp.Test
{
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertSamuraiIntoDatabase()
        {
            using(var context = new SamuraContext())
            {
                /*context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var samurai = new Samurai();
                context.Samurais.Add(samurai);
                Debug.WriteLine($"Sebelum save: {samurai.Id}");
                context.SaveChanges();
                Debug.WriteLine($"Setelah save: {samurai.Id}");
                Assert.AreNotEqual(0, samurai.Id);*/
            }
        }
    }
}