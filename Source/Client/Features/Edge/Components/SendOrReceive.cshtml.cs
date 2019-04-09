namespace Client.Features.Edge.Components
{
  using Client.Components;
  using Microsoft.AspNetCore.Components;

  public class SendOrReceiveModel : BaseComponent
  {
    [Parameter] protected bool IsSend { get; set; }
  }
}
