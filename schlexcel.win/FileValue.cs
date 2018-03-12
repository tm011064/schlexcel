using System.IO;
using System.Linq;

namespace schlexcel.win
{
  public class FileValue
  {
    public FileValue(FileInfo fileInfo, string[] values)
    {
      FileInfo = fileInfo;
      Values = values;
    }

    public FileInfo FileInfo { get; }

    public string[] Values { get; }

    public string GetValueAt(int index, string defaultValue = null)
    {
      return Values.Count() > index
        ? Values[index]
        : defaultValue;
    }
  }
}
