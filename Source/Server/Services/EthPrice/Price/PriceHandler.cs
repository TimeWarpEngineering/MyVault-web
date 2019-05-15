namespace Server.Services.EthPrice.Price
{
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using TimeWarp.Extensions;
  using static Server.Services.EthPrice.EthPriceConstants;

  public class PriceHandler : IRequestHandler<PriceRequest, PriceResponse>
  {
    public PriceHandler(
      HttpClient aHttpClient,
      IValidator<PriceRequest> aPriceRequestValidator
      )
    {
      HttpClient = aHttpClient;
      PriceRequestValidator = aPriceRequestValidator;
    }

    private HttpClient HttpClient { get; }
    private IValidator<PriceRequest> PriceRequestValidator { get; }

    public async Task<PriceResponse> Handle(PriceRequest aPriceRequest, CancellationToken aCancellationToken)
    {
      ValidationResult validationResult = PriceRequestValidator.Validate(aPriceRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }
      //?symbol=USDAGLD&range=MINUTE_1";
      string uri = $"{PriceUrl}?{nameof(aPriceRequest.Url).ToLower()}={aPriceRequest.Url}&{nameof(aPriceRequest.Range).ToLower()}={aPriceRequest.Range}";
      return await HttpClient.GetJsonAsync<PriceResponse>(uri);
    }
  }
}