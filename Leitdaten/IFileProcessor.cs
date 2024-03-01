using Leitdaten.Models;

namespace Leitdaten;

public interface IFileProcessor
{
    void Initialize();
    LeitdatenObject? ProcessLine(string line);
    List<string> GetKeys();
    string GetTotal(string key);
    string GetCount(string key);
}