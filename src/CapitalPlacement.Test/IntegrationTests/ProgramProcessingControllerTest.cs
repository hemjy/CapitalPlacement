

using CapitalPlacement.API.Controllers;
using CapitalPlacement.Application.DTOs;
using CapitalPlacement.Test.Helper;
using CapitalPlacement.Test.IntegrationTests.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using Xunit;

namespace CapitalPlacement.Test.IntegrationTests
{
    public class ProgramProcessingControllerTest : CPBaseTest<ProgramController>
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

        [Fact]
        public async Task Update_ReturnsBadRequestResult_WhenInValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.ProgramDetailDTOInvalidData();

            var programId = new Guid("bb5b51f3-ebc7-4350-a0d3-5ec7bcc2d2ab");
            var ob = JsonConvert.SerializeObject(validModel);
            var jsonContent = new StringContent(ob, Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/Program/{programId}", jsonContent);

            // Assert: Check the response
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task Create_Should_Return_CreatedResult()
        {
            // Arrange

            // Create a sample ProgramDetailDTO
            var programDetail = DummyDataGenerator.ProgramDetailDTOValidData();

            var employerId = Guid.NewGuid();

            // Act
            var response = await _client.PostAsJsonAsync($"/api/program/{employerId}", programDetail);

            // Assert
            response.EnsureSuccessStatusCode();
            var id = await response.Content.ReadFromJsonAsync<Guid>();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.True(id != null);
            Assert.True(id != Guid.Empty);
        }
    }
}
