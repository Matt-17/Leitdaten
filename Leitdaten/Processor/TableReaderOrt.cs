using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderOrt : TableReader<Ort>
{
    protected override IEnumerable<TableFieldDefinition<Ort>> GetFields()
    {
        yield return Field(8, null);
        yield return Field(8, (s, m) => m.Schluessel = s);
        yield return Field(1, (s, m) => m.Status = s == "G");
        yield return Field(40, (s, m) => m.Name = s.Trim());
        yield return Field(40, null);
        yield return Field(30, (s, m) => m.Zusatz = s.Trim());
        yield return Field(1, (s, m) => m.ZusatzArt = s == "1");
        yield return Field(24, null);
        yield return Field(8, (s, m) => m.GemeindeSchluessel = s);
        yield return Field(8, null);
    }

    protected override bool IsValidData(Ort data) => data.Status;
}