namespace Herc.Pwa.Client.Features.Edge
{
  using System;
  using System.Collections.Generic;

  public class EdgeWalletInfo : ICloneable
  {
    public List<string> AppIds { get; set; }
    public bool Archived { get; set; }
    public bool Deleted { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public int SortIndex { get; set; }
    public string Type { get; set; }

    public object Clone()
    {
      var clone = MemberwiseClone() as EdgeWalletInfo;
      clone.Keys = new Dictionary<string, string>(Keys);
      return clone;
    }
  }
}