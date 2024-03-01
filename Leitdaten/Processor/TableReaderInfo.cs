using Leitdaten.Models;

namespace Leitdaten.Processor;

internal sealed class TableReaderInfo : TableReader<Prueftabelle>
{
    protected override IEnumerable<TableFieldDefinition<Prueftabelle>> GetFields()
    {
        yield return Field(2, (s, m) => m.Dateikennung = s);
        yield return Field(1, (s, m) => m.Status = s);
        yield return Field(8, (s, m) => m.Satzzahl = Convert.ToInt32(s));
        yield return Field(16, (s, m) => m.DatumSumme = Convert.ToInt64(s));
    }

    private readonly Dictionary<string, int> info = [];

    protected override bool IsValidData(Prueftabelle data)
    {
        if (data.Status == "G")
        {
            info.Add(data.Dateikennung, data.Satzzahl);
        }
        return true;
    }

    public int GetTotal(string key)
    {
        if (key == "XX")
            return Count;
        return info.GetValueOrDefault(key, -1);
    }
}