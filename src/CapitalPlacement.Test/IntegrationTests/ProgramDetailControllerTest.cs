

using CapitalPlacement.API.Controllers;
using CapitalPlacement.Application.Common.Models;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Test.Helper;
using CapitalPlacement.Test.IntegrationTests.Base;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Xunit;

namespace CapitalPlacement.Test.IntegrationTests
{
    public class ProgramDetailControllerTest : CPBaseTest<ProgramDetailController>
    {
        [Fact]
        public async Task Update_ReturnsOkResult_WhenValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.ProgramDetailDTOValidData();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(validModel), Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/Program/{_programId}", jsonContent);

            // Assert: Check the response
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Update_ReturnsBadRequestResult_WhenInValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.ProgramDetailDTOInvalidData();
            var ob = JsonConvert.SerializeObject(validModel);
            var jsonContent = new StringContent(ob, Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/Program/{_programId}", jsonContent);

            // Assert: Check the response
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task Get_Should_Return_OkResult()
        {
            // Act
            var response = await _client.GetAsync($"/api/program/{_programId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
             var result = await response.Content.ReadFromJsonAsync<Result<ProgramDetailDTO>>();
             Assert.NotNull(result);
             Assert.True(result.Succeeded);
             Assert.NotEmpty(result.Data.Title);
        }

        [Fact]
        public async Task Get_Should_Return_ErrorResult()
        {
            var programId = Guid.NewGuid();
            // Act
            var response = await _client.GetAsync($"/api/program/{programId}");

            // Assert
            var programDetails = await response.Content.ReadFromJsonAsync<Result<ProgramDetailDTO>>();
            Assert.NotNull(programDetails);
            Assert.False(programDetails.Succeeded);
        }
    }
}
