using System.Collections.Generic;
using AnyClone;
using Client.Features.Edge.State;
using Shouldly;

namespace Client.Integration.Tests.Features.Edge.State
{
  class EdgeTransactionUnitTests
  {
    public void ShouldClone()
    {
      // Arrange
      var edgeTransaction = new EdgeTransaction
      {
        Date = new System.DateTime(), // mock epoch
        CurrencyCode = "Currency Code",
        BlockHeight = 2,
        NativeAmount = "3",
        NetworkFee = "NetworkFee",
        OurReceiveAddresses = new List<string> { "string1", "string2" },
        SignedTx = "SignedTx",
        ParentNetworkFee = "ParentNetworkFee"
      };
      // Act

      var clone = edgeTransaction.Clone() as EdgeTransaction;

      // Assert

      clone.Date.ShouldBe(edgeTransaction.Date);
      clone.CurrencyCode.ShouldBe(edgeTransaction.CurrencyCode);
      clone.BlockHeight.ShouldBe(edgeTransaction.BlockHeight);
      clone.NativeAmount.ShouldBe(edgeTransaction.NativeAmount);
      clone.NetworkFee.ShouldBe(edgeTransaction.NetworkFee);

      clone.OurReceiveAddresses.Count.ShouldBe(edgeTransaction.OurReceiveAddresses.Count);
      clone.OurReceiveAddresses.ShouldNotBeSameAs(edgeTransaction.OurReceiveAddresses);

      clone.SignedTx.ShouldBe(edgeTransaction.SignedTx);
      clone.ParentNetworkFee.ShouldBe(edgeTransaction.ParentNetworkFee);
      clone.OurReceiveAddresses[0].ShouldBe(edgeTransaction.OurReceiveAddresses[0]);
      clone.OurReceiveAddresses[1].ShouldBe(edgeTransaction.OurReceiveAddresses[1]);

    }


  }
}
