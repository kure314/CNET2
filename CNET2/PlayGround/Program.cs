// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using PlayGround;

//Tasky();

HttpClient httpClient = new HttpClient();

var res = await httpClient.GetAsync("https://google.com");
if(res.StatusCode == System.Net.HttpStatusCode.NotFound)
{
    return;
}

if (res.IsSuccessStatusCode)
{
    string conte = res.Content.ReadAsStringAsync().Result; // toto je synchronně

}



static void Tasky()
{
    string cestaSouboru = @"C:\Programovani\bigfiles\words01.txt";
    string cestaSouboru2 = @"C:\Programovani\bigfiles\words09.txt";

    var task1 = Task.Run(() => {
        TextTools.Analyza.FreqAnalysisFromFile(cestaSouboru, Environment.NewLine);
        Console.WriteLine("Doběhl Task 1");
    });



    var task2 = Task<Dictionary<string, int>>.Run(() => {
        var kk = TextTools.Analyza.FreqAnalysisFromFile(cestaSouboru2, Environment.NewLine);
        return TextTools.Analyza.GetTopWords(10, kk);

    });


    //Task.WaitAny(task1, task2);

    Task.WhenAll(task1, task2);
    //var kompozitni = Task.WhenAll(task1, task2);

    //kompozitni.Wait();

    Dictionary<string, int> vys = task2.Result;

    //Tisk("Kniha z tasku 2", vys);


    Console.WriteLine("Program skončil");

}







////Console.WriteLine("Hello, World!");
//var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
//var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

//Linq.Vyhodnotit();
//return;

//var vysledek = strings.Select( x => x.ToUpper());
////Debug.WriteLine(vysledek);

////PrintList(vysledek.ToList());
//bool isOnlyEvenNumber = numbers.All(x => x % 2 == 0);
////Console.WriteLine($"Jsou všechna čísla sudá? {isOnlyEvenNumber}");

//var slova = numbers.Select(x => strings[x]);

////PrintList(slova.ToList()); 

//foreach (var item in numbers)
//{
//   // Console.WriteLine(strings[item]);
//}

/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
//Console.WriteLine("Výsledek: " + strings.Select(x => x.Length).Sum());


// úkol č. 5 ------------------------- 555555555555555555555555555555555


//var listHodnotUpperLower = strings.Select(x => new UpperLowerString(x))
//                                    .Select(xy => $"upper: {xy.UpperCase}, lower: {xy.LowerCase}");

//var res = strings.Select(slovo =>(slovo.ToUpper(), slovo.ToLower()));

////PrintListGenericky<(string, string)>(res);

///// úkol č. 6 ------------------------- 666666666666666666666666666666666666
//var agg = string.Join("", strings).GroupBy(x => x).Select(g => ( g.Key, Pocet: g.Count(), Znaky: g.Count() )).OrderByDescending(g => g.Pocet);
////PrintListGenericky<(char, int, int)>(agg);

//string kniha1 = "alice.txt";
//string kniha2 = "holmes.txt";
//string kniha3 = "rur.txt";

//Dictionary<string, int> kniha1Ana = AnalyzatorTextu.AnalyzovatText(kniha1);
//Tisk(kniha1, kniha1Ana);

//Dictionary<string, int> kniha2Ana = AnalyzatorTextu.AnalyzovatText(kniha2);
//Tisk(kniha2, kniha2Ana);

//Dictionary<string, int> kniha3Ana = AnalyzatorTextu.AnalyzovatText(kniha3);
//Tisk(kniha3, kniha3Ana);

//Dictionary<string, int> vysll =  TextTools.Analyza.FreqAnalysis(kniha1);

//Dictionary<string, int> vysll2 = TextTools.Analyza.GetTopWords(10, vysll);


//Tisk("vvvvvvvvvvvvvvvvvvyyys", vysll2);

void Tisk(string kniha1, Dictionary<string, int> kniha)
{
    Console.WriteLine($"KNIHA: {kniha1}");
    foreach (var item in kniha)
    {
        Console.WriteLine($"Slovo: {item.Key}, výskyt: {item.Value}");
    }
}



///////////////////////////////////////////////////////////////////////////////////////////



static void PrintList(List<string> coVypsat)
{

    foreach (var item in coVypsat)
    {
        Console.WriteLine(item);
    }
}

static Dictionary<char, int>CharFreq (string vstup)
{
    var aggDic = string.Join("", vstup).GroupBy(x => x).Select(g => (Key: g.Key, Pocet: g.Count())).OrderByDescending(g => g.Pocet).ThenBy(x => x.Key);
    Dictionary<char, int> charFreq = new Dictionary<char, int>();

    foreach (var tuple in aggDic)
    {
        charFreq.Add(tuple.Key, tuple.Pocet);
    }

    return charFreq;
}
/// <summary>
/// T - generická metoda
/// </summary>
static void PrintListGenericky<T>(IEnumerable<T> coVypsat)
{
    
    foreach (var item in coVypsat)
    {
        Console.WriteLine(item);
    }
}