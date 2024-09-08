using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Voucher.API.Domain.Dtos;
using Voucher.API.Domain.Services;
using Voucher.API.Domain.UseCases;
using Voucher.Core;

namespace Voucher.API.Presentation.Endpoints;

public static class VoucherEndpoint
{

  public static void MapVoucher(this WebApplication app)
  {
    app.MapGet("/vouchers", GetVouchers).RequireAuthorization();
    app.MapGet("/vouchers/{id}", GetVoucher).RequireAuthorization();
    app.MapPost("/vouchers", CreateVoucher).RequireAuthorization();
    app.MapPut("/vouchers/{id}", UpdateVoucher).RequireAuthorization();
    app.MapDelete("/vouchers/{id}", RemoveVoucher).RequireAuthorization();
  }

  public static async Task<IResult> GetVouchers(IVoucherService voucherService)
  {
    var vouchers = await voucherService.GetAsync();
    return Results.Ok(vouchers);
  }

  public static async Task<IResult> GetVoucher(GetVoucherUseCase useCase, string id)
  {
    var voucher = await useCase.Execute(id);
    return Results.Ok(voucher);
  }

  public static async Task<IResult> CreateVoucher(ClaimsPrincipal claims, HttpContext ctx, [FromBody] VoucherCreateRequest request, CreateVoucherUseCase useCase)
  {
    await useCase.Execute(claims.ToUser(), request);
    return Results.Ok();
  }

  public static async Task<IResult> UpdateVoucher(ClaimsPrincipal claims, UpdateVoucherUseCase useCase, string id, VoucherUpdateRequest request)
  {
    await useCase.Execute(claims.ToUser(), id, request);
    return Results.Ok();
  }

  public static async Task<IResult> RemoveVoucher(DeleteVoucherUseCase useCase, string id)
  {
    await useCase.Execute(id);
    return Results.Ok();
  }
}
