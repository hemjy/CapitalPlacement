using CapitalPlacement.Domain.Entities;
using CapitalPlacement.Domain.Infrastructure.Respository;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace CapitalPlacement.Infrastructure.Repositories
{
    public class CPProgramRepository : ICPProgramRepository
    {
        private readonly Container _container;
        private readonly CosmosClient _cosmosClient;
        private readonly string _databaseName;

        public CPProgramRepository(IConfiguration configuration)
        {
            _cosmosClient = new CosmosClient(configuration["CosmosDbSettings:EndpointUri"], configuration["CosmosDbSettings:PrimaryKey"]);
            _databaseName = configuration["CosmosDbSettings:DatabaseName"];
            _container = CreateContainerIfNotExistsAsync("Programs").GetAwaiter().GetResult();

        }
        public async Task<CPProgram> GetByIdAsync(Guid id)
        {
            try
            {
                ItemResponse<CPProgram> response = await _container.ReadItemAsync<CPProgram>(id.ToString(), new PartitionKey(id.ToString()));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new ArgumentException("Item not Exit");
            }
        }

        public async Task<CPProgram> CreateAsync(CPProgram CPProgram)
        {
            var query = new QueryDefinition("SELECT * FROM c WHERE c.Title = @title")
                .WithParameter("@title", CPProgram.ProgramDetail.Title);

            var queryIterator = _container.GetItemQueryIterator<CPProgram>(query);

            while (queryIterator.HasMoreResults)
            {
                var results = await queryIterator.ReadNextAsync();
                if (results.Count > 0)
                {
                    throw new ArgumentException("A program with the same title already exists.");
                }
            }
            var response = await _container.CreateItemAsync(CPProgram);
            return response.Resource;
        }

        public async Task UpdateAsync(CPProgram CPProgram)
        {
            await _container.UpsertItemAsync(CPProgram);
        }

        private async Task<Container> CreateContainerIfNotExistsAsync(string containerName)
        {
            // Create the database if it doesn't exist
            var database = await _cosmosClient.CreateDatabaseIfNotExistsAsync(_databaseName);

            // Define the container with a partition key
            var containerProperties = new ContainerProperties(containerName, "/id");

            // Create the container if it doesn't exist
            var containerResponse = await database.Database.CreateContainerIfNotExistsAsync(containerProperties);

            var statusCode = containerResponse.StatusCode as int?;
            if (!(statusCode.HasValue && statusCode.Value >= 200 && statusCode.Value < 300))
            {
                Console.WriteLine($"Error while creating DB Container in Cosmos: {containerResponse.StatusCode}");
            }
            return containerResponse.Container;

        }

    }
}
