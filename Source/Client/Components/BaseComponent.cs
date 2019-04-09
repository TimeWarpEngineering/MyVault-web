namespace Herc.Pwa.Client.Components
{
  using System;
  using BlazorState.Pipeline.ReduxDevTools;
  using Herc.Pwa.Client.Features.Application;
  using Herc.Pwa.Client.Features.Edge;
  using Herc.Pwa.Client.Features.Edge.EdgeAccount;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using Herc.Pwa.Client.Shared;
  using Microsoft.AspNetCore.Components;

  /// <summary>
  /// Makes access to the State a little easier and by inheriting from
  /// BlazorStateDevToolsComponent it allows for ReduxDevTools operation.
  /// </summary>
  /// <remarks>
  /// In production one would NOT be required to use BlazorStateDevToolsComponent or BlazorStateComponent
  /// But would be required to properly implement the required interfaces.
  /// one could conditionally inherit from ComponentBase or BlazorStateComponent for production build.
  /// </remarks>
  public class BaseComponent : BlazorStateDevToolsComponent
  {
    [Inject] public ColorPalette ColorPalette { get; set; }

    public Guid Guid { get; } = Guid.NewGuid();
    public ApplicationState ApplicationState => GetState<ApplicationState>();
    public EdgeState EdgeState => GetState<EdgeState>();
    public EdgeAccountState EdgeAccountState => GetState<EdgeAccountState>();
    public EdgeCurrencyWalletsState EdgeCurrencyWalletsState => GetState<EdgeCurrencyWalletsState>();
  }
}