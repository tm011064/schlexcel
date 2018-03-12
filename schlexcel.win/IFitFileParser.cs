using System.Collections.Generic;

namespace schlexcel.win
{
  public interface IFitFileParser
  {
    IEnumerable<string> Parse(string filePath);
  }
}