using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Voucher.API.Domain.Entities;

namespace Voucher.API.Data.Models;

public class VoucherModel
{
  [BsonId]
  [BsonRepresentation(BsonType.ObjectId)]
  public string? Id { get; set; }
  public string? Description { get; set; } = null!;
  public decimal? Amount { get; set; }
  public string? Kind { get; set; } = null!;
  public string? Issuer { get; set; } = null!;
  public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

  public static VoucherModel FromEntity(VoucherEntity entity)
  {
    return new VoucherModel
    {
      Id = entity.Id,
      Description = entity.Description,
      Amount = entity.Amount,
      Kind = entity.Kind,
      Issuer = entity.Issuer,
    };
  }

  public VoucherEntity ToEntity()
  {
    return new VoucherEntity
    {
      Id = Id,
      Description = Description,
      Amount = Amount,
      Kind = Kind,
      Issuer = Issuer,
      CreatedAt = CreatedAt
    };
  }
}
