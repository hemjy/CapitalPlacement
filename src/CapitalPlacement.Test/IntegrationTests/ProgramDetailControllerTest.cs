﻿

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
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var data = await response.Content.ReadFromJsonAsync<ProgramId>();

            Assert.True(data != null);
            Assert.True(data.id != null);
            Assert.True(data.id != Guid.Empty);
        }
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
        }

        [Fact]
        public async Task Get_Should_Return_ErrorResult()
        {
            var programId = Guid.NewGuid();
            // Act
            var response = await _client.GetAsync($"/api/program/{programId}");

            // Assert
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
        }


        public class ProgramId
        {
            public Guid id { get; set; }
        }

    }
}
