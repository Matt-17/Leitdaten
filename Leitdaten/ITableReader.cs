using Leitdaten.Models;

namespace Leitdaten;

internal interface ITableReader
{
    int Count { get; }
    int Total { get; }
    void Initialize();
    LeitdatenObject? Process(string data);
}