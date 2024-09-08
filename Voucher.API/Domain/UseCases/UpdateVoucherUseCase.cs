using System;
using Voucher.API.Domain.Dtos;
using Voucher.API.Domain.Services;

namespace Voucher.API.Domain.UseCases;

public class UpdateVoucherUseCase
{
  private readonly IVoucherService _voucherService;

  public UpdateVoucherUseCase(IVoucherService voucherService)
  {
    _voucherService = voucherService;
  }

  public async Task Execute(string id, VoucherUpdateRequest request)
  {
    if (request == null) throw new ArgumentNullException(nameof(request));

    var voucher = request.ToEntity();
    voucher.Id = id;

    await _voucherService.UpdateAsync(id, voucher);
  }
}
