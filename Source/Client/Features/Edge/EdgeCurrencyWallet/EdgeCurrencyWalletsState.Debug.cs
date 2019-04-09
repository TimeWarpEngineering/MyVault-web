namespace Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet
{
  using System.Reflection;

  public partial class EdgeCurrencyWalletsState
  {
    /// <summary>
    /// Use in Tests ONLY, to initialize the State
    /// </summary>
    /// <param name="aEdgeCurrencyWalletsState"></param>
    public void Initialize(EdgeCurrencyWalletsState aEdgeCurrencyWalletsState)
    {
      ThrowIfNotTestAssembly(Assembly.GetCallingAssembly());
      EdgeCurrencyWallets = aEdgeCurrencyWalletsState.EdgeCurrencyWallets;
    }
  }

}