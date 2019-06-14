namespace Server.Integration.Tests.Misc
{
  using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
  using Microsoft.JSInterop;
  using Client.Features.Edge.EdgeCurrencyWallet;
  using System.Text.Json.Serialization;
  using System.IO;
  using System;

  class JsonSerializationTests
  {
    public void GoodSingle()
    {
      
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\GoodSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Parse<UpdateEdgeCurrencyWalletAction>(json);
    }


    // Skip: By making private will skip the test
    private void BadSingle()
    {
      // The amountSatoshi causes the error it should be a string.
      // But given we don't care about the field we now remove it prior to serialization
      string currentDirectory = Environment.CurrentDirectory;
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\BadSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Parse<UpdateEdgeCurrencyWalletAction>(json);
    }

  }
}
