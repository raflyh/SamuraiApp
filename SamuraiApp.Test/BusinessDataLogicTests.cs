using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Test
{
    //[TestClass]
    //public class BusinessDataLogicTests
    //{
        //[TestMethod]
        //public void CanAddSamuraiByName()
        //{
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseInMemoryDatabase("CanAddSamuraiByName");

        //    using (var context = new SamuraContext())
        //    {
        //        var bs = new BusinessDataLogic(context);
        //        int expected = 3;
        //        var namelist = new string[] { "Shura", "Kyubi", "Bijuu" };
        //        var result = bs.AddSamuraiByName(namelist);
        //        Assert.AreEqual(expected, result);
        //    }
        //}
        //[TestMethod]
        //public void CanInsertSingleSamurai()
        //{
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseInMemoryDatabase("CanInsertSingleSamurai");
        //    using (var context = new SamuraContext(builder.Options))
        //    {
        //        int expected = 1;
        //        var bs = new BusinessDataLogic(context);
        //        bs.InsertNewSamurai(new Samurai { Name = "Filsuf 10" });
        //        Assert.AreEqual(expected, context.Samurais.Count());
        //    }
        //}

        //[TestMethod]
        //public void CanInsertSamuraiWithQuotes()
        //{
        //    var expected = 2;
        //    var newSamurai = new Samurai
        //    {
        //        Name = "Filsuf 12",
        //        Quotes = new List<Quote>
        //        {
        //            new Quote { Text = "Be free" },
        //            new Quote { Text ="Just be yourself" }
        //        }
        //    };
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseInMemoryDatabase("CanInsertSamuraiWithQuotes");
        //    using (var context = new SamuraContext(builder.Options))
        //    {
        //        var bs = new BusinessDataLogic(context);
        //        var result = bs.InsertNewSamurai(newSamurai);
        //    }
        //    using (var context2 = new SamuraContext(builder.Options))
        //    {
        //        var samuraiWithQuotes = context2.Samurais.Include(x => x.Quotes).
        //            FirstOrDefault();
        //        Assert.AreEqual(expected, samuraiWithQuotes.Quotes.Count);
        //    }
        //}

        //[TestMethod]
        //public void CanGetSamuraiWithQuotes()
        //{
        //    int expected = 3;
        //    int samuraiId;
        //    var builder = new DbContextOptionsBuilder();
        //    builder.UseInMemoryDatabase("SamuraiGetQuotes");
        //    using (var context = new SamuraContext(builder.Options))
        //    {
        //        var newSamurai = new Samurai
        //        {
        //            Name = "Filsuf 999",
        //            Quotes = new List<Quote>
        //            {
        //                new Quote { Text = "Look at the stars" },
        //                new Quote { Text = "We are a little universe" },
        //                new Quote { Text = "We are just speck of dust" }
        //            }
        //        };
        //        context.Samurais.Add(newSamurai);
        //        context.SaveChanges();
        //        samuraiId = newSamurai.Id;

        //        using (var context2 = new SamuraContext(builder.Options))
        //        {
        //            var bs = new BusinessDataLogic(context2);
        //            var result = bs.GetSamuraiWithQuotes(samuraiId);
        //            Assert.AreEqual(expected, result.Quotes.Count);
        //        }
        //    }
    //    }
    //}
}
