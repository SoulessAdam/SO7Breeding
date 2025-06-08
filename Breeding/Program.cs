using System.Text;
using Breeding.Datatypes;
using Breeding.Parsers;

string myDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
if (!Directory.Exists(Path.Join(myDocumentPath, "SO7Breeding")))
{
    Console.WriteLine($"Initialising Directory {myDocumentPath}/SO7Breeding");
    FileStream filterStream = File.Create(String.Join(Path.Join(myDocumentPath, "SO7Breeding"), "Filter.json"));
    filterStream.Write(UTF8Encoding.UTF8.GetBytes("{\n  \"Pot\" : null,\n  \"Finish\" : null,\n  \"Extra\" : null,\n  \"Mat\" : null,\n  \"Score\" : null\n}"));
    filterStream.Close();
    
    FileStream mareStream = File.Create(String.Join(Path.Join(myDocumentPath, "SO7Breeding"), "Mares.csv"));
    FileStream stallionStream = File.Create(String.Join(Path.Join(myDocumentPath, "SO7Breeding"), "Stallions.csv"));
    mareStream.Write(UTF8Encoding.UTF8.GetBytes("Name,Pot,Finish,Extra,Mat"));
    stallionStream.Write(UTF8Encoding.UTF8.GetBytes("Name,Pot,Finish,Extra,Mat"));
    mareStream.Close();
    stallionStream.Close();
    
    Console.WriteLine("Directory and files created, please fill in info accordingly before continuing...");
    Environment.Exit(0);
}

CsvParser cParse = new CsvParser();
FilterParser fParse = new FilterParser();
Filter filter = fParse.parseFilter();
List<Horse> Stallions = new List<Horse>(cParse.ReadHorses(Path.Join(myDocumentPath, "SO7Breeding", "Stallions.csv")));
List<Horse> Mares = new List<Horse>(cParse.ReadHorses(Path.Join(myDocumentPath, "SO7Breeding", "Mares.csv")));
Child[] children = new Child[Stallions.Count * Mares.Count];
int idx = 0;
foreach (Horse sire in Stallions)
{
    foreach (Horse dam in Mares)
    {
        Child foal = new Child(sire, dam);
        if (foal.Pot < filter.getPot() || foal.Extra < filter.getExtra() || foal.Finish < filter.getFin() || foal.Score < filter.getScore())
        {
            continue;
        }

        children[idx] = foal;
        idx++;
    }
}
foreach (Child foal in children.OrderByDescending(x => x.Score))
{
    Console.WriteLine(foal);
}