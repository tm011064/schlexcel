using System;
using System.Collections.Generic;
using System.Linq;

namespace schlexcel.win
{
  public class CommandLineArguments
  {
    private readonly IDictionary<string, string> argumentsByKey = new Dictionary<string, string>();

    public CommandLineArguments(string[] args)
    {
      if (args.Count() % 2 != 0)
      {
        throw new ArgumentException($"Unable to parse arguments '{string.Join(" ", args)}'");
      }

      for (var i = 0; i < args.Count(); i += 2)
      {
        argumentsByKey[args[i]] = args[i + 1];
      }
    }

    public bool HasKey(string key)
    {
      return argumentsByKey.ContainsKey(key);
    }

    public string Get(string key, string defaultValue = null)
    {
      return HasKey(key)
        ? argumentsByKey[key]
        : defaultValue;
    }
  }
}
