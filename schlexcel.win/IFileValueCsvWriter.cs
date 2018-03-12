namespace schlexcel.win
{
  public interface IFileValueCsvWriter
  {
    void Write(string destinationFilePath, FileValue[] fileValues);
  }
}