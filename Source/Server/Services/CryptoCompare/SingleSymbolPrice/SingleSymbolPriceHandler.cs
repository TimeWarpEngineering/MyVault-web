namespace Server.Services.CryptoCompare.SingleSymbolPrice
{
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using static Server.Services.CryptoCompare.CryptoCompareConstants;
  using TimeWarp.Extensions;

  public class SingleSymbolPriceHandler : IRequestHandler<SingleSymbolPriceRequest, SingleSymbolPriceResponse>
  {
    public SingleSymbolPriceHandler(
      CryptoCompareHttpClient aCryptoCompareHttpClient,
      IValidator<SingleSymbolPriceRequest> aSingleSymbolPriceRequestValidator
      )
    {
      CryptoCompareHttpClient = aCryptoCompareHttpClient;
      SingleSymbolPriceRequestValidator = aSingleSymbolPriceRequestValidator;
    }

    private CryptoCompareHttpClient CryptoCompareHttpClient { get; }
    private IValidator<SingleSymbolPriceRequest> SingleSymbolPriceRequestValidator { get; }

    public async Task<SingleSymbolPriceResponse> Handle(SingleSymbolPriceRequest aSingleSymbolPriceRequest, CancellationToken aCancellationToken)
    {
      ValidationResult validationResult = SingleSymbolPriceRequestValidator.Validate(aSingleSymbolPriceRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }
      //?symbol=USDAGLD&range=MINUTE_1";
      string uri = $"{SingleSymbolPriceUrl}?{aSingleSymbolPriceRequest.ToQueryString()}";
      var singleSymbolPriceResponse = new SingleSymbolPriceResponse();
      singleSymbolPriceResponse.Prices = await CryptoCompareHttpClient.GetJsonAsync<Dictionary<string, decimal>>(uri);

      return singleSymbolPriceResponse;
    }
  }
}