using CapitalPlacement.Test.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Test.IntegrationTests.Base
{
    public abstract class CPBaseTest<TController> : IDisposable where TController : ControllerBase
    {
        protected readonly CapitalPlacementApplication<TController> _application;
        protected readonly HttpClient _client;
        protected CPBaseTest()
        {
            _application = new CapitalPlacementApplication<TController>();
            _client = _application.CreateClient();
        }
        public virtual void Dispose()
        {
            _client.Dispose();
            _application.Dispose();
        }
    }
}
