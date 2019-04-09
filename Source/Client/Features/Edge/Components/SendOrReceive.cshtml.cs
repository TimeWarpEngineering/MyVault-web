namespace Herc.Pwa.Client.Features.Edge.Components
{
  using Herc.Pwa.Client.Components;
  using Microsoft.AspNetCore.Components;

  public class SendOrReceiveModel : BaseComponent
  {
    [Parameter] protected bool IsSend { get; set; }
  }
}
