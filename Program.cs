// See https=//aka.ms/new-console-template for more information
using Mychallenges.Models;
using System.Data;
using System.Text;

Console.WriteLine("Hello, Bob!");

var marbles = new List<Marble>{
    new Marble { id =  1, color= "blue", name= "Bob", weight= 0.5 },
    new Marble { id= 2, color= "red", name= "John Smith", weight= 0.25 },
    new Marble { id= 3, color= "violet", name= "Bob O'Bob", weight= 0.5 },
    new Marble { id= 4, color= "indigo", name= "Bob Dad-Bob", weight= 0.75 },
    new Marble { id= 5, color= "yellow", name= "John", weight= 0.5 },
    new Marble { id= 6, color= "orange", name= "Bob", weight= 0.25 },
    new Marble { id= 7, color= "blue", name= "Smith", weight= 0.5 },
    new Marble { id= 8, color= "blue", name= "Bob", weight= 0.25 },
    new Marble { id= 9, color= "green", name= "Bobb Ob", weight= 0.75 },
    new Marble { id= 10, color= "blue", name= "Bob", weight= 0.5 }
};

var pattern = new List<string> { "red", "orange", "yellow", "green", "blue", "indigo", "violet" };

//extension methods have a complexity of O(n)
var filteredMarbles = marbles.Where(m => m.weight >= 0.5 && m.name.FlatString().IsPalindrome());

// Orderby uses quick sort so it's time complexity is N*LogN, worst case scenrio N^2
var orderedMarbles = filteredMarbles.OrderBy(m => m.color, new ColorComparer(pattern)).ToList();

foreach (var marble in orderedMarbles)
{
    Console.WriteLine($"id: {marble.id}, color: {marble.color}, name: {marble.name}, weight:{marble.weight}");
}

class ColorComparer : IComparer<string>
{
    private readonly List<string> _pattern;
    public ColorComparer(List<string> pattern)
    {
        _pattern = pattern;
    }
    public int Compare(string? x, string? y)
    {
        if (x is null || y is null || _pattern.Count == 0)
            throw new ArgumentNullException();

        if (_pattern.IndexOf(x) == -1 || _pattern.IndexOf(y) == -1)
            throw new ArgumentOutOfRangeException();
        //time space compexity O(n), so quick sort stays the same
        if (_pattern.IndexOf(x) > _pattern.IndexOf(y))
        {
            return 1;
        }
        else if (_pattern.IndexOf(x) == _pattern.IndexOf(y))
        {
            return 0;
        }
        else
        {
            return -1;
        }
    }
}

public static class Extension
{
    public static bool IsPalindrome(this string str)
    {
        //Time space complexity is O(n)
        for (int i = 0; i < str.Length / 2; i++)
        {
            if (str[i] != str[str.Length - 1 - i])
                return false;
        }
        return true;
    }

    public static string FlatString(this string str)
    {
        var sb = new StringBuilder();
        //Time space complexity is O(n)
        foreach (char c in str)
        {
            if (!char.IsPunctuation(c) && !char.IsWhiteSpace(c) && !char.IsDigit(c))
            {
                sb.Append(c);
            }
        }
        return sb.ToString().ToLower();
    }
}