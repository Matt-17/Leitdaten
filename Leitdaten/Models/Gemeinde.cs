namespace Leitdaten.Models;

public class Gemeinde : LeitdatenObject
{
    public string Schluessel { get; set; } = null!;
    public string Satzart { get; set; } = null!;
    public DateTime Datum { get; set; }
    public string Name { get; set; } = null!;
    public override string ToString() => Name;
}