

using CapitalPlacement.API.Controllers;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Test.Helper;
using CapitalPlacement.Test.IntegrationTests.Base;
using Newtonsoft.Json;
using System.Net;
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
    }
}
