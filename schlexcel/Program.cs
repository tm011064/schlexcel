using Microsoft.Extensions.CommandLineUtils;
using System.IO;

namespace schlexcel
{
  class Program
  {
    static void Main(string[] args)
    {
      var commandLineApplication = new CommandLineApplication();

      var sourceFolder = commandLineApplication.Option(
        "-s |--sourceFolder <sourceFolder>",
        "The folder containing the .fit files",
        CommandOptionType.SingleValue);

      var destinationFolder = commandLineApplication.Option(
        "-d |--destinationFolder <destinationFolder>",
        "The destination folder for the output file",
        CommandOptionType.SingleValue);

      var destinationFileName = commandLineApplication.Option(
        "-f |--destinationFileName <destinationFileName>",
        "The file name of the output file",
        CommandOptionType.SingleValue);

      commandLineApplication.HelpOption("-? | -h | --help");

      commandLineApplication.OnExecute(() =>
      {
        var fitFileConverter = new FitFileConverter(
          new FitFileParser(),
          new FileValueCsvWriter());

        var destinationFolderPath = destinationFolder.HasValue()
            ? destinationFolder.Value()
            : sourceFolder.Value();

        var outputFileName = destinationFileName.HasValue()
            ? destinationFileName.Value()
            : "output.csv";

        fitFileConverter.ConvertFromDirectory(
          sourceFolder.Value(),
          Path.Combine(destinationFolderPath, outputFileName));

        return 0;
      });

      commandLineApplication.Execute(args);
    }
  }
}