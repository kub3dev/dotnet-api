using System;
using MongoDB.Driver;
using Voucher.API.Data.Models;
using Voucher.API.Domain.Entities;
using Voucher.API.Domain.Services;

namespace Voucher.API.Data.Services;

public class VoucherService : IVoucherService
{
    private readonly IMongoCollection<VoucherModel> _vouchersCollection;

    public VoucherService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MongoDb");
        if (connectionString == null)
        {
            Console.WriteLine("You must set your 'MONGODB_URI' environment variable. To learn how to set it, see https://www.mongodb.com/docs/drivers/csharp/current/quick-start/#set-your-connection-string");
        }

        var mongoClient = new MongoClient(connectionString);

        var mongoDatabase = mongoClient.GetDatabase("voucher-api");

        _vouchersCollection = mongoDatabase.GetCollection<VoucherModel>("vouches");
    }

    public async Task<List<VoucherEntity>> GetAsync()
    {
        var vouchers = await _vouchersCollection.Find(_ => true).ToListAsync();
        return vouchers.Select(x => x.ToEntity()).ToList();
    }

    public async Task<VoucherEntity?> GetAsync(string id)
    {
        var voucher = await _vouchersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return voucher.ToEntity();
    }

    public async Task CreateAsync(VoucherEntity request) =>
        await _vouchersCollection.InsertOneAsync(VoucherModel.FromEntity(request));

    public async Task UpdateAsync(string id, VoucherEntity request) =>
        await _vouchersCollection.ReplaceOneAsync(x => x.Id == id, VoucherModel.FromEntity(request));

    public async Task RemoveAsync(string id) =>
        await _vouchersCollection.DeleteOneAsync(x => x.Id == id);
}
