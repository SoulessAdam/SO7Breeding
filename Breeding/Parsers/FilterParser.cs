using System.Text.Json;
using Breeding.Datatypes;

namespace Breeding.Parsers;

public class FilterParser
{
    public Filter parseFilter()
    {
        string jsonTxt = File.ReadAllText(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "SO7Breeding", "Filter.json"));
        return JsonSerializer.Deserialize<Filter>(jsonTxt);
    }
}