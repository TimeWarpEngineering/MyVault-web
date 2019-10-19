namespace Client.Features.Edge
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