

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
    public class WorkflowControllerTest : CPBaseTest<WorkflowController>
    {
        
        [Fact]
        public async Task Update_ReturnsOkResult_WhenValidDataIsProvided()
        {

            var validModel = DummyDataGenerator.GenerateFakeWorkflow();
            var json = JsonConvert.SerializeObject(validModel);
            var jsonContent = new StringContent(json, Encoding.UTF8, "application/json"); ;

            var response = await _client.PutAsync($"/api/Workflow/{_programId}", jsonContent);

            // Assert: Check the response
            response.EnsureSuccessStatusCode();
            var ret = await response.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }


        [Fact]
        public async Task Get_Should_Return_OkResult()
        {
            // Act
            var response = await _client.GetAsync($"/api/Workflow/{_programId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_Should_Return_ErrorResult()
        {
            var programId = Guid.NewGuid();
            // Act
            var response = await _client.GetAsync($"/api/Workflow/{programId}");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }



    }
}
