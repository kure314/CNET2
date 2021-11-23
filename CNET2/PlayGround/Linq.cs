using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class Linq
    {
        public static void Vyhodnotit()
        {
            string vstupTXT = "def.txt";
            string[] radky = File.ReadAllLines(vstupTXT);
            System.Drawing.Size velikostTisku = new System.Drawing.Size(0, 0);

            try
            {
                //toto nefunguje
                //var pokus333 = radky.Select(z => (Typ: z.Split(',')[0], Hodnota: z.Split(',')[1], X: Convert.ToInt32(z.Split(',')[7]),Y:Convert.ToInt32(z.Split(',')[8]))).Where(k => k.Typ == "I" && k.Hodnota == "7").FirstOrDefault();

                // toto je o trochu lepší, ale není zaručeno, že prvky [7] a [8] existují
                var pok444 = radky.Select(x => x.Split(',')).Where(g => g[0] == "I" && g[1] == "7" && g.Length>=8 ).Select(f=> (Sire:f[7],Vyska:f[8])).FirstOrDefault();
                if (pok444.Sire == null || pok444.Vyska==null) throw new Exception("Nenalezena definice pro velikost tisku.");
                if (char.IsDigit(pok444.Sire,0))
                {
                    Console.WriteLine("je digit");
                }
                return;
                //radky.Split // nejde napsat
                //if (pok333 == null) throw new Exception("Nejsou data");
                var ii = radky.Select(z => z).Where(x => x.Split(',')[0] == "I" && x.Split(',')[1] == "7").FirstOrDefault();
                if (ii == null) throw new Exception("Nenalezena definice pro velikost tisku.");
                var tuple = (Sire: ii.Split(',')[7], Vyska: ii.Split(',')[8]);
                velikostTisku = new System.Drawing.Size(Convert.ToInt32(tuple.Sire), Convert.ToInt32(tuple.Vyska));
                Console.WriteLine($"Šířka = {velikostTisku.Width}, výška = {velikostTisku.Height}");
            }
            catch
            {
                throw new Exception("Nenalezena definice pro velikost tisku.");
            }
        }
    }
}
