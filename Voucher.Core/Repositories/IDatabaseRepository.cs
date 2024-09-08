using System;

namespace Voucher.Core.Repositories;

public interface IDatabaseRepository<T>
{
  Task<List<T>> GetAsync();

  Task<T?> GetAsync(string id);

  Task CreateAsync(T request);

  Task UpdateAsync(string id, T request);

  Task RemoveAsync(string id);
}