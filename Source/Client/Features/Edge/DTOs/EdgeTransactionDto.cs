namespace Client.Features.Edge.Dtos
{
  using System.Collections.Generic;

  public class EdgeTransactionDto
  {
    public int BlockHeight { get; set; }
    public string CurrencyCode { get; set; }
    public float Date { get; set; }
    // MetaData
    public string NativeAmount { get; set; }
    public string NetworkFee { get; set; }
    public List<string> OurReceiveAddresses { get; set; }
    public string ParentNetworkFee { get; set; }
    public string SignedTx { get; set; }
    public string TxId { get; set; }
  }
}