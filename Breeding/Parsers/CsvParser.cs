using System.Globalization;

namespace Breeding.Parsers;
using Datatypes;
public class CsvParser
{
    public List<Horse> ReadHorses(string filePath)
    {
        List<Horse> Horses = new List<Horse>();

        using StreamReader reader = new StreamReader(filePath);
        bool header = true;

        while (reader.ReadLine() is { } nextLine)
        {
            if (header)
            {
                header = false;
                continue;
            }

            string[] data = nextLine.Split(',');

            if (data.Length != 5)
            {
                Console.WriteLine("Malformed Data detected. Please check CSV.");
                return null;
            }

            string hName = data[0].Trim();
            float hPot = float.Parse(data[1], CultureInfo.InvariantCulture);
            int hFin = int.Parse(data[2]);
            float hExtra = float.Parse(data[3], CultureInfo.InvariantCulture);
            float hMat = float.Parse(data[4], CultureInfo.InvariantCulture);
            Horses.Add(new Horse(hName, hPot, hFin, hExtra, hMat));
        }

        return Horses;
    }
}