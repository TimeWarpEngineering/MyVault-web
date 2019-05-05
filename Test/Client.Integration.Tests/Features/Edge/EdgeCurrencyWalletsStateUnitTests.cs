using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Features.Edge.EdgeCurrencyWallet;
using Shouldly;

namespace Client.Integration.Tests.Features.Edge
{
  public class EdgeCurrencyWalletsStateUnitTests
  {
    /// <summary>
    /// If no Id is selected then result should be first one if one exists.
    /// </summary>
    /// <returns></returns>
    public void SelectedEdgeCurrencyWallet_Should_Be_Selected_Id()
    {
      EdgeCurrencyWalletsState original = GetTestState();
      original.SelectedEdgeCurrencyWalletId = "EdgeCurrencyWallet2";
      original.SelectedEdgeCurrencyWallet.Id.ShouldBe("EdgeCurrencyWallet2");
    }

    /// <summary>
    /// If no Id is selected then result should be first one if one exists.
    /// </summary>
    /// <returns></returns>
    public void SelectedEdgeCurrencyWallet_Should_Be_First()
    {
      EdgeCurrencyWalletsState original = GetTestState();
      original.SelectedEdgeCurrencyWallet.Id.ShouldBe("EdgeCurrencyWallet1");
    }

    /// <summary>
    /// If no Id is selected then result should be null if no wallets exist.
    /// </summary>
    /// <returns></returns>
    public void SelectedEdgeCurrencyWallet_Should_Be_Null()
    {
      var original = new EdgeCurrencyWalletsState();
      original.SelectedEdgeCurrencyWallet.ShouldBeNull();
    }

    private EdgeCurrencyWalletsState GetTestState()
    {
      return new EdgeCurrencyWalletsState
      {
        EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>()
        {
          { "EdgeCurrencyWallet1",
            new EdgeCurrencyWallet
            {
              Id= "EdgeCurrencyWallet1",
              SelectedCurrencyCode = "abc",
              FiatCurrencyCode = "FCC",
              Balances = new Dictionary<string, string>() { { "ETH", "1000" }, { "AGLD", "2000" } },
              Keys = new Dictionary<string, string>() { { "somekey", "somevalue" }, { "someotherkey", "someothervalue" } }
            }
          },
          { "EdgeCurrencyWallet2",
            new EdgeCurrencyWallet
            {
              Id= "EdgeCurrencyWallet2",
              SelectedCurrencyCode = "efg",
              FiatCurrencyCode = "Fiat",
              Balances = new Dictionary<string, string>() { { "BTC", "444" }, { "NANO", "6666" } },
              Keys = new Dictionary<string, string>() { { "somekey2", "somevalue2" }, { "someotherkey2", "someothervalue2" } }
            }
          }
        }
      };
    }

    /// <summary>
    /// Test the clone ability of EdgeCurrencyWalletsState and all its child classes
    /// </summary>
    /// <returns></returns>
    public void Should_Clone()
    {
      // Arrange
      var original = new EdgeCurrencyWalletsState()
      {
        SelectedEdgeCurrencyWalletId = "EdgeCurrencyWallet1",
        EdgeCurrencyWallets = new Dictionary<string, EdgeCurrencyWallet>()
        {
          { "EdgeCurrencyWallet1",
            new EdgeCurrencyWallet
            {
              Id= "EdgeCurrencyWallet1",
              SelectedCurrencyCode = "abc",
              FiatCurrencyCode = "FCC",
              Balances = new Dictionary<string, string>() { { "ETH", "1000" }, { "AGLD", "2000" } },
              Keys = new Dictionary<string, string>() { { "somekey", "somevalue" }, { "someotherkey", "someothervalue" } }
            }
          },
          { "EdgeCurrencyWallet2",
            new EdgeCurrencyWallet
            {
              Id= "EdgeCurrencyWallet2",
              SelectedCurrencyCode = "efg",
              FiatCurrencyCode = "Fiat",
              Balances = new Dictionary<string, string>() { { "BTC", "444" }, { "NANO", "6666" } },
              Keys = new Dictionary<string, string>() { { "somekey2", "somevalue2" }, { "someotherkey2", "someothervalue2" } }
            }
          }
        }
      };
      // Act
      original.SelectedEdgeCurrencyWallet.ShouldNotBeNull(); // Test the derived SelectedEdgeCurrencyWallet method.
      var clone = original.Clone() as EdgeCurrencyWalletsState;
      // Assert

      clone.EdgeCurrencyWallets.Count.ShouldBe(2);

      // Check EdgeCurrencyWallet1
      EdgeCurrencyWallet edgeCurrencyWallet1 = clone.EdgeCurrencyWallets["EdgeCurrencyWallet1"]; // if not there will fail.
      edgeCurrencyWallet1.SelectedCurrencyCode.ShouldBe("abc");
      edgeCurrencyWallet1.Id.ShouldBe("EdgeCurrencyWallet1");
      edgeCurrencyWallet1.FiatCurrencyCode.ShouldBe("FCC");
      edgeCurrencyWallet1.Balances["ETH"].ShouldBe("1000");
      edgeCurrencyWallet1.Balances["AGLD"].ShouldBe("2000");
      edgeCurrencyWallet1.Keys["somekey"].ShouldBe("somevalue");
      edgeCurrencyWallet1.Keys["someotherkey"].ShouldBe("someothervalue");


      // Check EdgeCurrencyWallet2
      EdgeCurrencyWallet edgeCurrencyWallet2 = clone.EdgeCurrencyWallets["EdgeCurrencyWallet2"]; // if not there will fail.
      edgeCurrencyWallet2.SelectedCurrencyCode.ShouldBe("efg");
      edgeCurrencyWallet2.Id.ShouldBe("EdgeCurrencyWallet2");
      edgeCurrencyWallet2.FiatCurrencyCode.ShouldBe("Fiat");
      edgeCurrencyWallet2.Balances["BTC"].ShouldBe("444");
      edgeCurrencyWallet2.Balances["NANO"].ShouldBe("6666");
      edgeCurrencyWallet2.Keys["somekey2"].ShouldBe("somevalue2");
      edgeCurrencyWallet2.Keys["someotherkey2"].ShouldBe("someothervalue2");
    }
  }
}
