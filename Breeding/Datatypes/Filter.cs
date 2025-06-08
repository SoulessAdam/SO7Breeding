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

    [JsonConstructor]
    public Filter(float? Pot, int? Finish, float? Extra, float? Mat, float? Score)
    {
        minPot = Pot;
        minFin = Finish;
        minExt = Extra;
        minMat = Mat;
        minScore = Score;
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