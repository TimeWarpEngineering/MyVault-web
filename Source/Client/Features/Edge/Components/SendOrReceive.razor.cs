namespace Client.Features.Edge.Components
{
  using Client.Components;
  using Microsoft.AspNetCore.Components;

  public class SendOrReceiveBase : BaseComponent
  {
    [Parameter] public bool IsSend { get; set; }
  }
}
