using System;

namespace Voucher.API.Domain.Entities;

public class VoucherEntity
{
  public string? Id { get; set; }
  public string Description { get; set; } = null!;
  public decimal Amount { get; set; }
  public string Kind { get; set; } = null!;
  public string Issuer { get; set; } = null!;
}
