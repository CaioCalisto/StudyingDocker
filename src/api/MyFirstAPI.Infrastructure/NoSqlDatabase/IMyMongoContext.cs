using MongoDB.Driver;
using MyFirstAPI.Domain;
using MyFirstAPI.Domain.Common;

namespace MyFirstAPI.Infrastructure.NoSqlDatabase
{
    public interface IMyMongoContext: IUnitOfWork
    {
        IMongoCollection<Brand> Brands { get; }
    }
}
