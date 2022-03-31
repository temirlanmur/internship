using FractionConsole;
using System.Collections;

var frA = Fraction.Create(1, 2);
var frB = Fraction.Create(-3, -6);

Console.WriteLine(frA.Equals(frB));


// Test with Dictionary
var dict = new Dictionary<Fraction, string>();

dict[frA] = "hello";
dict[frB] = "hello";

Console.WriteLine($"Dictionary contains {dict.Count()} k-v pair");


// Test with Hashtable
var hashTable = new Hashtable();

hashTable[frA] = "hello";
hashTable[frB] = "hello";

Console.WriteLine($"Hashtable contains {hashTable.Count} k-v pair");


// Test with HashSet
var hashSet = new HashSet<Fraction>();

hashSet.Add(frA);
hashSet.Add(frB);

Console.WriteLine($"HashSet contains {hashSet.Count} k-v pair");
