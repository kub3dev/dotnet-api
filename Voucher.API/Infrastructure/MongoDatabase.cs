using System;
using MongoDB.Driver;
using Voucher.API.Domain.Repositories;

namespace Voucher.API.Infrastructure;

public class MongoDatabase<T>
{
   private readonly string _collectionName;
   private readonly IMongoCollection<T> _collection;

   public MongoDatabase(IConfiguration configuration, string collectionName)
   {
      _collectionName = collectionName;

      var connectionString = configuration.GetValue<string>("MONGODB:URI");
      if (connectionString == null)
      {
         Console.WriteLine("You must set your 'MONGODB:URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
      }

      var databaseName = configuration.GetValue<string>("MONGODB:DATABASE");
      if (databaseName == null)
      {
         Console.WriteLine("You must set your 'MONGODB:DATABASE' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-database-name");
      }


      var mongoClient = new MongoClient(connectionString);
      var mongoDatabase = mongoClient.GetDatabase(databaseName);
      _collection = mongoDatabase.GetCollection<T>(_collectionName);
   }

   public IMongoCollection<T> Collection => _collection;
}
