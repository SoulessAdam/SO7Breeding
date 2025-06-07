namespace Breeding.Datatypes;

public class Child
{
    public string Pairing;
    public float Pot;
    public int Finish;
    public float Extra;
    public float Mat;

    public Child(Horse Sire, Horse Mare)
    {
        this.Pairing = $"{Sire.Name} x {Mare.Name}";
        
    }
}