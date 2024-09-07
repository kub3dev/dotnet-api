using System;
using Voucher.API.Domain.Services;

namespace Voucher.API.Domain.UseCases;

public class DeleteVoucherUseCase
{
  private readonly IVoucherService _voucherService;

  public DeleteVoucherUseCase(IVoucherService voucherService)
  {
    _voucherService = voucherService;
  }

  public async Task Execute(string id)
  {
    await _voucherService.RemoveAsync(id);
  }

}
