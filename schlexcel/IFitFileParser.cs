using System.Collections.Generic;

namespace schlexcel
{
  public interface IFitFileParser
  {
    IEnumerable<string> Parse(string filePath);
  }
}