namespace Server.Integration.Tests.Features.Application.Get
{
  using Server.Integration.Tests;
  using System.Threading.Tasks;
  using Server.Data;
  using Shared.Features.Application;
  using Shouldly;
  using static SliceFixture;

  class GetApplicationTests : IntegrationTestBase
  {
    public async Task Should_get_Application_object()
    {
      // Arrange
      var getApplicationRequest = new GetApplicationRequest();
      // Act
      GetApplicationResponse getApplicationResponse = await SendAsync(getApplicationRequest);
      // Assert
      getApplicationResponse.ShouldNotBeNull();
      ApplicationDto application = getApplicationResponse.Application;
      application.Name.ShouldBe(DbInitializer.ApplicationName);
      application.Version.ShouldBe(DbInitializer.ApplicationVersion);
    }
  }
}
