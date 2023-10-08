using CapitalPlacement.Domain.Infrastructure.Respository;
using CapitalPlacement.Infrastructure.Repositories;
using CapitalPlacement.Test.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CapitalPlacement.Test.IntegrationTests.Base
{
    public abstract class CPBaseTest<TController> : IDisposable where TController : ControllerBase
    {
        protected readonly CapitalPlacementApplication<TController> _application;
        protected readonly HttpClient _client;
        protected readonly ICPProgramRepository _repository;
        protected readonly Guid _programId;
        protected CPBaseTest()
        {
            _application = new CapitalPlacementApplication<TController>();
            _client = _application.CreateClient();
            var configuration = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.Development.json") 
                  .Build();
           _repository = new CPProgramRepository(configuration); 
            if (_programId == null || _programId == Guid.Empty)
            {
                string id = _repository.FirstOrDefaultAsync().GetAwaiter().GetResult().id;
                _programId = new Guid(id);
            }
        }
        public virtual void Dispose()
        {
            _client.Dispose();
            _application.Dispose();
        }
    }
}
