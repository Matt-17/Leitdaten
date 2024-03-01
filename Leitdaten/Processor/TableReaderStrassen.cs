using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderStrassen : TableReader<Strasse>
{
    protected override IEnumerable<TableFieldDefinition<Strasse>> GetFields()
    {
        yield return Field(8, null);
        yield return Field(8, (s, m) => m.OrtSchluessel = s);
        yield return Field(11, (s, m) => m.Schluessel = s);
        yield return Field(8, (s, m) => m.HausnummerVon = string.IsNullOrWhiteSpace(s) ? null : s);
        yield return Field(8, (s, m) => m.HausnummerBis = string.IsNullOrWhiteSpace(s) ? null : s);
        yield return Field(1, (s, m) => m.Status = s == "G");
        yield return Field(1, null);
        yield return Field(1, null);
        yield return Field(46, null);
        yield return Field(46, (s, m) => m.Name = s.Trim());
        yield return Field(22, (s, m) => m.NameKurz = s.Trim());
        yield return Field(1, null);
        yield return Field(1, (s, m) => m.Hausnummernbereich = s == "N" ? 0 : s == "G" ? 1 : 2);
        yield return Field(5, (s, m) => m.Postleitzahl = s);
        yield return Field(3, (s, m) => m.Code = s);
        yield return Field(3, (s, m) => m.OrtsteilSchluessel = string.IsNullOrWhiteSpace(s) ? null : s);
        yield return Field(8, null);
        yield return Field(8, (s, m) => m.GemeindeSchluessel = s);
        yield return Field(8, null); // Archivdatensätze
        yield return Field(11, null);
        yield return Field(8, null);
        yield return Field(8, null);
    }

    protected override bool IsValidData(Strasse data) => data.Status;
}