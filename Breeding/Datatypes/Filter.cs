using System.Text.Json.Serialization;

namespace Breeding.Datatypes;

public struct Filter
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Pot")]
    public float? minPot { private set; get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Finish")]
    public int? minFin { private set; get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Extra")]
    public float? minExt { private set; get; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Mat")]
    public float? minMat  { private set; get; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("Score")]
    public float? minScore { private set; get; }

    public Filter(float? Pot, int? Fin, float? Extra, float? mat, float? score)
    {
        minPot = Pot;
        minFin = Fin;
        minExt = Extra;
        minMat = mat;
        minScore = score;
    }

    public float? getPot()
    {
        return minPot;
    }

    public int? getFin()
    {
        return minFin;
    }

    public float? getExtra()
    {
        return minExt;
    }

    public float? minMaturity()
    {
        return minMat;
    }

    public float? getScore()
    {
        return minScore;
    }
}