namespace Server.Services.AnthemGold.Price
{
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Threading;
  using System.Threading.Tasks;
  using static Shared.Constants.AnthemGoldConstants;

  public class PriceHandler : IRequestHandler<PriceRequest, PriceResponse>
  {
    public PriceHandler(
      AnthemGoldHttpClient aAnthemGoldHttpClient,
      IValidator<PriceRequest> aPriceRequestValidator
      )
    {
      AnthemGoldHttpClient = aAnthemGoldHttpClient;
      PriceRequestValidator = aPriceRequestValidator;
    }

    private AnthemGoldHttpClient AnthemGoldHttpClient { get; }
    private IValidator<PriceRequest> PriceRequestValidator { get; }

    public async Task<PriceResponse> Handle(PriceRequest aPriceRequest, CancellationToken aCancellationToken)
    {
      ValidationResult validationResult = PriceRequestValidator.Validate(aPriceRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }
      //?symbol=USDAGLD&range=MINUTE_1";
      string uri = $"{PriceUrl}?{nameof(aPriceRequest.Symbol).ToLower()}={aPriceRequest.Symbol}&{nameof(aPriceRequest.Range).ToLower()}={aPriceRequest.Range}";
      return await AnthemGoldHttpClient.GetJsonAsync<PriceResponse>(uri);
    }
  }
}