namespace Leitdaten.Models;

public class Ortsteil : LeitdatenObject
{
    public string OrtSchluessel { get; set; } = null!;
    public string Schluessel { get; set; } = null!;
    public string Postleitzahl { get; set; } = null!;
    public bool ZustellPlz { get; set; }
    public string Name { get; set; } = null!;
    public bool Status { get; set; }
    public override string ToString() => Name;
}