

using CapitalPlacement.API.Controllers;
using CapitalPlacement.Application.Common.Models;
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
        public async Task Preview_Should_Return_OkResult()
        {
            // Act
            var response = await _client.GetAsync($"/api/program/preview/{_programId}");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Preview_Should_Return_ErrorResult()
        {
            var programId = Guid.NewGuid();
            // Act
            var response = await _client.GetAsync($"/api/program/preview/{programId}");

            // Assert
            var result = await response.Content.ReadFromJsonAsync<Rootobject>();
            Assert.True(response.StatusCode == HttpStatusCode.BadRequest);
            Assert.NotNull(result);
            Assert.False(result.Succeeded);
        }

        public class Rootobject
        {
            public string Message { get; set; }
            public bool Succeeded { get; set; }
            public string[] Errors { get; set; }
            public object ErrorCode { get; set; }
        }


    }
}
