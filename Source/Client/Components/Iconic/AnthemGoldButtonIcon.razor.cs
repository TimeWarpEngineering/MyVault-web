namespace Client.Components.Iconic
{
  using Microsoft.AspNetCore.Components;
  public class AnthemGoldButtonIconModel : BaseComponent
  {

    [Parameter] public string FillColor { get; set; } = "purple";

    [Parameter] public string Size { get; set; } = "1em";
  }
}
