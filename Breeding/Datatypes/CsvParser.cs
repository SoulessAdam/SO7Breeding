using System.Globalization;

namespace Breeding.Datatypes;

public class CsvParser
{
    public static List<Horse> ReadHorses(string filePath)
    {
        List<Horse> Horses = new List<Horse>();

        using (StreamReader reader = new StreamReader(filePath))
        {
            string? nextLine;
            bool header = true;

            while ((nextLine = reader.ReadLine()) != null)
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
        }
        return Horses;
    }
}