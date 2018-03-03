using System.IO;
using System.Linq;

namespace schlexcel
{
  public class FitFileConverter
  {
    private readonly IFitFileParser fitFileParser;

    private readonly IFileValueCsvWriter csvWriter;

    public FitFileConverter(
      IFitFileParser fitFileParser,
      IFileValueCsvWriter csvWriter)
    {
      this.fitFileParser = fitFileParser;
      this.csvWriter = csvWriter;
    }

    public void ConvertFromDirectory(string sourceDirectoryPath, string destinationFilePath)
    {
      if (!Directory.Exists(sourceDirectoryPath))
      {
        throw new DirectoryNotFoundException($"Directory '{sourceDirectoryPath}' does not exist");
      }

      var fileInfos = Directory
        .GetFiles(sourceDirectoryPath)
        .Select(fileName => new FileInfo(fileName))
        .ToArray();

      var fileValues = fileInfos.Select(GetFileValue).ToArray();

      csvWriter.Write(destinationFilePath, fileValues);
    }

    private FileValue GetFileValue(FileInfo fileInfo)
    {
      return new FileValue(
        fileInfo,
        fitFileParser.Parse(fileInfo.FullName).ToArray());
    }
  }
}
