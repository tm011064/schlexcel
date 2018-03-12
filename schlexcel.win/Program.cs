using System;
using System.IO;

namespace schlexcel.win
{
  class Program
  {
    static string logo = @"
  WOHOO! File generated at '{PlaceHolder}'

     / /
     L_L_
    /    \
    |00  |       _______
    |_/  |      /  ___  \
    |    |     /  /   \  \
    |    |_____\  \_  /  /
     \          \____/  /_____
      \ _______________/______\.............................

{Joke}

  See you next time!";

    static string helpText = @"
Use the following arguments:

  --s <sourceFolder>         Folder containing the .fit files (required)
  --d <destinationFolder>    Folder where the output file gets generated (optional, default = source folder)
  --f <fileName>             Name of the output file (optional, default = 'output.csv')

Example: 'schlexcel --d c:\temp\input --s c:\temp\output --f my_file.csv'";

    static void Main(string[] args)
    {
      try
      {
        Run(args);
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
        Console.WriteLine(helpText);
      }
    }

    private static void Run(string[] args)
    {
      var commandLineArguments = new CommandLineArguments(args);

      if (!commandLineArguments.HasKey("--s"))
      {
        Console.WriteLine(helpText);
        return;
      }

      var sourceFolder = commandLineArguments.Get("--s");
      var destinationFolder = commandLineArguments.Get("--d", sourceFolder);
      var outputFileName = commandLineArguments.Get("--f", "output.csv");

      var fitFileConverter = new FitFileConverter(
        new FitFileParser(),
        new FileValueCsvWriter());

      var fullOutputFileName = Path.Combine(destinationFolder, outputFileName);

      fitFileConverter.ConvertFromDirectory(sourceFolder, fullOutputFileName);

      Console.WriteLine(logo
        .Replace("{PlaceHolder}", fullOutputFileName)
        .Replace("{Joke}", Jokes.Get(2)));
    }
  }
}
