namespace Server.Features.Conversion
{
  using System.Threading;
  using System.Threading.Tasks;
  using Shared.Features.Conversion;
  using System.Net.Http;
  using MediatR;
  using Microsoft.AspNetCore.Components;
  using System;
  using FluentValidation.Results;
  using FluentValidation;

  public class ConversionHandler : IRequestHandler<ConversionRequest, ConversionResponse>
  {
   public ConversionHandler(HttpClient aHttpClient, IValidator<ConversionRequest> aConversionRequestValidator) : base()
     {
      HttpClient = aHttpClient;
      ConversionRequestValidator = aConversionRequestValidator;
    }

    private HttpClient HttpClient { get; }
    private IValidator<ConversionRequest> ConversionRequestValidator { get; }

    private const string PriceUrl = @"https://chart.anthemgold.com/service-1.0-SNAPSHOT/PRICE?symbol=USDAGLD&range=MINUTE_1";
    public async Task<ConversionResponse> Handle(ConversionRequest aConversionRequest, CancellationToken aCancellationToken)
    {
      ValidationResult validationResult = ConversionRequestValidator.Validate(aConversionRequest);
      if (!validationResult.IsValid)
      {
        throw new Exception("NotValidYo");
      }  

      PriceDto priceDto =
           await HttpClient.GetJsonAsync<PriceDto>
           (PriceUrl);
      Console.WriteLine(priceDto + "hopefully the stuff");
      return new ConversionResponse
      {
        Rate = priceDto.C
      };      
      
    }
    private class PriceDto

    {
      public DateTime Ts { get; set; }
      public decimal O { get; set; }
      public decimal C { get; set; }
      public decimal H { get; set; }
      public decimal L { get; set; }


    }


  }

}
