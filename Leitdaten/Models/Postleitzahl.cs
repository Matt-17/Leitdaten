namespace Leitdaten.Models;

public class Postleitzahl : LeitdatenObject
{
    public string PLZ { get; set; } = null!;
    public string OrtSchluessel { get; set; } = null!;
    public bool ZustellPlz { get; set; }
    public string? OrtCode { get; set; }
    public int PLZArt { get; set; }
    public override string ToString() => PLZ;
}