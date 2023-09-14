using System;

public interface IMotomjeti
{
    string Tipi { get; set; }
    string Zhurma { get; set; }
    string ZhurmaMjetit();
    void TeDhenateMjetit();
}

public abstract class Patenta
{
    public abstract int MoshaMinPatentes { get; }
    public abstract int MoshaMaxPatentes { get; }
    public abstract void TeDhenatePatentes();
}

public class Automjeti : IMotomjeti
{
    public string Tipi { get; set; }
    public string Zhurma { get; set; }

    public string ZhurmaMjetit()
    {
        return $"Automjeti tipi {Tipi} zhurmon {Zhurma}.";
    }

    public void TeDhenateMjetit()
    {
        Console.WriteLine($"Te dhenat e automjetit: Tipi - {Tipi}, Zhurma - {Zhurma}");
    }
}

public class Aeroplani : IMotomjeti
{
    public string Tipi { get; set; }
    public string Zhurma { get; set; }

    public string ZhurmaMjetit()
    {
        return $"Aeroplan tipi {Tipi} zhurmon {Zhurma}.";
    }

    public void TeDhenateMjetit()
    {
        Console.WriteLine($"Te dhenat e aeroplanit: Tipi - {Tipi}, Zhurma - {Zhurma}");
    }
}

class Program
{
    static void Main()
    {
        
        IMotomjeti automjeti = new Automjeti { Tipi = "Benz", Zhurma = "brrr" };
        IMotomjeti aeroplani = new Aeroplani { Tipi = "F-22", Zhurma = "viuu" };

       
        Console.WriteLine(automjeti.ZhurmaMjetit());
        automjeti.TeDhenateMjetit();

        Console.WriteLine(aeroplani.ZhurmaMjetit());
        aeroplani.TeDhenateMjetit();
    }
}
