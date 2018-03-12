using System.IO;
using System.Linq;

namespace schlexcel.win
{
  public class FileValueCsvWriter : IFileValueCsvWriter
  {
    public void Write(string destinationFilePath, FileValue[] fileValues)
    {
      var numberOfLines = fileValues.Max(x => x.Values.Count());

      using (var fileStream = File.OpenWrite(destinationFilePath))
      using (var streamWriter = new StreamWriter(fileStream))
      {
        streamWriter.WriteLine(string.Join(",", fileValues.Select(x => x.FileInfo.Name)));

        for (var i = 0; i < numberOfLines; i++)
        {
          streamWriter.WriteLine(string.Join(",", fileValues.Select(x => x.GetValueAt(i))));
        }
      }
    }
  }
}
