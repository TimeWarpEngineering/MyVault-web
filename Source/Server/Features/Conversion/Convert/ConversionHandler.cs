namespace Server.Features.Conversion
{
  using System.Threading;
  using System.Threading.Tasks;
  using FluentValidation;
  using FluentValidation.Results;
  using MediatR;
  using Server.Services.AnthemGold.Price;
  using Shared.Features.Conversion;

  public class ConversionHandler : IRequestHandler<ConversionRequest, ConversionResponse>
  {

    public ConversionHandler(
      IValidator<ConversionRequest> aConversionRequestValidator,
      IMediator aMediator
      )
    {
      ConversionRequestValidator = aConversionRequestValidator;
      Mediator = aMediator;
    }

    private IValidator<ConversionRequest> ConversionRequestValidator { get; }
    private IMediator Mediator { get; }

    public async Task<ConversionResponse> Handle(ConversionRequest aConversionRequest, CancellationToken aCancellationToken)
    {
      // TODO when FluentValidation release new version for dotnet core 3 it will support integration into the MVC pipeline.
      // Thus we won't need to manually do this.
      // Or we could add Validation to the Mediator Piple (See ThaiTools)
      ValidationResult validationResult = ConversionRequestValidator.Validate(aConversionRequest);
      if (!validationResult.IsValid)
      {
        throw new ValidationException(validationResult.Errors);
      }

      PriceResponse priceResponse = await Mediator.Send(new PriceRequest());

      return new ConversionResponse.PriceResponse
      {
        Rate = priceResponse.C
      };
    }
  }
}