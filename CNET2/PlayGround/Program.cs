// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

Console.WriteLine("Hello, World!");
var numbers = new[] { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var strings = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


var vysledek = strings.Select( x => x.ToUpper());
//Debug.WriteLine(vysledek);

PrintList(vysledek.ToList());
bool isOnlyEvenNumber = numbers.All(x => x % 2 == 0);
Console.WriteLine($"Jsou všechna čísla sudá? {isOnlyEvenNumber}");

foreach (var item in numbers)
{
    Console.WriteLine(strings[item]);
}


static void PrintList(List<string> coVypsat)
{

    foreach (var item in coVypsat)
    {
        Console.WriteLine(item);
    }
}