using System;
using Microsoft.AspNetCore.Components;

namespace Client.Components.Iconic
{
  public class IconicBase : BaseComponent
  {
    
    [Parameter] public string FillColor { get; set; } = "purple";

    [Parameter] public int Size { get; set; } = 16;
  }
}
