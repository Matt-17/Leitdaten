using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderOrtsteil : TableReader<Ortsteil>
{
    protected override IEnumerable<TableFieldDefinition<Ortsteil>> GetFields()
    {
        yield return Field(8, null); // Datum ignorieren
        yield return Field(8, (s, m) => m.OrtSchluessel = s);
        yield return Field(3, (s, m) => m.Schluessel = s);
        yield return Field(5, (s, m) => m.Postleitzahl = s);
        yield return Field(1, (s, m) => m.Status = s == "G");
        yield return Field(1, (s, m) => m.ZustellPlz = s == "1");
        yield return Field(40, (s, m) => m.Name = s.Trim());
        yield return Field(8, null); // Gemeindeschlüssel wird ignoriert
    }

    protected override bool IsValidData(Ortsteil data) => data.Status;
}