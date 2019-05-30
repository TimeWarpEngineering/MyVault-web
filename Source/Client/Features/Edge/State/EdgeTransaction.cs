namespace Client.Features.Edge.State
{
  using System;
  using System.Collections.Generic;

  public class EdgeTransaction
  {
    const string NegativeChar = "-";

    public DateTime Date { get; set; }
    public string CurrencyCode { get; set; }
    public int BlockHeight { get; set; }
    public string NativeAmount { get; set; }
    public string NetworkFee { get; set; }
    public List<string> OurReceiveAddresses { get; set; }
    public string SignedTx { get; set; }
    public string ParentNetworkFee { get; set; }
    public string TxId { get; set; }
    public bool IsSend => NativeAmount.StartsWith(NegativeChar);
  };
}

