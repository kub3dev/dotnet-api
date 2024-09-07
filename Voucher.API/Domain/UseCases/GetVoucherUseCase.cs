using System;
using Voucher.API.Domain.Entities;
using Voucher.API.Domain.Services;

namespace Voucher.API.Domain.UseCases;

public class GetVoucherUseCase
{
  private readonly IVoucherService _voucherService;

  public GetVoucherUseCase(IVoucherService voucherService)
  {
    _voucherService = voucherService;
  }

  public async Task<VoucherEntity?> Execute(string id)
  {
    return await _voucherService.GetAsync(id);
  }

}
