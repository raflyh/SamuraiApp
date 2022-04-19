namespace SamuraiApp.Domain;

public class Samurai
{
    public int Id {get; set;}//primary key
    public string? Name {get; set;}
    public List<Quote> Quotes {get; set;} = new List<Quote>(); //relasi one to many
    public List<Battle> Battles {get; set;} = new List<Battle>();
    public List<Katana> Katanas {get; set;} = new List<Katana>();  
    public Horse? Horse {get; set;}
}
