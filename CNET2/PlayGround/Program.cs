// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using PlayGround;

Console.WriteLine("Hello, World!");
var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


var vysledek = strings.Select( x => x.ToUpper());
//Debug.WriteLine(vysledek);

PrintList(vysledek.ToList());
bool isOnlyEvenNumber = numbers.All(x => x % 2 == 0);
Console.WriteLine($"Jsou všechna čísla sudá? {isOnlyEvenNumber}");

var slova = numbers.Select(x => strings[x]);

PrintList(slova.ToList()); 

foreach (var item in numbers)
{
    Console.WriteLine(strings[item]);
}

/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////////////////////
/// </summary>
Console.WriteLine("Výsledek: " + strings.Select(x => x.Length).Sum());


// úkol č. 5 ------------------------- 555555555555555555555555555555555


var listHodnotUpperLower = strings.Select(x => new UpperLowerString(x))
                                    .Select(xy => $"upper: {xy.UpperCase}, lower: {xy.LowerCase}");

var res = strings.Select(slovo =>(slovo.ToUpper(), slovo.ToLower()));

PrintListGenericky<(string, string)>(res);

static void PrintList(List<string> coVypsat)
{

    foreach (var item in coVypsat)
    {
        Console.WriteLine(item);
    }
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