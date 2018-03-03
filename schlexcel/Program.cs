namespace schlexcel
{
  class Program
  {
    static void Main(string[] args)
    {
      var fitFileConverter = new FitFileConverter(
        new FitFileParser(),
        new FileValueCsvWriter());

      fitFileConverter.ConvertFromDirectory(
        args[0],
        args[1]);
    }
  }
}