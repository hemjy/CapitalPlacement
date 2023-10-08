

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

            var programId = new Guid("bb5b51f3-ebc7-4350-a0d3-5ec7bcc2d2ab");
            var ob = JsonConvert.SerializeObject(validModel);
            var jsonContent = new StringContent(ob, Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/Program/{programId}", jsonContent);

            // Assert: Check the response
            response.EnsureSuccessStatusCode(); 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
