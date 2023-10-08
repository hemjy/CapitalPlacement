using Microsoft.AspNetCore.Mvc.Testing;

namespace CapitalPlacement.Test.Infrastructure
{
    public class CapitalPlacementApplication<T> : WebApplicationFactory<T> where T : class
    {
    
    }
}
