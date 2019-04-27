namespace Client.Components.QrCode
{
  using System.Net;
  using Microsoft.AspNetCore.Components;
  public class QrCodeModel : BaseComponent
  {
    [Parameter] protected string Text { get; set; }
    [Parameter] protected string Width { get; set; } = "128";
    [Parameter] protected string Height { get; set; } = "128";

    private string UrlEncodedText => WebUtility.UrlEncode(Text);

    private const string GoogleChartsRootUrl = "https://chart.googleapis.com/chart?";

    //https://chart.googleapis.com/chart?chs=300x300&cht=qr&chl=0x8CCF9C4a7674D5784831b5E1237d9eC9Dddf9d7F&choe=UTF-8

    protected string Source => $"{GoogleChartsRootUrl}cht=qr&chs={Width}x{Height}&chl={UrlEncodedText}&choe=UTF-8&chld=L";

  }
}
