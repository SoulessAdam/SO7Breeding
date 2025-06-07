using System.Reflection.Metadata;

namespace Breeding.Datatypes;

public struct Horse
{
    public string Name;
    public float Pot;
    public int Finish;
    public float Extra;
    public float Mat;

    public Horse(string Name, float Pot, int Finish, float Extra, float Mat)
    {
        this.Name = Name;
        this.Pot = Pot;
        this.Finish = Finish;
        this.Extra = Extra;
        this.Mat = Mat;
    }

}