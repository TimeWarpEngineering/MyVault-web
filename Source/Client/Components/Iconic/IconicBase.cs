using System;
using Microsoft.AspNetCore.Components;

namespace Client.Components.Iconic
{
  public class IconicBase : BaseComponent
  {
    
    [Parameter] protected string FillColor { get; set; } = "purple";

    [Parameter] protected int Size { get; set; } = 16;
  }
}
