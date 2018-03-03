namespace schlexcel
{
  public interface IFileValueCsvWriter
  {
    void Write(string destinationFilePath, FileValue[] fileValues);
  }
}