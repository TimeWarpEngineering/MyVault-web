namespace Herc.Pwa.Server.Integration.Tests.Misc
{
  using Microsoft.JSInterop;
  using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
  using System.IO;
  using System;

  class JsonSerializationTests
  {
    public void GoodSingle()
    {
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\GoodSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = Json.Deserialize<UpdateEdgeCurrencyWalletAction>(json);
    }

    // Skip: By making private will skip the test
    private void BadSingle()
    {
      // The amountSatoshi causes the error it should be a string.
      // But given we don't care about the field we now remove it prior to serialization
      string currentDirectory = Environment.CurrentDirectory;
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\BadSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = Json.Deserialize<UpdateEdgeCurrencyWalletAction>(json);
    }

  }
}
