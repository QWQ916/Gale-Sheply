using Referat2;
using System.Collections.Specialized;

class Program
{ 
    private static void Main()
    {
        Dictionary<string, string> pairs = new Dictionary<string, string>();

        Dictionary<string, List<string>> WPref = new Dictionary<string, List<string>>()
        {
            {"w1", new List<string>(){"m2", "m1", "m3" } },
            {"w2", new List<string>(){"m1", "m3", "m2" } },
            {"w3", new List<string>(){"m1", "m2", "m3" } }
        };
        Dictionary<string, List<string>> MPref = new Dictionary<string, List<string>>()
        {
            {"m1", new List<string>(){"w1", "w2", "w3" } },
            {"m2", new List<string>(){"w1", "w2", "w3" } },
            {"m3", new List<string>(){"w2", "w3", "w1" } }
        };

        List<string> freemen = new List<string>(MPref.Keys);
        void print()
        {
            Console.WriteLine();
            foreach (var v in freemen)
            {
                Console.Write($"{v} ");
            }
            Console.Write("   |   ");
            foreach (var x in pairs) Console.Write($"{x.Key} -- {x.Value};  ");
            Console.WriteLine();
        }
        print();
        while (freemen.Count > 0)
        {
            string m = freemen[0];
            var mp = MPref[m];
            foreach (var w in mp)
            {
                if (!pairs.ContainsKey(w))
                {
                    pairs.Add(w, m);
                    freemen.Remove(m);
                    break;
                }
                else
                {
                    var wp = WPref[w];
                    string currentPartner = pairs.GetValueOrDefault(w);
                    int icurrentPartner = wp.IndexOf(currentPartner);
                    int im = wp.IndexOf(m);
                    if (im < icurrentPartner)
                    {
                        pairs.Remove(w);
                        freemen.Add(currentPartner);
                        pairs.Add(w, m);
                        freemen.Remove(m);
                        break;
                    }
                }
            }
            print();
        }
        foreach (var pair in pairs)
        {
            Console.WriteLine($"{pair.Value} -- {pair.Key}");
        }
        Console.ReadKey();
    }
}
