namespace Client.Services
{
  public class FormatAmountRequest
  {
    public string Amount { get; set; }
    public int Granularity { get; set; }
    public int DecimalPlacesToDisplay { get; set; }
    public char DecimalSeperator { get; set; } = '.';
  }
}
