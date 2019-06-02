namespace Client.Features.Edge
{
  using System;
  using System.Collections.Generic;

  public class EdgeWalletInfo
  {
    public List<string> AppIds { get; set; }
    public bool Archived { get; set; }
    public bool Deleted { get; set; }
    public string Id { get; set; }
    public Dictionary<string, string> Keys { get; set; }
    public int SortIndex { get; set; }
    public string Type { get; set; }
  }
}