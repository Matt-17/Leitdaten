namespace Leitdaten.Processor;

internal sealed class TableFieldDefinition<T>(int length, Action<string, T>? action)
{
    private readonly Action<string, T>? _action = action;

    internal int Length { get; } = length;

    internal void Invoke(string data, T entity) => _action?.Invoke(data, entity);
}