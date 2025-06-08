namespace Breeding.Datatypes;

public class Child
{
    public string Pairing;
    public float Pot;
    public int Finish;
    public float Extra;
    public float Mat;
    public float Score;
    float calcChildStat(float sireStat, float damStat)
    {
        float mean = (sireStat + damStat) / 2f;
        float max = Math.Max(sireStat, damStat);
        float bonusRange = 5f + (100 - max) * 0.1f;

        // Small chance for mutation spike (rare elite horses)
        float mutation = mutationBonusChance(0.01f) ? new Random().Next(0, 5) : 0f;

        float bonus = randRange(-3f, bonusRange) + mutation;

        return Math.Clamp(mean + bonus, 0f, 100f);
    }

    private float randRange(float min, float max)
    {
        Random rnd = new Random(Guid.NewGuid().GetHashCode());
        return (float)(rnd.NextDouble() * (max - min) + min);
    }
    
    private bool mutationBonusChance(double probability)
    {
        return new Random().NextDouble() < probability;
    }

    public Child(Horse Sire, Horse Dam)
    {
        Pairing = $"{Sire.Name} x {Dam.Name}";
        Pot = calcChildStat(Sire.Pot, Dam.Pot);
        Finish = (int)calcChildStat(Sire.Finish, Dam.Finish);
        Extra = calcChildStat(Sire.Extra, Dam.Extra);
        Mat = calcChildStat(Sire.Mat, Dam.Mat);
        Score = calculateScore();
    }
    
    private float calculateScore() {
        return (
            Pot * 0.2f +
            Finish * 0.4f +   
            Extra * 0.3f + 
            Mat * 0.1f 
        );
    }

    public override string ToString()
    {
        return $"{Pairing} : {Score} : Pot {Pot} | Finish {Finish} | Extra {Extra} | Mat {Mat}";
    }
}