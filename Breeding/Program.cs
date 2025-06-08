using Breeding.Datatypes;
using Breeding.Parsers;

string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
if (!Directory.Exists(Path.Join(myDocumentPath, "SO7Breeding")))
{
    Console.WriteLine($"Initialising Directory {myDocumentPath}/SO7Breeding");
    File.Create(Path.Join(myDocumentPath, "SO7Breeding", "Filter.json"));
    File.Create(Path.Join(myDocumentPath, "SO7Breeding", "Mares.csv"));
    File.Create(Path.Join(myDocumentPath, "SO7Breeding", "Stallions.csv"));
    Console.WriteLine("Directory and files created, please fill in info accordingly before continuing...");
    File.WriteAllText(Path.Join(myDocumentPath, "SO7Breeding", "Filter.json"), "{\n  \"Pot\" : null,\n  \"Finish\" : null,\n  \"Extra\" : null,\n  \"Mat\" : null,\n  \"Score\" : null\n}");
    File.WriteAllText(Path.Join(myDocumentPath, "SO7Breeding", "Mares.csv"), "Name,Pot,Finish,Extra,Mat}");
    File.WriteAllText(Path.Join(myDocumentPath, "SO7Breeding", "Stallions.csv"), "Name,Pot,Finish,Extra,Mat");
    Environment.Exit(0);
}

CsvParser cParse = new CsvParser();
List<Horse> Stallions = new List<Horse>(cParse.ReadHorses(Path.Join(myDocumentPath, "SO7Breeding", "Stallions.csv")));
List<Horse> Mares = new List<Horse>(cParse.ReadHorses(Path.Join(myDocumentPath, "SO7Breeding", "Mares.csv")));
Child[] children = new Child[Stallions.Count * Mares.Count];
int idx = 0;
foreach (Horse sire in Stallions)
{
    foreach (Horse dam in Mares)
    {
        children[idx] = new Child(sire, dam);
    }
}