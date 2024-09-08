using System;
using MongoDB.Driver;
using Voucher.API.Data.Models;
using Voucher.API.Domain.Repositories;
using Voucher.API.Infrastructure;

namespace Voucher.API.Data.Repositories;

public class VoucherRepository : IVoucherRepository
{
  private readonly MongoDatabase<VoucherModel> _database;


  public VoucherRepository(IConfiguration configuration)
  {
    _database = new MongoDatabase<VoucherModel>(configuration, "vouchers");
  }

  public async Task CreateAsync(VoucherModel request) =>
    await _database.Collection.InsertOneAsync(request);

  public async Task<List<VoucherModel>> GetAsync() =>
      await _database.Collection.Find(_ => true).ToListAsync();

  public async Task<VoucherModel?> GetAsync(string id) =>
      await _database.Collection.FindAsync(id).Result.FirstOrDefaultAsync();

  public async Task RemoveAsync(string id) =>
     await _database.Collection.DeleteOneAsync(id);

  public async Task UpdateAsync(string id, VoucherModel request) =>
      await _database.Collection.ReplaceOneAsync(id, request);
}