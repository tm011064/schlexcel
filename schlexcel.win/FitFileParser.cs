using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace schlexcel.win
{
  public class FitFileParser : IFitFileParser
  {
    public IEnumerable<string> Parse(string filePath)
    {
      if (!File.Exists(filePath))
      {
        throw new FileNotFoundException($"File '{filePath}' not found");
      }

      var pairs = GetPairs(filePath).ToArray();

      return pairs.Select(x => x.First)
        .Concat(pairs.Select(x => x.Second));
    }

    private IEnumerable<Pair> GetPairs(string filePath)
    {
      foreach (var line in File.ReadAllLines(filePath))
      {
        if (line.StartsWith("HMATCH"))
        {
          continue;
        }

        var values = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (values.Count() != 3)
        {
          continue;
        }

        yield return new Pair(values[1], values[2]);
      }
    }

    private struct Pair
    {
      public Pair(string first, string second) : this()
      {
        First = first;
        Second = second;
      }

      public string First { get; }

      public string Second { get; }
    }

  }
}
