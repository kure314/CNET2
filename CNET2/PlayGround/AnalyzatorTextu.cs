using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayGround
{
    public class AnalyzatorTextu
    {
        public static Dictionary<string, int> AnalyzovatText(string nazevSouboru)
        {
            var celaKniha = File.ReadAllText(nazevSouboru).Split(' ');
            var pocet = celaKniha.GroupBy(x => x).Select(g => (Klic: g.Key, Pocet: g.Count())).OrderByDescending(g => g.Pocet).Take(10);

            Dictionary<string, int> vysledek = new Dictionary<string, int>();
            foreach (var tuple in pocet)
            {
                vysledek.Add(tuple.Klic, tuple.Pocet);
            }
            return vysledek;
        }
    }
}
