namespace Server.Services.AnthemGold.Price
{
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System.Text.Json;
  using System.Threading;
  using System.Threading.Tasks;
  using static Shared.Constants.AnthemGoldConstants;

  public class PriceHandler : IRequestHandler<PriceRequest, PriceResponse>
  {
    public PriceHandler
    (
      AnthemGoldHttpClient aAnthemGoldHttpClient,
      IValidator<PriceRequest> aPriceRequestValidator
    )
    {
      AnthemGoldHttpClient = aAnthemGoldHttpClient;
      PriceRequestValidator = aPriceRequestValidator;
    }

    private readonly AnthemGoldHttpClient AnthemGoldHttpClient;
    private readonly IValidator<PriceRequest> PriceRequestValidator;

    public async Task<PriceResponse> Handle(PriceRequest aPriceRequest, CancellationToken aCancellationToken)
    {
      ValidationResult validationResult = PriceRequestValidator.Validate(aPriceRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }
      // ?symbol=USDAGLD&range=MINUTE_1";
      string uri = $"{PriceUrl}?{nameof(aPriceRequest.Symbol).ToLower()}={aPriceRequest.Symbol}&{nameof(aPriceRequest.Range).ToLower()}={aPriceRequest.Range}";
      string responseString = await AnthemGoldHttpClient.GetStringAsync(uri);
      PriceResponse result = JsonSerializer.Deserialize<PriceResponse>(responseString, AnthemGoldHttpClient.JsonSerializerOptions);
      return result;
      //return await AnthemGoldHttpClient.GetJsonAsync<PriceResponse>(uri);
    }
  }
}