using System;
using Voucher.Core.Models;

namespace Voucher.API.Domain.Entities;

public class VoucherEntity
{
  public string? Id { get; set; }
  public string? Description { get; set; } = null!;
  public decimal? Amount { get; set; }
  public string? Kind { get; set; } = null!;
  public User? Issuer { get; set; } = null!;
  public DateTime? CreatedAt { get; set; } = null!;
}
