using Leitdaten.Models;
using Leitdaten.Processor;

namespace Leitdaten;

public sealed class FileProcessor(string version) : IFileProcessor
{
    private readonly Dictionary<string, ITableReader?> _readers = [];
    private readonly string _version = version;
    private TableReaderInfo _info = null!;

    public void Initialize()
    {
        _info = new TableReaderInfo();
        _readers.Add("XX", _info);
        _readers.Add("KG", new TableReaderGemeinde());
        _readers.Add("OR", new TableReaderOrt());
        _readers.Add("OB", new TableReaderOrtsteil());
        _readers.Add("GE", null); // Großempfänger werden ignoriert
        _readers.Add("OE", null); // Organisationseinheiten werden ignoriert
        _readers.Add("PF", null); // Postfachverzeichnis wird ignoriert
        _readers.Add("PL", new TableReaderPostleitzahl());
        _readers.Add("SB", new TableReaderStrassen());

        foreach (var reader in _readers.Values)
        {
            reader?.Initialize();
        }
    }

    private ITableReader? Get(string table)
    {
        if (!_readers.TryGetValue(table, out var processor))
            throw new ArgumentOutOfRangeException(nameof(table), $"Prozessor für {table} wurde nicht gefunden");

        return processor;
    }

    public LeitdatenObject? ProcessLine(string line)
    {
        line = line.Trim();
        var table = line[..2];
        var version = line[2..9];
        var data = line[9..^1];

        if (!string.Equals(version, _version, StringComparison.OrdinalIgnoreCase))
            throw new Exception("Versionsdaten stimmen nicht überein");

        return Get(table)?.Process(data);
    }

    public List<string> GetKeys() => _readers
        .Where(reader => reader.Value != null)
        .Select(reader => reader.Key)
        .ToList();

    public string GetTotal(string key) => _info.GetTotal(key).ToString();

    public string GetCount(string key) => Get(key)?.Count.ToString() ?? "-";
}