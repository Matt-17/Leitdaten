using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderPostleitzahl : TableReader<Postleitzahl>
{
    protected override IEnumerable<TableFieldDefinition<Postleitzahl>> GetFields()
    {
        yield return Field(8, null);
        yield return Field(5, (s, m) => m.PLZ = s);
        yield return Field(8, (s, m) => m.OrtSchluessel = s);
        yield return Field(2, (s, m) => m.PLZArt = Convert.ToInt32(s));
        yield return Field(1, (s, m) => m.ZustellPlz = s == "1");
        yield return Field(1, null);
        yield return Field(40, null);
        yield return Field(30, null);
        yield return Field(1, null);
        yield return Field(24, null);
        yield return Field(1, null);
        yield return Field(8, null);
        yield return Field(8, null);
        yield return Field(8, null);
        yield return Field(3, (s, m) => m.OrtCode = string.IsNullOrWhiteSpace(s) ? null : s);
        yield return Field(3, null);
        yield return Field(1, null);
        yield return Field(2, null);
        yield return Field(2, null);
        yield return Field(2, null);
    }

    protected override bool IsValidData(Postleitzahl data) => true;
}