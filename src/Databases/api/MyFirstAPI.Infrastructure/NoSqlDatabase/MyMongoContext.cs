using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyFirstAPI.Domain;

namespace MyFirstAPI.Infrastructure.NoSqlDatabase
{
    public class MyMongoContext: IMyMongoContext
    {
        private MongoClient mongoClient;
        private IMongoDatabase mongoDatabase;
        private IClientSessionHandle session;

        public MyMongoContext(IConfiguration configuration)
        {
            mongoClient = new MongoClient(configuration["MongoConnectionString"]);
            mongoDatabase = mongoClient.GetDatabase(configuration["MongoDatabase"]);
        }

        public IMongoCollection<Brand> Brands
        {
            get { return this.mongoDatabase.GetCollection<Brand>("Brands"); }
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // TODO
            return Task.FromResult(true);
        }

        public Task BeginTransactionAsync()
        {
            session = this.mongoClient.StartSession();
            session.StartTransaction();
            return Task.CompletedTask;
        }

        public async Task CommitTransactionAsync()
        {
            await session.CommitTransactionAsync();
        }

        public void Dispose()
        {
            this.session.Dispose();
        }

        public void RollbackTransaction()
        {
            session.AbortTransaction();
        }

        
    }
}
