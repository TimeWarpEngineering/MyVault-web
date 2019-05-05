namespace Server.Features.Conversion
{
  using System;
  using System.Net.Http;
  using System.Threading;
  using System.Threading.Tasks;
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using Shared.Features.Conversion;

  public class ConversionHandler : IRequestHandler<ConversionRequest, ConversionResponse>
  {
    private const string PriceUrl = @"https://chart.anthemgold.com/service-1.0-SNAPSHOT/PRICE?symbol=USDAGLD&range=MINUTE_1";

    public ConversionHandler(HttpClient aHttpClient, IValidator<ConversionRequest> aConversionRequestValidator) : base()
    {
      HttpClient = aHttpClient;
      ConversionRequestValidator = aConversionRequestValidator;
    }

    private IValidator<ConversionRequest> ConversionRequestValidator { get; }
    private HttpClient HttpClient { get; }

    public async Task<ConversionResponse> Handle(ConversionRequest aConversionRequest, CancellationToken aCancellationToken)
    {
      // TODO when FluentValidation release new version for dotnet core 3 it will support integration into the pipeline.
      // Thus we won't need to manually do this.
      ValidationResult validationResult = ConversionRequestValidator.Validate(aConversionRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      PriceDto priceDto =
           await HttpClient.GetJsonAsync<PriceDto>
           (PriceUrl);

      return new ConversionResponse
      {
        Rate = priceDto.C
      };
    }

    private class PriceDto

    {
      public decimal C { get; set; }
      public decimal H { get; set; }
      public decimal L { get; set; }
      public decimal O { get; set; }
      public DateTime Ts { get; set; }
    }
  }
}