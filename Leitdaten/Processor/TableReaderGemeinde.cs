using System.Globalization;
using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderGemeinde : TableReader<Gemeinde>
{
    protected override IEnumerable<TableFieldDefinition<Gemeinde>> GetFields()
    {
        yield return Field(8, (s, m) => m.Datum = DateTime.ParseExact(s, "yyyyMMdd", CultureInfo.InvariantCulture));
        yield return Field(8, (s, m) => m.Schluessel = s);
        yield return Field(1, (s, m) => m.Satzart = s);
        yield return Field(40, (s, m) => m.Name = s.Trim());
    }

    protected override bool IsValidData(Gemeinde data) => data.Satzart == "G";
}