using System.Text;
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

    public void createExampleFilter(ref FileStream filterStream)
    {
        Filter newFilter = new Filter(50, 50, 75, 50, null);
        filterStream.Write(UTF8Encoding.UTF8.GetBytes(JsonSerializer.Serialize(newFilter)));
        filterStream.Close();
    }
}