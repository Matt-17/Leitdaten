namespace Leitdaten.Models;

public class Prueftabelle : LeitdatenObject
{
    public string Dateikennung { get; set; } = null!;
    public string Status { get; set; } = null!;
    public int Satzzahl { get; set; }
    public long DatumSumme { get; set; }
    public override string ToString() => Dateikennung;
}