namespace Herc.Pwa.Client.Services
{
  public class GetNativeAmountRequest
  {
    public string Amount { get; set; }
    public int Granularity { get; set; }
    public char DecimalSeperator { get; set; } = '.';
  }
}
