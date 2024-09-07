using System;
using Voucher.API.Domain.Dtos;
using Voucher.API.Domain.Services;

namespace Voucher.API.Domain.UseCases;

public class CreateVoucherUseCase
{
  private readonly IVoucherService _voucherService;

  public CreateVoucherUseCase(IVoucherService voucherService)
  {
    _voucherService = voucherService;
  }

  public void Execute(VoucherCreateRequest request)
  {
    if (request == null) throw new ArgumentNullException(nameof(request));

    _voucherService.CreateAsync(request.ToEntity());
  }
}
