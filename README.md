# Leitdaten

## Einführung
Leitdaten ist ein kleines Projekt, entwickelt, um die Verarbeitung der Leitdaten der Deutschen Post im .dat-Dateiformat zu unterstützen. 
Diese Library bietet eine API, die das Einlesen und Verarbeiten von Daten etwas vereinfacht.

## Schnellstart
Um schnell mit Leitdaten zu starten, lese eine .dat-Datei ein und verarbeite sie wie folgt:

```csharp
using Leitdaten;

var processor = new FileProcessor("1903060");
processor.Initialize();
```

## Verwendung
### Daten einlesen und verarbeiten
Um eine .dat-Datei zu verarbeiten, verwende die FileProcessor-Klasse:

```csharp
var processor = new FileProcessor("Version1");
processor.Initialize();

using (var reader = new StreamReader("meineDaten.dat", Encoding.GetEncoding(850)))
{
    var line = "";
    while ((line = reader.ReadLine()) != null)
    {
        var entity = processor.ProcessLine(line);
		// mach was damit...
    }
}
```

### Statistiken ausgeben
Nach der Verarbeitung kannst du einfache Statistiken zu den gelesenen Datensätzen ausgeben:

```csharp
Console.WriteLine($"Gelesene Datensätze: {processor.GetCount()}");
```

## Beitragen
Bei Wünschen gern ein Issue eröffnen.

## Lizenz
Leitdaten ist unter der MIT-Lizenz veröffentlicht. Weitere Details findest du in der LICENSE-Datei.
