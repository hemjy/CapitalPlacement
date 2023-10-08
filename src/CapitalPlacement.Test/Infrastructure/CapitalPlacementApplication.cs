using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using CapitalPlacement.Infrastructure.Repositories;

namespace CapitalPlacement.Test.Infrastructure
{
    public class CapitalPlacementApplication<T> : WebApplicationFactory<T> where T : class
    {
     
    }
}
