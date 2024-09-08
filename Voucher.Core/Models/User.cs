using System;

namespace Voucher.Core.Models;

public class User
{
  public string Id { get; set; } = null!;
  public string Email { get; set; } = null!;
  public string Name { get; set; } = null!;
  public string Surname { get; set; } = null!;
}
