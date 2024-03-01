namespace Leitdaten.Models;

public class Ort : LeitdatenObject
{
    public string Schluessel { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Zusatz { get; set; } = null!;
    public bool ZusatzArt { get; set; }
    public string GemeindeSchluessel { get; set; } = null!;
    public bool Status { get; set; }
    public override string ToString() => Name;
}