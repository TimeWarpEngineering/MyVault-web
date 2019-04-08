using System;
using System.Collections.Generic;
using System.Text;
using Herc.Pwa.Client.Features.Edge.EdgeCurrencyWallet;
using Herc.Pwa.Client.Features.Edge.State;
using Shouldly;

namespace Herc.Pwa.Client.Integration.Tests.Features.Edge.State
{
  class EdgeCurrencyWalletUnitTests
  {
    public void ShouldClone()
    {
      //Arrange
      var edgeCurrencyWallet = new EdgeCurrencyWallet
      {
        Id = "EdgeCurrencyWallet1",
        SelectedCurrencyCode = "abc",
        FiatCurrencyCode = "FCC",
        Balances = new Dictionary<string, string>() { { "ETH", "1000" }, { "HERC", "2000" } },
        Keys = new Dictionary<string, string>() { { "somekey", "somevalue" }, { "someotherkey", "someothervalue" } },
        EdgeTransactions = new List<EdgeTransaction>
        {
          new EdgeTransaction
          {
            Date = new DateTime(),
            CurrencyCode = "Currency Code",
            BlockHeight = 2,
            NativeAmount = "3",
            NetworkFee = "NetworkFee",
            OurReceiveAddresses = new List<string> { "string1", "string2" },
            SignedTx = "SignedTx",
            ParentNetworkFee = "ParentNetworkFee"
          },

          new EdgeTransaction
            {
              Date = new DateTime(),
              CurrencyCode = "Currency Code2",
              BlockHeight = 5,
              NativeAmount = "6",
              NetworkFee = "NetworkFee2",
              OurReceiveAddresses = new List<string> { "string3", "string4" },
              SignedTx = "SignedTx2",
              ParentNetworkFee = "ParentNetworkFee2"
            }
         }
      };

      //Act

      var clonedEdgeCurrencyWallet = edgeCurrencyWallet.Clone() as EdgeCurrencyWallet;

      //Assert

      clonedEdgeCurrencyWallet.Id.ShouldBe(edgeCurrencyWallet.Id);
      clonedEdgeCurrencyWallet.SelectedCurrencyCode.ShouldBe(edgeCurrencyWallet.SelectedCurrencyCode);
      clonedEdgeCurrencyWallet.FiatCurrencyCode.ShouldBe(edgeCurrencyWallet.FiatCurrencyCode);
      clonedEdgeCurrencyWallet.Balances.ShouldBe(edgeCurrencyWallet.Balances);
      clonedEdgeCurrencyWallet.Keys.ShouldBe(edgeCurrencyWallet.Keys);
      clonedEdgeCurrencyWallet.EdgeTransactions.ShouldNotBeSameAs(edgeCurrencyWallet.EdgeTransactions);
      clonedEdgeCurrencyWallet.EdgeTransactions[0].OurReceiveAddresses[0].ShouldBe(
        edgeCurrencyWallet.EdgeTransactions[0].OurReceiveAddresses[0]);
      clonedEdgeCurrencyWallet.EdgeTransactions[1].OurReceiveAddresses[1].ShouldBe(
        edgeCurrencyWallet.EdgeTransactions[1].OurReceiveAddresses[1]);

    }
  }
}
