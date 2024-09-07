using System;
using MongoDB.Bson;
using MongoDB.Driver;
using Voucher.API.Data.Models;
using Voucher.API.Domain.Entities;

namespace Voucher.API.Domain.Services;

public interface IVoucherService
{
  Task<List<VoucherEntity>> GetAsync();
  Task<VoucherEntity?> GetAsync(string id);
  Task CreateAsync(VoucherEntity request);
  Task UpdateAsync(string id, VoucherEntity request);
  Task RemoveAsync(string id);
}
