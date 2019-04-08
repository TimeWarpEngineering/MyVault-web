using System;
using Microsoft.AspNetCore.Components;

namespace Herc.Pwa.Client.Components.Iconic
{
  public class IconicBase : BaseComponent
  {
    
    [Parameter] protected string FillColor { get; set; } = "purple";

    [Parameter] protected int Size { get; set; } = 16;
  }
}
