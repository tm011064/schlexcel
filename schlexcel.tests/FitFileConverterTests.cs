using System;
using System.IO;
using Xunit;

namespace schlexcel.tests
{
  public class FitFileConverterTests
  {
    [Fact]
    public void WhenParsing()
    {
      var bs = AppContext.BaseDirectory;

      var filesFolder = Path.Combine(AppContext.BaseDirectory, "Files");
      var destinationFilePath = Path.Combine(AppContext.BaseDirectory, "output.csv");

      var fitFileConverter = new FitFileConverter(
        new FitFileParser(),
        new FileValueCsvWriter());

      fitFileConverter.ConvertFromDirectory(
        filesFolder,
        destinationFilePath);

      var lines = File.ReadAllLines(destinationFilePath);

      Assert.Equal(lines[0], "BIV0707.fit,BIV0708.fit");
      Assert.Equal(lines[1], ".10060343,.00060343");
      Assert.Equal(lines[2], "-.12622129,-.02622129");
      Assert.Equal(lines[3], ".13597909,.03597909");
      Assert.Equal(lines[4], "-.12706471,-.02706471");
      Assert.Equal(lines[5], ".14108446,.04108446");
      Assert.Equal(lines[6], "-.10598645,-.00598645");
      Assert.Equal(lines[7], ".11223479,.01223479");
      Assert.Equal(lines[8], "-.10925880,-.00925880");
      Assert.Equal(lines[9], "-.13173912,-.03173912");
      Assert.Equal(lines[10], "-.42968270,-.22968270");
      Assert.Equal(lines[11], ".41703288,.01703288");
      Assert.Equal(lines[12], "-.44315741,-.04315741");
      Assert.Equal(lines[13], "-.41420514,-.01420514");
      Assert.Equal(lines[14], "-.43350462,-.03350462");
      Assert.Equal(lines[15], ".41350367,.01350367");
      Assert.Equal(lines[16], ".41967673,.01967673");
      Assert.Equal(lines[17], ".43009647,.03009647");
      Assert.Equal(lines[18], ".41819366,.01819366");
    }
  }
}
