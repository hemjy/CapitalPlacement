

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
    public class ApplicationFormControllerTest : CPBaseTest<ApplicationFormController>
    {
        
        [Fact]
        public async Task Update_ReturnsOkResult_WhenValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.GenerateFakeApplicationForm();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(validModel), Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/ApplicationForm/{_programId}", jsonContent);

            // Assert: Check the response
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Update_ReturnsBadRequestResult_WhenInValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.GenerateInvalidFakeApplicationForm();
            var ob = JsonConvert.SerializeObject(validModel);
            var jsonContent = new StringContent(ob, Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/ApplicationForm/{_programId}", jsonContent);

            // Assert: Check the response
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task Get_Should_Return_OkResult()
        {
            // Act
            var response = await _client.GetAsync($"/api/ApplicationForm/{_programId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Should_Return_ErrorResult()
        {
            var programId = Guid.NewGuid();
            // Act
            var response = await _client.GetAsync($"/api/ApplicationForm/{programId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }



    }
}
