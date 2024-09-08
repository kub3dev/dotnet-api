using System;
using MongoDB.Driver;
using Voucher.API.Data.Models;
using Voucher.API.Domain.Entities;
using Voucher.API.Domain.Repositories;
using Voucher.API.Domain.Services;

namespace Voucher.API.Data.Services;

public class VoucherService : IVoucherService
{
    private readonly IVoucherRepository _repository;

    public VoucherService(IVoucherRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<VoucherEntity>> GetAsync()
    {
        var vouchers = await _repository.GetAsync();
        return vouchers.Select(x => x.ToEntity()).ToList();
    }

    public async Task<VoucherEntity?> GetAsync(string id)
    {
        var voucher = await _repository.GetAsync(id);
        return voucher?.ToEntity();
    }

    public async Task CreateAsync(VoucherEntity request) =>
        await _repository.CreateAsync(VoucherModel.FromEntity(request));

    public async Task UpdateAsync(string id, VoucherEntity request) =>
        await _repository.UpdateAsync(id, VoucherModel.FromEntity(request));

    public Task RemoveAsync(string id) =>
         _repository.RemoveAsync(id);
}
