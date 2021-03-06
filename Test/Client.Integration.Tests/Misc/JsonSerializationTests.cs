﻿namespace Server.Integration.Tests.Misc
{
  using System;
  using System.IO;
  using System.Text.Json;
  using static Client.Features.Edge.EdgeCurrencyWalletsState;

  internal class JsonSerializationTests
  {
    // Skip: By making private will skip the test
    private void BadSingle()
    {
      // The amountSatoshi causes the error it should be a string.
      // But given we don't care about the field we now remove it prior to serialization
      string currentDirectory = Environment.CurrentDirectory;
      string json = System.IO.File.ReadAllText(@".\TestData\SerializationTests\BadSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Deserialize<UpdateEdgeCurrencyWalletAction>(json);
    }

    public void GoodSingle()
    {
      string json = File.ReadAllText(@".\TestData\SerializationTests\GoodSingle.json");
      UpdateEdgeCurrencyWalletAction updateEdgeCurrencyWalletAction = JsonSerializer.Deserialize<UpdateEdgeCurrencyWalletAction>(json);
    }
  }
}