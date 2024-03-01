using System.Text;

using Leitdaten;

if (args.Length != 1)
{
    Console.WriteLine($"Befehl: {Path.GetFileNameWithoutExtension(Environment.ProcessPath)} {{Leitdaten-Datei (.dat)}}");
    return 1;
}

var filename = args[0];

if (!File.Exists(filename))
{
    Console.WriteLine("Die Datei wurde nicht gefunden");
    return 2;
}

if (!Path.GetExtension(filename).Equals(".dat", StringComparison.CurrentCultureIgnoreCase))
{
    Console.WriteLine("Die Datei ist im falschen Format");
    return 3;
}

var version = Path.GetFileNameWithoutExtension(filename)[1..];
if (version is not { Length: 7 })
{
    Console.WriteLine("Der Dateiname ist nicht versioniert");
    return 4;
}


var _count = 0;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
var encoding = Encoding.GetEncoding(850);
var processor = new FileProcessor(version);
processor.Initialize();
var keys = processor.GetKeys();

using (var reader = new StreamReader(filename, encoding))
{
    try
    {
        while (reader.Peek() != -1)
        {
            var readLine = reader.ReadLine();
            if (string.IsNullOrWhiteSpace(readLine))
                continue;
            var entity = processor.ProcessLine(readLine);

            // Ausgabe der aktuellen Zeile als Objekt
            //Console.WriteLine(entity switch
            //{
            //    Strasse strasse => $"Strasse: {strasse}",
            //    Postleitzahl postleitzahl => $"Postleitzahl: {postleitzahl}",
            //    Gemeinde gemeinde => $"Gemeinde: {gemeinde}",
            //    Ortsteil ortsteil => $"Ortsteil: {ortsteil}",
            //    Ort ort => $"Ort: {ort}",
            //    _ => string.Empty
            //});

            _count++;
        }
    }
    catch (Exception e)
    {

        Console.WriteLine("Fehler beim Verarbeiten: " + e.Message);
        return 5;
    }
}


Console.WriteLine($"{_count} Datensätze gelesen");
Console.WriteLine("===========================");

foreach (var key in keys)
{
    Console.WriteLine($"{key}: {processor.GetCount(key)} von {processor.GetTotal(key)} Datensätzen gelesen");
}

Console.WriteLine("Die Daten wurden erfolgreich importiert");
return 0;