// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

//SamuraContext _context = new SamuraContext();
//AddSamuraiByName("Hyuga","Shikamaru","Eichiro","Lance");
//_context.Database.EnsureCreated();

//AddSamurai("Oni","Giri","Iai","Rashomon");

//AddVariousTypes();
//QueryFilters();
//QueryAggregates();
//RetrieveAndUpdateSamurais();
//MultipleDatabaseOperations();
//RetrieveAndDeleteSamurai();
//QueryAndUpdateBattles_Disconnect();
//InsertNewSamuraiWithQuote();
//AddQuotetoExistingSamurai();
//AddQuotetoExistingSamuraiNoTracking(5);
//SimpleAddQuoteToExistingSamuraiNoTracking(3);
//EagerLoadiSamuraiWithQuote();
//ProjectingSample();
//ExplicitLoadQuotes();
//FilteringWithRelatedData();
//ModifyRelatedDataNoTracking();
//RetrieveBattleWithSamurai();
//AddAllSamuraisToAllBattles();
//RemoveSamuraiFromBattle();
//AddNewSamuraiWithHorse();
//AddNewHorseNoTracking();
//GetBattles();
//GetSamurais();
//QuerViewBattleStat();
//StoredProcedureRaw();
Console.WriteLine("Press any key");
Console.ReadLine();

//void AddSamurai(params string[] names){
//    foreach (string name in names)
//    {
//        _context.Samurais.Add(new Samurai { Name = name});
//    }
//    _context.SaveChanges();
//}
//void AddVariousTypes()
//{
//    /*_context.Samurais.AddRange(
//        new Samurai {Name="Shanju" },
//        new Samurai { Name="Kuro"} 
//        );
//    _context.Battles.AddRange(
//        new Battle { Name = "WholeCake Island" },
//        new Battle { Name = "Zou"}
//        );*/
//    _context.AddRange(new Samurai { Name = "Pedro" }, new Samurai { Name = "Coda" },
//        new Battle { Name = "Wano Arc" }, new Battle { Name = "Greed Islands" });
//    _context.SaveChanges();
//}
//void GetSamurais()
//{
//    var samurais = _context.Samurais
//        .TagWith("Get Samurai Method")
//        .ToList();
//    Console.WriteLine($"Jumlah samurai adalah... {samurais.Count}");
//    foreach (var samurai in samurais)
//    {
//        Console.WriteLine($"ID: {samurai.Id} - Nama: {samurai.Name}");
//    }
//}
//void GetBattles()
//{
//    var battles = _context.Battles
//        .TagWith("Get Battle Method")
//        .ToList();
//    foreach (var battle in battles)
//    {
//        Console.WriteLine($"{battle.Name}- Start: {battle.StartDate}-End: {battle.EndDate}");
//    }
//}
//void QueryFilters()
//{
//    //var samurais = _context.Samurais.Where(x => x.Name == "Rengoku").ToList();
//    var samurais = _context.Samurais.Where(x => x.Name.StartsWith("Ren")).ToList();
//    //var samurais = _context.Samurais.Where(x => EF.Functions.Like(x.Name, "Re%")).ToList();
//    foreach(var samurai in samurais)
//    {
//        Console.WriteLine(samurai.Name);
//    }
//}
//void QueryAggregates()
//{
//    var name = "Rengoku";
//    //var samurai = _context.Samurais.FirstOrDefault(x=>x.Name==name);//Linq Method (Lambda)
//    var samurai = (from s in _context.Samurais
//                   where s.Name==name
//                   select s).FirstOrDefault();//Linq Query
//    Console.WriteLine($"ID {samurai.Id} - Nama {samurai.Name}");
//}

//void RetrieveAndUpdateSamurai()
//{
//    var samurai = _context.Samurais.SingleOrDefault(x => x.Id == 2);
//    samurai.Name = "Kagura";
//    _context.SaveChanges();
//}
//void RetrieveAndUpdateSamurais()
//{
//    var samurais = _context.Samurais.Skip(0).Take(4).ToList();
//    samurais.ForEach(x => x.Name += " San");
//    _context.SaveChanges();
//}
//void MultipleDatabaseOperations()
//{
//    var samurai = _context.Samurais.OrderBy(x => x.Id).LastOrDefault();
//    samurai.Name += " San";
//    _context.Samurais.Add(new Samurai { Name = "Hayabusa" });
//    _context.SaveChanges();
//}
//void RetrieveAndDeleteSamurai()
//{
//    //var samurai = _context.Samurais.Find(6);
//    //_context.Samurais.Remove(samurai);
//    var samurais = _context.Samurais.Where(x => x.Name.StartsWith("Samurai")).ToList();
//    _context.RemoveRange(samurais);
//    _context.SaveChanges();
//}
//void QueryAndUpdateBattles_Disconnect()
//{
//    List<Battle> disconnectedBattles;
//    using (var context1 = new SamuraiContextNoTracking())
//    {
//        disconnectedBattles = context1.Battles.ToList();
//    }//context1 sudah di dispose
//    disconnectedBattles.ForEach(x =>
//    {
//        x.StartDate = new DateTime(1590, 01, 01);
//        x.EndDate = new DateTime(1597, 09, 01);
//    });
//    using (var context2 = new SamuraContext())
//    {
//        context2.UpdateRange(disconnectedBattles);
//        context2.SaveChanges();
//    }
//}
//void InsertNewSamuraiWithQuote()
//{
//    var samurai = new Samurai
//    {
//        Name = "Kuma",
//        Quotes = new List<Quote>
//        {
//            new Quote { Text = "No Pain No Gain" },
//            new Quote { Text = "You shall not pass" }
//        }
//    };
//    _context.Samurais.Add(samurai);
//    _context.SaveChanges();
//}
//void AddQuotetoExistingSamurai()
//{
//    var samurai = _context.Samurais.Where(x => x.Id == 1).FirstOrDefault();
//    samurai.Quotes.Add(new Quote {
//        Text = "Do not fear death"
//        });
//    _context.SaveChanges();
//}
//void AddQuotetoExistingSamuraiNoTracking(int samuraiId)
//{
//    var samurai = _context.Samurais.Find(samuraiId);
//    samurai.Quotes.Add(
//        new Quote { Text = "Just Do It" });
//    using (var context1 = new SamuraContext())
//    {
//        context1.Samurais.Attach(samurai);
//        context1.SaveChanges();
//    }
//}
//void SimpleAddQuoteToExistingSamuraiNoTracking(int samuraiId)
//{
//    var quote = new Quote { Text = "Do what you believe", SamuraiId = samuraiId };
//    using(var context1 =new SamuraContext())
//    {
//        context1.Quotes.Add(quote);
//        context1.SaveChanges();
//    }
//}
//void EagerLoadiSamuraiWithQuote()
//{
//    //var samuraiWithQuotes = _context.Samurais.Include(x => x.Quotes).ToList();
//    //var filteredEntity = _context.Samurais.Include(s => s.Quotes.Where(q=>q.Text.Contains("fear"))).ToList();
//    var filteredInclude = _context.Samurais.Where(s => s.Name.Contains("%uma"))
//         .Include(s => s.Quotes).ToList();
//}
//void ProjectingSample()
//{
//    //var results = _context.Samurais.Select(s => new { s.Id, s.Name, NumofQuotes = s.Quotes.Count }).ToList();//anonymous type
//    var samuraiAndQuotes = _context.Samurais.Select(s => new
//    {
//        Samurai = s,
//        BestQuote = s.Quotes.Where(q => q.Text.Contains("Do"))
//    }).ToList();
//}
//void ExplicitLoadQuotes()
//{
//    // _context.Set<Horse>().Add(new Horse { SamuraiId = 1, Name = "Michi" });
//    //_context.SaveChanges();
//    var samurai = _context.Samurais.Find(1);
//    _context.Entry(samurai).Collection(s => s.Quotes).Load();

//}
//void FilteringWithRelatedData()
//{
//    var samurais = _context.Samurais.Where(s => s.Quotes.Any(q => q.Text.Contains("Do"))).ToList();
//}
//void ModifyRelatedData()
//{
//    var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 23);
//    samurai.Quotes[0].Text = "A Man's Dream is A Man's Pride";
//    _context.Quotes.Remove(samurai.Quotes[1]);
//    _context.SaveChanges();
//}
//void ModifyRelatedDataNoTracking()
//{
//    var samurai = _context.Samurais.Include(s =>s.Quotes).FirstOrDefault(s => s.Id == 23);
//    var quote = samurai.Quotes[0];
//    quote.Text = "you only live once";

//    using(var context1 = new SamuraContext())
//    {
//        //context1.Quotes.Update(quote);
//        context1.Entry(quote).State = EntityState.Modified;
//        context1.SaveChanges();
//    }
//}
//void AddNewSamuraiToBattle()
//{
//    var battle = _context.Battles.FirstOrDefault();
//    battle.Samurais.Add(new Samurai { Name = "Nobunaga Oda" });
//    _context.SaveChanges();
//}
//void RetrieveBattleWithSamurai()
//{
//    var battles = _context.Battles.Include(s => s.Samurais).ToList();
//}
//void AddAllSamuraisToAllBattles()
//{
//    var allBattles = _context.Battles.ToList();
//    var allSamurais = _context.Samurais.ToList();
//    foreach(var battle in allBattles)
//    {
//        battle.Samurais.AddRange(allSamurais);
//    }
//    _context.SaveChanges();
//}
//void RemoveSamuraiFromBattle()
//{
//    var battleWithSamurai = _context.Battles.Include(b => b.Samurais.Where(s=>s.Id==23))
//        .SingleOrDefault(b=>b.BattleId==1);
//    var samurai = battleWithSamurai.Samurais[0];
//    battleWithSamurai.Samurais.Remove(samurai);
//    _context.SaveChanges();
//}
//void RemoveSamuraiFromBattleExplicit()
//{
//    var battleSamurai = _context.Set<BattleSamurai>()
//        .SingleOrDefault(bs => bs.BattleId==1 && bs.SamuraiId==2);
//    if (battleSamurai != null)
//    {
//        _context.Remove(battleSamurai);
//        _context.SaveChanges();
//    }
//}
//void AddNewSamuraiWithHorse()
//{
//    var samurai = new Samurai { Name = "Roronoa Zoro" };
//    samurai.Horse = new Horse { Name = "Momonosuke" };
//    _context.Samurais.Add(samurai);
//    _context.SaveChanges();
//}
//void AddNewHorseToSamurai()
//{
//    var horse = new Horse { Name = "Ramen", SamuraiId = 2 };
//    _context.Add(horse);
//    _context.SaveChanges();
//}
//void AddNewHorseNoTracking()
//{
//    var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 15);
//    samurai.Horse = new Horse { Name = "Uma" };
//    using (var context1 = new SamuraContext())
//    {
//        context1.Samurais.Attach(samurai);
//        context1.SaveChanges();
//    }
//}
//void GetSamuraiWithHorse()
//{
//    //var samurais = _context.Samurais.Include(s => s.Horse).ToList();
//    var horse = _context.Set<Horse>().Find(2);

//}

//void QuerViewBattleStat()
//{
//   /* var results = _context.SamuraiBattlesStats.ToList();
//    foreach (var stat in results)
//    {
//        Console.WriteLine($"{stat.Name} - {stat.NumberOfBattles} - {stat.EarliestBattle}");
//    }*/
//   var firststat = _context.SamuraiBattlesStats.FirstOrDefault(s => s.Name == "Nobunaga");
//    Console.WriteLine($"{firststat.Name}-{firststat.NumberOfBattles}-{firststat.EarliestBattle}");
//}
//void QueryUsingRawSql()
//{
//    //var samurais = _context.Samurais.FromSqlRaw("SELECT * FROM Samurais").ToList();
//    var name = "Nobunaga";
//    var samurais = _context.Samurais.FromSqlInterpolated($"SELECT * FROM Samurais WHERE Name={name}").ToList();//parameterized
//}

//void StoredProcedureRaw()
//{
//    //var text = "Do";
//    // var samurais = _context.Samurais.FromSqlRaw("EXEC dbo.SamuraisWhoSaidAWord {0}", text).ToList();
//    //var samurais = _context.Samurais.FromSqlInterpolated($"exec dbo.SamuraisWhoSaidAWord {text}").ToList();
//    var samuraiId = 23;
//    _context.Database.ExecuteSqlRaw("exec dbo.DeleteQuotesForSamurai {0}", samuraiId);
//}
//void AddSamuraiByName(params string[] names)
//{
//    var bs = new BusinessDataLogic();
//    var newsamuraiscreatecount = bs.AddSamuraiByName(names);
//}
struct IdAndName
{
    public IdAndName(int id, string name)
    {
       Id= id;
       Name = name;
    }
    public int Id;
    public string Name;
}
