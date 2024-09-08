using System;
using System.Security.Claims;
using Voucher.API.Domain.Dtos;
using Voucher.API.Domain.Services;
using Voucher.Core;
using Voucher.Core.Models;

namespace Voucher.API.Domain.UseCases;

public class CreateVoucherUseCase
{
  private readonly IVoucherService _voucherService;

  public CreateVoucherUseCase(IVoucherService voucherService)
  {
    _voucherService = voucherService;
  }

  public async Task Execute(User issuer, VoucherCreateRequest request)
  {
    if (request == null) throw new ArgumentNullException(nameof(request));

    var entity = request.ToEntity();
    entity.Issuer = issuer;
    await _voucherService.CreateAsync(entity);
  }
}
