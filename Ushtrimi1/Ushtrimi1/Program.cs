using System;
using System.Collections.Generic;
using System.Linq;

public class Lende
{
    public string EmriLendes { get; set; }

    public Lende(string emriLendes)
    {
        EmriLendes = emriLendes;
    }
}

public class Punonjes
{
    public string Emri { get; set; }
    private string Roli { get; }
    private string FullName => Roli + " " + Emri;

    public Punonjes(string emri)
    {
        Emri = emri;
        Roli = "Software Developer";
    }

    public string GetPunonjesFullName()
    {
        return FullName;
    }

    public List<Lende> Lendet { get; set; } = new List<Lende>();
}

public class Intern
{
    public string EmriKompanise { get; } = "Helius Systems";
    public string Emri { get; set; }
    public string Mbiemri { get; set; }
    public string EmriPlote => Emri + " " + Mbiemri;
    public int Mosha { get; set; }
}

class Program
{
    static void Main()
    {
       
        var lenda1 = new Lende("Web Dev");
        var lenda2 = new Lende("AI");
        var lenda3 = new Lende("Databases");
        var lenda4 = new Lende("Data Management");

        
        var punonjes1 = new Punonjes("Dukagjin Maxhuni");
        punonjes1.Lendet.AddRange(new List<Lende> { lenda1, lenda2, lenda3 });

        var punonjes2 = new Punonjes("Mirsjell Cumani");
        punonjes2.Lendet.AddRange(new List<Lende> { lenda2, lenda3, lenda4 });

        var punonjes3 = new Punonjes("Lavdimir Qosja");
        punonjes3.Lendet.AddRange(new List<Lende> { lenda1, lenda4 });

       
        var intern1 = new Intern { Emri = "Gugush", Mbiemri = "Amiti", Mosha = 22 };
        var intern2 = new Intern { Emri = "Vllazerim", Mbiemri = "Corbajram", Mosha = 51 };
        var intern3 = new Intern { Emri = "Zbukurime", Mbiemri = "Bajramovic", Mosha = 23 };
        var intern4 = new Intern { Emri = "Guci", Mbiemri = "Sapunxhiu", Mosha = 18 };

        
        var interns = new List<Intern> { intern1, intern2, intern3, intern4 };

       
        var youngestInterns = interns.OrderBy(i => i.Mosha).Take(3).ToList();

       
        var punonjesMesonLendet = new Dictionary<Punonjes, int>();
        foreach (var punonjes in new List<Punonjes> { punonjes1, punonjes2, punonjes3 })
        {
            punonjesMesonLendet[punonjes] = punonjes.Lendet.Count;
        }

      
        var maxLendet = punonjesMesonLendet.Max(kv => kv.Value);
        var punonjesMeMeShumeLende = punonjesMesonLendet
            .Where(kv => kv.Value == maxLendet)
            .Select(kv => kv.Key)
            .ToList();

        
        var internWithLongestName = interns.OrderByDescending(i => i.EmriPlote.Length).FirstOrDefault();

        
        var startingLetters = interns.Select(i => i.Emri[0]).ToList();
        var mostCommonStartingLetter = startingLetters
            .GroupBy(c => c)
            .OrderByDescending(g => g.Count())
            .First()
            .Key;

        var averageAge = interns.Average(i => i.Mosha);

        Console.WriteLine("3 intern me te vegjel:");
        foreach (var intern in youngestInterns)
        {
            Console.WriteLine($"Emri: {intern.EmriPlote}, Mosha: {intern.Mosha}");
        }

        Console.WriteLine("\nNr i lendeve te dhena nga punonjesit:");
        foreach (var punonjes in punonjesMesonLendet.Keys)
        {
            Console.WriteLine($"{punonjes.Emri}: {punonjesMesonLendet[punonjes]} lende");
        }

        Console.WriteLine("\nPunonjesit qe japin me shume kurse:");
        foreach (var punonjes in punonjesMeMeShumeLende)
        {
            Console.WriteLine($"{punonjes.Emri}");
        }

        Console.WriteLine($"\nInterni me emer me te gjate: {internWithLongestName.EmriPlote}");
        Console.WriteLine($"Germa me e shpeshte me te cilin nis emri i intern: {mostCommonStartingLetter}");
        Console.WriteLine($"Mosha mesatare e intern: {averageAge}");
    }
}
