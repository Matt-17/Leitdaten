using Leitdaten.Models;

namespace Leitdaten.Processor;

internal abstract class TableReader<T> : ITableReader where T : LeitdatenObject, new()
{
    protected readonly List<TableFieldDefinition<T>> Fields = [];

    protected List<T?> Rows { get; } = [];

    public int Length { get; set; }

    public int Count { get; set; }

    public int Total { get; set; }

    public void Initialize()
    {
        Fields.AddRange(GetFields().ToList());
        Length = Fields.Sum(x => x.Length);
    }

    public LeitdatenObject? Process(string data)
    {
        if (data.Length != Length)
            throw new InvalidDataException("Länge der Daten stimmt nicht mit Definition überein");

        var index = 0;
        var entity = new T();
        foreach (var field in Fields)
        {
            var s = data.Substring(index, field.Length);
            field.Invoke(s, entity);
            index += field.Length;
        }

        Total++;

        if (!IsValidData(entity))
            return null;

        Rows.Add(entity);
        Count++;

        return entity;
    }

    protected static TableFieldDefinition<T> Field(int length, Action<string, T>? action) => new(length, action);

    protected abstract IEnumerable<TableFieldDefinition<T>> GetFields();

    protected abstract bool IsValidData(T data);
}