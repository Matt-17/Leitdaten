namespace Leitdaten.Models;

public class Strasse : LeitdatenObject
{
    public string Schluessel { get; set; } = null!;
    public string OrtSchluessel { get; set; } = null!;
    public string? OrtsteilSchluessel { get; set; }
    public string? HausnummerVon { get; set; }
    public string? HausnummerBis { get; set; }
    public string Name { get; set; } = null!;
    public string NameKurz { get; set; } = null!;
    public int Hausnummernbereich { get; set; }
    public string Postleitzahl { get; set; } = null!;
    public string Code { get; set; } = null!;
    public string GemeindeSchluessel { get; set; } = null!;
    public bool Status { get; set; }
    public override string ToString() => Name;
}