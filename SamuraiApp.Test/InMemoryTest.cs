using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    //[TestClass]
    //public class InMemoryTest
    //{
    //    [TestMethod]
    //    public void CanInsertSamuraiIntoDatabaseInMemory()
    //    {
    //        var builder = new DbContextOptionsBuilder();
    //        builder.UseInMemoryDatabase("CanInsertSamurai");
    //        using(var context = new SamuraContext(builder.Options))
    //        {
    //            var samurai = new Samurai() { Name ="Nobunaga"};
    //            context.Samurais.Add(samurai);
    //            //Assert.AreNotEqual(0, samurai.Id);
    //            Assert.AreEqual(EntityState.Added,
    //                context.Entry(samurai).State);
    //        }
    //    }
    //}
}
