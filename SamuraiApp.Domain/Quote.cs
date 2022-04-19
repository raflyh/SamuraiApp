namespace SamuraiApp.Domain;

public class Quote
{
    public int Id {get; set;}
    public string? Text {get; set;}
    public Samurai? Samurai {get; set;} //relasi many to one
    public int SamuraiId { get; set; } //explicit foreign key
}
